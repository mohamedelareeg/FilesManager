
using FilesManager.Interfaces.Api;
using FilesManager.Models;
using FilesManager.Requestes;
using FilesManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;


namespace FilesManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        #region Property
        private readonly IFileService _fileService;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        public FileController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IFileService fileService)
        {
            _fileService = fileService;
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region Upload
       
        [HttpPost(nameof(Upload))]
        public IActionResult Upload([Required][FromForm] List<IFormFile> formFiles,[Required][FromForm] int BatchId,[FromForm] int? DocumentId)
        {
            try
            {
                _fileService.UploadFile(formFiles , BatchId, DocumentId);

                return Ok(new { formFiles.Count, Size = _fileService.SizeConverter(formFiles.Sum(f => f.Length)) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        [HttpPost(nameof(GetFiles))]
        public async Task<BatchCRUDViewModel> GetFiles([FromBody] LoadFilesRequest request)
        {
            return await _fileService.LoadAllFiles(request.path);
        }
        #region Download File
        [HttpGet(nameof(Download))]
      
        public IActionResult Download([Required]string subDirectory)
        {

            try
            {
                var (fileType, archiveData, archiveName) = _fileService.DownloadFiles(subDirectory);

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion
    }
}
