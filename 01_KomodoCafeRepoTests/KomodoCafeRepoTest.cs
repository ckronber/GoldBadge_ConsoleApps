using GoldBadge_ConsoleApps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafeRepoTests
{
    [TestClass]
    public class KomodoCafeRepoTest
    {
        [TestMethod]
        public void CreateMenuItem_ShouldReturnBool()
        {
            bool value; //value to return to see if an item was created or not
            MenuItem cafeItem = new MenuItem();
            MenuRepository cafeRepo = new MenuRepository();

            value = cafeRepo.CreateMenuItems(cafeItem);
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void DisplayAllItems_ShouldReturnCurrentCollection()
        {
            //Arrange
            MenuItem cafeItem = new MenuItem();
            MenuRepository cafeRepo = new MenuRepository();
            cafeRepo.CreateMenuItems(cafeItem);

            //Act
            List<MenuItem> cafedirectory = cafeRepo.ReadMenuItems();

            //Assert
            bool cafedirectoryhasContents = cafedirectory.Contains(cafeItem);
            Assert.IsTrue(cafedirectoryhasContents);
        }

        private MenuItem cafeItem;
        private  MenuRepository cafeRepository;

        [TestInitialize]
        public void Arrange()
        {
           cafeRepository = new MenuRepository();
           cafeItem = new MenuItem("Bobs Burger", "burger with fries", new List<string>() { "Wheat", "other stuff" }, 11.23m);
           cafeRepository.CreateMenuItems(cafeItem);
        }

        [TestMethod]
        public void UpdateMenuItem_ShouldReturnUpdatedMenuItem()
        {
            //Arrange
            //Already done in the Arrange() method
            cafeRepository.UpdateMenuItems(1,new MenuItem( "Burger with Cheese", "Burger with fries", new List<string>() { "item1", "item2" }, 12.45m));
            //Assert
            Assert.AreEqual(cafeItem.MealName, "Burger with Cheese");
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnBool()
        {
            //Arrange
            bool value;
            //Already done in the Arrange() method
            //Act
            value = cafeRepository.DeleteMenuItem(1);
            //Assert
            Assert.IsTrue(value);
        }
    }
}
