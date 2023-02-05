using BusinessManager.Models.DTOs;
using Microsoft.AspNetCore.Components;

namespace BusinessManagerWeb.Pages.Book
{
    public partial class UpsertBook
    {
        [Parameter]
        public int Id { get; set; }

        private bool isLoading = false;
        private BookDTO Book { get; set; } = new()
        {
            Avatar = "/images/default.jpg"
        };

        private IEnumerable<AuthorDTO> authors = Enumerable.Empty<AuthorDTO>();
        private IEnumerable<BookSizeDTO> bookSizes = Enumerable.Empty<BookSizeDTO>();
        private IEnumerable<BookTagDTO> bookTags = Enumerable.Empty<BookTagDTO>();
        private IEnumerable<PublisherDTO> publishers = Enumerable.Empty<PublisherDTO>();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                isLoading = true;
                StateHasChanged();
                authors = await UnitOfWork.Author.GetAllAsync();
                bookSizes = await UnitOfWork.BookSize.GetAllAsync();
                bookTags = await UnitOfWork.BookTag.GetAllAsync();
                publishers = await UnitOfWork.Publisher.GetAllAsync();
                isLoading = false;
                StateHasChanged();
            }
        }

        public void OnValidSubmit()
        {
        }
    }
}