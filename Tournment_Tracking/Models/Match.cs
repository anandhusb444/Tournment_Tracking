using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournment_Tracking.Models
{
    class Match
    {

       public string team1 { get; set; }
       public string team2 { get; set; }
       public int scoreTeam1 { get; set; }
       public int scoreTeam2 { get; set; }
       public string winner { get; set; }

    }
}
