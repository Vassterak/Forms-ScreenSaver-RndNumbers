using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RndScreenSaver
{
    public class MyRandom
    {
        uint x, a, c; 
        public MyRandom()
        {
            //C like pseudo generation
            x = Convert.ToUInt32(DateTime.Now.TimeOfDay.TotalMilliseconds);
            a = 1103515245;
            c = 12345;

        }

        public uint LCG_CLike()
        {
            x = x * a + c;
            return x;
        }
    }
}
