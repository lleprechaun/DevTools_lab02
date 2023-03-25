using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace Wintellect.PowerCollections.Tests
{
    [TestClass]
    public class ConstructorsStackTests
    {
        [TestMethod]
        public void ConstructorStackWithInputLength()
        {
            Stack<int> stack = new Stack<int>(5);
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(5, stack.Capacity);
        }
        [TestMethod]
        public void DefaultConstructorStack()
        {
            Stack<string> stack = new Stack<string>();
            Assert.AreEqual(0, stack.Count);
            //по дефолту длина стека равна 10
            Assert.AreEqual(10, stack.Capacity);
        }
        [TestMethod]
        public void ConstructorSteckWithInputArray()
        {
            int[] ints = { 1, 2, 3, 4 };
            Stack<int> stack = new Stack<int>(ints);
            Assert.AreEqual(ints.Length, stack.Count);
            Assert.AreEqual(ints.Length, stack.Capacity);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Длина стека не может быть меньше нуля")]
        public void ExceptionLengthStackNotLess0()
        {
            Stack<bool> stack = new Stack<bool>(-10);
        }
    }
    [TestClass]
    public class MethodsStackTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Стек переполнен")]
        public void ExceptionStackOverflow()
        {
            Stack<bool> stack = new Stack<bool>(0);
            stack.Push(true);
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(0, stack.Capacity);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Стек пуст")]
        public void PopExceptionStackIsEmpty()
        {
            Stack<bool> stack = new Stack<bool>(0);
            stack.Pop();
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(0, stack.Capacity);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Стек пуст")]
        public void TopExceptionStackIsEmpty()
        {
            Stack<bool> stack = new Stack<bool>(0);
            stack.Top();
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(0, stack.Capacity);
        }
        [TestMethod]
        public void PushStringAAA_stringBBB_stringCCC_then_PopStringCCC_expected_TopStringBBB()
        {
            Stack<string> stack = new Stack<string>(4);
            stack.Push("AAA");
            stack.Push("BBB");
            stack.Push("CCC");
            stack.Push("BROKE");
            Assert.AreEqual("CCC", stack.Pop());
            Assert.AreEqual("BBB", stack.Top());
            Assert.AreEqual(2, stack.Count);
            Assert.AreEqual(4, stack.Capacity);
        }
        [TestMethod]
        public void ExpectedTopBoolTrue()
        {
            bool[] bools = { true, false, false, true };
            Stack<bool> stack = new Stack<bool>(bools);
            Assert.IsTrue(stack.Top());
        }
        [TestMethod]
        public void ExpectedPopBoolTrue_and_TopBoolFalse()
        {
            bool[] bools = { true, false, false, true };
            Stack<bool> stack = new Stack<bool>(bools);
            Assert.IsTrue(stack.Pop());
            Assert.IsFalse(stack.Top());
        }
        [TestMethod]
        public void IEnumerableStack()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            Stack<int> stack = new Stack<int>(arr);
            Stack<int> stack2 = new Stack<int>();
            foreach (int item in stack)
            {
                stack2.Push(item);
            }
            Array.Reverse(arr);
            stack = new Stack<int>(arr);
            var expected = stack.toArray();
            var actual = stack.toArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
