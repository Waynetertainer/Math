using System;

namespace MyMath
{
    public class Vector3
    {
        public float x, y, z;
        public float magnitude => Magnitude();
        public Vector3 normalized => Normalize(this);
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
                    default:
                        throw new System.ArgumentOutOfRangeException();
                };
            }
        }

        public Vector3()
        {
            x = y = z = 0;
        }
        public Vector3(float input)
        {
            x = y = z = input;
        }
        public Vector3(float xIn, float yIn, float zIn)
        {
            x = xIn;
            y = yIn;
            z = zIn;
        }

        public Vector3(Vector4 input)
        {
            x = input.x;
            y = input.y;
            z = input.z;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector3 operator *(Vector3 a, float b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }
        public static Vector3 operator *(float b, Vector3 a)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }
        public static Vector3 operator /(Vector3 a, float b)
        {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }

        public override string ToString()
        {
            return x + " " + y + " " + z;
        }

        public static float Dot(Vector3 a, Vector3 b)
        {
            return (a.x * b.x + a.y * b.y + a.z * b.z);
        }
        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(a.y * b.z - b.y * a.z, a.z * b.x - b.z * a.x, a.x * b.y - b.x * a.y);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public static Vector3 Normalize(Vector3 a)
        {
            return a / a.magnitude;
        }
        public void Normalize()
        {
            Vector3 temp = Normalize(this);
            x = temp.x;
            y = temp.y;
            z = temp.z;
        }

        public void RotateAngleAxis(Vector3 axis, float angle)
        {
            float cos = (float)Math.Cos(angle.DegToRad());
            float sin = (float)Math.Sin(angle.DegToRad());
            float omc = 1 - cos;
            axis.Normalize();
            Matrix rotationMatrix = new Matrix(3, 3)
            {
                [0, 0] = omc * axis.x * axis.x + cos,
                [0, 1] = omc * axis.x * axis.y + sin * axis.z,
                [0, 2] = omc * axis.x * axis.z - sin * axis.y,
                [1, 0] = omc * axis.y * axis.x - sin * axis.z,
                [1, 1] = omc * axis.y * axis.y + cos,
                [1, 2] = omc * axis.y * axis.z + sin * axis.x,
                [2, 0] = omc * axis.z * axis.x + sin * axis.y,
                [2, 1] = omc * axis.z * axis.y - sin * axis.x,
                [2, 2] = omc * axis.z * axis.z + cos
            };
            Vector3 temp = rotationMatrix * this;
            x = temp.x;
            y = temp.y;
            z = temp.z;

        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            return (float)Math.Sqrt((b.x - a.x) * (b.x - a.x) + (b.y - a.y) * (b.y - a.y) + (b.z - a.z) * (b.z - a.z));
        }
    }
}
