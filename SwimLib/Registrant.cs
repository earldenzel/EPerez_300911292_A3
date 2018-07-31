using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimLib
{
    public class Registrant
    {
        private int number;
        private string name;
        private DateTime dateOfBirth; 
        private Address address;
        private long phoneNumber;
        private Club club;
        
        public Registrant() : this("",new DateTime(1,1,1),new Address(),0, 0)
        {

        }

        public Registrant(string name, DateTime dateOfBirth, Address address, long phoneNumber):this(name,dateOfBirth,address,phoneNumber,RegNumber.AssignRegNumber().Number)
        {
        }

        public Registrant(string name, DateTime dateOfBirth, Address address, long phoneNumber, int number)
        {
            this.number = number;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            string info = string.Format("Name: {0}\nAddress:\n\t{1}\n\t{2}\n\t{3}\n\t{4}\nPhone: {5}\nDOB: {6}\nReg number: {7}",name,address.StreetAddress, address.Municipality, address.Province, address.ZipCode, phoneNumber, dateOfBirth, number);
            if (club == null)
            {
                info += "\nClub: not assigned";
            }
            else
            {
                info += string.Format("\nClub: {0}", club.Name);
            }

            return info;
        }
        
        public string GetSwimmerName()
        {
            return string.Format("\n\t{0}", name);
        }


        public string Name
        {
            set
            {
                name = value;
                if (Number == 0)
                {
                    Number = RegNumber.AssignRegNumber().Number; 
                }
            }
            get
            {
                return name;
            }
        }

        public Address Address
        {
            set
            {
                address = value;
            }
            get
            {
                return address;
            }
        }

        public DateTime DateOfBirth
        {
            set
            {
                dateOfBirth = value;
            }
            get
            {
                return dateOfBirth;
            }
        }

        public long PhoneNumber
        {
            set
            {
                phoneNumber = value;
            }
            get
            {
                return phoneNumber;
            }
        }

        public Club Club
        {
            get
            {
                return club;
            }

            set
            {
                if (club == null)
                {                    
                    club = value;
                    int i = value.NoOfRegistrants;
                    value.Registrants[i] = this;
                    value.NoOfRegistrants++;
                }
                else
                {
                    throw new Exception("Swimmer is registered with a different club");
                }
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }
    }
}
