using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Core.FileUpload
{
    public class FileManager:IFileService
    {
        private static string _current = Environment.CurrentDirectory + "\\wwwroot\\";
        private static string _foldername = "\\images\\";

        public static IResult Upload(FileUpload objfile)
        {
            var fileExists = CheckFileExists(objfile);
            if (fileExists.Message!=null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var type = Path.GetExtension(objfile.files.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();
            if (typeValid.Message!=null)
            {
                return new ErrorResult(typeValid.Message);
            }
            CheckDirectoryExists(_current + _foldername);
            CreateImageFile(_current + _foldername + randomName + type, objfile);
            return new SuccessResult((_foldername + randomName + type).Trim('\\','/')); 
        }

        public static IResult Update(FileUpload objfile, string imagePath)
        {
            var fileExists = CheckFileExists(objfile);
            if (fileExists.Message!=null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var type = Path.GetExtension(objfile.files.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();
            if (typeValid.Message!=null)
            {
                return new ErrorResult(typeValid.Message);
            }
            DeleteOldImageFile((_current + imagePath).Trim('/', '\\'));
            CheckDirectoryExists(_current + _foldername);
            CreateImageFile(_current + _foldername + randomName + type, objfile);
            return new SuccessResult((_foldername + randomName + type).Trim('\\', '/'));
        }

        public static IResult Delete(string path)
        {
            DeleteOldImageFile((_current + path).Trim('/', '\\'));
            return new SuccessResult();
        }

        private static IResult CheckFileExists(FileUpload objfile)
        {
            if (objfile.files != null && objfile.files.Length>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File does not exist!!!");
        }

        private static IResult CheckFileTypeValid(string type)
        {
            if (type!=".jpeg"&&type!=".png"&&type!=".jpg")
            {
                return new ErrorResult("Wrong file type");
            }
            return new SuccessResult();
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        
        private static void CreateImageFile(string directory,FileUpload objfile)
        {
            using (FileStream fileStream = System.IO.File.Create(directory))
            {
                objfile.files.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory))
            {
                File.Delete(directory);
            }
        }

    }
}