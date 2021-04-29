using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_4
{
    public class GenString
    {
        public static string GenericString(string set, int lenght)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(lenght - 1);
            int pos;
            for (int i = 0; i < lenght; i++)
            {
                pos = rnd.Next(0, set.Length - 1);
                sb.Append(set[pos]);
            }
            return sb.ToString();
        }
        public static List<string> ListString(int num, string set, int lenght)
        {
            List<string> stringList = new List<string>();
            for (int i = 0; i < num; i++)
            {
                string newString = GenericString(set, lenght);
                stringList.Add(newString);
            }
            return stringList;
        }
        //public static void DisplayString(List<string> strList)
        //{
        //    for(int i = 0; i < strList.Count; i++)
        //    {
        //        Console.WriteLine($"{strList[i]}\n\r");
        //    }
        //}
    }
}
