using ArraySum.ConsoleApp;
using ArraySum.ConsoleApp.Impl;
using System.Diagnostics;

WorkWithArray(100000);
WorkWithArray(1000000);
WorkWithArray(10000000);

Console.ReadLine();


static void WorkWithArray(int arrayItemsCount)
{
    var array = RandomArrayGenerator.Generate(arrayItemsCount);
    Console.WriteLine($"Calculate sum for array with {arrayItemsCount} items");

    SumArray(array, new SimpleArraySumCalculator());
    SumArray(array, new ParallelThreadArraySumCalculator());
    SumArray(array, new ParallelLinqArraySumCalculator());
    Console.WriteLine();
}

static void SumArray(int[] arrayToCalculate, IArraySumCalculator sumCalculator)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    var sum = sumCalculator.CalculateSum(arrayToCalculate);
    stopwatch.Stop();
    Console.WriteLine($"{sumCalculator.GetType().Name}. Sum = {sum}. Working time: {stopwatch.Elapsed}");
}