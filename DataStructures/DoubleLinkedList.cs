using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class DoubleLinkedList
    {
        public int Length { get; private set; }

        private Node _startRoot;
        private Node _lastRoot;


        public DoubleLinkedList()
        {
            Length = 0;

            _startRoot = null;
            _lastRoot = null;
        }

        public DoubleLinkedList(int a)
        {
            Length = 1;

            _startRoot = new Node(a);
            _lastRoot = _startRoot;
        }

        public DoubleLinkedList(int[] array)
        {
            Length = array.Length;

            if (Length != 0)
            {
                _startRoot = new Node(array[0]);
                Node tmp = _startRoot;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp.Next.Previous = tmp;
                    tmp = tmp.Next;
                }
                _lastRoot = tmp;
            }
            else
            {
                _startRoot = null;
                _lastRoot = null;
            }
        }

        public override bool Equals(object obj)
        {
            DoubleLinkedList doubleLinkedList = (DoubleLinkedList)obj;

            if (Length != doubleLinkedList.Length)
            {
                return false;
            }

            Node tmp = _startRoot;
            Node tmpObj = doubleLinkedList._startRoot;

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

            Node tmp = _startRoot;

            for (int i = 0; i < Length; i++)
            {
                s += tmp.Value + ";";
                tmp = tmp.Next;
            }
            return s;
        }

        public Node this[int index]
        {
            get
            {
                Node tmp = _startRoot;
                if (index < Length / 2)
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        tmp = tmp.Next;
                    }
                }
                else
                {
                    tmp = _lastRoot;
                    for (int i = Length - 1; i >= index; i--)
                    {
                        tmp = tmp.Previous;
                    }
                }
                return tmp;
            }
            set
            {
                Node tmp = _startRoot;
                if (index < Length / 2)
                {
                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                }
                else
                {
                    tmp = _lastRoot;
                    for (int i = Length - 1; i >= index; i--)
                    {
                        tmp = tmp.Previous;
                    }
                }
                tmp.Value = this[index].Value;
            }
        }

        public void AddLast(int value)
        {
            Node tmp = new Node(value);

            if (_startRoot == null)
            {
                _startRoot = tmp;
                _lastRoot = tmp;
            }
            else
            {
                _lastRoot.Next = tmp;
                tmp.Previous = _lastRoot;
                _lastRoot = tmp;
            }
            Length++;
        }

        public void AddLastArray(int[] array)
        {
            Node tmp;

            if (_startRoot == null)
            {
                tmp = new Node(array[0]);
                _startRoot = tmp;
                _lastRoot = tmp;
                Node current = _startRoot;
                Length++;
                for (int i = 1; i < array.Length; i++)
                {
                    tmp = new Node(array[i]);
                    current.Next = tmp;
                    tmp.Previous = current;
                    current = current.Next;
                    Length++;
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    tmp = new Node(array[i]);
                    _lastRoot.Next = tmp;
                    tmp.Previous = _lastRoot;
                    _lastRoot = _lastRoot.Next;
                    Length++;
                }
            }
        }

        public void AddFirst(int value)
        {
            Node tmp = new Node(value);
            Node current = _startRoot;

            if (_startRoot == null)
            {
                _startRoot = tmp;
                _lastRoot = tmp;
            }
            else
            {
                _startRoot = tmp;
                tmp.Next = current;
                current.Previous = tmp;
            }
            Length++;

        }

        public void AddFirstArray(int[] array)
        {
            Node current;
            Node tmp;

            if (_startRoot == null)
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    current = _startRoot;
                    tmp = new Node(array[i]);
                    _startRoot = tmp;
                    tmp.Next = current;
                    Length++;
                }
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    current = _startRoot;
                    tmp = new Node(array[i]);
                    _startRoot = tmp;
                    tmp.Next = current;
                    current.Previous = tmp;
                    Length++;
                }
            }
        }

        public void AddByIndex(int value, int index)
        {
            if (index < Length && index >= 0)
            {
                Node tmp = new Node(value);
                Node current = _startRoot;

                if (index == 0)
                {
                    _startRoot = tmp;
                    tmp.Next = current;
                    current.Previous = tmp;
                }
                else
                {
                    current = this[index];
                    Node currentCopy = current.Next;
                    current.Next = tmp;
                    tmp.Previous = current;
                    tmp.Next = currentCopy;
                    tmp.Next.Previous = tmp;
                }
                Length++;
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
                        current = _startRoot;
                        tmp = new Node(array[i]);
                        _startRoot = tmp;
                        tmp.Next = current;
                        current.Previous = tmp;
                        Length++;
                    }
                }
                else
                {
                    current = this[index];

                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        tmp = new Node(array[i]);
                        Node currentCopy = current.Next;
                        current.Next = tmp;
                        tmp.Next = currentCopy;
                        Length++;
                    }
                }
            }
            else
            {
                throw new Exception("Ошибка! Элемент с введенным индексом отсутствует!");
            }
        }

        private int SelectIndexByValue(int value)
        {
            Node current = _startRoot;
            int index = -1;

            if (_startRoot.Value == value)
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
            return index;
        }

        public void RemoveLast()
        {
            _lastRoot.Previous = null;
            _lastRoot = _lastRoot.Previous;
            Length--;
        }

        public void RemoveFewLast(int n)
        {
            if (Length == n)
            {
                _startRoot = null;
            }
            else
            {
                Node current = _lastRoot;
                for (int i = Length - 1; i >= Length - n; i--)
                {
                    current = current.Previous;
                }
                current.Next = null;
            }
            Length = Length - n;
        }

        public void RemoveFirst()
        {
            Node current = _startRoot;
            _startRoot = current.Next;
            Length--;
        }

        public void RemoveFewFirst(int n)
        {
            Node current = _startRoot;
            for (int i = 0; i < n; i++)
            {
                _startRoot = current.Next;
                Length = Length - 1;
                current = _startRoot;
            }

        }

        public void RemoveByIndex(int index)
        {
            if (index < Length && index >= 0)
            {
                RemoveItemByIndex(index);
                Length--;
            }
            else
            {
                throw new Exception("Ошибка! Элемент с введенным индексом отсутствует!");
            }
            
        }

        private void RemoveItemByIndex(int index)
        {
            Node current = _startRoot;
            if (index == 0)
            {
                _startRoot = current.Next;
            }
            else if (index == Length - 1)
            {
                _lastRoot = _lastRoot.Previous;
            }
            else
            {
                current = this[index];
                current.Next = current.Next.Next;
                current.Next.Previous = current;
            }
        }

        public void RemoveFewByIndex(int index, int n)
        {
            if (index < Length && index >= 0)
            {
                Node current = _startRoot;

                if (index == 0)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        current = current.Next;
                    }
                    _startRoot = current;
                }
                else
                {
                    current = this[index];

                    for (int i = 1; i <= n; i++)
                    {
                        current.Next = current.Next.Next;
                    }
                }
                Length -= n;
            }
            else
            {
                throw new Exception("Ошибка! Элемент с введенным индексом отсутствует!");
            }
            
        }

        public int ReturnCount()
        {
            int count = 0;
            Node current = _startRoot;
            if (_startRoot == null)
            {
                count = 0;
            }
            else
            {
                count = 1;
                for (int i = 1; i < Length; i++)
                {
                    count++;
                }
            }
            return count;
        }

        public int ValueByIndex(int index)
        {
            Node current = _startRoot;
            int value;

            if (index < Length && index >= 0)
            {
                if (index == 0)
                {
                    value = current.Value;
                }
                else
                {
                    current = this[index];
                    value = current.Next.Value;                    
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
            int index = SelectIndexByValue(value);

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
            Node current = _startRoot;

            if (index < Length && index >= 0)
            {
                if (index == 0)
                {
                    current.Value = value;
                }
                else
                {
                    current = this[index];
                    current.Next.Value = value;
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

            Node oldRoot = _startRoot;
            Node tmp;

            while (oldRoot.Next != null)
            {
                tmp = oldRoot.Next;
                oldRoot.Next = tmp.Next;
                tmp.Next = _startRoot;
                _startRoot = tmp;
            }
        }

        public int FindMaxValue()
        {
            Node current = _startRoot;
            int maxValue = _startRoot.Value;

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
            Node current = _startRoot;
            int minValue = _startRoot.Value;

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
            Node current = _startRoot;
            int maxValue = _startRoot.Value;
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
            Node current = _startRoot;
            int minValue = _startRoot.Value;
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
            Node current = _startRoot;
            int[] array = new int[Length];

            array[0] = current.Value;
            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                array[i] = current.Value;
            }

            SortAscendingArray(array);

            _startRoot.Value = array[0];
            current = _startRoot;
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
            Node current = _startRoot;
            int[] array = new int[Length];

            array[0] = current.Value;
            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                array[i] = current.Value;
            }

            SortDescendingArray(array);

            _startRoot.Value = array[0];
            current = _startRoot;
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
            int startLength = Length;
            int index = SelectIndexByValue(value);
            RemoveByIndex(index);

            if (startLength == Length)
            {
                throw new Exception("Ошибка! Элемент с введенным значением отсутствует!");
            }
        }

        public void RemoveAllByValue(int value)
        {
            int startLength = Length;

            RemoveAllItemsByValue(value);

            if (startLength == Length)
            {
                throw new Exception("Ошибка! Элементы с введенным значением отсутствуют!");
            }

        }

        private void RemoveAllItemsByValue(int value)
        {
            Node current = _startRoot;

            while (_startRoot.Value == value)
            {
                if (current.Next != null)
                {
                    _startRoot = current.Next;
                    Length--;
                    current = _startRoot;
                }
                else
                {
                    _startRoot = null;
                    Length--;
                    break;
                }
            }

            if (_startRoot != null)
            {
                for (int i = 1; i < Length; i++)
                {
                    if (current.Next.Value == value)
                    {
                        current.Next = current.Next.Next;
                        i--;
                        Length--;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
        }

    }
}
