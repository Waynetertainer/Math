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
            Console.Out.WriteLine("Testing Transformation");
            TranformationTest();
            Console.Out.WriteLine("Transformation tests passed");
        }


        [TestMethod]
        public static void Vector3Test()
        {
            Vector3 a = new Vector3(1, 2, 3);
            Vector3 b = new Vector3(3, 2, 1);
            Assert.AreEqual(a + b, new Vector3(4, 4, 4));
            Assert.AreEqual(a + b, new Vector3(4, 4, 4));
            Assert.AreEqual(a - b, new Vector3(-2, 0, 2));
            Assert.AreEqual(a * 2, new Vector3(2, 4, 6));
            Assert.AreEqual(Vector3.Cross(a, b), new Vector3(-4, 8, -4));
            Assert.AreEqual(Vector3.Dot(a, b), 10);
            Assert.AreEqual(a.magnitude, 3.74, 0.01);
            Assert.AreEqual(a.normalized.magnitude, 1, 0.01);
        }

        [TestMethod]
        public static void MatrixTest()
        {
            float[,] arrayA = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            float[,] arrayB = { { 8, 7, 6 }, { 5, 4, 3 }, { 2, 1, 0 } };
            float[,] arrayC = { { 1, 3, -1 }, { 4, 0, 9 }, { 1, 2, 3 } };
            float[,] arrayAdditionResult = { { 8, 8, 8 }, { 8, 8, 8 }, { 8, 8, 8 } };
            float[,] arraySkalarResult = { { 0, 2, 4 }, { 6, 8, 10 }, { 12, 14, 16 } };
            float[,] arrayTransposeResult = { { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 } };
            float[,] arrayMultiplicationResult = { { 57, 78, 99 }, { 30, 42, 54 }, { 3, 6, 9 } };
            float[,] arrayInverseResult = { { 0.51f, 0.31f, -0.77f }, { 0.09f, -0.11f, 0.38f }, { -0.23f, -0.03f, 0.34f } };

            Matrix a = new Matrix(arrayA);
            Matrix b = new Matrix(arrayB);
            Matrix c = new Matrix(arrayC);
            Matrix AdditionResult = new Matrix(arrayAdditionResult);
            Matrix SkalarResult = new Matrix(arraySkalarResult);
            Matrix TransposeResult = new Matrix(arrayTransposeResult);
            Matrix MultiplicationResult = new Matrix(arrayMultiplicationResult);
            Matrix InverseResult = new Matrix(arrayInverseResult);

            Matrix Addition = a + b;
            Matrix Skalar = a * 2;
            Matrix Transpose = a.transposed;
            Matrix Multiplication = a * b;

            Assert.AreEqual(Addition, AdditionResult);
            Assert.AreEqual(Skalar, SkalarResult);
            Assert.AreEqual(Transpose, TransposeResult);
            Assert.AreEqual(Multiplication, MultiplicationResult);
            Assert.AreEqual(a * new Vector3(3, 2, 1), new Vector3(12, 18, 24));
            Assert.ThrowsException<ArithmeticException>(() => Matrix.Inverse(a));
            Assert.AreEqual(c.inverted, InverseResult);
        }

        [TestMethod]
        public static void TranformationTest()
        {
            Vector3 vec = new Vector3(3, 2, 1);
            //Matrix Rotation = Transformation.AngleAxis(new Vector3(2, 3, 5), 60);
            Matrix Rotation = Transformation.EulerZ(90);
            Transformation m = new Transformation(new Vector3(20, 0, 0), new Vector3(3), Rotation);
            Console.WriteLine();
            Console.Out.WriteLine("Original vector = {0}", vec);
            Console.Out.WriteLine("Transformation matrix");
            Console.Out.WriteLine(m);
            Console.Out.WriteLine("Transformed vector = = {0}", m * vec);
            Console.WriteLine();
        }
    }
}
