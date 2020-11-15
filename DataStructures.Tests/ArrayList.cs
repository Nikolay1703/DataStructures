using NUnit.Framework;
using DataStructures;

namespace DataStructures.Tests
{
    public class ArrayList
    {
        [TestCase(6, 1)]
        [TestCase(500, 1)]
        [TestCase(0, 1)]
        public void Add(int value, int expected)
        {
            DataStructures.ArrayList arrayList = new DataStructures.ArrayList();
            arrayList.Add(value);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, 8)]
        [TestCase(100, 103)]
        [TestCase(1, 2)]
        public void RizeSize(int size, int expected)
        {
            DataStructures.ArrayList arrayList = new DataStructures.ArrayList();
            arrayList.RizeSize(size);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }
    }
}