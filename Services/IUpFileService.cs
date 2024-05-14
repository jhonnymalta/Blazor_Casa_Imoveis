using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks.Dataflow;

namespace Blazor_Casa_Imoveis.Services
{
    public interface IUpFileService
    {
        Task<string> UpFile(IBrowserFile file);
        bool DeleteFile(string fileName);
    }
}
