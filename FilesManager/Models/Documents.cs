using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.Models
{
    public class Documents : EntityBase
    {

        public Int64 Id { get; set; }
        public int? DocumentId { get; set; }
        public string FileName { get; set; }
        public long BatchId { get; set; }
       

    }
}
