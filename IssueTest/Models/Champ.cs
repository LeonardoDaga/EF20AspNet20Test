using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTest.Models
{
    public class Champ
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        public int SeasonNum { get; set; }
    }
}
