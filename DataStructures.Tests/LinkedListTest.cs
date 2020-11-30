using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DataStructures;

namespace DataStructures.Tests
{
    class LinkedListTest
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
        [TestCase(new int[] { 1 }, 0, 1)]
        public void GetByIndexTest(int[] array, int index, int expected) 
        {
            LinkedList linkedList = new LinkedList(array);
            int actual = linkedList[index];
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 10, new int[] { 10, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 100, new int[] { 1, 2, 3, 4, 100 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 333, new int[] { 1, 2, 333, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 999, new int[] { 1, 999, 3, 4, 5 })]
        [TestCase(new int[] { 1 }, 0, -1, new int[] { -1 })]
        public void SetByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual[index] = value;
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2 }, 3, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { }, 100, new int[] { 100 })]
        public void AddTest(int[] array, int value, int[] expArray) 
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }
    }
}
