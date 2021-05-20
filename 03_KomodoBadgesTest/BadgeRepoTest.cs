using _03_KomodoBadges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadgesTest
{
    [TestClass]
    public class BadgeRepoTest
    {
        [TestMethod]
        public void AddBadge_ShouldReturnBool()
        {
            bool isAdded;
            Badge myBadge = new Badge();
            BadgeRepository badgeRepo = new BadgeRepository();

            isAdded = badgeRepo.AddBadge(myBadge);

            Assert.IsTrue(isAdded);
        }

        [TestMethod]
        public void ReadBadge_ShouldReturnDictionary()
        {
            Badge myBadge = new Badge(39482,new List<string> { "A1","B4"});
            BadgeRepository badgeRepo = new BadgeRepository();

            badgeRepo.AddBadge(myBadge);

            Dictionary<int, List<string>> newBadgeRepo = badgeRepo.DisplayBadges();

            Assert.IsTrue(newBadgeRepo.ContainsKey(myBadge.BadgeID));
        }

        [TestMethod]
        public void UpdateRemoveDoor_ShouldReturnBool()
        {
            List<string> UpdatedList;
            bool updated = true;
            Badge myBadge = new Badge(12334, new List<string> { "C3", "D5" });
            BadgeRepository badgeRepo = new BadgeRepository();
            badgeRepo.AddBadge(myBadge);

            UpdatedList = badgeRepo.UpdateBadgebyKey(12334, "D5", false);

            foreach(string door in UpdatedList)
            {
                if (door == "D5")
                {
                    updated = false;
                    break;
                }
            }

            Assert.IsTrue(updated);
        }

        [TestMethod]
        public void UpdateAddDoor_ShouldReturnBool()
        {
            List<string> UpdatedList;
            bool updated = false;
            string DoorToAdd = "G6";
            Badge myBadge = new Badge(12334, new List<string> { "C3", "D5" });
            BadgeRepository badgeRepo = new BadgeRepository();
            badgeRepo.AddBadge(myBadge);

            UpdatedList = badgeRepo.UpdateBadgebyKey(12334, DoorToAdd, true);

            foreach (string door in UpdatedList)
            {
                if (door == DoorToAdd)
                {
                    updated = true;
                    break;
                }
            }

            Assert.IsTrue(updated);
        }
    }
}