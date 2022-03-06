using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploaddsController : ControllerBase
    {
        //public static IWebHostEnvironment _environment;
        //public FileUploaddsController(IWebHostEnvironment environment)
        //{
        //    _environment = environment;
        //}
        //[HttpPost("fileadd")]
        //public async Task<string> Post([FromForm] FileUpload objfile)
        //{
        //    try
        //    {
        //        if (objfile.files.Length > 0)
        //        {
        //            if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
        //            {
        //                Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
        //            }
        //            using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + 
        //               objfile.files.FileName))
        //            {
        //                objfile.files.CopyTo(fileStream);
        //                fileStream.Flush();
        //                return "\\uploads\\" + objfile.files.FileName+"Eklendi";
        //            }
        //        }
        //        else
        //        {
        //            return "Failed";
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return ex.Message.ToString();
        //    }
            
        //}
    }
}
