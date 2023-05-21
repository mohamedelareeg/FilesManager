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
        public string? CreatedBy { get; set; }//= ClaimTypes.NameIdentifier// ApplicationUserID 
        public string? ModifiedBy { get; set; } // ApplicationUserID
        public bool Cancelled { get; set; }
        public bool Status { get; set; } = true;
    }
}
