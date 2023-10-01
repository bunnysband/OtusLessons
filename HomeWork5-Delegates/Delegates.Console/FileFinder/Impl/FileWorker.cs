namespace Delegates.Console.FileFinder.Impl
{
    internal class FileWorker : IWorker, IDisposable    
    {
        private readonly IFileFinder _fileFinder;

        public FileWorker(IFileFinder fileFinder)
        {
            _fileFinder = fileFinder;
        }

        public void StartWork()
        {
            _fileFinder.FileFound += OnFileFound;
        }

        public void StopWork()
        {
            _fileFinder.FileFound -= OnFileFound;
        }

        private void OnFileFound(object? sender, FileArgs e)
        {
            System.Console.WriteLine($"Found file {e.FileName}");
        }

        public void Dispose()
        {
            StopWork(); 
        }
    }
}
