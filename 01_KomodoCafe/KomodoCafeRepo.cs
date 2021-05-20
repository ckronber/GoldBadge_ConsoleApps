using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_ConsoleApps
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _CafeRepo = new List<MenuItem>() { };

        // Create Menu Items
        public bool CreateMenuItems(MenuItem MenuItem)
        {
            MenuItem.MealNumber = _CafeRepo.Count+1;
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
            MenuItem updateMenuItem = _CafeRepo[mealNumber-1];
            updateMenuItem.MealName = MenuItem.MealName;
            updateMenuItem.MealDescription = MenuItem.MealDescription;
            updateMenuItem.Ingredients = MenuItem.Ingredients;
            updateMenuItem.price = MenuItem.price;
        }

        //Delete Menu Items
        public bool DeleteMenuItem(int mealNumber)
        {
            int repoCount = _CafeRepo.Count;
            _CafeRepo.Remove(_CafeRepo[mealNumber-1]);

            if (_CafeRepo.Count > 0)
            {
                for (int i = 0; i < _CafeRepo.Count; i++)
                {
                    _CafeRepo[i].MealNumber = i + 1;
                }
            }

            if (_CafeRepo.Count < repoCount)
                return true; // item was deleted
            else
                return false; // item was not deleted
        }
    }
}
