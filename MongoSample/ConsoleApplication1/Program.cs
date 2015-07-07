using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueFun();
        }

        static void QueueFun()
        {
            Queue q = new Queue();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue("sdfgsfg");
            q.Enqueue("dsfgdsfg");

            int count = q.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(q.Dequeue());
            }
            Console.ReadKey();
        }

        static void function()
        {
            BitArray myBA1 = new BitArray(5);

            BitArray myBA2 = new BitArray(5, false);

            byte[] myBytes = new byte[5] { 1, 2, 3, 4 , 5};
            BitArray myBA3 = new BitArray(myBytes);

            bool[] myBools = new bool[5] { true, false, true, true, false };
            BitArray myBA4 = new BitArray(myBools);

            int[] myInts = new int[8] { 6, 7, 8, 9, 10,3,8,09 };
            BitArray myBA5 = new BitArray(myInts);

            // Displays the properties and values of the BitArrays.
            //Console.WriteLine("myBA1");
            //Console.WriteLine("   Count:    {0}", myBA1.Count);
            //Console.WriteLine("   Length:   {0}", myBA1.Length);
            //Console.WriteLine("   Values:");
            //PrintValues(myBA1, 8);

            //Console.WriteLine("myBA2");
            //Console.WriteLine("   Count:    {0}", myBA2.Count);
            //Console.WriteLine("   Length:   {0}", myBA2.Length);
            //Console.WriteLine("   Values:");
            //PrintValues(myBA2, 8);

            //Console.WriteLine("myBA3");
            //Console.WriteLine("   Count:    {0}", myBA3.Count);
            //Console.WriteLine("   Length:   {0}", myBA3.Length);
            //Console.WriteLine("   Values:");
            //PrintValues(myBA3, 8);

            //Console.WriteLine("myBA4");
            //Console.WriteLine("   Count:    {0}", myBA4.Count);
            //Console.WriteLine("   Length:   {0}", myBA4.Length);
            //Console.WriteLine("   Values:");
            //PrintValues(myBA4, 8);

            Console.WriteLine("myBA5");
            Console.WriteLine("   Count:    {0}", myBA5.Count);
            Console.WriteLine("   Length:   {0}", myBA5.Length);
            Console.WriteLine("   Values:");
            PrintValues(myBA5, 8);
        }

        public static void PrintValues(IEnumerable myList, int myWidth)
        {
            int i = myWidth;
            foreach (Object obj in myList)
            {
                if (i <= 0)
                {
                    i = myWidth;
                    Console.WriteLine();
                }
                i--;
                Console.Write("{0,8}", obj);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}