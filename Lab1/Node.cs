namespace Lab1
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set;  }

        public Node(T data)
        {
            Data = data;
        }
    }
}