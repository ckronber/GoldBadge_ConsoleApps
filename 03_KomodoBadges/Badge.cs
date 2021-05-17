using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges
{
    public class Badge
    {
        public Badge() { }
        public Badge(int badgeId, List<string> doorNames) {
            this.BadgeID = badgeId;
            this.DoorNames = doorNames;
        }
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
    }
}
