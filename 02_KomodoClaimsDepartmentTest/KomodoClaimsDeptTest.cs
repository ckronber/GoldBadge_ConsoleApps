using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KomodoClaimsDepartment;
using System.Collections.Generic;

namespace _02_KomodoClaimsDepartmentTest
{
    [TestClass]
    public class KomodoClaimsDeptTest
    {
        [TestMethod]
        public void addToQueue_ShouldReturnBool()
        {
            //Arrange
            bool value;
            Claim newClaim = new Claim();
            ClaimRepository claimRepo = new ClaimRepository();
            //Act
            value = claimRepo.addToQueue(newClaim);
            //Assert
            Assert.IsTrue(value);
        }
        [TestMethod]
        public void displayAll_ShouldReturnCollection()
        {
            //Assert
            Claim newClaim = new Claim();
            ClaimRepository claimRepo = new ClaimRepository();
            claimRepo.addToQueue(newClaim);
            //Arrange
            List<Claim> myQueue = claimRepo.readQueue();
            bool collectionHasClaim = myQueue.Contains(newClaim);
            //Assert
            Assert.IsTrue(collectionHasClaim);
        }
        [TestMethod]
        public void deleteFromQueue_shouldreturnBool()
        {
            //Assert
            Claim newClaim = new Claim();
            ClaimRepository claimRepo = new ClaimRepository();
            claimRepo.addToQueue(newClaim);
            bool wasDeleted;

            //Arrange
            wasDeleted = claimRepo.DeleteQueue();

            //Assert
            Assert.IsTrue(wasDeleted);
        }
        [TestMethod]
        public void getNext_shouldreturnClaim()
        {
            //Assert
            Claim newClaim = new Claim();
            ClaimRepository claimRepo = new ClaimRepository();
            claimRepo.addToQueue(newClaim);

            //Arrange
            List<Claim> myList = new List<Claim>();
            myList.Add(claimRepo.getNext());
            bool hasClaim = myList.Contains(newClaim);

            //Assert
            Assert.IsTrue(hasClaim);
        }
    }
}
