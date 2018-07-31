using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimLib
{
    /*
     * i. List of the best times for each event and course (SCY, SCM, LCM) (This may require changes to EnterSwimmerTime() method and Event class.
     * ii. Coach that is being coached by.
     * iii. Method GetBestTime that has 3 parameters: course, distance, and stroke. This method returns TimeSpan type that represents the best time for the swimmer.
     * iv. Method AddAsBestTime that has 4 parameters: course, distance, stroke, and time. This method check if the given time (TimeSpan) is the best time and if it is it will save it as the best time for the course, the distance and the stroke specified.
     */
     
    public class Swimmer : Registrant
    {
        BestTime[] bestTimes = new BestTime[20];
        Coach coach;
        int noOfBestTimes = 0;

        public Swimmer(): base()
        {

        }
        
        public Swimmer(string name, DateTime dateOfBirth, Address address, long phoneNumber, int number): base(name, dateOfBirth, address, phoneNumber, number)
        {

        }


        public Swimmer(string name, DateTime dateOfBirth, Address address, long phoneNumber) :base(name, dateOfBirth, address, phoneNumber)
        {

        }

        public BestTime[] BestTimes
        {
            get
            {
                return bestTimes;
            }

            set
            {
                bestTimes = value;
            }
        }

        public Coach Coach
        {
            get
            {
                return coach;
            }

            set
            {
                if (value.Club != Club)
                {
                    throw new Exception("Coach is not assigned to the club");
                }
                coach = value;
            }
        }

        public int NoOfBestTimes
        {
            get
            {
                return noOfBestTimes;
            }

            set
            {
                noOfBestTimes = value;
            }
        }

        public override string ToString()
        {
            string info;
            if (Coach == null)
                info = "\nCoach: not assigned";
            else
                info = string.Format("Coach: {0}", Coach.Name);

            return base.ToString() + info;
        }

        public void AddAsBestTime(PoolType poolType, EventDistance eventDistance, Stroke stroke, TimeSpan time)
        {
            int id;
            TimeSpan bestTime = GetBestTime(poolType, stroke, eventDistance, out id);
            if (bestTime == new TimeSpan(1, 0, 0))
            {
                BestTimes[NoOfBestTimes] = new BestTime(poolType, eventDistance, stroke, time);
                NoOfBestTimes++;
            }
            else if (time < bestTime)
            {
                BestTimes[id].RecordTime = time;
            }
        }

        public TimeSpan GetBestTime(PoolType poolType, Stroke stroke, EventDistance eventDistance, out int id)
        {
            id = 999;
            BestTime best;
            for (int i = 0; i < NoOfBestTimes; i++)
            //foreach (BestTime best in bestTimes)
            {
                best = BestTimes[i];
                if (best.PoolType == poolType && best.EventDistance == eventDistance && best.Stroke == stroke)
                {
                    id = i;
                    return best.RecordTime;
                }
            }
            return new TimeSpan(1, 0, 0);
        }

        public TimeSpan GetBestTime(PoolType poolType, Stroke stroke, EventDistance eventDistance)
        {
            BestTime best;
            for (int i = 0; i<NoOfBestTimes; i++)
            {
                best = BestTimes[i];
                if (best.PoolType == poolType && best.EventDistance == eventDistance && best.Stroke == stroke)
                {
                    return best.RecordTime;
                }
            }
            return new TimeSpan(1,0,0);
        }
    }
}
