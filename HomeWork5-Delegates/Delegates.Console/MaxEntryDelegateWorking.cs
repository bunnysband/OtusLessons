using Delegates.Console.MaxEntryGetter;
using Delegates.Console.MaxEntryGetter.Extensions;

namespace Delegates.Console
{
    internal class MaxEntryDelegateWorking
    {
        public void Show()
        {
            var random = new Random();
            var testCollection = new List<TestEntry>
            {
                new TestEntry("1st", NextFloat(random)),
                new TestEntry("2d", NextFloat(random)),
                new TestEntry("3th", NextFloat(random))
            };

            testCollection.ForEach(System.Console.WriteLine);
            var maxValue = testCollection.GetMax(entry => entry.Identity);

            System.Console.WriteLine($"Max entry is: {maxValue}");
        }

        private float NextFloat(Random random)
        {
            var buffer = new byte[4];
            random.NextBytes(buffer);
            return BitConverter.ToSingle(buffer, 0);
        }
    }
}
