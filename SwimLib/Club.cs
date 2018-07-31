using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimLib
{
    
    public class Club
    {
        private int noOfRegistrants = 0;
        private int noOfCoaches = 0;
        private int number;
        private string name;
        private Address address;
        private long phoneNumber;
        private Registrant[] registrants;
        private Coach[] coaches;

        public Club():this("",new Address(), 0, 0)
        {

        }

        public Club(string name, Address address, long phoneNumber) : this(name, address, phoneNumber, RegNumber.AssignRegNumber().Number)
        {

        }


        public Club(string name, Address address, long phoneNumber, int number)
        {
            this.number = number;
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            registrants = new Registrant[20];
            coaches = new Coach[20];
        }

        public override string ToString()
        {
            string info = string.Format("Name: {0}\nAddress:\n\t{1}\n\t{2}\n\t{3}\n\t{4}\nPhone: {5}\nReg number: {6}\nSwimmers:", name, address.StreetAddress, address.Municipality, address.Province, address.ZipCode, phoneNumber, number);
            string coaches = "";
            for (int i = 0; i < NoOfRegistrants; i++)
            {
                Swimmer swimmer = registrants[i] as Swimmer;
                if (swimmer != null)
                    info += registrants[i].GetSwimmerName();
                else
                    coaches += registrants[i].GetSwimmerName();
            }

            info += string.Format("\nCoaches: {0}", coaches);

            return info;
        }

        public string Name
        {
            set
            {
                name = value;
                if (Number == 0)
                {
                    Number = RegNumber.AssignRegNumber().Number; //club number 1 from harness
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

        public Registrant[] Registrants
        {
            get
            {
                return registrants;
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

        public int NoOfRegistrants
        {
            get
            {
                return noOfRegistrants;
            }

            set
            {
                noOfRegistrants = value;
            }
        }

        public int NoOfCoaches
        {
            get
            {
                return noOfCoaches;
            }

            set
            {
                noOfCoaches = value;
            }
        }

        public Coach[] Coaches
        {
            get
            {
                return coaches;
            }

            set
            {
                coaches = value;
            }
        }

        public void AddSwimmer(Registrant aRegistrant)
        {
            aRegistrant.Club = this;
        }

        public void AddCoach(Coach coach)
        {
            coach.Club = this;
            Coaches[NoOfCoaches] = coach;
            NoOfCoaches++;
        }
    }
}
