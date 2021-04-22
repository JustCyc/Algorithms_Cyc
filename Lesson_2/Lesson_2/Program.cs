using System;

namespace Lesson_2
{
    class Program
    {
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
        public class TestCase_BinarySearch
        {
            public int search_num { get; set; }
            public int[] intArray { get; set; }
            public int expected_pos { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static void Test_Binary(TestCase_BinarySearch testCase)
        {
            try
            {
                int result = BinarySearch(testCase.intArray, testCase.search_num);
                if (result == testCase.expected_pos)
                {
                    Console.WriteLine("Expected Result\n\r");
                }
                else
                {
                    Console.WriteLine("Unexpected Result\n\r");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine($"Expected Result, {ex.Message}\n\r");
                }
                else
                {
                    Console.WriteLine($"Unexpected Result, {ex.Message}\n\r");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Checking For Binary Search:\n\r");
            Console.ResetColor();
            var testCase_1 = new TestCase_BinarySearch()
            {
                search_num = 13,
                intArray = new int[6] { 87, 10, 95, 42, 13, 2 },
                expected_pos = 4,
                ExpectedException = null
            };
            Test_Binary(testCase_1);
            Console.ReadKey();
        }
    }
}
