using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FileUpload
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
    }
}
