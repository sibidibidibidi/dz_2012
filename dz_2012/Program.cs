using System;
using System.Data;
using System.Reflection;

namespace dz_2012
{
    class Program
    {
        delegate void callback(int[] arr);

        static void cheven(int[] arr)
        {
            Console.WriteLine("Even: ");
            foreach (int i in arr)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        static void chodd(int[] arr)
        {
            Console.WriteLine("Odd: ");
            foreach (int i in arr)
            {
                if (i % 2 != 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        public static bool isprime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        static void chprime(int[] arr)
        {
            Console.WriteLine("Prime: ");
            foreach (int i in arr)
            {
                if (isprime(i)) Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        static bool perfectsquare(int x)
        {
            int s = (int)Math.Sqrt(x);
            return (s * s == x);
        }

        static void chfibonacci(int[] arr)
        {
            Console.WriteLine("Fibonacci: ");
            foreach (int i in arr)
            {
                if (perfectsquare(5 * i * i + 4) || perfectsquare(5 * i * i - 4))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введіть елементи масиву (через пробіл):");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] arr = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                arr[i] = int.Parse(parts[i]);
            }

            callback result = cheven;
            result += chodd;
            result += chprime;
            result += chfibonacci;

            result(arr);

            Console.ReadLine(); 
        }
    }
}

