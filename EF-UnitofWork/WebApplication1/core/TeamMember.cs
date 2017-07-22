using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.core
{
    [Table("TeamMembers")]
    public class TeamMember
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamMemberID { get; set; }
        [Required]
        public Guid ProjectID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}