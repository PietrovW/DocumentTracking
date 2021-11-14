using DocumentTracking.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace DocumentTracking.Controllers
{
    public class FileManagerController : AuthorizedControllersBase
    {
        public FileManagerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            if (file?.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using var stream = System.IO.File.Create(filePath);
                    await file.CopyToAsync(stream);
            }
            return Ok();// (new { count = files.Count, size, filePath });
        }
    }
}
