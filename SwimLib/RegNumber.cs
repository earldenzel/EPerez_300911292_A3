using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimLib
{
    //This class is a singleton
    public class RegNumber
    {
        private int number;
        private static RegNumber instance;

        private RegNumber()
        {
            Number = 0;
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
        
        public static RegNumber AssignRegNumber()
        {
            if (instance == null)
            {
                instance = new RegNumber();
            }
            instance.Number++;
            return instance;
        }
    }
}
