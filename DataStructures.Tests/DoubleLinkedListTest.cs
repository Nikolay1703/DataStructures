using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;
using NUnit.Framework;

namespace DataStructures.Tests
{
    public class DoubleLinkedListTest
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2 }, 3, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { }, 100, new int[] { 100 })]
        public void AddLastTest(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddLast(value);
            Assert.AreEqual(expected, actual);
        }
    

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { }, new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 3 }, new int[] { 1, 2, 3 })]
        public void AddLastArrayTest(int[] array, int[] newArray, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddLastArray(newArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { 6, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2 }, 3, new int[] { 3, 1, 2 })]
        [TestCase(new int[] { 1 }, 2, new int[] { 2, 1 })]
        [TestCase(new int[] { }, 100, new int[] { 100 })]
        public void AddFirstTest(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { }, new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 5 }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 2, 3 }, new int[] { 1 }, new int[] { 1, 2, 3 })]
        public void AddFirstArrayTest(int[] array, int[] newArray, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddFirstArray(newArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 3, 4, 5 }, 2, 1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10 }, 9, 8, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { 1, 2, 4, 5, 6, 7, 8, 9, 10 }, 3, 2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { 1, 2 }, 3, 0, new int[] { 3, 1, 2 })]
        public void AddByIndexTest(int[] array, int value, int index, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, 2, 1 )]
        [TestCase(new int[] { 1, 2, 3 }, 4, 3 )]
        [TestCase(new int[] { 1, 2, 3 }, 4, -1 )]
        public void AddByIndexTestNegative(int[] array, int value, int index)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            try
            {
                doubleLinkedList.AddByIndex(value, index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 4, 5, 6, 7 }, new int[] { 1, 2, 3 }, 0, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 2, 3, 4, 5 }, new int[] { 1 }, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8 }, 4, new int[] { 1, 2, 3, 4, 6, 7, 8, 5 })]
        [TestCase(new int[] { 5 }, new int[] { 1, 2, 3, 4 }, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 4, 5 }, new int[] { 2, 3 }, 1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 8, 9, 10 }, new int[] { 4, 5, 6, 7 }, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { 1, 2, 3, 5, 6, 7 }, new int[] { 4 }, 3, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 7 }, new int[] { 4, 5, 6 }, 3, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 4 }, new int[] { 3 }, 2, new int[] { 1, 2, 3, 4 })]
        public void AddByIndexArrayTest(int[] array, int[] newArray, int index, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddByIndexArray(newArray, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 1, 2, 3 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 }, 3)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, -1)]
        public void AddByIndexArrayTestNegative(int[] array, int[] newArray, int index)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            try
            {
                doubleLinkedList.AddByIndexArray(newArray, index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

    }
}
