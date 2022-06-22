namespace Lab2
{
    public class QueueNode<T>
    {
        public QueueNode(T data)
        {
            Data = data;
        }
        
        public T Data { get; set; }
        public QueueNode<T> Next { get; set; }
    }
}