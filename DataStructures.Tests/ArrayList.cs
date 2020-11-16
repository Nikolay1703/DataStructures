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

        /*[TestCase(6, 6)]
        public void Add(int value, int expected)
        {
            DataStructures.ArrayList arrayList = new DataStructures.ArrayList();
            arrayList.Add(value);
            int actual = array;
            Assert.AreEqual(expected, actual);
        }*/


        [TestCase(5, 1)]
        [TestCase(100, 1)]
        [TestCase(1, 1)]
        public void AddTheFirstElement(int value, int expected)
        {
            DataStructures.ArrayList arrayList = new DataStructures.ArrayList();
            arrayList.AddTheFirstElement(value);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        
    }
}