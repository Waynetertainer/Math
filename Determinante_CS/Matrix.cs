using System;
using System.Text;


namespace MyMath
{
    class Matrix
    {
        private float[,] values;

        public float this[int a, int b]
        {
            get => values[a, b];
            set => values[a, b] = value;
        }

        public Matrix(int height, int length)
        {
            values = new float[height, length];
        }
        public Matrix(Vector3 v)
        {
            values = new float[3, 1];
            values[0, 0] = v.x;
            values[1, 0] = v.y;
            values[2, 0] = v.z;
        }

        public static Vector3 operator *(Matrix a, Vector3 b)
        {
            if (a.values.GetLength(1) != 3) throw new System.ArgumentException("Matrix must be of length 3");
            if (a.values.GetLength(0) != 3) throw new System.ArgumentException("Matrix must be of height 3");
            Vector3 output = new Vector3();

            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    output[i] += a[i, k] * b[k];
                }

            }

            return output;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.values.GetLength(1) != b.values.GetLength(0)) throw new System.ArgumentException("Matrices incompatible");

            Matrix output = new Matrix(a.values.GetLength(0), b.values.GetLength(1));

            for (int i = 0; i < a.values.GetLength(0); i++)
            {
                for (int j = 0; j < b.values.GetLength(1); j++)
                {
                    for (int k = 0; k < a.values.GetLength(1); k++)
                    {
                        output[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return output;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(values.GetLength(0) * values.GetLength(1));
            for (int i = 0; i < values.GetLength(1); i++, output.AppendLine())
            {
                for (int j = 0; j < values.GetLength(0); j++)
                {
                    output.Append(values[j, i]);
                    output.Append(" ");
                }
            }
            return output.ToString();
        }
    }

}
