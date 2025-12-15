using ERP.Common.Enums;
using ERP.Common.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

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

            string pathUpload = GetPath(uploadType);

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

        [HttpGet("image")]
        public IActionResult ViewImage([FromQuery] UploadType uploadType, [FromQuery] string fileName)
        {
            string pathUpload = GetPath(uploadType);

            if (string.IsNullOrEmpty(pathUpload))
            {
                var err = new { code = "UploadFileError", message = "UploadType không hợp lệ." };
                return BadRequest(err);
            }

            var filePath = Path.Combine(pathUpload, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                var err = new { code = "UploadFileError", message = "Không tìm thấy ảnh." };
                return BadRequest(err);
            }

            var mimeType = GetMimeType(filePath);
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return File(stream, mimeType);
        }

        private string GetMimeType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        private string GetPath(UploadType uploadType)
        {
            string pathUpload = "";
            if (uploadType == UploadType.Product)
            {
                pathUpload = Utils.GetPathUploadProducts();
            }
            return pathUpload;
        }
    }
}
