using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_ConsoleApps
{
    public class MenuItem
    {
        public MenuItem() { }
        public MenuItem(string mealName, string mealDescription, List<string> mealIngredients, decimal price) {
            MealNumber += 1;
            this.MealName = mealName;
            this.MealDescription = mealDescription;
            this.Ingredients = mealIngredients;
            this.price = price;
        }
        public int MealNumber { get; private set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>() { };
        public decimal price { get; set; }
    }
}
