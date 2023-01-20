using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.Models.DTOs;
using BusinessManagerWeb.Pages.BookTag;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BusinessManagerWeb.Pages.CoverForm
{
    public partial class CoverForm
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Inject] protected IUnitOfWork unitOfWork { get; set; }
        [Inject] protected IDialogService DialogService { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private string searchString = "";
        private CoverFormDTO selectedItem = new();
        private List<CoverFormDTO> elements = new();
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
            var enumerable = await unitOfWork.CoverForm.GetAllAsync();
            elements = enumerable.ToList();
        }

        private async Task OpenUpsertDialog(CoverFormDTO? itemDTO)
        {
            //Setting Dialog
            var parameter = new DialogParameters { ["item"] = itemDTO };
            var options = new DialogOptions { DisableBackdropClick = true };
            var dialog = await DialogService.ShowAsync<UpsertCoverFormDialog>("", parameter, options);
            //Get Dialog result
            var resultFromDialog = await dialog.Result;

            //Handle returned value
            if (!resultFromDialog.Canceled)
            {
                //Get result when Dialog return ok
                var result = (CoverFormDTO?)resultFromDialog.Data;
                //Handle when return value have Id != 0 => valid data
                if (result != null)
                {
                    //Check that is the object exist in list
                    var obj = elements.Find(e => e.CoverName == result.CoverName);
                    if (obj != null)
                    {
                        //Change data if exist
                        obj.CoverName = result.CoverName;
                    }
                    else
                    {
                        //Create Data Success + Not exist in list => new data
                        await GetEntity(result);
                    }
                }
            }
        }

        private async Task DeleteItemAsync(CoverFormDTO itemDTO)
        {
            //Setting Dialog
            var parameters = new DialogParameters
            {
                { "ContentText", "Do you really want to delete this item? This process cannot be undone." },
                { "ButtonText", "Delete" },
                { "Color", Color.Error },
                { "itemId", itemDTO.Id}
            };
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = DialogService.Show<DeleteCoverFormDialog>("Delete Item", parameters, options);

            //Get Dialog result
            var resultFromDialog = await dialog.Result;

            //Handle returned value
            if (!resultFromDialog.Canceled)
            {
                var result = (bool)resultFromDialog.Data;
                if (result)
                {
                    elements.Remove(itemDTO);
                }
            }
        }

        private bool FilterFunc(CoverFormDTO item)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (item.CoverName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetEntity(CoverFormDTO itemDTO)
        {
            var data = await unitOfWork.CoverForm.GetFirstOrDefaultAsync(tag => tag.CoverName == itemDTO.CoverName);
            if (data != null)
            {
                elements.Insert(0, data);
            }
        }
    }
}
