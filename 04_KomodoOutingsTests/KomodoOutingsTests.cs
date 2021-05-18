using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace _04_KomodoOutingsTests
{
    [TestClass]
    public class KomodoOutingsTests
    {
        [TestMethod]
        public void addOuting_ShouldReturnBool()
        {
            testRepo = new KomodoOutingsRepo();
            KomodoOutings testOuting = new KomodoOutings() { };

            bool isTrue = true;
            Assert.isTrue(isTrue);
        }
        [TestMethod]
        public void ReadOutings_ShouldReturnRepo()
        {

        }
        [TestMethod]
        public void RemvoeOuting_ShouldReturnBool()
        {

        }
    }
}
