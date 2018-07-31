using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimLib
{
    public struct Address
    {
        public string StreetAddress;
        public string Municipality;
        public string Province;
        public string ZipCode;

        public Address(string streetAddress, string municipality, string province, string zipCode)
        {
            StreetAddress = streetAddress;
            Municipality = municipality;
            Province = province;
            ZipCode = zipCode;
        }
    }
}
