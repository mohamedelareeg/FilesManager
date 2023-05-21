
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
        void UploadFile(List<IFormFile> files ,Int64 StageId ,Int64 BatchId);
        (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory);
        string SizeConverter(long bytes);
    }
}
