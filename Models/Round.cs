using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourneyBracket.Models
{
    public class Round
    {
        [Key]
        public int RoundID { get; set; }

        public int BracketID { get; set; }
        public BracketTable BracketTable { get; set; }
       public ICollection<Match> Matches { get; set; }
    }
}
