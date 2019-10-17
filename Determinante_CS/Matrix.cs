using System.Text;


namespace MyMath
{
    public class Matrix
    {
        protected float[,] values;

        public float this[int a, int b]
        {
            get => values[a, b];
            set => values[a, b] = value;
        }

        public static Matrix GetUnit(int size)
        {
            Matrix output=new Matrix(size,size);
            for (int i = 0; i < size; i++)
            {
                output[i, i] = 1;
            }

            return output;
        }

        public bool square => rows == columns;
        public int columns => values.GetLength(0);
        public int rows => values.GetLength(1);
        public Matrix transposed => Transpose(this);
        public Matrix inverted => Inverse(this);
        public Matrix cofactor => Cofactor(this);
        public float det => Det(this);

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
        public Matrix(float[,] a)
        {
            values = a;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.values.GetLength(0) != b.values.GetLength(0) || a.values.GetLength(1) != b.values.GetLength(1))
            {
                throw new System.ArgumentException("Matrices incompatible");
            }
            Matrix output = new Matrix(a.values.GetLength(0), a.values.GetLength(1));
            for (int i = 0; i < a.values.GetLength(0); i++)
            {
                for (int j = 0; j < a.values.GetLength(1); j++)
                {
                    output[i, j] = a[i, j] + b[i, j];
                }
            }

            return output;
        }
        public static Matrix operator *(Matrix a, float b)
        {
            Matrix output = new Matrix(a.values.GetLength(0), a.values.GetLength(1));
            for (int i = 0; i < a.values.GetLength(0); i++)
            {
                for (int j = 0; j < a.values.GetLength(1); j++)
                {
                    output[i, j] = a[i, j] * b;
                }
            }

            return output;
        }
        public static Vector3 operator *(Matrix a, Vector3 b)
        {
            if (a.columns != 3) throw new System.ArgumentException("Matrix must be of length 3");
            if (a.rows != 3) throw new System.ArgumentException("Matrix must be of height 3");
            Vector3 output = new Vector3();

            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    output[i] += a[k, i] * b[k];
                }

            }

            return output;
        }
        public static Vector3 operator *(Vector3 b, Matrix a)
        {
            return a * b;
        }
        public static Vector4 operator *(Matrix a, Vector4 b)
        {
            if (a.columns != 4) throw new System.ArgumentException("Matrix must be of length 4");
            if (a.rows != 4) throw new System.ArgumentException("Matrix must be of height 4");
            Vector4 output = new Vector4();

            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    output[i] += a[k, i] * b[k];
                }

            }

            return output;
        }
        public static Vector4 operator *(Vector4 b, Matrix a)
        {
            return a * b;
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

        public static Matrix Transpose(Matrix a)
        {
            Matrix output = new Matrix(a.values.GetLength(1), a.values.GetLength(0));
            for (int i = 0; i < a.values.GetLength(0); i++)
            {
                for (int j = 0; j < a.values.GetLength(1); j++)
                {
                    output[i, j] = a[j, i];
                }
            }

            return output;
        }
        public static float Cofactor(Matrix a, int p, int q)
        {
            if (a.values.GetLength(0) != a.values.GetLength(1)) throw new System.ArgumentException("Matrix must be square");

            Matrix submatrix = new Matrix(a.values.GetLength(0) - 1, a.values.GetLength(1) - 1);
            int i = 0, j = 0;

            for (int r = 0; r < a.values.GetLength(0); r++)
            {
                for (int c = 0; c < a.values.GetLength(0); c++)
                {
                    if (r != p && c != q)
                    {
                        submatrix[i, j++] = a[r, c];
                        if (j == a.values.GetLength(0) - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }

            return (float)System.Math.Pow(-1, p + q) * Det(submatrix);
        }
        public static Matrix Cofactor(Matrix a)
        {
            if (a.values.GetLength(0) != a.values.GetLength(1)) throw new System.ArgumentException("Matrix must be square");
            Matrix output = new Matrix(a.values.GetLength(0), a.values.GetLength(1));
            for (int i = 0; i < a.values.GetLength(0); i++)
            {
                for (int j = 0; j < a.values.GetLength(1); j++)
                {
                    output[i, j] = Cofactor(a, i, j);
                }
            }

            return output;
        }
        public static float Det(Matrix a)
        {
            if (a.values.GetLength(0) != a.values.GetLength(1)) throw new System.ArgumentException("Matrix must be square");
            if (a.values.GetLength(0) == 2) return ((a[0, 0] * a[1, 1]) - (a[1, 0] * a[0, 1]));
            float det = 0;
            int sign = 1;
            Matrix submatrix = new Matrix(a.values.GetLength(0) - 1, a.values.GetLength(0) - 1);


            for (int x = 0; x < a.values.GetLength(0); x++)
            {
                int subi = 0;
                for (int i = 1; i < a.values.GetLength(0); i++)
                {
                    int subj = 0;
                    for (int j = 0; j < a.values.GetLength(0); j++)

                    {
                        if (j == x)
                            continue;
                        submatrix[subi, subj] = a[i, j];
                        subj++;
                    }
                    subi++;
                }
                det = det + (sign * a[0, x] * Det(submatrix));
                sign *= -1;
            }

            return det;
        }
        public static Matrix Inverse(Matrix a)
        {
            return Transpose(Cofactor(a)) * (1 / Det(a));
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
