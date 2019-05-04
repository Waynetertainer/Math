using System;


namespace MyMath
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] test = new int[2, 2]
            {
                { 2 , 1 },
                { 2 , 1 }
            };
            //Program instance = new Program();
            Vector3 input = new Vector3(5, 2, 10);
            Vector3 axis = new Vector3(0, 0, 1);
            float angle = 90;
            Quaternion rotator = new Quaternion(angle, axis);


            //Console.WriteLine(Quaternion.RotateAxis(rotator, input));
            input.RotateAngleAxis(axis, angle);
            //Console.WriteLine(input);


        }


        private int Det(int[,] input)
        {
            if (input.GetLength(0) == 1 || input.GetLength(1) == 1)
            {
                return input[0, 0];
            }
            int result = 0;
            int x = input.GetLength(0);
            int y = input.GetLength(1);
            bool positive = false;

            for (int i = 0; i < input.GetLength(0); i++)
            {
                int offset = 0;
                int[,] array = new int[input.GetLength(0) - 1, input.GetLength(1) - 1];
                for (int j = 0, newRow = 0; j < array.GetLength(0); j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    for (int k = 0; k < input.GetLength(1); k++)
                    {

                        array[newRow, k] = input[j, k];
                    }

                    newRow++;
                }

                if (positive)
                {
                    result += input[i, 0] * Det(array);
                }
                else
                {
                    result -= input[i, 0] * Det(array);
                }
                positive = !positive;
            }

            return result;
        }
    }
}
