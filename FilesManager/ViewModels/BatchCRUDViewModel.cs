
using FilesManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FilesManager.ViewModels
{
    public class BatchCRUDViewModel : EntityBase
    {
        [Display(Name = "Id")]
        public long Id { get; set; }
        public int BatchId { get; set; }
        public string FileName { get; set; }
        public List<DocumentCRUDViewModel> Nodes { get; set; }
        //public List<Papers> Papers { get; set; }


        public static implicit operator BatchCRUDViewModel(Batches _batches)
        {
            return new BatchCRUDViewModel
            {
                Id = _batches.Id,
                BatchId = _batches.BatchId,
                FileName = _batches.FileName,
                //Name = _batches.Name,
                CreatedDate = _batches.CreatedDate,
                ModifiedDate = _batches.ModifiedDate,
               

            };
        }

        public static implicit operator Batches(BatchCRUDViewModel vm)
        {
            return new Batches
            {
                Id = vm.Id,
                BatchId = vm.BatchId,
            FileName = vm.FileName,
           // Name = vm.Name,
            CreatedDate = vm.CreatedDate,
            ModifiedDate = vm.ModifiedDate,
          

        };
        }
    }
}
