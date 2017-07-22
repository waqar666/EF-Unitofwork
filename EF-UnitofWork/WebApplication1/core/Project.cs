using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.core
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public Guid ProjectID { get; set; }
        [Required]
        public string ProjectName { get; set; }
    }
}