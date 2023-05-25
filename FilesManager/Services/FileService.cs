
using FilesManager.EF;
using FilesManager.Interfaces;
using FilesManager.Interfaces.Api;
using FilesManager.Migrations;
using FilesManager.Models;
using FilesManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO.Compression;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace FilesManager.Services.Api
{
    public class FileService : IFileService
    {
        #region Property
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;
        private IHostingEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        public FileService(IHostingEnvironment hostingEnvironment, IUnitOfWork unitOfWork , ApplicationDbContext dbContext)
        {
            _hostingEnvironment = hostingEnvironment;
            _unitOfWork = unitOfWork;
            _context = dbContext;
        }
        #endregion

        #region Upload File
        public  void UploadFile(List<IFormFile> files, int BatchId, int? DocumentId)
        {
            try
            {
                Batches _batch = new Batches { BatchId = BatchId, FileName = BatchId.ToString() };
                if (_unitOfWork.Batches.isExist(a => a.BatchId == BatchId) == false) { 
                
                    
                    _unitOfWork.Batches.Add(_batch);
                    _unitOfWork.Complete();
                }
                else
                {
                    _batch = _unitOfWork.Batches.Find(a=>a.BatchId == BatchId);
                }
                Documents _docu = new Documents { BatchId = BatchId , DocumentId = DocumentId  , FileName = DocumentId.ToString()};
               
                
                if (_unitOfWork.Documents.isExist(a => a.DocumentId == DocumentId) == false)
                {


                    _unitOfWork.Documents.Add(_docu);
                    _unitOfWork.Complete();
                }
                else
                {
                    _docu = _unitOfWork.Documents.Find(a => a.DocumentId == DocumentId);
                }
               
              



                var subDirectory = Path.Combine("UploadedFiles", BatchId.ToString());
                var target = Path.Combine(_hostingEnvironment.WebRootPath, subDirectory);
                Directory.CreateDirectory(target);

                files.ForEach(async file =>
                {
                   
                    if (file.Length <= 0) return;
                    var filePath = Path.Combine(subDirectory, file.FileName);
                    var rootPath = Path.Combine(target, file.FileName);
                    await _unitOfWork.Papers.AddAsync(new Models.Papers {RootPath = rootPath,FilePath = filePath, BatchId = _batch.BatchId , FileName=file.FileName  , DocumentId = (int?)_docu.Id});
                    using (var stream = new FileStream(rootPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                });
                _unitOfWork.Complete();
            }
            catch (Exception ex) { }
        }
        #endregion

        #region Download File
        public (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory)
        {
            var zipName = $"archive-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            var files = Directory.GetFiles(Path.Combine(_hostingEnvironment.WebRootPath, "UploadedFiles", subDirectory)).ToList();

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    files.ForEach(file =>
                    {
                        var theFile = archive.CreateEntry(file);
                        using (var streamWriter = new StreamWriter(theFile.Open()))
                        {
                            streamWriter.Write(File.ReadAllText(file));
                        }

                    });
                }

                return ("application/zip", memoryStream.ToArray(), zipName);
            }

        }
        #endregion

        #region Size Converter
        public string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }

        public async Task<BatchCRUDViewModel> LoadAllFiles(int BatchId)
        {
            BatchCRUDViewModel vm = new BatchCRUDViewModel();
            vm = await _context.Batches.Where(x => x.BatchId == BatchId).SingleOrDefaultAsync();
            vm.Nodes = (from t in _context.Documents
                            join j in _context.Batches on t.BatchId equals j.BatchId
                            where t.BatchId == vm.BatchId
                            //where v.DocumentId == vm.Id
                            select new DocumentCRUDViewModel
                            {
                                Id = t.Id,
                                FileName = t.FileName,
                                BatchId = t.BatchId,
                                Nodes = _context.Papers.Where(a => a.DocumentId == t.DocumentId).ToList()

                            }).ToList();
            //vm.Papers = await _context.Papers.Where(x => x.BatchId == vm.BatchId).ToListAsync();
            return vm;
        }


        #endregion
    }
}
