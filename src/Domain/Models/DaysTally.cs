using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DaysTally
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public string Action { get; set; }
    }
}
