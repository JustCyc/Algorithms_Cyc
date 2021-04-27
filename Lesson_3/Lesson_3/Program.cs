using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;


namespace Lesson_3
{
    class Program
    {
        public PointClass[] arrayClass = GenPointClass();
        public PointStruct[] arrayStruct = GenPointStruct();
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadKey();
        }

        public static PointClass[] GenPointClass()
        {
            //Random rnd = new Random();
            var point_1 = new PointClass() { _x = 21, _y = 15 };
            var point_2 = new PointClass() { _x = 13, _y = 5 };
            var point_array = new PointClass[2];
            point_array[0] = point_1;
            point_array[1] = point_2;
            return point_array;
        }
        public static PointStruct[] GenPointStruct()
        {
            Random rnd = new Random();
            var point_1 = new PointStruct() { _x = rnd.Next(0, 50), _y = rnd.Next(0, 50) };
            var point_2 = new PointStruct() { _x = rnd.Next(0, 50), _y = rnd.Next(0, 50) };
            var point_array = new PointStruct[2];
            point_array[0] = point_1;
            point_array[1] = point_2;
            return point_array;
        }
        public class PointClass
        {
            public int _x;
            public int _y;
        }

        public struct PointStruct
        {
            public int _x;
            public int _y;
        }

        public float PointDist_ClassFloat(PointClass[] pointArray)
        {
            float x = pointArray[0]._x - pointArray[1]._x;
            float y = pointArray[0]._y - pointArray[1]._y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public float PointDist_StructFloat(PointStruct[] pointArray)
        {
            float x = pointArray[0]._x - pointArray[1]._x;
            float y = pointArray[0]._y - pointArray[1]._y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public double PointDist_StructDouble(PointStruct[] pointArray)
        {
            double x = pointArray[0]._x - pointArray[1]._x;
            double y = pointArray[0]._y - pointArray[1]._y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public float PointDistShort_StructFloat(PointStruct[] pointArray)
        {
            float x = pointArray[0]._x - pointArray[1]._x;
            float y = pointArray[0]._y - pointArray[1]._y;
            return (x * x) + (y * y);
        }
        //[Benchmark]
        //public void Test_ClassFloat(PointClass[] arrayClass)
        //{
        //    PointDist_ClassFloat(arrayClass);
        //}
        [Benchmark]
        public void Test_StructFloat(PointStruct[] arrayStruct)
        {
            PointDist_StructFloat(arrayStruct);
        }
        [Benchmark]
        public void Test_StructDouble(PointStruct[] arrayStruct)
        {
            PointDist_StructDouble(arrayStruct);
        }
        [Benchmark]
        public void Test_StructFloatShort(PointStruct[] arrayStruct)
        {
            PointDistShort_StructFloat(arrayStruct);
        }
    }
}
