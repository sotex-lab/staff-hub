using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team? Team { get; set; }

        public ICollection<DaysTally>? DaysTallies { get; set; }
    }
}
