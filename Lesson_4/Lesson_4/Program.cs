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
            //GenString.DisplayString(strList);

            //TestSearch.ArraySearch(strList);
            //TestSearch.HashSetSearch(strList);
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadKey();
        }
    }
    public class TestSearch
    {
        public string RandomString { get; set; }
        public List<string> strList = GenString.ListString(100, "qwertyuiopasdfghjklzxcvbnm1029384756", 6);
        //public HashSet<TestSearch> hashSet;
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
        //public TestSearch ListToHashSet(List<string> strList)
        //{
        //    var hashSet = new HashSet<TestSearch>();
        //    for (int i = 0; i < strList.Count; i++)
        //    {
        //        var strHash = new TestSearch() { RandomString = strList[i] };
        //        hashSet.Add(strHash);
        //    }
        //    return hashSet;
        //}
    

        [Benchmark]
        public void HashSetSearch()
        {
            Random rnd = new Random();
            var hashSet = new HashSet<TestSearch>();
            for (int i = 0; i < strList.Count; i++)
            {
                var strHash = new TestSearch() { RandomString = strList[i] };
                hashSet.Add(strHash);
            }
            var rndString = new TestSearch() { RandomString = strList[rnd.Next(0, 100)] };
            Console.WriteLine($"contains string {hashSet.Contains(rndString)}, {rndString.RandomString}");
        }
        [Benchmark]
        public void ArraySearch()
        {
            var result = false;
            Random rnd = new Random();
            int k = strList.Count;
            string[] arrayString = new string[k];
            for (int i = 0; i < strList.Count; i++)
            {
                arrayString[i] = strList[i];
            }
            var rndString = arrayString[rnd.Next(0, 100)];
            foreach (var str in arrayString)
            {
                if (str == rndString)
                {
                    result = true;
                    Console.WriteLine($"contains string {result}, {str}");
                }
                else
                {
                    Console.WriteLine($"contains string {result}, {str}");
                }
            }

        }
    }
}