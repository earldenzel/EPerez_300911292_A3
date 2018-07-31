using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimLib
{
    public enum PoolType
    {
        SCM, SCY, LCM
    }

    public class SwimMeet
    {
        private DateTime startDate;
        private DateTime endDate;
        private string name;
        private PoolType poolType;
        private int lanes;
        private readonly Event[] events;
        private int noOfEvents = 0;

        public SwimMeet():this("",new DateTime(), new DateTime(), PoolType.SCM, 8)
        {

        }

        public SwimMeet(string name, DateTime startDate, DateTime endDate, PoolType poolType, int lanes)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.name = name;
            this.poolType = poolType;
            this.lanes = lanes;
            events = new Event[50];
        }

        public override string ToString()
        {
            string info = string.Format("Swim Meet name: {0}\nFrom-to: {1} to {2}\nPool Type: {3}\nNo. of Lanes: {4}\nEvents:", name, startDate.ToString("MMMM dd, yyyy"), endDate.ToString("MMMM dd, yyyy"), poolType, lanes);
            for(int i = 0; i < noOfEvents; i++)
            {
                info += events[i].ToString() + "\n";
            }
            return info;
        }

        public DateTime StartDate
        {
            set
            {
                startDate = value;
            }
            get
            {
                return startDate;
            }
        }

        public DateTime EndDate
        {
            set
            {
                endDate = value;
            }
            get
            {
                return endDate;
            }
        }

        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        public PoolType PoolType
        {
            set
            {
                poolType = value;
            }
            get
            {
                return poolType;
            }
        }

        public int Lanes
        {
            get
            {
                return lanes;
            }

            set
            {
                lanes = value;
            }
        }

        public Event[] Events
        {
            get
            {
                return events;
            }

            //set
            //{
            //    events = value;
            //}
        }

        public void AddEvent(Event aEvent)
        {
            events[noOfEvents] = aEvent;
            events[noOfEvents].SwimMeet = this;
            noOfEvents++;
        }

        public void Seed()
        {
            for (int i=0; i<noOfEvents; i++)
            {
                events[i].SwimMeet = this;
                events[i].Seed();
            }
        }
    }
}
