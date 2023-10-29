using System.Text.RegularExpressions;

namespace ReadFiles.ConsoleApp.Impl
{
    internal class RegexpSpaceCounter : ISpaceCounter
    {
        public int CountSpaces(string source)
        {
            return new Regex("\\s").Matches(source).Count();
        }
    }
}
