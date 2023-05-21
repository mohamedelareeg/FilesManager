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
    public class Batches : EntityBase
    {
        public Int64 Id { get; set; }
       // public string? Name { get; set; }
        public int TemplatesId { get; set; }
        public int DefaultFormId { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string? Barcode { get; set; }

    }
}
