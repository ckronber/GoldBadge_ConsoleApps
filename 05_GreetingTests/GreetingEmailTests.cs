using _05_Greeting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _05_GreetingTests
{
    [TestClass]
    public class GreetingEmailTests
    {
        [TestMethod]
        public void AddEmail_ShouldReturnBool()
        {
            KomodoEmailRepo emailRepo = new KomodoEmailRepo();
            KomodoEmail email = new KomodoEmail();
            bool IsAdded;
            IsAdded = emailRepo.AddEmail(email);
            Assert.IsTrue(IsAdded);
        }

        private KomodoEmailRepo _emailRepo;
        private KomodoEmail _email;

        [TestInitialize]
        public void Arrange()
        {
            _emailRepo = new KomodoEmailRepo();
            _email = new KomodoEmail("Billy","Maze","bmaze@gmail.com",CustType.Current);
            _emailRepo.AddEmail(_email);
        }

        [TestMethod]
        public void ReadEmail_ShouldReturnObject()
        {
            List<KomodoEmail> ReturnedRepo = _emailRepo.Read();
            Assert.AreEqual(_emailRepo.Read(), ReturnedRepo);
        }

        [TestMethod]
        public void DeleteEmail_ShouldReturnBool()
        {
            bool wasDeleted;
            wasDeleted = _emailRepo.RemoveEmail(_email);
            Assert.IsTrue(wasDeleted);
        }

        [TestMethod]
        public void UpdateEmail_ShouldReturnObject()
        {
            KomodoEmail updatedEmail = new KomodoEmail();
            string fullName = _email.FirstName + " " + _email.LastName;
            _emailRepo.UpdatebyFullName(fullName, new KomodoEmail("Seymour", "Butts", "sbutts@gmail.com", CustType.Current));
            updatedEmail = _emailRepo.FindUserByFullName("Seymour Butts");
            Assert.AreEqual("Seymour", updatedEmail.FirstName);
        }
    }
}
