using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AngularProjectAPI.Data;
using AngularProjectAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadDownloadController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly NewsContext _context;

        public UploadDownloadController(IHostingEnvironment environment, NewsContext context)
        {
            _hostingEnvironment = environment;
            _context = context;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            var img = new Image { FileName = file.FileName, Path = "uploads/" + file.FileName };
            _context.Images.Add(img);
            await _context.SaveChangesAsync();
            return Ok(img.ImageID);
        }
    }
}