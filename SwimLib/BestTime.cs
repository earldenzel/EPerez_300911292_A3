using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimLib
{
    public struct BestTime
    {
        public PoolType PoolType;
        public EventDistance EventDistance;
        public Stroke Stroke;
        public TimeSpan RecordTime;

        public BestTime(PoolType poolType, EventDistance eventDistance, Stroke stroke, TimeSpan recordTime)
        {
            PoolType = poolType;
            EventDistance = eventDistance;
            Stroke = stroke;
            RecordTime = recordTime;
        }
    }
}
