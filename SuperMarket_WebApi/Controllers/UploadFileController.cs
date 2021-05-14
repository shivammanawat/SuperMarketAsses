using Microsoft.AspNetCore.Mvc;
using Supermarket_WebApi.Models;
using Supermarket_WebApi.Service;
using System.Threading.Tasks;

namespace SuperMarket_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadFileController : Controller
    {
        private IFileManager _ifileManager;
        public UploadFileController(IFileManager iFileManager)
        {
            _ifileManager = iFileManager;
        }
        [HttpPost("UploadFile")]
        public async Task<IActionResult> Upload([FromForm] FileModel model)
        {
            if (model.ImageFile != null)
            {
                await _ifileManager.Upload(model);
                return Ok("File uploaded sucessfully");
            }
            return BadRequest("Invaild file");
        }
    }
}
