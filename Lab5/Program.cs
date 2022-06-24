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
        Console.WriteLine("Rand 1000 index: " + Time(algo.LinearSearch, rand1000, 60));
        Console.WriteLine("Rand 10_000 index: " + Time(algo.LinearSearch, rand10000, 60));
        Console.WriteLine("========================");

        Console.WriteLine();

        Console.WriteLine("===== Binary Search =====");
        Console.WriteLine("Rand 1000 index: " + Time(algo.BinarySearch, rand1000, 60));
        Console.WriteLine("Rand 10_000 index: " + Time(algo.BinarySearch, rand10000, 60));
        Console.WriteLine("========================");

        Console.WriteLine();

        Console.WriteLine("===== Break Search =====");
        Console.WriteLine("Rand 1000 index: " + Time(algo.BreakSearch, rand1000, 60));
        Console.WriteLine("Rand 10_000 index: " + Time(algo.BreakSearch, rand10000, 60));
        Console.WriteLine("========================");

        Console.WriteLine();

        string txt =
            "The old man was bent into a capital C, his head leaning so far forward that his beard nearly touched his knobby knees.";
        string pattern = "beard";
        string mTxt =
            "I'm in a band that does Metallica covers with our private parts - it's called Myphallica. Petrovache. I'm in a band that does Metallica covers with our private parts - it's called Myphallica. Petrovache. I don't need a big house, just a two-floor condo - you could say I have lofty expectations. Most streets are two-way streets...why does that make love so special?. To Catch A Predator would have been a great name for a Steve Irwin show. Mintslavicia. Smiling could easily be misinterpreted for showing your teeth to someone because they said something that made you happy. If Fantasy Hockey actually lived up to its name, every team would have Henrik Lundqvist and Joffrey Lupul on it. I have a moral code, but I haven't figured out how to read it yet. If a dog and cat had a baby together that grew up and worked a desk job he'd be a Cog in the machine. Why don't we call glasses duocles.";
        string pattern2 = "Steve Irwin";

        Console.WriteLine("===== Knuth-Morris-Pratt Search =====");
        Console.WriteLine("Simple text: " + Time(algo.KMPSearch, pattern, txt));
        Console.WriteLine("Medium text: " + Time(algo.KMPSearch, pattern2, mTxt));
        Console.WriteLine("========================");

        Console.WriteLine();

        Console.WriteLine("===== Boyer Moore Search =====");
        Console.WriteLine("Simple text: " + Time(algo.BMSearch, pattern, txt));
        Console.WriteLine("Medium text: " + Time(algo.BMSearch, pattern2, mTxt));
        Console.WriteLine("========================");

        Console.WriteLine();

        Console.WriteLine("===== Rabin Karp Search =====");
        Console.WriteLine("Simple text: " + Time(algo.RKSearch, pattern, txt, 1));
        Console.WriteLine("Medium text: " + Time(algo.RKSearch, pattern2, mTxt, 1));
        Console.WriteLine("========================");
    }

    static TimeSpan Time(Delegate method, string pattern, string text)
    {
        Stopwatch clock = new Stopwatch();
        clock.Start();
        method.DynamicInvoke(pattern, text);
        clock.Stop();
        return clock.Elapsed;
    }

    static TimeSpan Time(Delegate method, string pattern, string text, int q)
    {
        Stopwatch clock = new Stopwatch();
        clock.Start();
        method.DynamicInvoke(pattern, text, q);
        clock.Stop();
        return clock.Elapsed;
    }

    static TimeSpan Time(Delegate method, int[] arr, int key)
    {
        Stopwatch clock = new Stopwatch();
        clock.Start();
        method.DynamicInvoke(arr, key);
        clock.Stop();
        return clock.Elapsed;
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