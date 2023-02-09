using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.Models.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BusinessManagerWeb.Pages.Author
{
    public partial class Author
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Inject] protected IUnitOfWork UnitOfWork { get; set; }
        [Inject] protected IDialogService DialogService { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private string searchString = "";
        private AuthorDTO selectedItem = new();
        private List<AuthorDTO> elements = new();
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
            var enumerable = await UnitOfWork.Author.GetAllAsync();
            elements = enumerable.ToList();
        }

        private async Task OpenUpsertDialog(AuthorDTO? itemDTO)
        {
            //Setting Dialog
            var parameter = new DialogParameters { ["item"] = itemDTO };
            var options = new DialogOptions { DisableBackdropClick = true };
            var dialog = await DialogService.ShowAsync<UpsertAuthorDialog>("", parameter, options);
            //Get Dialog result
            var resultFromDialog = await dialog.Result;

            //Handle returned value
            if (!resultFromDialog.Canceled)
            {
                //Get result when Dialog return ok
                var result = (AuthorDTO?)resultFromDialog.Data;
                //Handle when return value have Id != 0 => valid data
                if (result != null)
                {
                    //Check that is the object exist in list
                    var obj = elements.Find(e => e.Name == result.Name);
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

        private async Task DeleteItemAsync(AuthorDTO itemDTO)
        {
            //Setting Dialog
            var parameters = new DialogParameters
            {
                { "ContentText", "Do you really want to delete this item? This process cannot be undone." },
                { "ButtonText", "Delete" },
                { "Color", Color.Error },
                { "item" , itemDTO}
            };
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = DialogService.Show<DeleteAuthorDialog>("Delete Item", parameters, options);

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

        private bool FilterFunc(AuthorDTO item)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (item.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task GetEntity(AuthorDTO authorDTO)
        {
            var getData = await UnitOfWork.Author.GetFirstOrDefaultAsync(tag => tag.Name == authorDTO.Name);
            if (getData != null)
            {
                elements.Insert(0, getData);
            }
        }
    }
}
