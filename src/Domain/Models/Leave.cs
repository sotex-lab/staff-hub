using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Leave
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }

        public DaysTally? DaysTally { get; set; }
    }
}
