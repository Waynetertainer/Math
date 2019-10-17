using System;

namespace MyMath
{
    public class Vector2
    {
        public float x, y;
        public float magnitude => Magnitude();
        public Vector2 normalized => Normalize(this);
        public float this[int a]
        {
            get
            {
                switch (a)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        throw new System.ArgumentOutOfRangeException();
                };
            }
            set
            {
                switch (a)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new System.ArgumentOutOfRangeException();
                };
            }
        }

        public Vector2()
        {
            x = y = 0;
        }
        public Vector2(float input)
        {
            x = y = input;
        }
        public Vector2(float xIn, float yIn)
        {
            x = xIn;
            y = yIn;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static Vector2 operator *(float b, Vector2 a)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.x / b, a.y / b);
        }

        public override string ToString()
        {
            return x + " " + y;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public static Vector2 Normalize(Vector2 a)
        {
            return a / a.magnitude;
        }
        public void Normalize()
        {
            Vector2 temp = Normalize(this);
            x = temp.x;
            y = temp.y;
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            return (float)Math.Sqrt((b.x - a.x) * (b.x - a.x) + (b.y - a.y) * (b.y - a.y));
        }
    }
}
