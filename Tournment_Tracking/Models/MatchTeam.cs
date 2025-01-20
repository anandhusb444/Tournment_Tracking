using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournment_Tracking.Models
{
    class MatchTeam
    {
        public List<string> Teams { get; set; }

        public MatchTeam()
        {
            Teams = new List<string>();
        }
    }
}
