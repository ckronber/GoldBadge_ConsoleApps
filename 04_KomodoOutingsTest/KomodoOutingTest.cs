using _04_KomodoOutingsConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _04_KomodoOutingsTest
{
    [TestClass]
    public class KomodoOutingTest
    {
        private KomodoOutingsRepo _newRepo;
        private KomodoOutings _newOuting;

        [TestInitialize]
        public void ArrangeOutings()
        {
            _newRepo = new KomodoOutingsRepo();
            _newOuting = new KomodoOutings();
        }

        [TestMethod]
        public void AddOuting_ShouldReturnBool()
        {
            bool wasAdded;
            wasAdded = _newRepo.AddEvent(_newOuting);

            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void ReadEvents_ShouldReturnBool()
        {
            bool wasRead;
            List<KomodoOutings> myList = new List<KomodoOutings>();
            _newRepo.AddEvent(_newOuting);

            myList = _newRepo.ReadEvents();

            if (myList.Contains(_newOuting))
                wasRead = true;
            else
                wasRead = false;

            Assert.IsTrue(wasRead);
        }

        [TestMethod]
        public void DeleteEvent_ShouldReturnBool()
        {
            KomodoOutings myOuting = new KomodoOutings();
            _newRepo.AddEvent(myOuting);

            bool wasDeleted;
            wasDeleted = _newRepo.DeleteEvent(myOuting);

            Assert.IsTrue(wasDeleted);
        }
    }
}
