using System;
using System.Collections;

namespace Wintellect.PowerCollections
{
    class Stack<T>
    {
        private readonly T[] array;
        private const int defaultLength = 10;
        private int count = 0;

        //конструктор с параметром, задающим размер внутреннего хранилища
        // по дефолту стек создается с макс размером 10
        public Stack()
        {
            array = new T[defaultLength];
        }
        //стек с заданной длиной
        public Stack(int length)
        {
            if(length < 0)
            {
                throw new InvalidOperationException("Длина стека не может быть меньше нуля");
            }
            array = new T[length];
        }
        public Stack(params T[] arr)
        {
            array = arr;
            count = arr.Length;
        }
        public T this[int x]
        { 
            get
            {
                return array[x];
            }
        }

        //свойство, максимальный размер стека
        public int Capacity { get { return array.Length; } }

        //свойство, текущее число элементов в стеке
        public int Count { get { return count; } }


        //добавить элемент на вершину стека
        public void Push(T element)
        {
            if (count == array.Length)
            {
                throw new InvalidOperationException("Стек переполнен");
            }
            array[count++] = element;
        }

        //снять элемент с вершины и вернуть его значение
        public T Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Стек пуст");
            }
            var element = array[--count];
            array[count] = default(T);
            return element;
        }

        //вернуть значение элемента на вершине стека, но не извлекать
        public T Top()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Стек пуст");
            }
            return array[count - 1];
        }
        public T[] toArray()
        {
            return array;
        }
        //
        public IEnumerator GetEnumerator()
        {
            return new Enumerator<T>(array, count);
        }
    }

    class Enumerator<T> : IEnumerator
    {
        private readonly T[] array;
        private int position;
        private int count;

        public Enumerator(T[] arr, int coun)
        {
            array = arr;
            position = coun;
            count = coun;
        }
        public object Current
        {
            get
            {
                if (position == count || position < 0)
                    throw new ArgumentException();
                return array[position];
            }
        }
        public bool MoveNext()
        {
            if (position > 0)
            {
                position--;
                return true;
            }
            else
                return false;
        }
        public void Reset() => position = count;
    }
}