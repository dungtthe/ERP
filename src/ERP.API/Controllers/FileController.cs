using ERP.Common.Enums;
using ERP.Common.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/files")]
    public class FileController : BaseApiController
    {
        public FileController(ISender mediator) : base(mediator)
        {
        }


        [HttpPost("uploads")]
        public async Task<IActionResult> UploadFiles([FromQuery] UploadType uploadType)
        {
            var files = Request.Form.Files;

            if (files == null || files.Count == 0)
            {
                var err = new { code = "UploadFileError", message = "Không có file nào được gửi." };
                return BadRequest(err);
            }

            string pathUpload = "";
            if (uploadType == UploadType.Product)
            {
                pathUpload = Utils.GetPathUploadProducts();
            }

            if (string.IsNullOrEmpty(pathUpload))
            {
                var err = new { code = "UploadFileError", message = "UploadType không hợp lệ." };
                return BadRequest(err);
            }

            if (!Directory.Exists(pathUpload))
                Directory.CreateDirectory(pathUpload);

            var savedFileNames = new List<string>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var originalFileName = file.FileName;
                    var ext = Path.GetExtension(file.FileName);
                    var fileName = $"{Guid.NewGuid()}{ext}";
                    var filePath = Path.Combine(pathUpload, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    savedFileNames.Add(fileName);
                }
            }
            return Ok(savedFileNames);
        }
    }
}
