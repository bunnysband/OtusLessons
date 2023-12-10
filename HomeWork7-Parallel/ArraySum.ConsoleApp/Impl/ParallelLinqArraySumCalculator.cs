namespace ArraySum.ConsoleApp.Impl
{
    internal class ParallelLinqArraySumCalculator : IArraySumCalculator
    {
        public int CalculateSum(int[] arrayToCalulate)
        {
            return CalculateInternal(arrayToCalulate).Single();

            int[] CalculateInternal(int[] array)
            {
                if (array.Length == 1)
                    return array;
                var newArrayLength = array.Length % 2 == 0 ? array.Length / 2 : array.Length / 2 + 1;
                var newArray = new int[newArrayLength];
                Parallel.For(0, array.Length/2, x => newArray[x] = array[x * 2] + array[x * 2 + 1]);

                if (array.Length % 2 != 0)
                {
                    newArray[newArrayLength - 1] = array[^1];
                }
                return CalculateInternal(newArray);
            }
        }
    }
}
