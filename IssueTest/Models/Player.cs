using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTest.Models
{
    public class Player
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Birthday { get; set; }

        // Navigation property
        [ScaffoldColumn(false)]
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
    }
}
