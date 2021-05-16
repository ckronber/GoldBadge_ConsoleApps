using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_ConsoleApps
{
    public class MenuRepository
    {
        private List<MenuItem> _CafeRepo = new List<MenuItem>() { };

        // Create Menu Items
        public bool CreateMenuItems(MenuItem MenuItem)
        {
            int repCount = _CafeRepo.Count;

            _CafeRepo.Add(MenuItem);

            if (_CafeRepo.Count > repCount)
                return true;
            else
                return false;

        }

        //Read Menu Items
        public List<MenuItem> ReadMenuItems()
        {
            return _CafeRepo;
        }

        //Update Menu Items
        public void UpdateMenuItems(int mealNumber, MenuItem MenuItem)
        {
            MenuItem updateMenuItem = _CafeRepo[mealNumber - 1];
            updateMenuItem.MealName = MenuItem.MealName;
            updateMenuItem.MealDescription = MenuItem.MealDescription;
            updateMenuItem.Ingredients = MenuItem.Ingredients;
            updateMenuItem.price = MenuItem.price;
        }

        //Delete Menu Items
        public void DeleteMenuItem(int mealNumber)
        {
            _CafeRepo.Remove(_CafeRepo[mealNumber - 1]);

        }
    }
}
