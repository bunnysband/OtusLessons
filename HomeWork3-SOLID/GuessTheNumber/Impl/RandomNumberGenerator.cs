namespace GuessTheNumber.Impl
{
    internal class RandomNumberGenerator : INumberGenerator
    {
        private readonly Settings settings;
        public RandomNumberGenerator(ISettingsProvider settingsProvider)
        {
            settings = settingsProvider.GetSettings();
        }
        public int Generate()
        {
            var random = new Random();
            return random.Next(settings.MinNumberLimit, settings.MaxNumberLimit);
        }
    }
}
