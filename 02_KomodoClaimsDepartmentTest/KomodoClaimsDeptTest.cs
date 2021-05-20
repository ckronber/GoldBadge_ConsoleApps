using KomodoClaimsDepartment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _02_KomodoClaimsDepartmentTest
{
    [TestClass]
    public class KomodoClaimsDeptTest
    {
        [TestMethod]
        public void AddToQueue_ShouldReturnBool()
        {
            //Arrange
            bool value;
            Claim newClaim = new Claim();
            ClaimRepository claimRepo = new ClaimRepository();
            //Act
            value = claimRepo.AddToQueue(newClaim);
            //Assert
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void DisplayAll_ShouldReturnCollection()
        {
            //Assert
            Claim newClaim = new Claim();
            ClaimRepository claimRepo = new ClaimRepository();
            claimRepo.AddToQueue(newClaim);
            //Arrange
            List<Claim> myQueue = claimRepo.ReadQueue();
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
            claimRepo.AddToQueue(newClaim);
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
            claimRepo.AddToQueue(newClaim);

            //Arrange
            List<Claim> myList = new List<Claim>();
            myList.Add(claimRepo.GetNext());
            bool hasClaim = myList.Contains(newClaim);

            //Assert
            Assert.IsTrue(hasClaim);
        }
    }
}