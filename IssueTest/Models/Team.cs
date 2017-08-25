using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTest.Models
{
    public class Team
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        // Navigation property
        [ScaffoldColumn(false)]
        public int? ChampID;
        public Champ Champ { get; set; }

        // Navigation property
        public ICollection<Player> Players { get; set; }
    }
}
