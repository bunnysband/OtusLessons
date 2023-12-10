namespace ArraySum.ConsoleApp
{
    internal class RandomArrayGenerator
    {
        public static int[] Generate(int itemsCount)
        {
            var generated = new int[itemsCount];
            var random = new Random();
            for (int i = 0; i < itemsCount; i++)
            {
                generated[i] = random.Next(0, 100);
            }
            return generated;
        }
    }
}
