
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
    public class DocumentCRUDViewModel : EntityBase
    {
        [Display(Name = "Id")]
        public long Id { get; set; }
        public string FileName { get; set; }
        public long BatchId { get; set; }
        public List<Papers> Nodes { get; set; }
   

        public static implicit operator DocumentCRUDViewModel(Documents _item)
        {
            return new DocumentCRUDViewModel
            {
                Id = _item.Id,
                FileName = _item.FileName,
                BatchId = _item.BatchId,
                CreatedDate = _item.CreatedDate,
                ModifiedDate = _item.ModifiedDate,
               

            };
        }

        public static implicit operator Documents(DocumentCRUDViewModel vm)
        {
        return new Documents
        {
            Id = vm.Id,
            FileName = vm.FileName,
            BatchId = vm.BatchId,
            CreatedDate = vm.CreatedDate,
            ModifiedDate = vm.ModifiedDate,
           

        };
        }
    }
}
