namespace ArraySum.ConsoleApp.Impl
{
    internal class ParallelThreadArraySumCalculator : IArraySumCalculator
    {
        private const int ThreadsNumber = 8;
        public int CalculateSum(int[] arrayToCalulate)
        {
            var partNumber = arrayToCalulate.Length / ThreadsNumber + 1;

            var threads = new Thread[ThreadsNumber];
            var sum = new List<int>();

            for (int i = 0; i < ThreadsNumber; Interlocked.Increment(ref i))
            {
                var index = i;
                var elementsNumber = (arrayToCalulate.Length - index * partNumber) < partNumber ? (arrayToCalulate.Length - index * partNumber) : partNumber;
                Thread thread = new(x =>
                {
                    var newArray = new ArraySegment<int>(arrayToCalulate, index * partNumber, elementsNumber).ToArray();
                    sum.Add(CalculateInternal(newArray));
                });

                threads[i] = thread;
            }

            for (int j = 0; j < ThreadsNumber; Interlocked.Increment(ref j))
            {
                threads[j].Start();
                threads[j].Join();
            }

            return CalculateInternal([.. sum]);
        }
        private static int CalculateInternal(int[] arrayToCalulate)
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
