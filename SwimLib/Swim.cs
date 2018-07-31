using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimLib
{
    public class Swim
    {
        private string swimTime;
        private int heat;
        private int lane;
        private Registrant registrant;
        private Event swimEvent;

        public Swim(int heat, int lane) : this("", heat, lane)
        {

        }

        public Swim(string swimTime, int heat, int lane)
        {
            this.swimTime = swimTime;
            this.heat = heat;
            this.lane = lane;
        }

        public string GetInfo()
        {
            if (swimTime == "")
            {
                return "no time";
            }
            else
            {
                return swimTime;
            }
        }

        public int Lane
        {
            get
            {
                return lane;
            }

            set
            {
                lane = value;
            }
        }

        public int Heat
        {
            get
            {
                return heat;
            }

            set
            {
                heat = value;
            }
        }

        public string SwimTime
        {
            get
            {
                return swimTime;
            }

            set
            {
                swimTime = value;
            }
        }

        public Registrant Registrant
        {
            get
            {
                return registrant;
            }

            set
            {
                registrant = value;
            }
        }

        public Event SwimEvent
        {
            get
            {
                return swimEvent;
            }

            set
            {
                swimEvent = value;
            }
        }
    }
}
