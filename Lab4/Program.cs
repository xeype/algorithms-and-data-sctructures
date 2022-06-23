using System;
using System.Diagnostics;
using Lab4;

public class Program
{
    static void Main(string[] args)
    {
        int[] rand100000 = new int[100000];
        int[] rand10000 = new int[10000];
        int[] rand1000 = new int[1000];
        int[] rand100 = new int[100];
        int[] rand10 = new int[10];

        rand100000 = FillRand(rand100000);
        rand10000 = FillRand(rand10000);
        rand1000 = FillRand(rand1000);
        rand100 = FillRand(rand100);
        rand10 = FillRand(rand10);

        int[] desc100000 = new int[100000];
        int[] desc10000 = new int[10000];
        int[] desc1000 = new int[1000];
        int[] desc100 = new int[100];
        int[] desc10 = new int[10];

        desc100000 = FillDescending(desc100000);
        desc10000 = FillDescending(desc10000);
        desc1000 = FillDescending(desc1000);
        desc100 = FillDescending(desc100);
        desc10 = FillDescending(desc10);

        int[] asc100000 = new int[100000];
        int[] asc10000 = new int[10000];
        int[] asc1000 = new int[1000];
        int[] asc100 = new int[100];
        int[] asc10 = new int[10];

        asc100000 = FillAscending(asc100000);
        asc10000 = FillAscending(asc10000);
        asc1000 = FillAscending(asc1000);
        asc100 = FillAscending(asc100);
        asc10 = FillAscending(asc10);

        Algorithms algo = new ();

        Console.WriteLine("======== TESTS ==========");

        Console.WriteLine("========== Bubble Sort ===========");
        Console.WriteLine("Rand 10: " + Time(algo.BubbleSort, rand10));
        Console.WriteLine("Rand 100: " + Time(algo.BubbleSort, rand100));
        Console.WriteLine("Rand 1000: " + Time(algo.BubbleSort, rand1000));
        Console.WriteLine("Rand 10_000: " + Time(algo.BubbleSort, rand10000));
        Console.WriteLine("Rand 100_000: " + Time(algo.BubbleSort, rand100000));
        Console.WriteLine("--------------------------");
        Console.WriteLine("Asc 10: " + Time(algo.BubbleSort, asc10));
        Console.WriteLine("Asc 100: " + Time(algo.BubbleSort, asc100));
        Console.WriteLine("Asc 1000: " + Time(algo.BubbleSort, asc1000));
        Console.WriteLine("Asc 10_000: " + Time(algo.BubbleSort, asc1000));
        Console.WriteLine("Asc 100_000: " + Time(algo.BubbleSort, asc100000));
        Console.WriteLine("--------------------------");
        Console.WriteLine("Desc 10: " + Time(algo.BubbleSort, desc10));
        Console.WriteLine("Desc 100: " + Time(algo.BubbleSort, desc100));
        Console.WriteLine("Desc 1000: " + Time(algo.BubbleSort, desc1000));
        Console.WriteLine("Desc 10_000: " + Time(algo.BubbleSort, desc10000));
        Console.WriteLine("Desc 100_000: " + Time(algo.BubbleSort, desc100000));
        Console.WriteLine("===================================");
        
        Console.WriteLine("========== Radix Sort ===========");
        Console.WriteLine("Rand 10: " + Time(algo.RadixSort, rand10));
        Console.WriteLine("Rand 100: " + Time(algo.RadixSort, rand100));
        Console.WriteLine("Rand 1000: " + Time(algo.RadixSort, rand1000));
        Console.WriteLine("Rand 10_000: " + Time(algo.RadixSort, rand10000));
        Console.WriteLine("Rand 100_000: " + Time(algo.RadixSort, rand100000));
        Console.WriteLine("--------------------------");
        Console.WriteLine("Asc 10: " + Time(algo.RadixSort, asc10));
        Console.WriteLine("Asc 100: " + Time(algo.RadixSort, asc100));
        Console.WriteLine("Asc 1000: " + Time(algo.RadixSort, asc1000));
        Console.WriteLine("Asc 10_000: " + Time(algo.RadixSort, asc1000));
        Console.WriteLine("Rand 100_000: " + Time(algo.RadixSort, asc100000));
        Console.WriteLine("--------------------------");
        Console.WriteLine("Desc 10: " + Time(algo.RadixSort, desc10));
        Console.WriteLine("Desc 100: " + Time(algo.RadixSort, desc100));
        Console.WriteLine("Desc 1000: " + Time(algo.RadixSort, desc1000));
        Console.WriteLine("Desc 10_000: " + Time(algo.RadixSort, desc10000));
        Console.WriteLine("Rand 100_000: " + Time(algo.RadixSort, desc100000));
        Console.WriteLine("===================================");
    }

    static TimeSpan Time(Delegate method, params int[] arr)
    {
        Stopwatch clock = new Stopwatch();
        clock.Start();
        method.DynamicInvoke(arr);
        clock.Stop();
        return clock.Elapsed;
    }

    static int[] FillRand(int[] arr)
    {
        Random rnd = new();

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(1, 10000);
        }

        return arr;
    }

    static int[] FillAscending(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        return arr;
    }

    static int[] FillDescending(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = arr.Length - i;
        }

        return arr;
    }
}