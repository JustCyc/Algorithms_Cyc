using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_1
{
    class Program
    {
        // Тестовый класс для простого числа 
        public class TestCase_1
        {
            public int Number { get; set; }
            public string Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        public class TestCase_2
        {
            public int Number { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        // Функция для простого числа
        static string PrimeNumber(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Prime Number Must Be > 0");
            }
            int d = 0;
            int i = 2;

            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                i++;
            }
            if (d == 0)
            {
                return "Prime Number";
            }
            else
            {
                return "Not A Prime Number";
            }
        }
        // Тестовая функция для простого числа 
        static void Test_PrimeNumber(TestCase_1 testCase)
        {
            try
            {
                string result = PrimeNumber(testCase.Number);
                if (result == testCase.Expected)
                {
                    Console.WriteLine("Expected Result\n");
                }
                else
                {
                    Console.WriteLine("Unexpected Result\n");
                }
            }
            catch(Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine($"Expected Result, {ex.Message}\n");
                }
                else
                {
                    Console.WriteLine($"Unexpected Result, {ex.Message}\n");
                }
            }
        }
        // Нужно посчитать сложность функции 

        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;                                            // O(1)
            for (int i = 0; i < inputArray.Length; i++)             // O(N)
            {                                                       //
                for (int j = 0; j < inputArray.Length; j++)         // O(N)  
                {                                                   //
                    for (int k = 0; k < inputArray.Length; k++)     // O(N) три раза перебирает все элементы массива 
                    {                                               //
                        int y = 0;                                  //  
                                                                    //       
                        if (j != 0)                                 //  
                        {                                           //          
                            y = k / j;                              //  
                        }                                           //  
                        sum += inputArray[i] + i + k + j + y;       //  
                    }                                               //  
                }                                                   //
            }                                                       //
            return sum;                                             // O(1)
        }
        // Асимптотическая сложность равна O(1+N*N*N*+1) = O(N^3), так как при возрастании N превысит сумму постоянных величин

        // Рекурсивная функция вычисления числа Фибоначчи 
        static int Recursive_Fibonachi(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Index Number Must Be => 0");
            }
            if (num == 0 || num == 1)
            {
                return num;
            }
            else
            {
                return Recursive_Fibonachi(num - 1) + Recursive_Fibonachi(num - 2);
            }
        }
        // Цикл для вычисления числа Фибоначчи
        static int Cycle_Fibonachi(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Index Number Must Be => 0");
            }
            int previous = 0;
            int current = 1;
            int temporary;
            for (int i = 0; i < num; i++)
            {
                temporary = previous;
                previous = current;
                current += temporary;
            }
            return previous;
        }
        static void Test_Fibonachi(TestCase_2 testCase)
        {
            try
            {
            
                if (Recursive_Fibonachi(testCase.Number) == testCase.Expected && Cycle_Fibonachi(testCase.Number) == testCase.Expected)
                {
                        Console.WriteLine("Expected Result\n");
                }
                else
                {
                    Console.WriteLine("Unexpected Result\n");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine($"Expected Result, {ex.Message}\n");
                }
                else
                {
                    Console.WriteLine($"Unexpected Result, {ex.Message}\n");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Checking For Prime Number:\n");
            Console.ResetColor();
            var testCase_1 = new TestCase_1()
            {
                Number = 5,
                Expected = "Prime Number",
                ExpectedException = null
            };
            var testCase_2 = new TestCase_1()
            {
                Number = 18,
                Expected = "Not A Prime Number",
                ExpectedException = null
            };
            var testCase_3 = new TestCase_1()
            {
                Number = 103,
                Expected = "Prime Number",
                ExpectedException = null
            };
            var testCase_4 = new TestCase_1()
            {
                Number = 41,
                Expected = "Not A Prime Number",
                ExpectedException = null
            };
            var testCase_5 = new TestCase_1()
            {
                Number = 0,
                Expected = "Prime Number",
                ExpectedException = null
            };
            Test_PrimeNumber(testCase_1);
            Test_PrimeNumber(testCase_2);
            Test_PrimeNumber(testCase_3);
            Test_PrimeNumber(testCase_4);
            Test_PrimeNumber(testCase_5);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Checking For Fibonacci Number:\n");
            Console.ResetColor();
            var testCase1 = new TestCase_2()
            {
                Number = 0,
                Expected = 0,
                ExpectedException = null
            };
            var testCase2 = new TestCase_2()
            {
                Number = 2,
                Expected = 2,
                ExpectedException = null
            };
            var testCase3 = new TestCase_2()
            {
                Number = 7,
                Expected = 13,
                ExpectedException = null
            };
            var testCase4 = new TestCase_2()
            {
                Number = -1,
                Expected = 1,
                ExpectedException = null
            };
            var testCase5 = new TestCase_2()
            {
                Number = 12,
                Expected = 144,
                ExpectedException = null
            };
            Test_Fibonachi(testCase1);
            Test_Fibonachi(testCase2);
            Test_Fibonachi(testCase3);
            Test_Fibonachi(testCase4);
            Test_Fibonachi(testCase5);

            Console.ReadKey();

        }
    }
}
