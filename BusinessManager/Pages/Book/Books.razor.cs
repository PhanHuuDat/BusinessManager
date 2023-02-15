using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.Models.DTOs;
using BusinessManagerWeb.Pages.BookSize;
using BusinessManagerWeb.Shared.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace BusinessManagerWeb.Pages.Book
{
    public partial class Books
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Inject] protected IUnitOfWork UnitOfWork { get; set; }
        [Inject] protected IDialogService DialogService { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private string searchString = "";
        private BookDTO selectedItem = new();
        private List<BookDTO> itemList = new();
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
            var enumerable = await UnitOfWork.Book.GetAllAsync(includeProperties: "Author,Size,Tags,Publisher");
            itemList = enumerable.ToList();
        }

        private bool FilterFunc(BookDTO item)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (item.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task DeleteItemAsync(BookDTO itemDTO)
        {
            //Setting Dialog
            var parameters = new DialogParameters
            {
                { "ContentText", "Do you really want to delete this item? This process cannot be undone." },
                { "ButtonText", "Delete" },
                { "Color", Color.Error }
            };
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog =  await DialogService.ShowAsync<SimpleDialog>("Delete Item", parameters, options);

            //Get Dialog result
            var resultFromDialog = await dialog.Result;

            //Handle returned value
            if (!resultFromDialog.Canceled)
            {
                isLoading = true;
                StateHasChanged();
                var deleteResult = await UnitOfWork.Book.DeleteAsync(itemDTO.Id);
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
    }
}
