namespace Delegates.Console.FileFinder.Impl
{
    internal class FileArgs : EventArgs
    {
        public FileArgs(string fileName)
        {
            FileName = fileName;
        }
        public string? FileName { get; set; }
    }
}
