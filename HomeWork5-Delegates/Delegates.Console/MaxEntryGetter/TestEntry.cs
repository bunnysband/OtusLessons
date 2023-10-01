namespace Delegates.Console.MaxEntryGetter
{
    internal class TestEntry
    {
        public TestEntry(string name, float identity)
        {
            Identity = identity;
            Name = name;
        }

        public string Name { get; }
        public float Identity { get; }

        public override string ToString()
        {
            return $"{Name} {Identity}";
        }
    }
}
