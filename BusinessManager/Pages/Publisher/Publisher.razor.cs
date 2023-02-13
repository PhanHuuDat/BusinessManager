using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.Models.DTOs;
using BusinessManagerWeb.Pages.BookTag;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BusinessManagerWeb.Pages.Publisher
{
    public partial class Publisher
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Inject] protected IUnitOfWork unitOfWork { get; set; }
        [Inject] protected IDialogService DialogService { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private string searchString = "";
        private PublisherDTO selectedItem = new();
        private List<PublisherDTO> itemList = new();
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
            var enumerable = await unitOfWork.Publisher.GetAllAsync();
            itemList = enumerable.OrderByDescending(item => item.Id).ToList();
        }

        private async Task OpenUpsertDialog(PublisherDTO? itemDTO)
        {
            //Setting Dialog
            var parameter = new DialogParameters { ["Item"] = itemDTO };
            var options = new DialogOptions { DisableBackdropClick = true };
            var dialog = await DialogService.ShowAsync<UpsertPublisherDialog>("", parameter, options);
            //Get Dialog result
            var resultFromDialog = await dialog.Result;

            //Handle returned value
            if (!resultFromDialog.Canceled)
            {
                //Get result when Dialog return ok
                var result = (PublisherDTO?)resultFromDialog.Data;
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

        private async Task DeleteItemAsync(PublisherDTO itemDTO)
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
            var dialog = DialogService.Show<DeletePublisherDialog>("Delete Item", parameters, options);

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

        private bool FilterFunc(PublisherDTO item)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (item.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetEntity(PublisherDTO itemDTO)
        {
            var data = await unitOfWork.Publisher.GetFirstOrDefaultAsync(tag => tag.Name == itemDTO.Name);
            if (data != null)
            {
                itemList.Insert(0, data);
            }
        }
    }
}
