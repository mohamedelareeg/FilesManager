
using FilesManager.Models;
using FilesManager.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.Interfaces.Api
{
    public interface IFileService
    {
        void UploadFile(List<IFormFile> files , int path, int? DocumentId);
        Task<BatchCRUDViewModel> LoadAllFiles(int BatchId);
        (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory);
        string SizeConverter(long bytes);
    }
}
