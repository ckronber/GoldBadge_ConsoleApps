using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Greeting
{
    public class ProgramUI
    {
        public KomodoEmailRepo _emailRepo = new KomodoEmailRepo();
        public bool _keepRunning = true;

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
            Console.WriteLine("\tKomodo Email List\n" +
                "=====================================\n" +
                "Choose a menu item:\n" +
                "1. Display All Customers\n" +
                "2. Add Customer to List\n" +
                "3. Update Customer in List\n" +
                "4. Remove Customer from List\n" +
                "5. Exit\n\n");

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

        public void DisplayEmailCustomers()
        {
            List<KomodoEmail> eList = _emailRepo.Read();
            string DisplayFormat = "{0,-12}{1,-10}{2,-10}{3,-50}";

            Console.WriteLine(DisplayFormat, "FirstName", "LastName", "Type", "EmailContent");
            Console.WriteLine(DisplayFormat, "=========", "========", "====", "============");
            foreach (KomodoEmail email in eList)
            {
                Console.WriteLine(DisplayFormat, email.FirstName,email.LastName,email.TypeOfCustomer,email.Email);
            }
            Console.WriteLine();
        }

        public void AddEmailCustomer()
        {
            KomodoEmail email = new KomodoEmail();
            _emailRepo.AddEmail(getCustomerInfo(email,true));
        }

        public KomodoEmail getCustomerInfo(KomodoEmail email,bool AddUpdate)
        {
            string updated = "";

            if (AddUpdate == false)
                updated = "The Updated ";
            Console.Write($"Enter {updated}First Name: ");
            email.FirstName = Console.ReadLine();

            Console.Write($"Enter {updated}Last Name: ");
            email.LastName = Console.ReadLine();

            Console.Write($"Enter {updated}Email Address: ");
            email.EmailAddress = Console.ReadLine();

            email.TypeOfCustomer = DisplayCustomerOptions(AddUpdate);

            return email;
        }

        public CustType DisplayCustomerOptions(bool update)
        {
            int choice;
            if (update == true)
            {
                Console.Write("\n\nEnter the Customer Type\n" +
                    "--------------------------------------------\n" +
                    "1. Potential\n" +
                    "2. Current\n" +
                    "3. Past\n\n" +
                    "Enter a Number: ");
            }
            else
            {
                Console.Write("\n\nUpdate the Customer Type\n" +
                    "--------------------------------------------\n" +
                    "1. Potential\n" +
                    "2. Current\n" +
                    "3. Past\n\n" +
                    "Enter a Number: ");
            }

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    return CustType.Potential;
                case 2:
                    return CustType.Current;
                case 3:
                    return CustType.Past;
                default:
                    Console.WriteLine("Select a valid number");
                    ClearAfterKeypress();
                    return CustType.Potential;
            }
        }

        public void UpdateEmailCustomer()
        {
            KomodoEmail email = new KomodoEmail();
            List <KomodoEmail> checkList = _emailRepo.Read();

            DisplayEmailCustomers();

            string Name = "";
            Console.Write("Enter the First and Last name to update seperated by a space:");
            Name = Console.ReadLine().ToLower();

            if(IsNameInList(Name))
                _emailRepo.UpdatebyFullName(Name,getCustomerInfo(email, false));
            else
                Console.WriteLine("Name not Found in List. Check Spelling and Try Again");
        }

        public bool IsNameInList(string Name)
        {
            List <KomodoEmail> eRepo = _emailRepo.Read();
            string[] FullName = Name.Split(' ');

            foreach(KomodoEmail email in eRepo)
            {
                if (email.FirstName.ToLower() == FullName[0].ToLower() && email.LastName.ToLower() == FullName[1].ToLower())
                    return true;
            }
            return false;
        }

        public void DeleteEmailCustomer()
        {
            DisplayEmailCustomers();
            KomodoEmail email = new KomodoEmail();
            bool wasDeleted;

            Console.Write("Enter Full Name with space to Delete: ");
            email = _emailRepo.FindUserByFullName(Console.ReadLine());
            wasDeleted = _emailRepo.RemoveEmail(email);

            if(wasDeleted)
                Console.WriteLine("Email was Deleted.");
            else
                Console.WriteLine("Email was not Found/Deleted.");
        }

        public void SeedEmails()
        {
            _emailRepo.AddEmail(new KomodoEmail("Joe", "Rogan", "jrogan@gmail.com", CustType.Past));
            _emailRepo.AddEmail(new KomodoEmail("Elon", "Musk", "muske@gmail.com", CustType.Current));
            _emailRepo.AddEmail(new KomodoEmail("Seymour", "Butts", "sbutts@gmail.com", CustType.Past));
            _emailRepo.AddEmail(new KomodoEmail("Ben", "Dover", "bendover@gmail.com", CustType.Potential));
        }
    }
}
