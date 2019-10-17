using System;

namespace MyMath
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program instance = new Program();
            //int[,] test = new int[2, 2]
            //{
            //    { 2 , 1 },
            //    { 2 , 1 }
            //};
            //Vector3 input = new Vector3(5, 2, 10);
            //Vector3 axis = new Vector3(0, 0, 1);
            //float angle = 90;
            //Quaternion rotator = new Quaternion(angle, axis);


            //Console.WriteLine(Quaternion.RotateAxis(rotator, input));
            //input.RotateAngleAxis(axis, angle);
            //Console.WriteLine(input);
            //float[,] mat = { { 1, 3, -1 }, { 4, 0, 9 }, { 1, 2, 3 } };
            //Matrix a = new Matrix(mat);
            //Console.Out.WriteLine("a = {0}", a);
            //Console.Out.WriteLine("a.columns = {0}", a.columns);
            //Console.Out.WriteLine("a.rows = {0}", a.rows);
            //Console.WriteLine(a.ToString());
            //Console.WriteLine(Matrix.Det(a).ToString());
            //Console.WriteLine(Matrix.Cofactor(a, 1, 2));

            //Console.WriteLine(Matrix.Cofactor(a).ToString());
            //Console.WriteLine(Matrix.Inverse(a));

            //float[,] mat = { { 0, 1, 2, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } };
            //Transformation transMat = new Transformation(mat);
            //Console.Out.WriteLine("transMat = {0}", transMat);
            //Console.Out.WriteLine("Translation = {0}", transMat.Translation);
            //Console.Out.WriteLine("Scale = {0}", transMat.Scale);
            //Console.Out.WriteLine("Rotation = {0}", transMat.Rotation);

            //Vector3 vec = new Vector3(2, 5, 7);
            //Console.Out.WriteLine("vec = {0}", vec);
            //vec.RotateAngleAxis(new Vector3(2, 3, 5), 60);
            //Console.Out.WriteLine("vec = {0}", vec);
            //vec.RotateAngleAxis(new Vector3(0, 1, 0), 90);
            //Console.Out.WriteLine("vec = {0}", vec);

            //Console.Out.WriteLine("vec = {0}", vec);
            //Console.Out.WriteLine("a = {0}", a);
            //Console.Out.WriteLine("mat*vec = {0}", (a * vec));
            //Console.Out.WriteLine("X = {0}", Transformation.EulerX(60) * vec);
            //Console.Out.WriteLine("Y = {0}", Transformation.EulerY(60) * vec);
            //Console.Out.WriteLine("Z = {0}", Transformation.EulerZ(60) * vec);
            //Console.Out.WriteLine("XY = {0}", Transformation.EulerY(90) * (Transformation.EulerX(50) * vec));
            //Console.Out.WriteLine("YX = {0}", Transformation.EulerX(50) * (Transformation.EulerY(90) * vec));
            //Console.Out.WriteLine("XY = {0}", Transformation.EulerXY(90, 90) * vec);
            //Console.Out.WriteLine("X_Y_Z = {0}", Transformation.EulerXYZ(12,14,16)*vec);
            //Console.Out.WriteLine("XY_Z = {0}", Transformation.EulerXY_Z(12,14,16)*vec);
            //Console.Out.WriteLine("X_YZ = {0}", Transformation.EulerX_YZ(12,14,16)*vec);
            //Console.Out.WriteLine("XZY = {0}", Transformation.EulerXZY(12,16,14)*vec);

            Vector3 vec = new Vector3(2, 5, 7);
            Matrix Rotation = Transformation.AngleAxis(new Vector3(2, 3, 5), 60);
            Console.Out.WriteLine("Rotation = {0}", Rotation);
            Transformation m = new Transformation(new Vector3(0), new Vector3(1), Rotation);
            Console.Out.WriteLine("m.Translation = {0}", m.Translation);
            Console.Out.WriteLine("m.Scale = {0}", m.Scale);
            Console.Out.WriteLine("m.Rotation = {0}", m.Rotation);
            Console.Out.WriteLine("m = {0}", m);
            Console.Out.WriteLine("vec * m = {0}", vec * m);


        }


        //private int Det(int[,] input)
        //{
        //    if (input.GetLength(0) == 1 || input.GetLength(1) == 1)
        //    {
        //        return input[0, 0];
        //    }
        //    int result = 0;
        //    int x = input.GetLength(0);
        //    int y = input.GetLength(1);
        //    bool positive = false;

        //    for (int i = 0; i < input.GetLength(0); i++)
        //    {
        //        int offset = 0;
        //        int[,] array = new int[input.GetLength(0) - 1, input.GetLength(1) - 1];
        //        for (int j = 0, newRow = 0; j < array.GetLength(0); j++)
        //        {
        //            if (j == i)
        //            {
        //                continue;
        //            }

        //            for (int k = 0; k < input.GetLength(1); k++)
        //            {

        //                array[newRow, k] = input[j, k];
        //            }

        //            newRow++;
        //        }

        //        if (positive)
        //        {
        //            result += input[i, 0] * Det(array);
        //        }
        //        else
        //        {
        //            result -= input[i, 0] * Det(array);
        //        }
        //        positive = !positive;
        //    }

        //    return result;
        //}
    }
}
