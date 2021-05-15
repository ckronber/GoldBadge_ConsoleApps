using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_ConsoleApps
{
    public class KomodoCafe
    {
        public KomodoCafe() { }
        public KomodoCafe(int mealNumber, string mealName, string mealDescription, List<string> mealIngredients, decimal price) { }
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>() { };
        public decimal price { get; set; }
    }
}
