using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.Models.DTOs;
using BusinessManagerWeb.Shared.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BusinessManagerWeb.Pages.Book.Import
{
    public partial class Import
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Inject] protected IUnitOfWork UnitOfWork { get; set; }
        [Inject] protected IDialogService DialogService { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Parameter]
        public int Id { get; set; }

        private string searchString = "";
        private ImportDTO selectedItem = new();
        private List<ImportDTO> itemList = new();
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
            var enumerable = await UnitOfWork.Import.GetAllAsync(c => c.BookId == Id, includeProperties:"Book" ,isTracking: false);
            itemList = enumerable.OrderByDescending(item => item.Id).ToList();
        }

        private async Task OpenUpsertDialog(ImportDTO? itemDTO)
        {
            //Setting Dialog
            var parameter = new DialogParameters { ["Item"] = itemDTO };
            var options = new DialogOptions { DisableBackdropClick = true };
            var dialog = await DialogService.ShowAsync<UpsertImportDialog>("", parameter, options);
            //Get Dialog result
            var resultFromDialog = await dialog.Result;

            //Handle returned value
            if (!resultFromDialog.Canceled)
            {
                //Get result when Dialog return ok
                var result = (bool)resultFromDialog.Data;
                //Handle when return value have Id != 0 => valid data
                if (result)
                {
                    isLoading = true;
                    StateHasChanged();
                    await GetItemListAsync();
                    isLoading = false;
                    StateHasChanged();
                }
            }
        }

        private async Task DeleteItemAsync(ImportDTO itemDTO)
        {
            //Setting Dialog
            var parameters = new DialogParameters
            {
                { "ContentText", "Do you really want to delete this item? This process cannot be undone." },
                { "ButtonText", "Delete" },
                { "Color", Color.Error },
            };
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = DialogService.Show<SimpleDialog>("Delete Item", parameters, options);

            //Get Dialog result
            var resultFromDialog = await dialog.Result;

            //Handle returned value
            if (!resultFromDialog.Canceled)
            {
                isLoading = true;
                StateHasChanged();
                var deleteResult = await UnitOfWork.Tag.DeleteAsync(itemDTO.Id!);
                if (deleteResult)
                {
                    Snackbar.Add("Deleted Successfully", Severity.Success);
                    itemList.Remove(itemDTO);
                }
                else
                {
                    Snackbar.Add("Deleted Failed", Severity.Error);
                }
                isLoading = false;
                StateHasChanged();
            }
        }

        private bool FilterFunc(ImportDTO item)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            return false;
        }
    }

}
