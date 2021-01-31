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

        public int this[int index]
        {
            get
            {
                Node tmp = _startRoot;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            set
            {
                Node tmp = _startRoot;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
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
                    int halfList = IdentifyHalfList(index);
                    current = SelectItemByIndex(halfList, index);

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
                    int halfList = IdentifyHalfList(index);
                    current = SelectItemByIndex(halfList, index);

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

        private int IdentifyHalfList(int index)
        {
            int halfList = 1;

            if (index >= Length / 2)
            {
                halfList = 2;
            }
            return halfList;
        }

        private Node SelectItemByIndex(int halfList, int index)
        {
            Node current = _startRoot;
            if (halfList == 1)
            {
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
            }
            else if (halfList == 2)
            {
                current = _lastRoot;
                for (int i = Length - 1; i >= index; i--)
                {
                    current = current.Previous;
                }
            }
            return current;
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
                Node current = _startRoot;
                if (index == 0)
                {
                    _startRoot = current.Next;
                }
                else
                {
                    int halfList = IdentifyHalfList(index);
                    current = SelectItemByIndex(halfList, index);

                    current.Next = current.Next.Next;
                    current.Previous = current.Previous.Previous;
                }
                Length--;
            }
            else
            {
                throw new Exception("Ошибка! Элемент с введенным индексом отсутствует!");
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
                    int halfList = IdentifyHalfList(index);
                    current = SelectItemByIndex(halfList, index);

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

    }
}
