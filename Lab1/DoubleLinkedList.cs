using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

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

        public bool Remove(T data)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }

                current = current.Next;
            }

            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }

                count--;
                return true;
            }

            return false;
        }

        public int Count
        {
            get { return count; }
        }

        public void Swap(T firstData, T secondData)
        {
            Node<T> prevX = null, currX = head;

            if (firstData.Equals(secondData))
                return;

            while (currX != null && !currX.Data.Equals(firstData))
            {
                prevX = currX;
                currX = currX.Next;
            }

            Node<T> prevY = null, currY = head;
            while (currY != null && !currY.Data.Equals(secondData))
            {
                prevY = currY;
                currY = currY.Next;
            }

            if (currX == null || currY == null)
                return;

            if (prevX != null)
                prevX.Next = currY;
            else
                head = currY;

            if (prevY != null)
                prevY.Next = currX;
            else
                head = currX;


            Node<T> temp = currX.Next;
            currX.Next = currY.Next;
            currY.Next = temp;
        }

        public DoubleLinkedList<T> Merge(DoubleLinkedList<T> secondList)
        {
            DoubleLinkedList<T> mergedList = this;
            foreach (var item in secondList)
            {
                mergedList.Add(item);
            }
            return mergedList;
        }

        public void Clear()
        {
            count = 0;
            head = null;
            tail = null;
        }

        public void Show()
        {
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}