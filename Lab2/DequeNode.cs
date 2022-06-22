namespace Lab2
{
    public class DequeNode<T>
    {
        public DequeNode(T data)
        {
            Data = data;
        }
        
        public T Data { get; set; }
        public DequeNode<T> Previous { get; set; }
        public DequeNode<T> Next { get; set; }
    }
}