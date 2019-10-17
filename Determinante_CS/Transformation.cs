using System;

namespace MyMath
{
    public class Transformation : Matrix
    {
        private Vector3 mTranslation;
        public Vector3 Translation
        {
            get => mTranslation;
            set
            {
                mTranslation = value;
                RecalculateValues();

            }
        }

        private Vector3 mScale;
        public Vector3 Scale
        {
            get => mScale;
            set { mScale = value; RecalculateValues(); }
        }

        private Matrix mRotation;
        public Matrix Rotation
        {
            get => mRotation;
            set
            {
                if (value.rows != 3 || value.columns != 3) throw new System.ArgumentException("Matrix must be 3x3");
                mRotation = value;
                RecalculateValues();
            }
        }

        public Transformation(float[,] a) : base(a)
        {
            if (a.GetLength(0) != 4 || a.GetLength(1) != 4) throw new System.ArgumentException("Input array must be 4x4");
            values = a;
        }
        public Transformation() : base(4, 4)
        {

        }

        public Transformation(Vector3 translation, Vector3 scale, Matrix rotation = null) : base(4, 4)
        {
            mTranslation = translation;
            mScale = scale;
            mRotation = (rotation != null) ? rotation : new Matrix(3, 3);
            RecalculateValues();
        }

        public static Vector3 operator *(Vector3 v, Transformation m)
        {
            return new Vector3(m * new Vector4(v));
        }

        public static Matrix EulerX(float angle)
        {
            Matrix output = new Matrix(3, 3);

            output[0, 0] = 1;
            output[1, 0] = 0;
            output[2, 0] = 0;
            output[0, 1] = 0;
            output[1, 1] = (float)Math.Cos(angle.DegToRad());
            output[2, 1] = -(float)Math.Sin(angle.DegToRad());
            output[0, 2] = 0;
            output[1, 2] = (float)Math.Sin(angle.DegToRad());
            output[2, 2] = (float)Math.Cos(angle.DegToRad());

            return output;
        }
        public static Matrix EulerY(float angle)
        {
            Matrix output = new Matrix(3, 3);

            output[0, 0] = (float)Math.Cos(angle.DegToRad());
            output[1, 0] = 0;
            output[2, 0] = (float)Math.Sin(angle.DegToRad());
            output[0, 1] = 0;
            output[1, 1] = 1;
            output[2, 1] = 0;
            output[0, 2] = -(float)Math.Sin(angle.DegToRad());
            output[1, 2] = 0;
            output[2, 2] = (float)Math.Cos(angle.DegToRad());

            return output;
        }
        public static Matrix EulerZ(float angle)
        {
            Matrix output = new Matrix(3, 3);

            output[0, 0] = (float)Math.Cos(angle.DegToRad());
            output[1, 0] = -(float)Math.Sin(angle.DegToRad());
            output[2, 0] = 0;
            output[0, 1] = (float)Math.Sin(angle.DegToRad());
            output[1, 1] = (float)Math.Cos(angle.DegToRad());
            output[2, 1] = 0;
            output[0, 2] = 0;
            output[1, 2] = 0;
            output[2, 2] = 1;

            return output;
        }
        public static Matrix EulerXY(float x, float y)
        {
            return EulerX(x) * EulerY(y);
        }
        public static Matrix EulerXZ(float x, float z)
        {
            return EulerX(x) * EulerZ(z);
        }
        public static Matrix EulerYX(float y, float x)
        {
            return EulerY(y) * EulerX(x);
        }
        public static Matrix EulerYZ(float y, float z)
        {
            return EulerY(y) * EulerZ(z);
        }
        public static Matrix EulerZX(float z, float x)
        {
            return EulerZ(z) * EulerX(x);
        }
        public static Matrix EulerZY(float z, float y)
        {
            return EulerZ(z) * EulerY(y);
        }
        public static Matrix EulerXYZ(float x, float y, float z)
        {
            return EulerX(x) * EulerY(y) * EulerZ(z);
        }
        public static Matrix EulerXZY(float x, float z, float y)
        {
            return EulerX(x) * EulerZ(z) * EulerY(y);
        }
        public static Matrix EulerYXZ(float y, float x, float z)
        {
            return EulerY(y) * EulerX(x) * EulerZ(z);
        }
        public static Matrix EulerYZX(float y, float z, float x)
        {
            return EulerY(y) * EulerZ(z) * EulerX(x);
        }
        public static Matrix EulerZXY(float z, float x, float y)
        {
            return EulerZ(z) * EulerX(x) * EulerY(y);
        }
        public static Matrix EulerZYX(float z, float y, float x)
        {
            return EulerZ(z) * EulerY(y) * EulerX(x);
        }

        public static Matrix AngleAxis(Vector3 axis, float angle)
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
            return rotationMatrix;
        }

        public void SetTranslation(Vector3 a)
        {
            Translation = a;
        }
        public void SetScale(Vector3 a)
        {
            Scale = a;
        }
        public void SetRotation(Matrix a)
        {
            if (a.rows != 3 || a.columns != 3) throw new System.ArgumentException("Matrix must be 3x3");
            Rotation = a;
        }

        private void RecalculateValues()
        {
            //TODO unit * scale * rot* Transformation
            Matrix scaleTranslation = new Matrix(4, 4);
            scaleTranslation[0, 0] = Scale.x;
            scaleTranslation[1, 1] = Scale.y;
            scaleTranslation[2, 2] = Scale.z;
            scaleTranslation[3, 0] = Translation.x;
            scaleTranslation[3, 1] = Translation.y;
            scaleTranslation[3, 2] = Translation.z;
            scaleTranslation[3, 3] = 1;
            Matrix rotation = new Matrix(4, 4);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    rotation[i, j] = Rotation[i, j];
                }
            }
            rotation[3, 3] = 1;
            Console.Out.WriteLine("rotation = {0}", rotation);
            Matrix transformation = scaleTranslation * rotation;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    values[i, j] = transformation[i, j];
                }
            }
        }

    }
}
