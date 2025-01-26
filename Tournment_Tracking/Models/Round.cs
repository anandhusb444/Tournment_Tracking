using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournment_Tracking.Models
{
    internal class Round

    {
        public int RounndNumber { get; set; }
        public List<Match> matches { get; set; }

    }
}
