using System;

namespace Lab3
{
    public class BinaryTree
    {
        public Node Root { get; set; }

        public bool Add(string surname, int year, int group)
        {
            Node before = null, after = this.Root;
            while (after != null)
            {
                before = after;
                if (surname.Length < after.Surname.Length)
                    after = after.LeftNode;
                else if (surname.Length > after.Surname.Length)
                    after = after.RightNode;
                else
                {
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Surname = surname;
            newNode.Year = year;
            newNode.Group = group;

            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                if (group < before.Group)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(String.Format("Surname: {0}, Year: {1}, Group: {2}", parent.Surname, parent.Year,
                    parent.Group));
                Console.WriteLine();
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(String.Format("Surname: {0}, Year: {1}, Group: {2}", parent.Surname, parent.Year,
                    parent.Group));
                Console.WriteLine();
                TraverseInOrder(parent.RightNode);
            }
        }

        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(String.Format("Surname: {0}, Year: {1}, Group: {2}", parent.Surname, parent.Year,
                    parent.Group));
                Console.WriteLine();
            }
        }
    }
}