using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournment_Tracking.Models
{
    class Tournament
    {
        public string tournamentName { get; set; }
        public decimal entryfee { get; set; }
        public List<Teams> enterdTeams { get; set; }
    }
}
