using System.Reflection;

namespace Delegates.Console.FileFinder.Impl
{
    internal class DirectoryFilesFinder : IFileFinder
    {
        public DirectoryFilesFinder()
        {
            DirectoryForSerach = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        }
        public DirectoryFilesFinder(string directoryForSerach)
        {
            DirectoryForSerach = directoryForSerach;
        }

        public string DirectoryForSerach { get; set; }

        public event EventHandler<FileArgs>? FileFound;

        public void Find()
        {
            foreach (var file in Directory.GetFiles(DirectoryForSerach))
            {
                FileFound?.Invoke(this, new FileArgs(file));
            }
        }
    }
}
