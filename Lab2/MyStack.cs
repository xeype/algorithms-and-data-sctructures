using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab2
{
    public class MyStack<T> : IEnumerable<T>
    {
        private StackNode<T> head;
        private int count;

        public bool isEmpty
        {
            get { return count == 0; }
        }

        public int Count
        {
            get { return count; }
        }

        public void Push(T item)
        {
            StackNode<T> node = new StackNode<T>(item);
            node.Next = head;
            head = node;
            count++;
        }

        public T Pop()
        {
            if (isEmpty)
                throw new InvalidOperationException("Stack is empty");
            StackNode<T> temp = head;
            head = head.Next;
            count--;
            return temp.Data;
        }

        public T Peek()
        {
            if (isEmpty)
                throw new InvalidOperationException("Stack is empty");
            return head.Data;
        }

        public void SwapFirstAndLast()
        {
            if (isEmpty)
                throw new InvalidOperationException("Stack is empty");

            MyStack<T> tmpStack = new();

            foreach (var item in this)
            {
                tmpStack.Push(item);
            }

            var tmpStackHead = tmpStack.Pop();
            var stackHead = Pop();
            tmpStack.Push(tmpStackHead);

            count = 0;
            head = null;

            foreach (var item in tmpStack)
            {
                if (item.Equals(tmpStackHead))
                {
                    Push(stackHead);
                    continue;
                }

                if (item.Equals(stackHead))
                {
                    Push(tmpStackHead);
                    continue;
                }

                Push(item);
            }
        }

        public void Reverse()
        {
            MyStack<T> tmpStack = new();
            foreach (var item in this)
            {
                tmpStack.Push(item);
            }

            MyStack<T> tmpStack2 = new();
            foreach (var item in tmpStack)
            {
                tmpStack2.Push(item);
            }

            count = 0;
            head = null;

            foreach (var item in tmpStack2)
            {
                Push(item);
            }
        }

        public void DeleteEverySecond()
        {
            int counter = 1;
            MyStack<T> tmpStack = new();
            foreach (var item in this)
            {
                if (counter % 2 == 0)
                {
                    counter++;
                }
                else
                {
                    tmpStack.Push(item);
                    counter++;
                }
            }


            count = 0;
            head = null;
            foreach (var item in tmpStack)
            {
                Push(item);
            }
        }

        public void DeleteAllButTheLast()
        {
            MyStack<T> tmp = new();
            foreach (var item in this)
            {
                tmp.Push(item);
            }

            tmp.Pop();

            count = 0;
            head = null;
            foreach (var item in tmp)
            {
                Push(item);
            }
        }

        public void DeleteAllButTheFirst()
        {
            MyStack<T> tmp = new();
            foreach (var item in this)
            {
                tmp.Push(item);
            }

            MyStack<T> tmp2 = new();
            foreach (var item in tmp)
            {
                tmp2.Push(item);
            }

            tmp2.Pop();

            tmp = new();
            foreach (var item in tmp2)
            {
                tmp.Push(item);
            }

            count = 0;
            head = null;
            foreach (var item in tmp)
            {
                Push(item);
            }
        }

        public void DeleteMin()
        {
            MyStack<T> tmp = new();
            double min = Convert.ToDouble(head.Data);
            foreach (var item in this)
            {
                tmp.Push(item);

                if (min > Convert.ToDouble(item))
                {
                    min = Convert.ToDouble(item);
                }
            }

            count = 0;
            head = null;

            foreach (var item in tmp)
            {
                if (!Convert.ToDouble(item).Equals(min))
                {
                    Push(item);
                }
            }
        }

        public void PutZeroAfterMax()
        {
            MyStack<T> tmp = new();
            double max = Convert.ToDouble(head.Data);
            foreach (var item in this)
            {
                tmp.Push(item);

                if (max < Convert.ToDouble(item))
                {
                    max = Convert.ToDouble(item);
                }
            }

            count = 0;
            head = null;

            foreach (var item in tmp)
            {
                if (!Convert.ToDouble(item).Equals(max))
                {
                    Push(item);
                }
                else
                {
                    Push(item);
                    /* Type conversion issue */
                    // Push(0);
                }
            }
        }

        public void Show()
        {
            foreach (var item in this)
            {
                Console.WriteLine(item + " ");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            StackNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}