using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RndScreenSaver
{
    public class MyRandom
    {
        uint x, a, c;

        private TimeSpan UpTime
        {
            get
            {
                using (var uptime = new PerformanceCounter("System", "System Up Time"))
                {
                    //Call this an extra time before reading its value
                    uptime.NextValue();
                    return TimeSpan.FromSeconds(uptime.NextValue());
                }
            }
        }

        public MyRandom()
        {
            //C like pseudo generation
            x = Convert.ToUInt32(DateTime.Now.TimeOfDay.TotalMilliseconds); //get seed from current time in day
            a = 1103515245;
            c = 12345;
        }

        public uint LCG_CLike()
        {
            x = x * a + c;
            return x;
        }

        public uint LogisticMapAlgorithm()
        {
            x = c * x * (1 - x);
            return x;
        }

        public uint MyOwnRandom()
        {
            return (uint)(UpTime.TotalMilliseconds * (double)x - (UpTime.TotalMilliseconds / c));
        }
    }
}
