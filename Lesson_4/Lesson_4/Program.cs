using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson_4
{
   
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadKey();
        }
    }
    public class TestSearch
    {

        public string RandomString { get; set; }
        public override bool Equals(object obj)
        {
            var user = obj as TestSearch;

            if (user == null)
                return false;

            return RandomString == user.RandomString;
        }
        public override int GetHashCode()
        {
            int RandomStringCode = RandomString?.GetHashCode() ?? 0;
            return RandomStringCode;
        }
        
        public static HashSet<TestSearch> ListToHashSet()
        {
            List<string> strList = GenString.ListString(10000, 8);
            var hashSet = new HashSet<TestSearch>();
            for (int i = 0; i < strList.Count; i++)
            {
                var strHash = new TestSearch() { RandomString = strList[i] };
                hashSet.Add(strHash);
            }
            return hashSet;
        }

        public static string[] ListToArray()
        {
            List<string> strList = GenString.ListString(10000, 8);
            int k = strList.Count;
            string[] arrayString = new string[k];
            for (int i = 0; i < strList.Count; i++)
            {
                arrayString[i] = strList[i];
            }
            return arrayString;
        }

        [Benchmark]
        public void HashSetSearch()
        {
            HashSet<TestSearch> hashSet = ListToHashSet();
            var rndString = new TestSearch() { RandomString = "19847635"};
            Console.WriteLine($"Contains string {hashSet.Contains(rndString)}");
        }
        [Benchmark]
        public void ArraySearch()
        {
            string[] arrayString = ListToArray();
            var result = false;
            var rndString = "19847635";
            foreach (var str in arrayString)
            {
                if (str == rndString)
                {
                    result = true;
                    Console.WriteLine($"contains string {result}");
                }
                else
                {
                    Console.WriteLine($"contains string {result}");
                }
            }

        }
    }
}