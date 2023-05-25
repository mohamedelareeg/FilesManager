using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.Models
{
    public class Papers : EntityBase
    {
        public Int64 Id { get; set; }
        public string RootPath { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public int? DocumentId { get; set; }
        public int? BatchId { get; set; }

    }
}
