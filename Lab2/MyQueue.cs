using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab2
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;
        private int count;

        public void Enqueue(T data)
        {
            QueueNode<T> node = new QueueNode<T>(data);
            QueueNode<T> tempNode = tail;
            tail = node;
            if (count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }

        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsEmpty
        {
            get { return count == 0; }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            QueueNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }

            return false;
        }

        public void Show()
        {
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
        }

        public void Average()
        {
            double average = 0;
            foreach (var item in this)
            {
                average += Convert.ToDouble(item);
            }

            average = average / count;
            Console.WriteLine(average);
        }

        public void FindLimits()
        {
            double min = Convert.ToDouble(head.Data);
            double max = Convert.ToDouble(head.Data);

            foreach (var item in this)
            {
                if (min > Convert.ToDouble(item)) min = Convert.ToDouble(item);
                if (max < Convert.ToDouble(item)) max = Convert.ToDouble(item);
            }

            Console.WriteLine("Min element: " + min);
            Console.WriteLine("Min element: " + max);
        }

        public void FindMinPrevious()
        {
            double min = Convert.ToDouble(head.Data);

            foreach (var item in this)
            {
                if (min > Convert.ToDouble(item)) min = Convert.ToDouble(item);
            }

            double prev = Convert.ToDouble(head.Data);
            foreach (var item in this)
            {
                if (Convert.ToDouble(item).Equals(min)) break;
                prev = Convert.ToDouble(item);
            }
            Console.WriteLine(prev);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            QueueNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}