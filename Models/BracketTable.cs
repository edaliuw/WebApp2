using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourneyBracket.Models
{
    public class BracketTable
    {
        
        [Key]
        public int BracketID { get; set; }
        [Required]
        public string Name { get; set; }
        public int RoundFormat { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public int Active { get; set; }
        [Required]
        public int TeamTotal { get; set; }
    }
}
