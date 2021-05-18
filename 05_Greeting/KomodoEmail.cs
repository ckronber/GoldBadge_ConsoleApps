using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting
{
    public enum CustType
    {
        Potential, Current, Past
    }
    public class KomodoEmail
    {
        public KomodoEmail() { }
        public KomodoEmail(string firstName, string LastName, string emailAddress, CustType typeCutomer)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
            this.TypeOfCustomer = typeCutomer;
            this.EmailAddress = emailAddress;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string EmailAddress { get; set; }
        public CustType TypeOfCustomer { get; set; }
        public string Email
        {
            get
            {
                if (this.TypeOfCustomer == CustType.Current)
                    return "Thank you for your work with us. We appreciate your Loyalty!";
                else if (this.TypeOfCustomer == CustType.Past)
                    return "It's been a long time since we've heard from you, we would like to see you come back";
                else
                    return "We currently have the lowest rates in Helicopter Insurane!";

            }
        }
    }
}
