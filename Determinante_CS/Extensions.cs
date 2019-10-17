using System;

namespace MyMath
{
    public static class Extensions
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
