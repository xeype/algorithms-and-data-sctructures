using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab2
{
    public class MyDeque<T> : IEnumerable<T>
    {
        private DequeNode<T> head;
        private DequeNode<T> tail;
        private int count;

        public void Add(T data)
        {
            DequeNode<T> node = new DequeNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }

            tail = node;
            count++;
        }

        public T Remove()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = tail.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }

            count--;
            return output;
        }

        public void AddFirst(T data)
        {
            DequeNode<T> node = new DequeNode<T>(data);
            DequeNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }

        public T RemoveFirst()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }

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

        public T SixthElement
        {
            get
            {
                if (IsEmpty || count < 6)
                    throw new InvalidOperationException("Not enough elements");

                int counter = 0;
                foreach (var item in this)
                {
                    counter++;
                    if (counter == 6) return item;
                }

                throw new InvalidOperationException("Not found");
            }
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

        public void Show()
        {
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
        }

        public bool Contains(T data)
        {
            DequeNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DequeNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}