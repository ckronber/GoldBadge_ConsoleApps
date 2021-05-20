using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting
{
    public class KomodoEmailRepo
    {
        private readonly List<KomodoEmail> _emailList = new List<KomodoEmail>();

        //Create
        public bool AddEmail(KomodoEmail email)
        {
            int count;
            count = _emailList.Count();
            _emailList.Add(email);          //Spamalot?

            return _emailList.Count() > count ? true:false;
        }

        //Read
        public List<KomodoEmail> Read()
        {
            return _emailList;
        }

        //Update
        public void UpdatebyFullName(string FullName,KomodoEmail updateEmail)
        {
            KomodoEmail email = FindUserByFullName(FullName);

            email.FirstName = updateEmail.FirstName;
            email.LastName = updateEmail.LastName;
            email.EmailAddress = updateEmail.EmailAddress;
            email.TypeOfCustomer = updateEmail.TypeOfCustomer;
        }

        public KomodoEmail FindUserByFullName(string FullName)
        {
            string[] Name = FullName.Split(' ');
            
            foreach(KomodoEmail email in _emailList)
            {
                if (Name[0].ToLower() == email.FirstName.ToLower() && Name[1].ToLower() == email.LastName.ToLower())
                {
                    return email;
                }
            }
            return null;
        }

        //Delete
        public bool RemoveEmail(KomodoEmail email)
        {
            int count = _emailList.Count();
            _emailList.Remove(email);

            return _emailList.Count() < count ? true:false;
        }
    }
}
