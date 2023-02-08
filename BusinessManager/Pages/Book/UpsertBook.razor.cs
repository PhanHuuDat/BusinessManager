using BusinessManager.Models.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Newtonsoft.Json.Serialization;

namespace BusinessManagerWeb.Pages.Book
{
    public partial class UpsertBook
    {

        [Parameter]
        public int Id { get; set; }

        private bool isLoading = false;
        private string Title { get; set; } = "Create";
        private BookDTO Book { get; set; } = new()
        {
            Avatar = "/images/default.jpg"
        };
        public string OldImageUrl { get; set; }

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
                if (Id != 0)
                {
                    Book = await UnitOfWork.Book.GetFirstOrDefaultAsync(book => book.ID == Id) ?? new();
                    Title = "Update";
                    OldImageUrl = Book.Avatar;
                }
                isLoading = false;
                StateHasChanged();
            }
        }

        public async Task OnValidSubmit()
        {
            BookDTO? result;
            if (Book.Id == 0)
            {
                result = await UnitOfWork.Book.CreateAsync(Book);
                
            }
            else
            {
                if (OldImageUrl != Book.Avatar)
                {
                    FileUpload.DeleteFile(OldImageUrl);

                }
                result = await UnitOfWork.Book.UpdateAsync(Book);
            }

            if (result == null)
            {
                Snackbar.Add("Upsert book failed", Severity.Error);
            }
            else
            {
                await UnitOfWork.SaveAsync();
                Snackbar.Add("Upsert book successfully", Severity.Success);
            }

            NavigationManager.NavigateTo("books");
        }

        private async Task HandleImageUpload(InputFileChangeEventArgs e)
        {

            try
            {
                if (e.GetMultipleFiles().Count > 0)
                {
                    foreach (var file in e.GetMultipleFiles())
                    {
                        FileInfo fileInfo = new(file.Name);
                        if (fileInfo.Extension.ToLower() == ".jpg" ||
                          fileInfo.Extension.ToLower() == ".png" ||
                          fileInfo.Extension.ToLower() == ".jpeg")
                        {
                            Book.Avatar = await FileUpload.UploadFile(file);
                        }
                        else
                        {
                            Snackbar.Add("Please select .jpg/.jpeg/.png file only", Severity.Warning);
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Snackbar.Add("Upload file failed", Severity.Error);
            }
        }
    }
}