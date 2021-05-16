using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_ConsoleApps
{
    class ProgramUI
    {
        public void Run()
        {
            displayChoices();


        }

        public void displayChoices()
        {
            Console.WriteLine("Welcome to Komodo Cafe\n" +
                "================================================\n" +
                "Menu Choices\n" +
                "1. Add Menu Items\n" +
                "2. Update Menu Items\n" +
                "3. Delete Menu Items\n" +
                "4. Display Menu Items\n\n\n");
        }
    }
}
