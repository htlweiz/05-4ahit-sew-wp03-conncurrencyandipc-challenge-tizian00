using System;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{
   
    static int threadACount = 0;
    static int threadBCount = 0;
    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 1: Zwei Threads – Zählen & Winner");
        Thread threadA = new Thread(CountUpThreadA);
        Thread threadB = new Thread(CountDownThreadB);
        
        threadA.Start();
        threadB.Start();
        threadA.Join();
        threadB.Join();
        if (threadACount > threadBCount)
        {
            Console.WriteLine("Thread A hat gewonnen!");
        }
        else if (threadBCount < threadACount)
        {
            Console.WriteLine("Thread B hat gewonnen!");
        }
        Console.WriteLine("Fertig");
        
    }
    
    private static void CountUpThreadA()
    {
        for (int i = 1; i <= 100; i++)
        {
            threadACount = i;
            if (threadACount == threadBCount)
            {
                Console.WriteLine($"Thread A: {threadACount}");
                Console.WriteLine($"Thread B: {threadBCount}");
                break;
            }
            Thread.Sleep(100);
        }
    }
    
    private static void CountDownThreadB()
    {
        for (int i = 100; i >= 1; i--)
        {
            threadBCount = i;
            if (threadBCount == threadACount)
            {
                Console.WriteLine($"Thread B: {threadBCount}");
                Console.WriteLine($"Thread A: {threadACount}");
                break;
            }
            Thread.Sleep(100);
        }
    }
}
