using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_ConsoleApps
{
    public class KomodoCafeRepo
    {
        private List<KomodoCafe> _CafeRepo = new List<KomodoCafe>() { };

        // Create Menu Items
        public bool CreateMenuItems(KomodoCafe MenuItem)
        {
            int repCount = _CafeRepo.Count;

            _CafeRepo.Add(MenuItem);

            if (_CafeRepo.Count > repCount)
                return true;
            else
                return false;

        }

        //Read Menu Items
        public List<KomodoCafe> ReadMenuItems()
        {
            return _CafeRepo;
        }

        //Update Menu Items
        public void UpdateMenuItems(int mealNumber, KomodoCafe MenuItem)
        {
            KomodoCafe updateMenuItem = _CafeRepo[mealNumber - 1];
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
