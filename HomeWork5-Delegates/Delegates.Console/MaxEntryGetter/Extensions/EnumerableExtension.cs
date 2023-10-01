namespace Delegates.Console.MaxEntryGetter.Extensions
{
    internal static class EnumerableExtension
    {
        public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) where T : class
        {
            var maxValue = e.Max(getParameter);
            return e.Single(x => getParameter(x).Equals(maxValue));
        }
    }
}
