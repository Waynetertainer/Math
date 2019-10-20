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
        }


        [TestMethod]
        public static void Vector3Test()
        {
            Vector3 a = new Vector3(1, 2, 3);
            Vector3 b = new Vector3(3, 2, 1);
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
    }
}
