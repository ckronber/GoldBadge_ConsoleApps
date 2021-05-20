using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    public class ProgramUI
    {
        public bool _keepRunning = true;
        public ClaimRepository _claimRepo = new ClaimRepository();
        public int _count = 0;
       
        public void Run()
        {
            SeedClaims();
            while (_keepRunning)
            {
                DisplayClaimsMenu();
            }
        }

        private void DisplayClaimsMenu()
        {
            Console.Clear();
            Console.WriteLine("\tKomodo Claims Department\n" +
                "=======================================\n\n" +
                "Choose a menu item:\n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter new claim\n" +
                "4. Exit\n");

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
                        SeeClaims();
                        ClearAfterKeypress();
                        break;
                    case 2:
                        Console.Clear();
                        TakeCareofClaims();
                        Thread.Sleep(2000);
                        break;
                    case 3:
                        Console.Clear();
                        EnterNewClaim();
                        ClearAfterKeypress();
                        break;
                    case 4:
                        _keepRunning = false;
                        break;
                    default:
                        Console.Write("Choose a number between 1 and 4");
                        Thread.Sleep(1000);
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
            Console.Write("\n\nPress a key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private void SeeClaims()
        {
            List<Claim> claimArray = _claimRepo.ReadQueue();

            Console.WriteLine("{0,-10}{1,-10}{2,-25}{3,-10}{4,-18}{5,-18}{6,-10}","ClaimID","Type","Description","Amount","DateOfAccident","DateOfClaim","IsValid");
            foreach (Claim myClaim in claimArray)
            {
                Console.WriteLine("{0,-10}{1,-10}{2,-25}{3,-10}{4,-18}{5,-18}{6,-10}", myClaim.ClaimID,myClaim.TypeOfClaim,myClaim.Description,$"${myClaim.ClaimAmount}",myClaim.DateOfIncident.ToShortDateString(),myClaim.DateOfClaim.ToShortDateString(),myClaim.IsValid);
            }
        }

        private void TakeCareofClaims()
        {
            bool isDealt;
            string answer;
            Claim myClaim = _claimRepo.GetNext();

            if (myClaim != null)
            {
                Console.WriteLine($"ClaimID: {myClaim.ClaimID}\n" +
                    $"Description: {myClaim.TypeOfClaim}\n" +
                    $"Amount: {myClaim.ClaimAmount}\n" +
                    $"DateOfAccident: {myClaim.DateOfIncident.ToShortDateString()}\n" +
                    $"DateOfClaim: {myClaim.DateOfClaim.ToShortDateString()}\n" +
                    $"isValid: {myClaim.IsValid}\n");

                Console.Write("\n Do you want to deal with this claim now? (y/n): ");
                answer = Console.ReadLine();
                if (answer == "y" || answer == "Y")
                {
                    isDealt = _claimRepo.DeleteQueue();
                    Console.WriteLine("\nClaim Has Been Dealt with by Jared from State Farm");
                }
                else
                {
                    Console.WriteLine("\nI dont really want deal with it either =)");
                }
            }
            else
            {
                Console.WriteLine("There are no more Claims.");
            }
        }

        private void EnterNewClaim()
        {
            Claim myClaim = new Claim();

            Console.Write("Enter the Claim ID: ");
            myClaim.ClaimID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the claim type (car, home, or theft): ");
            myClaim.TypeOfClaim = DisplayClaimtypeMenu();
            Console.WriteLine($"Claim ID: {myClaim.ClaimID}");
            Console.WriteLine($"Claim Type: {myClaim.TypeOfClaim}");
            Console.Write("Enter a Claim Description: ");
            myClaim.Description = Console.ReadLine();
            Console.Write("Amount of Damage: $");
            myClaim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Date of Accident in Month/Day/Year format: ");
            string[] calEntry = Console.ReadLine().Split('/');
            myClaim.DateOfIncident = new DateTime(Convert.ToInt32(calEntry[2]), Convert.ToInt32(calEntry[0]), Convert.ToInt32(calEntry[1]));
            Console.Write("Date of Claim in Month/Day/Year format: ");
            string[] cal2Entry = Console.ReadLine().Split('/');
            myClaim.DateOfClaim= new DateTime(Convert.ToInt32(cal2Entry[2]), Convert.ToInt32(cal2Entry[0]), Convert.ToInt32(cal2Entry[1]));
            if(myClaim.IsValid)
                Console.WriteLine("The claim is valid.");
            else
                Console.WriteLine("The claim is NOT valid.");

            _claimRepo.AddToQueue(myClaim);
        }

        private ClaimType DisplayClaimtypeMenu()
        {
            int responseValue;

            do
            {
                Console.Clear();
            Console.WriteLine("\tInsurance Claim Type\n" +
                "=======================================\n\n" +
                "Choose a Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            

                responseValue = GetClaimResponse();
            } while (responseValue <= 0 || responseValue > 3);
            Console.Clear();

            return (ClaimType)responseValue;
        }

        private int GetClaimResponse()
        {
            Console.Write("Enter a Number: ");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        return 1;
                    case 2:
                        Console.Clear();
                        return 2;
                    case 3:
                        Console.Clear();
                        return 3;
                    default:
                        Console.Write("Choose a number between 1 and 3");
                        Thread.Sleep(1000);
                        Console.Clear();
                        return -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(1000);
            }
            return 0;
        }

        private void SeedClaims()
        {
            _claimRepo.AddToQueue(new Claim(1,ClaimType.Car,"Car Accident on I65",432.25m,new DateTime(2020,5,23),new DateTime(2020,5,31)));
            _claimRepo.AddToQueue(new Claim(2,ClaimType.Home, "Hail Damage to Roof", 432.25m,new DateTime(2020, 4, 23), new DateTime(2020, 5, 31)));
            _claimRepo.AddToQueue(new Claim(3,ClaimType.Theft, "Ipod stolen", 432.25m,new DateTime(2020, 4, 23), new DateTime(2020, 5, 15)));
        }
    }
}
