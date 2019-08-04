using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TourneyBracket.Models
{
    public class Player
    {
        [Key]
        public int playerID { get; set; }
        [Required]
        public string playerName { get; set; }
        public ICollection<Match> Matches { get; set; }
        public ICollection<Match> OppMatches { get; set; }
    }
}
