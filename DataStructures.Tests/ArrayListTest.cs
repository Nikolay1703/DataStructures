using NUnit.Framework;
using DataStructures;

namespace DataStructures.Tests
{
    public class ArrayListTest
    {
        [TestCase(6, 1)]
        [TestCase(500, 1)]
        [TestCase(0, 1)]
        public void AddTest(int value, int expected)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(value);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, -10, new int[] { 0, 15, 40, 7, 8, -10 })]
        [TestCase(new int[] {5}, -10, new int[] {5, -10})]
        public void AddTest(int[] array, int value, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.Add(value);
            int[] actual = arrayList.ReturnValues(); 
            Assert.AreEqual(expected, actual);
        }


        [TestCase(5, 1)]
        [TestCase(100, 1)]
        [TestCase(1, 1)]
        public void AddTheFirstElementTest(int value, int expected)
        {
            DataStructures.ArrayList arrayList = new DataStructures.ArrayList();
            arrayList.AddTheFirstElement(value);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, -10, new int[] { -10, 0, 15, 40, 7, 8 })]
        [TestCase(new int[] { 5 }, -10, new int[] { -10, 5 })]
        public void AddTheFirstElementTest(int[] array, int value, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.AddTheFirstElement(value);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(6, 0, 1)]
        [TestCase(500, 1, 1)]
        [TestCase(0, 2, 1)]
        public void AddValueByIndexTest(int value, int index, int expected)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.AddValueByIndex(value, index);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, 2, new int[] { 1, 2, 4, 3 })]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, -10, 1, new int[] { 0, -10, 15, 40, 7, 8 })]
        [TestCase(new int[] { 5 }, -10, 0, new int[] { -10, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, 4, 3, new int[] { 1, 2, 3, 4 })]
        public void AddValueByIndexTest(int[] array, int value, int index, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.AddValueByIndex(value, index);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, 2)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1,1,1,1,1,1,1,1,1}, 8)]
        public void RemoveTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.Remove();
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, new int[] { 0, 15, 40, 7 })]
        [TestCase(new int[] { 5 }, new int[] { })]
        public void Remove(int[] array, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.Remove();
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, 2)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 8)]
        public void RemoveFirstElementOfArrayTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.RemoveFirstElementOfArray();
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, new int[] { 15, 40, 7, 8 })]
        [TestCase(new int[] { 5 }, new int[] { })]
        public void RemoveFirstElementOfArrayTest(int[] array, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.RemoveFirstElementOfArray();
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, 1, 2)]
        [TestCase(new int[] { 1 }, 0, 0)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 },8, 8)]
        public void RemoveElementByIndexTest(int[] array, int index, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.RemoveElementByIndex(index);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 1, 2, 3, 5 })]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, 4, new int[] { 0, 15, 40, 7 })]
        [TestCase(new int[] { 5 }, 0, new int[] { })]
        public void RemoveElementByIndexTest(int[] array, int index, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.RemoveElementByIndex(index);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1, 2 }, 2)]
        [TestCase(new int[] { 0 }, 1)]
        public void ReturnTheLengthTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.ReturnTheLength();
            Assert.AreEqual(expected, actual);
        }


        
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, 4, 8)]
        public void GetAccessToAnArrayElementByIndexTest(int[] array, int index, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.GetAccessToAnArrayElementByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 15, 40, 7, 8 }, 5)]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, 20)]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, -1)]
        public void GetAccessToAnArrayElementByIndexTestNegative(int[] array, int index)
        {
            ArrayList arrayList = new ArrayList(array);
            try
            {
                arrayList.GetAccessToAnArrayElementByIndex(index);
            }
            catch 
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 0)]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, 8, 4)]
        public void DetermineArrayIndexByValueTest(int[] array, int value, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.DetermineArrayIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 15, 40, 7, 8 }, 5)]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, 20)]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, -1)]
        public void DetermineArrayIndexByValueTestNegative(int[] array, int value)
        {
            ArrayList arrayList = new ArrayList(array);
            try
            {
                arrayList.DetermineArrayIndexByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 2, new int[] { 1, 2, 5, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 100, 0, new int[] { 100, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, 77, 4, new int[] { 0, 15, 40, 7, 77 })]
        public void ChangeTheValueOfTheElementWithThePassedIndexTest(int[] array, int value, int index, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.ChangeTheValueOfTheElementWithThePassedIndex(value, index);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, -1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 100, 10)]
        [TestCase(new int[] { 0, 15, 40, 7, 8 }, 77, 100)]
        public void ChangeTheValueOfTheElementWithThePassedIndexTestNegative(int[] array, int value, int index)
        {
            ArrayList arrayList = new ArrayList(array);
            try
            {
                arrayList.ChangeTheValueOfTheElementWithThePassedIndex(value, index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1})]
        [TestCase(new int[] { -10, 20, -30 }, new int[] { -30, 20, -10 })]
        [TestCase(new int[] { 8 }, new int[] { 8 })]
        public void ReverseTest(int[] array, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.Reverse();
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { -10, 20, -30 }, -30)]
        [TestCase(new int[] { 8, 7, 8, 5, 8, -20, 0 }, -20)]
        [TestCase(new int[] { -8, 17, -8, 15, -8, 20, 0 }, -8)]
        public void FindTheMinimumValueTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.FindTheMinimumValue();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { -10, 20, -30 }, 1)]
        [TestCase(new int[] { 8, 7, 8, 5, 8, -20, 0 }, 0)]
        [TestCase(new int[] { -8, 17, -8, 15, -8, 20, 0 }, 5)]
        public void FindTheIndexOfTheMaximumElementTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.FindTheIndexOfTheMaximumElement();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { -10, 20, -30 }, 2)]
        [TestCase(new int[] { 8, 7, 8, 5, 8, -20, 0 }, 5)]
        [TestCase(new int[] { -8, 17, -8, 15, -8, 20, 0 }, 0)]
        public void FindTheIndexOfTheMinimumElementTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.FindTheIndexOfTheMinimumElement();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 5, 2, 4, 1, 3 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -170, 2, -14, 0, 5, -83, 19 }, new int[] { -170, -83, -14, 0, 2, 5, 19 })]
        [TestCase(new int[] { 17, 15, 17, 0, 15, -3 }, new int[] { -3, 0, 15, 15, 17, 17 })]
        public void SortTheArrayInAscendingOrderText(int[] array, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.SortTheArrayInAscendingOrder();
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 5, 2, 4, 1, 3 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { -170, 2, -14, 0, 5, -83, 19 }, new int[] { 19, 5, 2, 0, -14, -83, -170 })]
        [TestCase(new int[] { 17, 15, 17, 0, 15, -3 }, new int[] { 17, 17, 15, 15, 0, -3 })]
        public void SortTheArrayInDescendingOrder(int[] array, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.SortTheArrayInDescendingOrder();
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }


        
        [TestCase(new int[] { 1, 5, 3, 4, 5, 7, 5 }, 5, new int[] { 1, 3, 4, 5, 7, 5 })]
        [TestCase(new int[] { 100, 2, 300, 100, 5, 18 }, 100, new int[] { 2, 300, 100, 5, 18 })]
        [TestCase(new int[] { 15, 15, 15, 15, 15 }, 15, new int[] { 15, 15, 15, 15 })]
        public void DeleteTheFirstElementWithThePassedValueTest(int[] array, int value, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.DeleteTheFirstElementWithThePassedValue(value);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 5, 3, 4, 5, 7, 5 }, 50)]
        [TestCase(new int[] { 100, 2, 300, 100, 5, 18 }, 0)]
        [TestCase(new int[] { 15, 15, 15, 15, 15 }, 16)]
        public void DeleteTheFirstElementWithThePassedValueTestNegative(int[] array, int value)
        {
            ArrayList arrayList = new ArrayList(array);
            try
            {
                arrayList.DeleteTheFirstElementWithThePassedValue(value);
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
        public void RemoveAllElementsWithThePassedValueTest(int[] array, int value, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.RemoveAllElementsWithThePassedValue(value);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 5, 3, 4, 5, 7, 5 }, 50)]
        [TestCase(new int[] { 100, 2, 300, 100, 5, 18 }, 0)]
        [TestCase(new int[] { 15, 15, 15, 15, 15 }, 16)]
        public void RemoveAllElementsWithThePassedValueTestNegative(int[] array, int value)
        {
            ArrayList arrayList = new ArrayList(array);
            try
            {
                arrayList.RemoveAllElementsWithThePassedValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 0 }, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] {  }, 5)]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { }, new int[] { }, 0)]
        [TestCase(new int[] { 1 }, new int[] { }, 1)]
        public void AddAnArrayOfElementsToTheEndOfTheArrayTest(int[] array, int[] addArray, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.AddAnArrayOfElementsToTheEndOfTheArray(addArray);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6  })]
        [TestCase(new int[] {  }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void AddAnArrayOfElementsToTheEndOfTheArrayTest(int[] array, int[] addArray, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.AddAnArrayOfElementsToTheEndOfTheArray(addArray);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 0 }, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { }, 5)]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { }, new int[] { }, 0)]
        [TestCase(new int[] { 1 }, new int[] { }, 1)]
        public void AddAnArrayOfElementsToTheBeginningOfTheArrayTest(int[] array, int[] addArray, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.AddAnArrayOfElementsToTheBeginningOfTheArray(addArray);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 0 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 2, 3, 4, 5 }, new int[] { 0, 1 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 7 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void AddAnArrayOfElementsToTheBeginningOfTheArrayTest(int[] array, int[] addArray, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.AddAnArrayOfElementsToTheBeginningOfTheArray(addArray);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 0 }, 2, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { }, 3, 5)]
        [TestCase(new int[] { 1 }, new int[] { 1, 2, 3, 4, 5 }, 0, 6)]
        [TestCase(new int[] { 1, 2 }, new int[] { 3 }, 1, 3)]
        [TestCase(new int[] { 1 }, new int[] { }, 0, 1)]
        public void AddAnArrayOfElementsToTheArrayByIndexTest(int[] array, int[] addArray, int index, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.AddAnArrayOfElementsToTheArrayByIndex(addArray, index);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4 }, 2, new int[] { 1, 2, 4, 3 } )]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 10, 10 }, 0, new int[] { 10, 10, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0, 3, 4, 5 }, new int[] { 1, 2 }, 1, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 7 }, new int[] { 1, 2, 3, 4, 5, 6 }, 0, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void AddAnArrayOfElementsToTheArrayByIndexTest(int[] array, int[] addArray, int index, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.AddAnArrayOfElementsToTheArrayByIndex(addArray, index);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 1)]
        [TestCase(new int[] { 1, 2 }, 1, 1)]
        [TestCase(new int[] { 1 }, 1, 0)]
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 5, 5)]
        public void RemoveThePassedNumberOfElementsFromTheEndOfTheArrayTest(int[] array, int n, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.RemoveThePassedNumberOfElementsFromTheEndOfTheArray(n);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 1, 2})]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1 })]
        [TestCase(new int[] { 1, 2 }, 1, new int[] { 1 })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 5, new int[] { 5, 5, 5, 5, 5 })]
        public void RemoveThePassedNumberOfElementsFromTheEndOfTheArrayTest(int[] array, int n, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.RemoveThePassedNumberOfElementsFromTheEndOfTheArray(n);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 5, 3, 4, 5, 7, 5 }, 50)]
        [TestCase(new int[] { 100, 2, 300, 100, 5, 18 }, -1)]
        [TestCase(new int[] { 15, 15, 15, 15, 15 }, 6)]
        public void RemoveThePassedNumberOfElementsFromTheEndOfTheArrayTestNegative(int[] array, int n)
        {
            ArrayList arrayList = new ArrayList(array);
            try
            {
                arrayList.RemoveThePassedNumberOfElementsFromTheEndOfTheArray(n);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }



        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 1)]
        [TestCase(new int[] { 1, 2 }, 1, 1)]
        [TestCase(new int[] { 1 }, 1, 0)]
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 5, 5)]
        public void RemoveTheTransferredNumberOfElementsFromTheBeginningOfTheArrayTest(int[] array, int n, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.RemoveTheTransferredNumberOfElementsFromTheBeginningOfTheArray(n);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 5 })]
        [TestCase(new int[] { 1, 2 }, 1, new int[] { 2 })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 5, new int[] { 5, 5, 5, 5, 5 })]
        public void RemoveTheTransferredNumberOfElementsFromTheBeginningOfTheArrayTest(int[] array, int n, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.RemoveTheTransferredNumberOfElementsFromTheBeginningOfTheArray(n);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 5, 3, 4, 5, 7, 5 }, 50)]
        [TestCase(new int[] { 100, 2, 300, 100, 5, 18 }, -1)]
        [TestCase(new int[] { 15, 15, 15, 15, 15 }, 6)]
        public void RemoveTheTransferredNumberOfElementsFromTheBeginningOfTheArrayTestNegative(int[] array, int n)
        {
            ArrayList arrayList = new ArrayList(array);
            try
            {
                arrayList.RemoveTheTransferredNumberOfElementsFromTheBeginningOfTheArray(n);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }



        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 3, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 5, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 0, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 1, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 4, 1)]
        [TestCase(new int[] { 1, 2 }, 0, 1, 1)]
        [TestCase(new int[] { 1 }, 0, 1, 0)]
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 2, 5, 5)]
        public void RemoveTheNumberOfElementsFromTheArrayByIndexTest(int[] array, int index, int n, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.RemoveTheNumberOfElementsFromTheArrayByIndex(index, n);
            int actual = arrayList.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 3, new int[] { 1, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 5, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 1, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 4, new int[] { 1 })]
        [TestCase(new int[] { 1, 2 }, 0, 1, new int[] { 2 })]
        [TestCase(new int[] { 1 }, 0, 1, new int[] { })]
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 2, 5, new int[] { 5, 5, 5, 5, 5 })]
        public void RemoveTheNumberOfElementsFromTheArrayByIndexTest(int[] array, int index, int n, int[] expected)
        {
            ArrayList arrayList = new ArrayList(array);
            arrayList.RemoveTheNumberOfElementsFromTheArrayByIndex(index, n);
            int[] actual = arrayList.ReturnValues();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 5, 3, 4, 5, 7, 5 }, 4, 50)]         // неправильный n
        [TestCase(new int[] { 100, 2, 300, 100, 5, 18 }, 0, -1)]
        [TestCase(new int[] { 15, 15, 15, 15, 15 }, 2, 6)]
        public void RemoveTheNumberOfElementsFromTheArrayByIndexTestNegative(int[] array, int index, int n)
        {
            ArrayList arrayList = new ArrayList(array);
            try
            {
                arrayList.RemoveTheNumberOfElementsFromTheArrayByIndex(index, n);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 5, 3, 4, 5, 7, 5 }, -1, 4)]    // неправильный index
        [TestCase(new int[] { 100, 2, 300, 100, 5, 18 }, 6, 1)]
        [TestCase(new int[] { 15, 15, 15, 15, 15 }, 50, 4)]
        public void RemoveTheNumberOfElementsFromTheArrayByIndexTestNegativeTwo(int[] array, int index, int n)
        {
            ArrayList arrayList = new ArrayList(array);
            try
            {
                arrayList.RemoveTheNumberOfElementsFromTheArrayByIndex(index, n);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }










    }
}