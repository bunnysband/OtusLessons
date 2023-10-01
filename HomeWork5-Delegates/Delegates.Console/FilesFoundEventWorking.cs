using Delegates.Console.FileFinder;

namespace Delegates.Console
{
    internal class FilesFoundEventWorking
    {
        private readonly IFileFinder _fileFinder;
        private readonly IWorker _worker;

        public FilesFoundEventWorking(IFileFinder fileFinder, IWorker worker)
        {
            _fileFinder = fileFinder;
            _worker = worker;
        }
        public void Show()
        {
            _worker.StartWork();
            _fileFinder.Find();
        }
    }
}
