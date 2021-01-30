using System;

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

        public ArrayList(int a) 
        {
            _array = new int[3];
            _array[0] = a;
            Length = 1;
        }

        public ArrayList(int[] array)
        {
            _array = new int[array.Length];
            Array.Copy(array, _array, array.Length);
            Length = array.Length;
        }

        public int[] ReturnValues()
        {
            return _array;
        }

        public void Add(int value)        //Добавляет элемент в конец массива
        {
            if (Length >= _array.Length)
            {
                RizeSize(1);
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

        private void RizeSize(int size)   // Увеличивает массив на size количество элементов 
        {
            int newLength = _array.Length;
            
            while(newLength < Length + size)
            {
                //newLength = (int)(newLength * 1.33d + 1);
                newLength = (int)(newLength + 1);
            }

            int[] newArray = new int[newLength];

            Array.Copy(_array, newArray, _array.Length);

            _array = newArray;
        }

        public void AddTheFirstElement(int value)   //Добавляет элемент в начало массива 
        {
            if (Length >= _array.Length)
            {
                RizeSize(1);
            }

            ShiftArrayElementsToTheRight(1);
            _array[0] = value;
            Length++;
        }

        private void ShiftArrayElementsToTheRight(int n)   //Сдвигает элементы массива на n элементов вправо 
        {
            for (int i = _array.Length - 1; i >= n; i--)
            {
                _array[i] = _array[i - n];
            }
        }

        public void AddValueByIndex(int value, int index)   // Добавляет значение по индексу
        {
            if (Length >= _array.Length)
            {
                RizeSize(1);
            }

            ShiftItemsToTheRightStartingAtTheGivenIndex(index, 1);
            _array[index] = value;
            Length++;
        }

        private void ShiftItemsToTheRightStartingAtTheGivenIndex(int index, int n)  //Сдвигает элементы вправо начиная с заданного индекса на n количество элементов
        {
            int[] newArray = new int[_array.Length];

            Array.Copy(_array, newArray, index);
            
            for (int i = index + n; i < newArray.Length; i++)
            {
                newArray[i] = _array[i - n];
            }

            _array = newArray;
        }

        public void Remove()          // Удаляет последний элемент массива
        {
            
            if (Length == _array.Length)
            {
                ReduceTheArrayByTheNumberOfElements(1);
                Length--;
            }
            else if (Length < _array.Length)
            {
                ReduceTheArrayByTheNumberOfElements(1);
            }
        }

        private void ReduceTheArrayByTheNumberOfElements(int n)     // Уменьшает массив на n элементов
        {
            int[] newArray = new int[_array.Length - n];

            Array.Copy(_array, newArray, _array.Length - n);

            _array = newArray;
        }

        public void RemoveFirstElementOfArray()     // Удаляет первый элемент массива
        {
            ReduceTheArrayFromTheBeginningByTheNumberOfElements(1);
            Length--;
        }

        private void ReduceTheArrayFromTheBeginningByTheNumberOfElements(int n)       // Удаляет из начала массива n элементов
        {
            int[] newArray = new int[_array.Length - n];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = _array[i + n];
            }

            _array = newArray;
        }

        public void RemoveElementByIndex(int index)         // Удаление элемента по индексу
        {
            DecreaseTheArrayByTheNumberOfElementsByIndex(index, 1);
            Length--;
        }

        private void DecreaseTheArrayByTheNumberOfElementsByIndex(int index, int n)  // Уменьшаем массив на N элементов по индексу
        {
            int[] newArray = new int[_array.Length - n];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = _array[i];
            }

            for (int i = index; i < newArray.Length; i++)
            {
                newArray[i] = _array[i + n];
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
        
        public int GetAccessToAnArrayElementByIndex(int index)       //Получаем доступ к элементу по индексу 
        {
            int value = 0;
            if (index < _array.Length && index >= 0)                 // Проверяем, что введенный индекс входит в наш массив
            {
                if (_array[index].ToString() != "")    // Проверяем, что элемент с данным индексом имеет значение  
                {
                    value = _array[index];
                    return value;
                }
                else
                {
                    throw new Exception("Элемент массива с данным индексом не содержит значение");
                }
            }
            else
            {
                throw new Exception("Введенный индекс не входит в массив. Элемента с таким индексом не существует!");
            }
        }
        
        public int DetermineArrayIndexByValue(int value)      // Определяем индекс массива по значению 
        {
            int x = 0;
            string s = "" + value;
            bool result = int.TryParse(s, out x); 

            if (result == false) 
            {
                throw new Exception("Введено некорректное значение. Введите целое число!");
            }
            
            int index = -1;
            
            for (int i = 0; i < _array.Length; i++) 
            {
                if (_array[i] == value) 
                {
                    index = i;
                    break;
                }
            
            }
            
            if (index >= 0) 
            {
                return index;
            }
            else 
            {
                throw new Exception("Элемент с таким значением в массиве отсутствует!");
            }
        }

        public void ChangeTheValueOfTheElementWithThePassedIndex(int value, int index) // Меняем значение элемента с переданным индексом
        {
            if (index < _array.Length && index >= 0)
            {
                if (value.ToString() != "")
                {
                    _array[index] = value;
                }
                else
                {
                    throw new Exception("Не было введено значение!");
                }
            }
            else 
            {
                throw new Exception("Введенный индекс не входит в массив. Элемента с таким индексом не существует!");
            }
                
        }
        
        public void Reverse() // Реверс массива
        {
            DoTheReverseOfTheArray();
        }
        
        private void DoTheReverseOfTheArray() 
        {
            int[] newArray = new int[_array.Length];
            
            for (int i = 0; i < newArray.Length; i++) 
            {
                newArray[i] = _array[_array.Length - 1 - i];
            }
            
            _array = newArray;
        }
        
        public int FindTheMaximumValue()    // Поиск наибольшего элемента массива
        {
            int maxValue = IterateThroughTheArrayAndFindTheMaximumValue();
            return maxValue;
        }
        
        private int IterateThroughTheArrayAndFindTheMaximumValue() 
        {
            int maxValue = _array[0];
            
            foreach (int x in _array) 
            {
                if(maxValue < x) 
                {
                    maxValue = x;
                }
            }
            
            return maxValue;
        }
        
        public int FindTheMinimumValue()    // Поиск наименьшего элемента массива
        {
            int minValue = IterateThroughTheArrayAndFindTheMinimumValue();
            return minValue;
        }
        
        private int IterateThroughTheArrayAndFindTheMinimumValue() 
        {
            int minValue = _array[0];
            
            foreach (int x in _array) 
            {
                if(minValue > x) 
                {
                    minValue = x;
                }
            }
            
            return minValue;
        }
        
        public int FindTheIndexOfTheMaximumElement()    // Поиск индекса наибольшего элемента массива
        {
            int indexMaxElement = IterateThroughTheArrayAndFindTheIndexOfTheMaximumElement();
            return indexMaxElement;
        }
        
        private int IterateThroughTheArrayAndFindTheIndexOfTheMaximumElement() 
        {
            int indexMaxElement = 0;
            int maxValue = _array[0];
            
            for (int i = 1; i < _array.Length; i++) 
            {
                if (maxValue < _array[i]) 
                {
                    maxValue = _array[i];
                    indexMaxElement = i;
                }
            } 
            
            return indexMaxElement;
        }
              
        public int FindTheIndexOfTheMinimumElement()    // Поиск индекса наименьшего элемента массива
        {
            int indexMinElement = IterateThroughTheArrayAndFindTheIndexOfTheMinimumElement();
            return indexMinElement;
        }
        
        private int IterateThroughTheArrayAndFindTheIndexOfTheMinimumElement() 
        {
            int indexMinElement = 0;
            int minValue = _array[0];
            
            for (int i = 1; i < _array.Length; i++) 
            {
                if (minValue > _array[i]) 
                {
                    minValue = _array[i];
                    indexMinElement = i;
                }
            } 
            
            return indexMinElement;
        }
        
        public void SortTheArrayInAscendingOrder()   // Сортировка массива по возрастанию
        {
            GoThroughTheArrayAndSortItInAscendingOrder();
        }
        
        private void GoThroughTheArrayAndSortItInAscendingOrder() 
        {
            for (int i = _array.Length - 1; i >= 0; i--) 
            {
                for (int j = 0; j < i; j++) 
                {
                    if (_array[j] > _array[j+1]) 
                    {
                        int x = _array[j+1];
                        _array[j+1] = _array[j];
                        _array[j] = x;
                    }
                }
            }
        }
        
        public void SortTheArrayInDescendingOrder()   // Сортировка массива по убыванию
        {
            GoThroughTheArrayAndSortItInDescendingOrder();
        }
        
        private void GoThroughTheArrayAndSortItInDescendingOrder() 
        {
            for (int i = _array.Length - 1; i >= 0; i--) 
            {
                for (int j = 0; j < i; j++) 
                {
                    if (_array[j] < _array[j+1]) 
                    {
                        int x = _array[j+1];
                        _array[j+1] = _array[j];
                        _array[j] = x;
                    }
                }
            }
        }
        
        public void DeleteTheFirstElementWithThePassedValue(int value)     // Удаляет первый элемент с переданным значением 
        {
            int index = DetermineTheIndexOfTheElementByValue(value);
            
            if (index >= 0) 
            {
                DecreaseTheArrayByTheNumberOfElementsByIndex(index, 1);
            }
            else 
            {
                throw new Exception("Элемент с таким значением в массиве отсутствует!");
            }
        }
        
        private int DetermineTheIndexOfTheElementByValue(int value)   //Возвращает индекс первого элемента с переданным значением
        {
            int index = -1;
        
            for (int i = 0; i < _array.Length; i++) 
            {
                if (value == _array[i]) 
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void RemoveAllElementsWithThePassedValue(int value)  // удаление по значению всех
        {
            int count = 0;
            int initialLength = _array.Length;

            for (int i = 0; i < _array.Length; i++)
            {
                if (value == _array[i])
                {
                    DecreaseTheArrayByTheNumberOfElementsByIndex(i, 1);
                    i--;
                    count++;
                }
            }

            if(count == 0)
            {
                throw new Exception("Элементы с таким значением в массиве отсутствует!");
            }
        }

        public void AddAnArrayOfElementsToTheEndOfTheArray(int[] array)   //Добавляем массив элементов в конец массива
        {
            int _arrayLength = _array.Length;
            if (Length + array.Length > _array.Length)
            {
                RizeSize( (Length + array.Length) - _array.Length );
            }

            int index = 0;
            for (int i = _arrayLength; i < _array.Length; i++)
            {
                _array[i] = array[index];
                index++;
            }

            Length += array.Length;
        }

        public void AddAnArrayOfElementsToTheBeginningOfTheArray(int[] array)  //Добавляем массив элементов в начало массива
        {
            if (Length + array.Length > _array.Length)
            {
                RizeSize((Length + array.Length) - _array.Length);
            }

            ShiftArrayElementsToTheRight(array.Length);

            for(int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
            Length += array.Length;
        }

        public void AddAnArrayOfElementsToTheArrayByIndex(int[] array, int index) //Добавляем массив элементов в массив по индексу
        {
            if (Length + array.Length > _array.Length)
            {
                RizeSize((Length + array.Length) - _array.Length);
            }

            ShiftItemsToTheRightStartingAtTheGivenIndex(index, array.Length);

            int x = 0;
            for(int i = index; i < index + array.Length; i++)
            {
                _array[i] = array[x];
                x++;
            }
            Length += array.Length;

        }

        public void RemoveThePassedNumberOfElementsFromTheEndOfTheArray(int n)  // Удаляет из конца массива переданное количество элементов
        {
            if (n >= 0 && n <= _array.Length) 
            {
                int count = 0;
                for (int i = _array.Length - 1; i > _array.Length - 1 - n; i--)
                {
                   count++;
                }
                ReduceTheArrayByTheNumberOfElements(n);
                Length -= count;
            }
            else
            {
                throw new Exception("Значение N превышает длину массива!");
            }
        }

        public void RemoveTheTransferredNumberOfElementsFromTheBeginningOfTheArray(int n) //  Удаляет из начала массива переданное количество элементов
        {
            if (n >= 0 && n <= _array.Length)
            {
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    count++;
                }
                ReduceTheArrayFromTheBeginningByTheNumberOfElements(n);
                Length -= count;
            }
            else 
            {
                throw new Exception("Значение N превышает длину массива, , либо N меньше 0!");
            }
        }

        public void RemoveTheNumberOfElementsFromTheArrayByIndex(int index, int n) // Удаляет из массива по индексу N количество элементов
        {
            if (n >= 0 && n <= _array.Length - index)
            {
                if (index >= 0 && index < _array.Length)
                {
                    int count = 0;
                    for (int i = index; i < index + n; i++)
                    {
                        count++;
                    }
                    DecreaseTheArrayByTheNumberOfElementsByIndex(index, n);
                    Length -= count;
                }
                else 
                {
                    throw new Exception("Элемент с таким индексом в массиве отсутствует!");
                }
            }
            else
            {
                throw new Exception("Значение N превышает длину массива, либо N меньше 0!");
            }
        }



        












    }
}
