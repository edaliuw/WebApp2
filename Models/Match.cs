using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourneyBracket.Models
{
    public class Match 
    {
        [Key]
        public int MatchID { get; set; }
        public int TeamAID { get; set; }
        public int TeamBID { get; set; }
        public Player TeamA { get; set; }
        public Player TeamB { get; set; }
        public string TeamAScore { get; set; }
        public string TeamBScore { get; set; }
        [Required]
        public int BracketID { get; set; }
        public BracketTable BracketTable { get; set; }
        public Round Round { get; set; }
        public string RoundType { get; set; }
        [Required]
        public int RoundID { get; set; }
    }
}
