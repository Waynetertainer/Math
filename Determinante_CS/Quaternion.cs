using System;

namespace MyMath
{
    class Quaternion
    {
        public float w;
        public float x;
        public float y;
        public float z;

        public float magnitude => this.Magnitude();

        public Quaternion()
        {
            w = x = y = z = 0;
        }
        public Quaternion(float wIn, float xIn, float yIn, float zIn)
        {
            w = wIn;
            x = xIn;
            y = yIn;
            z = zIn;
        }
        public Quaternion(Vector3 v)
        {
            w = 0;
            x = v.x;
            y = v.y;
            z = v.z;
        }
        public Quaternion(float angle, Vector3 axis)
        {
            w = (float)Math.Cos(angle.DegToRad() / 2);
            x = axis.normalized.x * (float)Math.Sin(angle.DegToRad() / 2);
            y = axis.normalized.y * (float)Math.Sin(angle.DegToRad() / 2);
            z = axis.normalized.z * (float)Math.Sin(angle.DegToRad() / 2);
        }

        public override string ToString()
        {
            return w + " " + x + " " + y + " " + z;
        }

        public static Quaternion operator +(Quaternion a, Quaternion b)
        {
            return new Quaternion(a.w + b.w, a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Quaternion operator -(Quaternion a, Quaternion b)
        {
            return new Quaternion(a.w - b.w, a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Quaternion operator *(Quaternion a, Quaternion b)
        {
            return new Quaternion(
                a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z,
                a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y,
                a.w * b.y - a.x * b.z + a.y * b.w + a.z * b.x,
                a.w * b.z + a.x * b.y - a.y * b.x + a.z * b.w);
        }

        public static Quaternion operator /(Quaternion a, Quaternion b)
        {
            float divisor = b.w * b.w + b.x * b.x + b.y * b.y + b.z * b.z;
            return new Quaternion(
                (b.w * a.w + b.x * a.x + b.y * a.y + b.z * a.z) / divisor,
                (b.w * a.x - b.x * a.w - b.y * a.z + b.z * a.y) / divisor,
                (b.w * a.y + b.x * a.z - b.y * a.w - b.z * a.x) / divisor,
                (b.w * a.z - b.x * a.y + b.y * a.x - b.z * a.w) / divisor);
        }

        public static Quaternion operator /(Quaternion a, float b)
        {
            return new Quaternion(a.w / b, a.x / b, a.y / b, a.z / b);
        }

        private float Magnitude()
        {
            return (float)Math.Sqrt(w * w + x * x + y * y + z * z);
        }

        public static Quaternion Normalize(Quaternion a)
        {
            return a / a.magnitude;
        }
        public void Normalize()
        {
            Quaternion temp = Normalize(this);
            w = temp.w;
            x = temp.x;
            y = temp.y;
            z = temp.z;
        }

        public static Quaternion Conjugated(Quaternion a)
        {
            return new Quaternion(a.w, -a.x, -a.y, -a.z);
        }
        public void Conjugate()
        {
            Quaternion temp = Conjugated(this);
            w = temp.w;
            x = temp.x;
            y = temp.y;
            z = temp.z;
        }

        public static Quaternion Inverse(Quaternion a)
        {
            return Conjugated(a / (a.magnitude * a.magnitude));
        }

        public void Inverse()
        {
            Quaternion temp = Inverse(this);
            w = temp.w;
            x = temp.x;
            y = temp.y;
            z = temp.z;
        }

        public static Quaternion RotateAxis(Quaternion rotator, Vector3 input)
        {
            Quaternion newInput = new Quaternion(input);
            return rotator * newInput * Conjugated(rotator);
        }

        public void RotateAxis(Quaternion rotator)
        {
            Quaternion temp = rotator * this * Conjugated(rotator);
            w = temp.w;
            x = temp.x;
            y = temp.y;
            z = temp.z;
        }
    }
}