using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath;
using System;

namespace Test
{
    [TestClass]
    public class Program
    {

        public static void Main()
        {
            Console.Out.WriteLine("Testing Vector3");
            Vector3Test();
            Console.Out.WriteLine("Vector3 tests passed");
            Console.Out.WriteLine("Testing Matrix");
            MatrixTest();
            Console.Out.WriteLine("Matrix tests passed");
        }


        [TestMethod]
        public static void Vector3Test()
        {
            Vector3 a = new Vector3(1, 2, 3);
            Vector3 b = new Vector3(3, 2, 1);
            Assert.AreEqual(a + b, new Vector3(4, 4, 4));
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual((a + b)[i], new Vector3(4, 4, 4)[i]);
                Assert.AreEqual((a - b)[i], new Vector3(-2, 0, 2)[i]);
                Assert.AreEqual((a * 2)[i], new Vector3(2, 4, 6)[i]);
                Assert.AreEqual(Vector3.Cross(a, b)[i], new Vector3(-4, 8, -4)[i]);
            }
            Assert.AreEqual(Vector3.Dot(a, b), 10);
            Assert.AreEqual(a.magnitude, 3.74, 0.01);
            Assert.AreEqual(a.normalized.magnitude, 1, 0.01);
        }

        [TestMethod]
        public static void MatrixTest()
        {
            float[,] arrayA = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            float[,] arrayB = { { 8, 7, 6 }, { 5, 4, 3 }, { 2, 1, 0 } };
            float[,] arrayAdditionResult = { { 8, 8, 8 }, { 8, 8, 8 }, { 8, 8, 8 } };
            float[,] arraySkalarResult = { { 0, 2, 4 }, { 6, 8, 10 }, { 12, 14, 16 } };
            float[,] arrayTransposeResult = { { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 } };
            float[,] arrayMultiplicationResult = { { 57, 78, 99 }, { 30, 42, 54 }, { 3, 6, 9 } };
            Matrix a = new Matrix(arrayA);
            Matrix b = new Matrix(arrayB);
            Matrix AdditionResult = new Matrix(arrayAdditionResult);
            Matrix SkalarResult = new Matrix(arraySkalarResult);
            Matrix TransposeResult = new Matrix(arrayTransposeResult);
            Matrix MultiplicationResult = new Matrix(arrayMultiplicationResult);

            Matrix Addition = a + b;
            Matrix Skalar = a * 2;
            Matrix Transpose = a.transposed;
            Matrix Multiplication = a * b;
            Console.Out.WriteLine("Multiplication = {0}", Multiplication);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(Addition[i, j], AdditionResult[i, j]);
                    Assert.AreEqual(Skalar[i, j], SkalarResult[i, j]);
                    Assert.AreEqual(Transpose[i, j], TransposeResult[i, j]);
                    Assert.AreEqual(Multiplication[i, j], MultiplicationResult[i, j]);
                }
            }
        }
    }
}
