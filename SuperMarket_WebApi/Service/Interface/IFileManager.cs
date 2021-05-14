using Supermarket_WebApi.Models;
using System.Threading.Tasks;

namespace Supermarket_WebApi.Service
{
    public interface IFileManager
    {
        Task Upload(FileModel model);
    }
}
