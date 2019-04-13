using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IO.FileServices
{
    public interface IFileService
    {
        string Save(IFormFile file);
        string Save(string dirPath, IFormFile file);  
        void Delete(string dirPath, string filePath);
        string getRelativePath(string dirPath, string filePath);
    }
}
