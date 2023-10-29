namespace ReadFiles.ConsoleApp.Impl
{
    internal class ParallelFilesReadWorker : IDirectoryWorker
    {
        private readonly ISpaceCounter _spaceCounter;

        public ParallelFilesReadWorker(ISpaceCounter spaceCounter)
        {
            _spaceCounter = spaceCounter;
        }

        public void Work(string directory)
        {          
            Console.WriteLine($"Getting files from directory {directory}");
            var files = Directory.GetFiles(directory, "*", searchOption: SearchOption.AllDirectories);

            List<Task<int>> fileSpacesCounterTasks = new();

            foreach (var file in files)
            {
                fileSpacesCounterTasks.Add(ReadFileAndCountSpacesAsync(file));   
            }

            Task.WaitAll(fileSpacesCounterTasks.ToArray());
            Console.WriteLine($"Working finished");
        }

        private async Task<int> ReadFileAndCountSpacesAsync(string file)
        {
            Console.WriteLine($"Reading file {file}");
            using var reader = new StreamReader(file);
            var content = await reader.ReadToEndAsync();
            var spacesCount = _spaceCounter.CountSpaces(content);
            Console.WriteLine($"File {file} contains {spacesCount} spaces");
            return spacesCount;
        }
    }
}
