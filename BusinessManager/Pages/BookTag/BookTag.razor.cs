using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.Models.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BusinessManagerWeb.Pages.BookTag
{
    public partial class BookTag
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Inject] protected IUnitOfWork unitOfWork { get; set; }
        [Inject] protected IDialogService DialogService { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private string searchString = "";
        private TagDTO selectedItem = new();
        private List<TagDTO> itemList = new();
        private bool isLoading = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                isLoading = true;
                StateHasChanged();
                await GetItemListAsync();
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task GetItemListAsync()
        {
            var enumerable = await unitOfWork.Tag.GetAllAsync();
            itemList = enumerable.OrderByDescending(item => item.Id).ToList();
        }

        private async Task OpenUpsertDialog(TagDTO? itemDTO)
        {
            //Setting Dialog
            var parameter = new DialogParameters { ["Item"] = itemDTO };
            var options = new DialogOptions { DisableBackdropClick = true };
            var dialog = await DialogService.ShowAsync<UpsertBookTagDialog>("", parameter, options);
            //Get Dialog result
            var resultFromDialog = await dialog.Result;

            //Handle returned value
            if (!resultFromDialog.Canceled)
            {
                //Get result when Dialog return ok
                var result = (TagDTO?)resultFromDialog.Data;
                //Handle when return value have Id != 0 => valid data
                if (result != null)
                {
                    //Check that is the object exist in list
                    var obj = itemList.Find(e => e.Name == result.Name);
                    if (obj != null)
                    {
                        //Change data if exist
                        obj.Name = result.Name;
                    }
                    else
                    {
                        //Create Data Success + Not exist in list => new data
                        await GetEntity(result);
                    }
                }
            }
        }

        private async Task DeleteItemAsync(TagDTO itemDTO)
        {
            //Setting Dialog
            var parameters = new DialogParameters
            {
                { "ContentText", "Do you really want to delete this item? This process cannot be undone." },
                { "ButtonText", "Delete" },
                { "Color", Color.Error },
                { "Item", itemDTO}
            };
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = DialogService.Show<DeleteBookTagDialog>("Delete Item", parameters, options);

            //Get Dialog result
            var resultFromDialog = await dialog.Result;

            //Handle returned value
            if (!resultFromDialog.Canceled)
            {
                var result = (bool)resultFromDialog.Data;
                if (result)
                {
                    itemList.Remove(itemDTO);
                }
            }
        }

        private bool FilterFunc(TagDTO item)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (item.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetEntity(TagDTO itemDTO)
        {
            var data = await unitOfWork.Tag.GetFirstOrDefaultAsync(tag => tag.Name == itemDTO.Name);
            if (data != null)
            {
                itemList.Insert(0, data);
            }
        }
    }
}
