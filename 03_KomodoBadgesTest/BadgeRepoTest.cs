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
            Badge myBadge = new Badge();
            BadgeRepository badgeRepo = new BadgeRepository();
           
            badgeRepo.AddBadge(myBadge);

            Dictionary<int, List<string>> newBadgeRepo = badgeRepo.DisplayBadges();

            Assert.IsTrue(newBadgeRepo.ContainsKey(myBadge.BadgeID));     
        }

        [TestMethod]
        public void UpdateRemoveDoor_ShouldReturnBool()
        {
            bool wasUpdated;
            Badge myBadge = new Badge(12334,new List<string>{"C3","D5"});
            BadgeRepository badgeRepo = new BadgeRepository();
            badgeRepo.AddBadge(myBadge);

            wasUpdated = badgeRepo.UpdateBadgebyKey(12334, "D5", false);

            Assert.IsTrue(wasUpdated);
        }
        [TestMethod]
        public void UpdateAddDoor_ShouldReturnBool()
        {
            bool wasUpdated;
            Badge myBadge = new Badge(12334, new List<string> { "C3", "D5" });
            BadgeRepository badgeRepo = new BadgeRepository();
            badgeRepo.AddBadge(myBadge);

            wasUpdated = badgeRepo.UpdateBadgebyKey(12334, "G6", true);

            Assert.IsTrue(wasUpdated);
        }
    }
}
