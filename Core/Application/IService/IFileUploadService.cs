using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace Application.IService
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string fileName);
    }
}