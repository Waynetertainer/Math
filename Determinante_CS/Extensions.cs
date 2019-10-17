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

        public static float Clamp(this float val, float max)
        {
            return val > max ? max : val;
        }

        public static int Clamp(this int val, int max)
        {
            return val > max ? max : val;
        }
    }
}
