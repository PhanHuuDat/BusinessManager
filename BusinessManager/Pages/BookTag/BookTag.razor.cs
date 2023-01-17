using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.Models.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BusinessManagerWeb.Pages.BookTag
{
    public partial class BookTag
    {
        [Inject] protected IUnitOfWork unitOfWork { get; set; }
        [Inject] protected IDialogService DialogService { get; set; }

        private string searchString = "";
        private BookTagDTO selectedItem = new();
        private List<BookTagDTO> Elements = new List<BookTagDTO>();
        private bool isLoading { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                GetCategoryListAsync();
            }
        }

        private async void GetCategoryListAsync()
        {
            isLoading= true;
            StateHasChanged();
            var enumerable = await unitOfWork.BookTag.GetAllAsync();
            Elements = enumerable.ToList();
            isLoading = false;
            StateHasChanged();
        }

        private async Task OpenDialog(BookTagDTO categoryDTO)
        {
            //Setting Dialog
            var parameter = new DialogParameters { ["category"] = categoryDTO };
            var options = new DialogOptions { DisableBackdropClick = true };
            var dialog = await DialogService.ShowAsync<UpsertBookTagDialog>("", parameter, options);
            //Get Dialog result
            var resultFromDialog = await dialog.Result;

            //Handle returned value
            if (!resultFromDialog.Canceled)
            {
                var result = (BookTagDTO)resultFromDialog.Data;
                if (categoryDTO.Id == 0)
                {
                    Elements.Insert(0, result);
                }
                else
                {
                    var obj = Elements.FirstOrDefault(e => e.Id == result.Id);
                    if (obj != null)
                    {
                        obj.Name = result.Name;
                    }
                }
            }
        }

        private async Task DeleteCategoryAsync(BookTagDTO categoryDTO)
        {
            //Setting Dialog
            var parameters = new DialogParameters
            {
                { "ContentText", "Do you really want to delete this book tag? This process cannot be undone." },
                { "ButtonText", "Delete" },
                { "Color", Color.Error },
                { "bookTagId", categoryDTO.Id}
            };
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = DialogService.Show<DeleteBookTag>("Delete Book Tag", parameters, options);

            //Get Dialog result
            var resultFromDialog = await dialog.Result;

            //Handle returned value
            if (!resultFromDialog.Canceled)
            {
                var result = (bool)resultFromDialog.Data;
                if (result)
                {
                    Elements.Remove(categoryDTO);
                }
            }
        }

        private bool FilterFunc(BookTagDTO item)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (item.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
