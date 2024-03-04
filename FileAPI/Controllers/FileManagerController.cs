using FileAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        private readonly IUploadInterface _uploadInterface;
        public FileManagerController(IUploadInterface uploadInterface)
        {
            _uploadInterface = uploadInterface;
        }
        [HttpPost]
        [Route("uploadfile")]
        public async Task<IActionResult> Upload_File(IFormFile _IFormfile)
        {
            var result = await _uploadInterface.Upload_File(_IFormfile);
            return Ok(result);
        }
        [HttpGet]
        [Route("downloadfile")]
        public async Task<IActionResult> DownloadFile(string Filename)
        {
            var result = await _uploadInterface.DownloadFile(Filename);
            return File(result.Item1, result.Item2, result.Item2);
        }
    }
}
