using System;
using System.Collections;

namespace Stack
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
            if (length < 0)
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
    }

    class Program
    {
        static void Main(string[] args)
        {

            var stack = new Stack<int>(4);
            stack.Push(1);
            stack.Push(2);
            Console.WriteLine(stack.Capacity);
        }
    }
}