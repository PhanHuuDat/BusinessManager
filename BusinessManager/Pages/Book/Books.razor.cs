using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.Models.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;

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
        private List<BookDTO> elements = new();
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
            var enumerable = await UnitOfWork.Book.GetAllAsync();
            elements = enumerable.ToList();
        }



        private bool FilterFunc(BookDTO item)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (item.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetEntity(BookDTO itemDTO)
        {
            var data = await UnitOfWork.Book.GetFirstOrDefaultAsync(tag => tag.Title == itemDTO.Title);
            if (data != null)
            {
                elements.Insert(0, data);
            }
        }
    }
}
