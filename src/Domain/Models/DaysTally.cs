using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int? LeaveId { get; set; }
        [ForeignKey("LeaveId")]
        public Leave? Leave { get; set; }
    }
}
