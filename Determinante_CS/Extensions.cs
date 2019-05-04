using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMath
{
    static class Extensions
    {

        public static float DegToRad(this float val)
        {
            return ((float)Math.PI / 180) * val;
        }

        public static float Sq(this float val)
        {
            return val * val;
        }
    }
}
