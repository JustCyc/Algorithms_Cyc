using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_4
{
    public class GenString
    {
        public static string set = "1234567890";
        public static string GenericString(int lenght)
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
        public static List<string> ListString(int num, int lenght)
        {
            List<string> stringList = new List<string>();
            for (int i = 0; i < num; i++)
            {
                string newString = GenericString(lenght);
                if (stringList.Contains(newString))
                {
                    i--;
                }
                else
                {
                    stringList.Add(newString);
                }
            }
            return stringList;
        }
    }
}
