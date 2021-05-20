using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoldBadge_ConsoleApps
{
    class ProgramUI
    {
        bool _keepRunning = true;
        public MenuRepository _cafeRepository = new MenuRepository() { };
        public MenuItem _cafeMenuItem = new MenuItem();

        public void Run()
        {
            seedItems();
            while (_keepRunning)
            {
                DisplayCafeMenu();
                GetResponse();
            }
        }

        public void DisplayCafeMenu()
        {
            Console.Clear();
            Console.WriteLine("   Welcome to Komodo Cafe\n" +
                "=================================\n\n" +
                "Menu Choices\n" +
                "1. Add Menu Items\n" +
                "2. Update Menu Items\n" +
                "3. Display Menu Items\n" +
                "4. Delete Menu Items\n" +
                "5. Exit\n\n");
        }

        public void GetResponse()
        {
            Console.Write("Enter a Number: ");
            try {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        CreateOrUpdateItem(true);
                        Console.WriteLine("Press a key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        CreateOrUpdateItem(false);
                        Console.WriteLine("Press a key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        DisplayItems();
                        Console.WriteLine("Press a key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        DeleteItem();
                        Console.WriteLine("Press a key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        _keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Choose a number between 1 and 5");
                        Thread.Sleep(1000);
                        break;
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(1000);
            }
            
        }
        
        private void CreateOrUpdateItem(bool createUpdate)
        {
            List<MenuItem> repo = _cafeRepository.ReadMenuItems();

            int cafeMealNumber = 0;

            if (createUpdate == false)
            {
                DisplayItems();
                Console.WriteLine("\nEnter the number for the Menu Item you would like to update: ");
                cafeMealNumber = Convert.ToInt32(Console.ReadLine());
            }    

            Console.WriteLine("Enter the Menu Item Name:");
            _cafeMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the Menu Description:");
            _cafeMenuItem.MealDescription = Console.ReadLine();

            //addIngredients
            Console.WriteLine($"Enter the Ingredients for {_cafeMenuItem.MealName} seperated by commas:");
            string[] IngredientList = Console.ReadLine().Split(',');

            foreach(string Ingredient in IngredientList)
                _cafeMenuItem.Ingredients.Add(Ingredient); //reads from the user the ingredient they would like to add
    
            //Add or Update price for the Menu Item
            Console.WriteLine("Enter the price of the Menu Item");
            _cafeMenuItem.price = Convert.ToDecimal(Console.ReadLine());

            if (createUpdate == true)
                _cafeRepository.CreateMenuItems(_cafeMenuItem);
            else
                _cafeRepository.UpdateMenuItems(cafeMealNumber,_cafeMenuItem);
        }

        private void DisplayItems()
        {
            List<MenuItem> repo = _cafeRepository.ReadMenuItems();
            
            foreach (MenuItem Item in repo)
            {
                Console.WriteLine($"Menu Item Number: {Item.MealNumber}\n" +
                $"Menu Item Name: {Item.MealName}\n" +
                $"Menu Item Description: {Item.MealDescription}");
                Console.Write("Menu Ingredients: ");
                //foreach to display all ingredients
                int value = 1;
                foreach (string ingredient in Item.Ingredients)
                {
                    if (value < Item.Ingredients.Count)
                        Console.Write($"{ingredient},");
                    else
                        Console.Write($"{ingredient}\n");
                    value++;
                }
                Console.WriteLine($"Menu Item Price: ${Item.price}\n\n");
            }
        }

        private void DeleteItem()
        {
            List<MenuItem> repo = _cafeRepository.ReadMenuItems();

            if (repo.Count == 0)
                Console.WriteLine("There are no Menu Items");
            else
            {
                DisplayItems();
                Console.WriteLine("Enter the number for the Item you would like to delete: ");
                _cafeRepository.DeleteMenuItem(Convert.ToInt32(Console.ReadLine()));
            }
        }

        private void seedItems()
        {
            _cafeRepository.CreateMenuItems(new MenuItem("Bobs Burger", "burger with fries", new List<string>() { "Wheat", "other stuff" }, 8.25m));
            _cafeRepository.CreateMenuItems(new MenuItem("Bobs Burger with Bacon", "burger with bacon and fries", new List<string>() { "Wheat", "Bacon","Beef Patties" }, 9.50m));
            _cafeRepository.CreateMenuItems(new MenuItem("Bobs Burger with no Bun", "burger minus the bun with fries", new List<string>() { "Beef Patties", "other stuff","More Stuff" }, 11.50m));
        }
    }
}
