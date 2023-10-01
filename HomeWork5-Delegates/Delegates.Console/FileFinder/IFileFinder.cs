using Delegates.Console.FileFinder.Impl;

namespace Delegates.Console.FileFinder
{
    internal interface IFileFinder
    {
        public event EventHandler<FileArgs>? FileFound;

        public void Find();
    }
}
