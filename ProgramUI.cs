using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_ConsoleApps
{
    class ProgramUI
    {
        bool _keepRunning = true;
        MenuRepository cafeRepository = new MenuRepository();
        MenuItem cafeMenuItem = new MenuItem();
        public void Run()
        {
            while (_keepRunning)
            {
                DisplayCafeMenu();
                GetResponse();
            }
        }

        public void DisplayCafeMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Komodo Cafe\n" +
                "================================================\n" +
                "Menu Choices\n" +
                "1. Add Menu Items\n" +
                "2. Update Menu Items\n" +
                "3. Delete Menu Items\n" +
                "4. Display Menu Items\n" +
                "5. Exit\n\n\n");
        }

        public void GetResponse()
        {
            Console.WriteLine("Enter a Number: ");

            switch (Console.Read())
            {
                case 1:
                    
                    break;

                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:
                    _keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Choose a number between 1 and 5");
                    break;

            }
        }

        public void CreateOrUpdateItem(bool createUpdate)
        {

           if(createUpdate == true)
            {
                
            }
            else
            {

            }

        }
    }
}
