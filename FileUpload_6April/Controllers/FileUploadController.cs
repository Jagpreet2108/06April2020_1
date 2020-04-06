using System;
using FileUpload_6April.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FileUpload_6April.Controllers
{
    public class FileUploadController : Controller
    {

        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FileUploadController> _logger;

        public FileUploadController(ILogger<FileUploadController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(FileUpload fileUpload)
        {
            string strpath = System.IO.Path.GetExtension(fileUpload.FormFile.FileName);

            if (fileUpload.FormFile != null)
            {

                string FilePath = $"{_env.WebRootPath}/images/{fileUpload.FormFile.FileName}";
                var stream = System.IO.File.Create(FilePath);
                fileUpload.FormFile.CopyTo(stream);
                return Redirect("/FileUpload/Success");

            }
            return Redirect("/");
        }

        public IActionResult Success()
        {
            return View();
        }

    }
}