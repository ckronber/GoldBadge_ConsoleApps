using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, List<string>> _badgeRepo = new Dictionary<int, List<string>>();

        //Create
        public bool AddBadge(Badge myBadge)
        {
            int count = _badgeRepo.Count;
            _badgeRepo.Add(myBadge.BadgeID,myBadge.DoorNames);
            if (_badgeRepo.Count > count)
                return true;
            else
                return false;
        }

        //Read
        public Dictionary<int,List<string>> DisplayBadges()
        {
            return _badgeRepo;
        }

        //Update
        public bool UpdateBadgebyKey(int key,string door,bool AddRemove)
        {
            int count = _badgeRepo[key].Count;
            List<string> myList = _badgeRepo[key];
            if (AddRemove == true)
            {
                myList.Add(door);
                return _badgeRepo[key].Count > count ? true : false;
            }
            else
            {
                myList.Remove(door);
                return _badgeRepo[key].Count < count ? true : false;
            }
        }
    }
}
