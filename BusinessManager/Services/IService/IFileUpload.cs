using Microsoft.AspNetCore.Components.Forms;

namespace BusinessManagerWeb.Services.IService
{
    public interface IFileUpload
    {
        bool DeleteFile(string filePath);
        Task<string> UploadFile(IBrowserFile file);
    }
}