using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimLib
{
    public enum Stroke
    {
        Butterfly, Backstroke, Breaststroke, Freestyle, Individual_Medley
    }
    public enum EventDistance
    {
        _50 = 50, _100 = 100, _200 = 200, _400 = 400, _800 = 800, _1500 = 1500
    }
    public class Event
    {
        private EventDistance distance;
        private Stroke stroke;
        private Registrant[] registrants;
        private int noOfRegistrants = 0;
        private SwimMeet swimMeet;
        private Swim[] swims;

        public Event():this(EventDistance._1500,Stroke.Individual_Medley)
        {

        }

        public Event(EventDistance distance, Stroke stroke)
        {
            this.distance = distance;
            this.stroke = stroke;
            registrants = new Registrant[100];
            swims = new Swim[100];
        }

        public override string ToString()
        {
            string info = string.Format("\n\t{0} {1}\n\tSwimmers:",distance,stroke);
            for (int i = 0; i<NoOfRegistrants; i++)
            {
                info += registrants[i].GetSwimmerName();
                
                if (Swims[i] == null)
                {
                    info += "\n\t\tNot seeded/No swim";
                }
                else
                {
                    info += string.Format("\tH{0}L{1}\tTime: {2}", Swims[i].Heat, Swims[i].Lane, Swims[i].GetInfo());
                }
            }
            return info;
        }

        public EventDistance Distance
        {
            set
            {
                distance = value;
            }
            get
            {
                return distance;
            }
        }

        public Stroke Stroke
        {
            set
            {
                stroke = value;
            }
            get
            {
                return stroke;
            }
        }

        public Registrant[] Registrants
        {
            get
            {
                return registrants;
            }

            set
            {
                registrants = value;
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

        public SwimMeet SwimMeet
        {
            get
            {
                return swimMeet;
            }

            set
            {
                swimMeet = value;
            }
        }

        public Swim[] Swims
        {
            get
            {
                return swims;
            }

            set
            {
                swims = value;
            }
        }

        public void AddSwimmer(Registrant aSwimmer)
        {
            for (int i=0; i<NoOfRegistrants; i++)
            {
                if (registrants[i].Number == aSwimmer.Number)
                {
                    throw new Exception(string.Format("Swimmer {0},{1} is already entered", aSwimmer.Name, aSwimmer.Number));
                }
            }
            registrants[NoOfRegistrants] = aSwimmer;
            NoOfRegistrants++;
        }

        public void Seed()
        {
            for (int i = 0; i < NoOfRegistrants; i++)
            {
                Swim newSwim = new Swim(1 + i / SwimMeet.Lanes, 1 + i % SwimMeet.Lanes);
                newSwim.Registrant = Registrants[i];
                newSwim.SwimEvent = this;
                swims[i] = newSwim;
            }
        }

        public void EnterSwimmersTime(Registrant registrant, string swimTime)
        {
            Swimmer swimmer = registrant as Swimmer;
            for (int i = 0; i < noOfRegistrants; i++)
            {
                if (swimmer.Number == registrants[i].Number)
                {
                    swims[i].SwimTime = swimTime;
                    swimmer.AddAsBestTime(swimMeet.PoolType, Distance, Stroke, TimeSpan.Parse("00:"+swimTime));
                    return;
                }
            }
            throw new Exception("Swimmer has not entered event");
        }
    }
}
