using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlanConsole
{
    class ProgramUI
    {
        public void Run()
        {
            SeedEmails();

            while (_keepRunning)
            {
                DisplayMenu();
            }
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\tKomodo Green Plan\n" +
                "=====================================\n" +
                "Choose a Vehicle Type:\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n" +
                "4. Exit\n\n");

            GetResponse();
        }

        private void GetResponse()
        {
            Console.Write("Enter a Number: ");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        DisplayEmailCustomers();
                        ClearAfterKeypress();
                        break;
                    case 2:
                        Console.Clear();
                        AddEmailCustomer();
                        ClearAfterKeypress();
                        break;
                    case 3:
                        Console.Clear();
                        UpdateEmailCustomer();
                        ClearAfterKeypress();
                        break;
                    case 4:
                        DeleteEmailCustomer();
                        ClearAfterKeypress();
                        break;
                    case 5:
                        _keepRunning = false;
                        break;
                    default:
                        Console.Write("Choose a number between 1 and 4");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(1000);
            }
        }

        private void ClearAfterKeypress()
        {
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
