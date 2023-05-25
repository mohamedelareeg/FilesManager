using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FilesManager.Models
{
    public class EntityBase
    {
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }
       
    }
}
