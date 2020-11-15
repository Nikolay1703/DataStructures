﻿using System;

namespace DataStructures
{
    public class ArrayList
    {
        private int[] _array;
        public int Length { get; private set; }

        public ArrayList()
        {
            _array = new int[3];
            Length = 0;
        }

        public void Add(int value)        //Добавляет элемент в конец массива
        {
            if (Length >= _array.Length)
            {
                RizeSize();
            }
            _array[Length] = value;
            Length++;
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void RizeSize(int size = 1)   // Увеличивает массив на size количество элементов 
        {
            int newLength = _array.Length;

            while(newLength < _array.Length + size)
            {
                newLength = (int)(newLength * 1.33d + 1);
            }

            int[] newArray = new int[newLength];

            Array.Copy(_array, newArray, _array.Length);

            _array = newArray;
        }

        public void AddTheFirstElement(int value)   //Добавляет элемент в начало массива 
        {
            if (Length >= _array.Length)
            {
                RizeSize();
            }

            ShiftArrayElementsOneElementToTheRight();
            _array[0] = value;
            Length++;
        }

        private void ShiftArrayElementsOneElementToTheRight()   //Сдвигает элементы массива на один элемент вправо 
        {
            int[] newArray = new int[_array.Length];
            for(int i = 1; i < newArray.Length; i++)
            {
                newArray[i] = _array[i - 1];
            }
            _array = newArray;
        }

        public void AddValueByIndex(int value, int index)   // Добавляет значение по индексу
        {
            if (Length >= _array.Length)
            {
                RizeSize();
            }

            ShiftItemsToTheRightStartingAtTheGivenIndex(index);
            _array[index] = value;
            Length++;
        }

        private void ShiftItemsToTheRightStartingAtTheGivenIndex(int index)  //Сдвигает элементы вправо начиная с заданного индекса
        {
            int[] newArray = new int[_array.Length];

            Array.Copy(_array, newArray, index);
            
            for (int i = index; i < newArray.Length; i++)
            {
                newArray[i + 1] = _array[i];
            }

            _array = newArray;
        }

        public void Remove()          // Удаляет последний элемент массива
        {
            DecreaseTheArrayByOneElement();
            
            if (Length == _array.Length)
            {
                Length--;
            }
        }

        private void DecreaseTheArrayByOneElement()     // Уменьшает массив на один элемент
        {
            int[] newArray = new int[_array.Length - 1];

            Array.Copy(_array, newArray, _array.Length - 1);

            _array = newArray;
        }

        public void RemoveFirstElementOfArray()     // Удаляет первый элемент массива
        {
            if (_array[0].ToString() != "")
            {
                DecreaseTheArrayByTheFirstElement();
                Length--;
            }
            else
            {
                DecreaseTheArrayByTheFirstElement();
            }
                
        }

        private void DecreaseTheArrayByTheFirstElement()       // Уменьшает массив на первый элемент
        {
            int[] newArray = new int[_array.Length - 1];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = _array[i + 1];
            }

            _array = newArray;
        }

        public void RemoveElementByIndex(int index)         // Удаление элемента по индексу
        {
            if( _array[index].ToString() != "")
            {
                DecreaseTheArrayByTheElementAtThePassedIndex(index);
                Length--;
            }
            else
            {
                DecreaseTheArrayByTheElementAtThePassedIndex(index);
            }
            
        }

        private void DecreaseTheArrayByTheElementAtThePassedIndex(int index)  // Уменьшаем массив на элемент по индексу
        {
            int[] newArray = new int[_array.Length - 1];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = _array[i];
            }

            for (int i = index; i < newArray.Length; i++)
            {
                newArray[index] = _array[index + 1];
            }

            _array = newArray;
        }

        public int ReturnTheLength()   // Возвращаем длину массива
        {
            int count = 0;

            foreach( int x in _array) 
            {
                count++;
            }

            return count;
        }

        
    }
}