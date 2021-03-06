﻿using System;
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

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        public void RemoveLastTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 1, 2 })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        [TestCase(new int[] { 1, 2 }, 2, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 1, 2 })]
        public void RemoveFewLastTest(int[] array, int n, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFewLast(n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        public void RemoveFirstTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 4, 5 })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        [TestCase(new int[] { 1, 2 }, 2, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 2, 3 })]
        public void RemoveFewFirstTest(int[] array, int n, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFewFirst(n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 3, 4, 5 })]
        [TestCase(new int[] { 1 }, 0, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 2 }, 0, new int[] { 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 1, 2, 3, 5 })]
        public void RemoveByIndexTest(int[] array, int index, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1, 2, 3 }, -1)]
        public void RemoveByIndexTestNegative(int[] array, int index)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            try
            {
                doubleLinkedList.RemoveByIndex(index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1 }, 0, 1, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 4, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 2, new int[] { 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 4, new int[] { 5 })]
        [TestCase(new int[] { 1, 2 }, 1, 1, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 1, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 2, new int[] { 1, 2, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 1, new int[] { 1, 2, 3, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 2, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 3, new int[] { 1, 5 })]
        public void RemoveFewByIndexTest(int[] array, int index, int n, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFewByIndex(index, n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, 1, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 3, 1)]
        [TestCase(new int[] { 1, 2, 3 }, -1, 1)]
        public void RemoveFewByIndexTestNegative(int[] array, int index, int n)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            try
            {
                doubleLinkedList.RemoveFewByIndex(index, n);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 1, 2 }, 2)]
        [TestCase(new int[] { }, 0)]
        public void ReturnCountTest(int[] array, int count)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int expected = count;
            int actual = doubleLinkedList.ReturnCount();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 1 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 1)]
        [TestCase(new int[] { 1, 2 }, 1, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 4)]
        public void ValueByIndexTest(int[] array, int index, int value)
        {
            int expected = value;
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.ValueByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 5)]
        [TestCase(new int[] { 1, 2 }, 100)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6)]
        public void ValueByIndexTestNegative(int[] array, int index)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            try
            {
                doubleLinkedList.ValueByIndex(index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 1)]
        [TestCase(new int[] { 1 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 0)]
        [TestCase(new int[] { 1, 2 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 3)]
        [TestCase(new int[] { 1, 2, 3, 2, 5, 2 }, 2, 1)]
        public void IndexByValueTest(int[] array, int value, int index)
        {
            int expected = index;
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.IndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, -5)]
        [TestCase(new int[] { 1, 2 }, 100)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -20)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6)]
        [TestCase(new int[] { 1, 2, 3, 2, 5, 2 }, 0)]
        public void IndexByValueTestNegative(int[] array, int value)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            try
            {
                doubleLinkedList.IndexByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 100, new int[] { 1, 2, 100, 4, 5 })]
        [TestCase(new int[] { 1 }, 0, 100, new int[] { 100 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 100, new int[] { 100, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2 }, 1, 100, new int[] { 1, 100 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 100, new int[] { 1, 2, 3, 4, 100 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 100, new int[] { 1, 2, 3, 100, 5 })]
        public void ChangeValueByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.ChangeValueByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10, 100)]
        [TestCase(new int[] { 1 }, 1, 100)]
        [TestCase(new int[] { 1, 2, 3, 4 }, -5, 100)]
        [TestCase(new int[] { 1, 2 }, 100, 100)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -20, 100)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, 100)]
        [TestCase(new int[] { 1, 2, 3, 2, 5, 2 }, 30, 100)]
        public void ChangeValueByIndexTestNegative(int[] array, int index, int value)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            try
            {
                doubleLinkedList.ChangeValueByIndex(index, value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [TestCase(new int[] { 1, 2, 2, 3 }, new int[] { 3, 2, 2, 1 })]
        public void ReverseTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 4, 2, 3 }, 4)]
        [TestCase(new int[] { 5, 5, 5, 3, 1, 5 }, 5)]
        [TestCase(new int[] { 7, 3, 5, 1 }, 7)]
        [TestCase(new int[] { 1, 9, 3, 4, 9, 8, 7 }, 9)]
        [TestCase(new int[] { 1, 2, 3, 5, 5, 2 }, 5)]
        public void FindMaxValueTest(int[] array, int maxValue)
        {
            int expected = maxValue;
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.FindMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 4, 2, 1, 3 }, 1)]
        [TestCase(new int[] { 1, 1, 1, 3, 5, 1 }, 1)]
        [TestCase(new int[] { 7, 3, 5, 1 }, 1)]
        [TestCase(new int[] { 9, 1, 3, 4, 1, 8, 7 }, 1)]
        [TestCase(new int[] { 5, 2, 5, 1, 1, 2 }, 1)]
        public void FindMinValueTest(int[] array, int minValue)
        {
            int expected = minValue;
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.FindMinValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 4, 2, 3 }, 1)]
        [TestCase(new int[] { 5, 5, 5, 3, 1, 5 }, 0)]
        [TestCase(new int[] { 7, 3, 5, 1 }, 0)]
        [TestCase(new int[] { 1, 9, 3, 4, 9, 8, 7 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 5, 5, 2 }, 3)]
        public void FindIndexMaxValueTest(int[] array, int index)
        {
            int expected = index;
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.FindIndexMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 4, 2, 1, 3 }, 2)]
        [TestCase(new int[] { 1, 1, 1, 3, 5, 1 }, 0)]
        [TestCase(new int[] { 7, 3, 5, 1 }, 3)]
        [TestCase(new int[] { 9, 1, 3, 4, 1, 8, 7 }, 1)]
        [TestCase(new int[] { 5, 2, 5, 1, 1, 2 }, 3)]
        public void FindIndexMinValueTest(int[] array, int index)
        {
            int expected = index;
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.FindIndexMinValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 2, 4, 1, 3 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -170, 2, -14, 0, 5, -83, 19 }, new int[] { -170, -83, -14, 0, 2, 5, 19 })]
        [TestCase(new int[] { 17, 15, 17, 0, 15, -3 }, new int[] { -3, 0, 15, 15, 17, 17 })]
        public void SortAscendingTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 2, 4, 1, 3 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { -170, 2, -14, 0, 5, -83, 19 }, new int[] { 19, 5, 2, 0, -14, -83, -170 })]
        [TestCase(new int[] { 17, 15, 17, 0, 15, -3 }, new int[] { 17, 17, 15, 15, 0, -3 })]
        public void SortDescendingTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.SortDescending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 5, 3, 4, 5, 7, 5 }, 5, new int[] { 1, 3, 4, 5, 7, 5 })]
        [TestCase(new int[] { 100, 2, 300, 100, 5, 18 }, 100, new int[] { 2, 300, 100, 5, 18 })]
        [TestCase(new int[] { 15, 15, 15, 15, 15 }, 15, new int[] { 15, 15, 15, 15 })]
        [TestCase(new int[] { 5, 2, 4, 1, 3 }, 3, new int[] { 5, 2, 4, 1 })]
        public void RemoveFirstByValueTest(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFirstByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, -5)]
        [TestCase(new int[] { 1, 2 }, 100)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -20)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6)]
        [TestCase(new int[] { 1, 2, 3, 2, 5, 2 }, 30)]
        public void RemoveFirstByValueTestNegative(int[] array, int value)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            try
            {
                doubleLinkedList.RemoveFirstByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 5, 3, 4, 5, 7, 5 }, 5, new int[] { 1, 3, 4, 7 })]
        [TestCase(new int[] { 100, 2, 300, 100, 5, 18 }, 100, new int[] { 2, 300, 5, 18 })]
        [TestCase(new int[] { 15, 15, 15, 15, 15 }, 15, new int[] { })]
        [TestCase(new int[] { 5, 2, 4, 1, 3 }, 4, new int[] { 5, 2, 1, 3 })]
        [TestCase(new int[] { 5, 5, 5, 3, 3 }, 3, new int[] { 5, 5, 5 })]
        [TestCase(new int[] { 5, 5, 5, 3 }, 3, new int[] { 5, 5, 5 })]
        [TestCase(new int[] { 5, 5, 5, 3 }, 5, new int[] { 3 })]
        public void RemoveAllByValueTest(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveAllByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, -5)]
        [TestCase(new int[] { 1, 2 }, 100)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -20)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6)]
        [TestCase(new int[] { 1, 2, 3, 2, 5, 2 }, 30)]
        public void RemoveAllByValueTestNegative(int[] array, int value)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            try
            {
                doubleLinkedList.RemoveAllByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}
