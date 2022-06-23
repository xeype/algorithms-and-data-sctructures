using System;
using System.Diagnostics;
using Lab5;

public class Program
{
    static void Main(string[] args)
    {
        Algorithms algo = new();

        int[] rand10000 = new int[10000];
        int[] rand1000 = new int[1000];

        rand10000 = FillRand(rand10000);
        rand1000 = FillRand(rand1000);

        Console.WriteLine("===== Linear Search =====");
        Console.WriteLine("Rand 1000 index: " + algo.LinearSearch(rand1000, 60));
        Console.WriteLine("Rand 10_000 index: " + algo.LinearSearch(rand10000, 60));
        Console.WriteLine("========================");
        
        
        Console.WriteLine("===== Binary Search =====");
        Console.WriteLine("Rand 1000 index: " + algo.BinarySearch(rand1000, 60));
        Console.WriteLine("Rand 10_000 index: " + algo.BinarySearch(rand10000, 60));
        Console.WriteLine("========================");
        
        Console.WriteLine("===== Break Search =====");
        Console.WriteLine("Rand 1000 index: " + algo.BreakSearch(rand1000, 60));
        Console.WriteLine("Rand 10_000 index: " + algo.BreakSearch(rand10000, 60));
        Console.WriteLine("========================");
    }

    static int[] FillRand(int[] arr)
    {
        Random rnd = new();

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(1, 1000);
        }

        return arr;
    }
}