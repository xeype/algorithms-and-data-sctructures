using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] agrs)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu();
            }
        }

        private static Dictionary<string, DoubleLinkedList<float>>? Lists = new();

        private static int countOfLists = 0;

        private static void CreateList()
        {
            Console.WriteLine("Enter list name: ");
            string listName = Console.ReadLine();

            Lists?.Add(listName, new DoubleLinkedList<float>());
        }

        private static void ShowAllLists()
        {
            Console.WriteLine("All created lists: ");
            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    Console.WriteLine(key);
                }
        }

        private static void AddElement()
        {
            Console.WriteLine("Select list: ");
            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    Console.WriteLine(key);
                }

            string listName = Console.ReadLine();

            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    if (key == listName)
                    {
                        Console.WriteLine("Enter element to add: ");
                        float elementToAdd = float.Parse(Console.ReadLine());
                        value.Add(elementToAdd);
                        break;
                    }
                }

            Console.ReadLine();
            Menu();
        }

        private static void RemoveElement()
        {
            Console.WriteLine("Select list: ");
            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    Console.WriteLine(key);
                }

            string listName = Console.ReadLine();

            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    if (key == listName)
                    {
                        if (value.Count != 0)
                        {
                            Console.WriteLine("List elements: ");
                            foreach (var item in value)
                            {
                                Console.Write(item + " ");
                            }

                            Console.WriteLine("\nEnter element to remove: ");
                            float elementToRemove = float.Parse(Console.ReadLine());
                            value.Remove(elementToRemove);
                            Console.ReadLine();
                        }
                    }
                }
        }

        private static void ListLength()
        {
            Console.WriteLine("Select list: ");
            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    Console.WriteLine(key);
                }

            string? listName = Console.ReadLine();


            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    if (key == listName)
                    {
                        Console.WriteLine("Length: " + value.Count);
                        Console.ReadLine();
                        break;
                    }
                }
        }

        private static void SwapElements()
        {
            Console.WriteLine("Select list: ");
            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    Console.WriteLine(key);
                }

            string listName = Console.ReadLine();


            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    if (key == listName)
                    {
                        Console.WriteLine("List elements: ");
                        foreach (var item in value)
                        {
                            Console.Write(item + " ");
                        }

                        Console.WriteLine("\nSelect first element to swap: ");
                        float firstElement = float.Parse(Console.ReadLine());

                        Console.WriteLine("\nSelect second element to swap: ");
                        float secondElement = float.Parse(Console.ReadLine());

                        value.Swap(firstElement, secondElement);

                        Console.WriteLine("Elements swapped");

                        foreach (var item in value)
                        {
                            Console.Write(item + " ");
                        }

                        Console.ReadLine();
                    }
                }
        }

        private static void MergeLists()
        {
            Console.WriteLine("Select first list: ");
            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    Console.WriteLine(key);
                }

            string firstList = Console.ReadLine();

            Console.WriteLine("Select second list: ");
            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    Console.WriteLine(key);
                }

            string secondList = Console.ReadLine();

            DoubleLinkedList<float> temp1 = new();
            DoubleLinkedList<float> temp2 = new();
            if (Lists != null)

                foreach (var (key, value) in Lists)
                {
                    Lists.TryGetValue(firstList, out temp1);
                    Lists.TryGetValue(secondList, out temp2);
                }

            DoubleLinkedList<float> mergedList = temp1.Merge(temp2);
            Lists.Add($"Merged list of {firstList} and {secondList}", mergedList);
        }

        private static void ClearList()
        {
            Console.WriteLine("Select list to clear: ");
            if (Lists != null)
                foreach (var (key, value) in Lists)
                {
                    Console.WriteLine(key);
                }

            string listToClear = Console.ReadLine();

            foreach (var (key, value) in Lists)
            {
                if (key == listToClear)
                {
                    value.Clear();
                    Console.WriteLine("List cleared");
                    Console.ReadLine();
                }
            }
        }

        private static bool Menu()
        {
            Console.Clear();
            Console.WriteLine("===== Menu =====");
            Console.WriteLine("1) Create List");
            Console.WriteLine("2) My lists");
            Console.WriteLine("3) Add element");
            Console.WriteLine("4) Remove element");
            Console.WriteLine("5) List length");
            Console.WriteLine("6) Swap elements");
            Console.WriteLine("7) Merge lists");
            Console.WriteLine("8) Clear list");
            Console.WriteLine("0) Exit");
            Console.WriteLine("Select an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    CreateList();
                    return true;
                case "2":
                    ShowAllLists();
                    Console.ReadLine();
                    return true;
                case "3":
                    AddElement();
                    return true;
                case "4":
                    RemoveElement();
                    return true;
                case "5":
                    ListLength();
                    return true;
                case "6":
                    SwapElements();
                    return true;
                case "7":
                    MergeLists();
                    return true;
                case "8":
                    ClearList();
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }
    }
}