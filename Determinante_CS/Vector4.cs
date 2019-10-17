using System;

namespace MyMath
{
    public class Vector4
    {
        public float w, x, y, z;

        public float magnitude => Magnitude();
        public Vector4 normalized => Normalize(this);
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
                    case 2:
                        return z;
                    case 3:
                        return w;
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
                    case 2:
                        z = value;
                        break;
                    case 3:
                        w = value;
                        break;
                    default:
                        throw new System.ArgumentOutOfRangeException();
                };
            }
        }

        public Vector4()
        {
            x = y = z = w = 0;
        }
        public Vector4(float input)
        {
            x = y = z = w = input;
        }
        public Vector4(float wIn, float xIn, float yIn, float zIn)
        {
            x = xIn;
            y = yIn;
            z = zIn;
            w = wIn;
        }
        public Vector4(Vector3 vec, float wIn = 1)
        {
            w = wIn;
            x = vec.x;
            y = vec.y;
            z = vec.z;
        }

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.w + b.w, a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.w - b.w, a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector4 operator *(Vector4 a, float b)
        {
            return new Vector4(a.w * b, a.x * b, a.y * b, a.z * b);
        }
        public static Vector4 operator *(float b, Vector4 a)
        {
            return new Vector4(a.w * b, a.x * b, a.y * b, a.z * b);
        }
        public static Vector4 operator /(Vector4 a, float b)
        {
            return new Vector4(a.w / b, a.x / b, a.y / b, a.z / b);
        }

        public override string ToString()
        {
            return x + " " + y + " " + z + " " + w;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public static Vector4 Normalize(Vector4 a)
        {
            return a / a.magnitude;
        }
        public void Normalize()
        {
            Vector4 temp = Normalize(this);
            x = temp.x;
            y = temp.y;
            z = temp.z;
            w = temp.w;
        }

        //public void RotateAngleAxis(Vector3 axis, float angle)
        //{
        //    float cos = (float)Math.Cos(angle.DegToRad());
        //    float sin = (float)Math.Sin(angle.DegToRad());
        //    float omc = 1 - cos;
        //    Matrix rotationMatrix = new Matrix(3, 3)
        //    {
        //        [0, 0] = omc * axis.x * axis.x + cos,
        //        [1, 0] = omc * axis.x * axis.y + sin * axis.z,
        //        [2, 0] = omc * axis.x * axis.z - sin * axis.y,
        //        [0, 1] = omc * axis.y * axis.x - sin * axis.z,
        //        [1, 1] = omc * axis.y * axis.y + cos,
        //        [1, 1] = omc * axis.y * axis.z + sin * axis.x,
        //        [0, 2] = omc * axis.z * axis.x + sin * axis.y,
        //        [1, 2] = omc * axis.z * axis.y - sin * axis.x,
        //        [2, 2] = omc * axis.z * axis.z + cos
        //    };
        //    Vector3 temp = rotationMatrix * this;
        //    x = temp.x;
        //    y = temp.y;
        //    z = temp.z;

        //}

        public static float Distance(Vector4 a, Vector4 b)
        {
            return (float)Math.Sqrt((b.w - a.w).Sq() + (b.x - a.x).Sq() + (b.y - a.y).Sq() + (b.z - a.z).Sq());
        }
    }
}
