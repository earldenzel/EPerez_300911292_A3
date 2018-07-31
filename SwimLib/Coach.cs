using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimLib
{
    /*
     * i. Coaching credentials (string)
     * ii. List of swimmers that are being coached by this coach
     */

    public class Coach : Registrant
    {
        string credentials;
        Swimmer[] swimmers;
        int noOfSwimmers = 0;

        public Coach(string name, DateTime dateOfBirth, Address address, long phoneNumber): base(name, dateOfBirth,address,phoneNumber)
        {
            swimmers = new Swimmer[50];
        }

        public string Credentials
        {
            get
            {
                return credentials;
            }

            set
            {
                credentials = value;
            }
        }

        public Swimmer[] Swimmers
        {
            get
            {
                return swimmers;
            }

            set
            {
                swimmers = value;
            }
        }

        public int NoOfSwimmers
        {
            get
            {
                return noOfSwimmers;
            }

            set
            {
                noOfSwimmers = value;
            }
        }

        public void AddSwimmer(Swimmer swimmer)
        {
            if (Club == null)
            {
                throw new Exception("Coach is not assigned to a club");
            }
            else if (Club != swimmer.Club)
            {
                throw new Exception("Coach and swimmer are not in the same club");
            }
            else
            {
                Swimmers[NoOfSwimmers] = swimmer;
                NoOfSwimmers++;
                swimmer.Coach = this;
            }
        }

        public override string ToString()
        {
            string info = string.Format("\nCredentials: {0}\nSwimmers:", Credentials);
            for (int i = 0; i < NoOfSwimmers; i++)
            {
                info += Swimmers[i].GetSwimmerName();
            }
            return base.ToString() + info;
        }
    }
}
