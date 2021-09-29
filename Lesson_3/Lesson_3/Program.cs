using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;


namespace Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadKey();
        }
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
    public class BenchmarkClass
    {
        public static PointClass[] GenPointClass()
        {
            Random rnd = new Random();
            var point_1 = new PointClass() { _x = rnd.Next(0, 50), _y = rnd.Next(0, 50) };
            var point_2 = new PointClass() { _x = rnd.Next(0, 50), _y = rnd.Next(0, 50) };
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
        public PointClass[] arrayClass = GenPointClass();
        public PointStruct[] arrayStruct = GenPointStruct();
        public float PointDist_ClassFloat(PointClass[] arrayClass)
        {
            float x = arrayClass[0]._x - arrayClass[1]._x;
            float y = arrayClass[0]._y - arrayClass[1]._y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public float PointDist_StructFloat(PointStruct[] arrayStruct)
        {
            float x = arrayStruct[0]._x - arrayStruct[1]._x;
            float y = arrayStruct[0]._y - arrayStruct[1]._y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public double PointDist_StructDouble(PointStruct[] arrayStruct)
        {
            double x = arrayStruct[0]._x - arrayStruct[1]._x;
            double y = arrayStruct[0]._y - arrayStruct[1]._y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public float PointDistShort_StructFloat(PointStruct[] arrayStruct)
        {
            float x = arrayStruct[0]._x - arrayStruct[1]._x;
            float y = arrayStruct[0]._y - arrayStruct[1]._y;
            return (x * x) + (y * y);
        }
        [Benchmark]
        public void Test_ClassFloat()
        {
            PointDist_ClassFloat(arrayClass);
        }
        [Benchmark]
        public void Test_StructFloat()
        {
            PointDist_StructFloat(arrayStruct);
        }
        [Benchmark]
        public void Test_StructDouble()
        {
            PointDist_StructDouble(arrayStruct);
        }
        [Benchmark]
        public void Test_StructFloatShort()
        {
            PointDistShort_StructFloat(arrayStruct);
        }
    }
}



