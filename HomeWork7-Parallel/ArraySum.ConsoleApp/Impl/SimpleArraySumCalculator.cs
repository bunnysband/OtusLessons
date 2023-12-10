namespace ArraySum.ConsoleApp.Impl
{
    internal class SimpleArraySumCalculator : IArraySumCalculator
    {
        public int CalculateSum(int[] arrayToCalulate)
        {
            int sum = 0;
            foreach (var item in arrayToCalulate) 
            { 
                sum += item;
            }
            return sum;
        }
    }
}
