using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class LinkedList
    {
        public int Length { get; private set; }

        private Node _root;


        public LinkedList()
        {
            Length = 0;

            _root = null;
        }

        public LinkedList(int a)
        {
            Length = 1;

            _root = new Node(a);
        }

        public LinkedList(int[] array)
        {
            Length = array.Length;

            if (Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }
            }
            else
            {
                _root = null;
            }
        }

        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }

            Node tmp = _root;
            Node tmpObj = linkedList._root;

            for (int i = 0; i < Length; i++)
            {
                if (tmp.Value != tmpObj.Value)
                {
                    return false;
                }
                tmp = tmp.Next;
                tmpObj = tmpObj.Next;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";

            Node tmp = _root;

            for (int i = 0; i < Length; i++)
            {
                s += tmp.Value + ";";
                tmp = tmp.Next;
            }
            return s;
        }

        public int this[int index]
        {
            get
            {
                Node tmp = _root;
                for(int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            set 
            {
                Node tmp = _root;
                for(int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }

        }

        public void AddLast(int value)
        {
            
            Node tmp = new Node(value);
            Node current = _root;     

            if (_root == null)
            {
                _root = tmp;
            }
            else
            {
                for (int i = 1; i < Length; i++)
                {
                    current = current.Next;
                }
                current.Next = tmp;
            }
            RizeSize(1);

        }

        public void AddLastArray(int[] array)
        {
            Node current;
            Node tmp;

            if(_root == null)
            {
                tmp = new Node(array[0]);
                _root = tmp;
                current = _root;
                RizeSize(1);
                for (int i = 1; i < array.Length; i++)
                {
                    tmp = new Node(array[i]);
                    current.Next = tmp;
                    current = current.Next;
                    RizeSize(1);
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    current = _root;
                    tmp = new Node(array[i]);
                    for (int j = 1; j < Length; j++)
                    {
                        current = current.Next;
                    }
                    current.Next = tmp;
                    RizeSize(1);
                }
            }
        }

        public void AddFirst(int value)
        {
            Node tmp = new Node(value);
            Node current = _root;

            if (_root == null)
            {
                _root = tmp;
            }
            else
            {
                _root = tmp;
                tmp.Next = current;
            }
            RizeSize(1);

        }

        public void AddFirstArray(int[] array)
        {
            Node current;
            Node tmp;

            if (_root == null)
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    current = _root;
                    tmp = new Node(array[i]);
                    _root = tmp;
                    tmp.Next = current;
                    RizeSize(1);
                }
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    current = _root;
                    tmp = new Node(array[i]);
                    _root = tmp;
                    tmp.Next = current;
                    RizeSize(1);
                }
            }
        }

        public void AddByIndex(int value, int index)
        {
            if (index < Length && index >= 0)
            {
                Node tmp = new Node(value);
                Node current = _root;

                if (index == 0)
                {
                    _root = tmp;
                    tmp.Next = current;
                }
                else
                {
                    for (int i = 1; i < index; i++)
                    {
                        current = current.Next;
                    }
                    Node currentCopy = current.Next;
                    current.Next = tmp;
                    tmp.Next = currentCopy;
                }
                RizeSize(1);
            }
            else
            {
                throw new Exception("Ошибка! Элемент с введенным индексом отсутствует!");
            }
        }

        public void AddByIndexArray(int[] array, int index)
        {
            if (index < Length && index >= 0)
            {
                Node tmp;
                Node current;

                if (index == 0)
                {
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        current = _root;
                        tmp = new Node(array[i]);
                        _root = tmp;
                        tmp.Next = current;
                        RizeSize(1);
                    }
                }
                else
                {
                    current = _root;
                    for (int i = 1; i < index; i++)
                    {
                        current = current.Next;
                    }
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        tmp = new Node(array[i]);
                        Node currentCopy = current.Next;
                        current.Next = tmp;
                        tmp.Next = currentCopy;
                        RizeSize(1);
                    }
                }
            }
            else
            {
                throw new Exception("Ошибка! Элемент с введенным индексом отсутствует!");
            }
        }

        private void RizeSize(int size)
        {
            int newLength = Length;

            while (newLength < Length + size)
            {
                newLength = newLength + 1;
            }

            Length = newLength;
        }

        public void RemoveLast()
        {
            Node current = _root;
            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
            }
            current.Next = null;
            Length = Length - 1;
        }

        public void RemoveFewLast(int n)
        {
            Node current = _root;
            for (int i = 1; i < Length - n; i++)
            {
                current = current.Next;
            }
            current.Next = null;
            Length = Length - n;
        }

        public void RemoveFirst()
        {
            Node current = _root;
            _root = current.Next;
            Length = Length - 1;
        }

        public void RemoveFewFirst(int n)
        {
            Node current = _root;
            for(int i = 0; i < n; i++)
            {
                _root = current.Next;
                Length = Length - 1;
                current = _root;
            }
            
        }

        public void RemoveByIndex(int index)
        {
            Node current = _root;
            if (index == 0)
            {
                _root = current.Next;
            }
            else
            {
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
            }
            Length = Length - 1;
        }

        public void RemoveFewByIndex(int index, int n)
        {
            Node current = _root;
            if (index == 0)
            {
                _root = current.Next;
                Length = Length - 1;
                for (int i = 2; i <= n; i++)
                {
                    current = _root;
                    _root = current.Next;
                    Length = Length - 1;
                }
            }
            else
            {
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                for (int i = 1; i <= n; i++)
                {
                    current.Next = current.Next.Next;
                    Length = Length - 1;
                }
            }
        }

        public int ReturnCount()
        {
            int count = 0;
            Node current = _root;
            if (_root == null)
            {
                count = 0;
            }
            else
            {
                count = 1;
                for(int i = 1; i < Length; i++)
                {
                    count++;
                }
            }
            return count;
        } 

        public int ValueByIndex(int index)
        {
            Node current = _root;
            int value;

            if (index < Length && index >= 0)                 
            {
                if (index == 0)
                {
                    value = current.Value;
                }
                else
                {
                    for (int i = 1; i <= index; i++)
                    {
                        current = current.Next;
                    }
                    value = current.Value;
                }
                return value;
            }
            else
            {
                throw new Exception("Ошибка! Элемент с введенным индексом отсутствует!");
            }
            
        }

        public int IndexByValue(int value)
        {
            int index = -1;
            Node current = _root;

            if (current.Value == value)
            {
                index = 0;
            }
            else
            {
                for (int i = 1; i < Length; i++)
                {
                    current = current.Next;
                    if (current.Value == value)
                    {
                        index = i;
                        break;
                    }
                }
            }

            if (index != -1)
            {
                return index;
            }
            else
            {
                throw new Exception("Ошибка! Элемент с введенным значением отсутствует!");
            }
        }

        public void ChangeValueByIndex(int index, int value)
        {
            Node current = _root;

            if (index < Length && index >= 0) 
            {
                if (index == 0)
                {
                    current.Value = value;
                }
                else
                {
                    for (int i = 1; i <= index; i++)
                    {
                        current = current.Next;
                    }
                    current.Value = value;
                }
            }
            else
            {
                throw new Exception("Ошибка! Элемент с введенным индексом отсутствует!");
            }
        }

        public void Reverse()
        {
            if (Length == 0)
            {
                return;
            }

            Node oldRoot = _root;
            Node tmp;

            while (oldRoot.Next != null)
            {
                tmp = oldRoot.Next;
                oldRoot.Next = tmp.Next;
                tmp.Next = _root;
                _root = tmp;
            }
        }

        public int FindMaxValue()
        {
            Node current = _root;
            int maxValue = _root.Value;

            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                if (maxValue < current.Value)
                {
                    maxValue = current.Value;
                }
            }
            return maxValue;
        }

        public int FindMinValue()
        {
            Node current = _root;
            int minValue = _root.Value;

            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                if (minValue > current.Value)
                {
                    minValue = current.Value;
                }
            }
            return minValue;
        }

        public int FindIndexMaxValue()
        {
            Node current = _root;
            int maxValue = _root.Value;
            int index = 0;

            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                if (maxValue < current.Value)
                {
                    maxValue = current.Value;
                    index = i;
                }
            }
            return index;
        }

        public int FindIndexMinValue()
        {
            Node current = _root;
            int minValue = _root.Value;
            int index = 0;

            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                if (minValue > current.Value)
                {
                    minValue = current.Value;
                    index = i;
                }
            }
            return index;
        }

        public void SortAscending()
        {
            Node current = _root;
            int[] array = new int[Length];

            array[0] = current.Value;
            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                array[i] = current.Value;
            }

            SortAscendingArray(array);

            _root.Value = array[0];
            current = _root;
            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                current.Value = array[i];
            }

        }

        private void SortAscendingArray(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int x = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = x;
                    }
                }
            }
        }

        public void SortDescending()
        {
            Node current = _root;
            int[] array = new int[Length];

            array[0] = current.Value;
            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                array[i] = current.Value;
            }

            SortDescendingArray(array);

            _root.Value = array[0];
            current = _root;
            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                current.Value = array[i];
            }

        }

        private void SortDescendingArray(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        int x = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = x;
                    }
                }
            }
        }

        public void RemoveFirstByValue(int value)
        {
            Node current = _root;
            int startLength = Length;

            if (_root.Value == value)
            {
                _root = current.Next;
                Length = Length - 1;
            }
            else
            {
                for (int i = 1; i < Length; i++)
                {
                    if (current.Next.Value == value)
                    {
                        current.Next = current.Next.Next;
                        Length = Length - 1;
                        break;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }

            if (startLength == Length)
            {
                throw new Exception("Ошибка! Элемент с введенным значением отсутствует!");
            }
        }

        public void RemoveAllByValue(int value)
        {
            Node current = _root;
            int startLength = Length;

            while (_root.Value == value)
            {
                if (current.Next != null)
                {
                    _root = current.Next;
                    Length = Length - 1;
                    current = _root;
                }
                else
                {
                    _root = null;
                    Length = Length - 1;
                    break;
                }
            }

            if (_root != null)
            {
                for (int i = 1; i < Length; i++)
                {
                    if (current.Next.Value == value)
                    {
                        current.Next = current.Next.Next;
                        i--;
                        Length = Length - 1;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }

            if (startLength == Length)
            {
                throw new Exception("Ошибка! Элементы с введенным значением отсутствуют!");
            }

        }
    }    
}
