using MySerializer.Console;
using MySerializer.Serializer;
using System.Diagnostics;

RunSerializerDemo(new MyCsvSerializer(), "FTest.csv");
RunSerializerDemo(new JsonWrapperSerializer(), "FTest.json");

Console.ReadKey();

static void RunSerializerDemo(IMySerializer serializer, string fileToDeserialize, int iterationsCount = 10000)
{
    var serializerName = serializer.GetType().Name;
    Console.WriteLine($"--- Run {serializerName} ---");
    var stopwatch = new Stopwatch();

    // Serialization
    F serializableObj = F.Get();
    string? serializedValue = null;
    
    stopwatch.Start();

    for (int i = 0; i < iterationsCount; i++)
    {
        serializedValue = serializer.Serialize(serializableObj);
    }

    stopwatch.Stop();

    Console.WriteLine($"{serializerName} serialized value:");
    Console.WriteLine(serializedValue ?? "Couldn't serialize obj");
    Console.WriteLine($"{serializerName} serialization time on {iterationsCount} iterations = {Math.Round(stopwatch.Elapsed.TotalMilliseconds)}");

    // Deserialization
    var stringToDeserialize = File.ReadAllText(fileToDeserialize);
    F? deserializedObj = null;

    stopwatch.Restart();
    for (int i = 0; i < iterationsCount; i++)
    {
        deserializedObj = serializer.Deserialize<F>(stringToDeserialize);
    }

    stopwatch.Stop();
    Console.WriteLine($"{serializerName} deserialized object:");
    Console.WriteLine(deserializedObj?.ToString() ?? "Couldn't serialize obj");
    Console.WriteLine($"{serializerName} deserialization time on {iterationsCount} iterations = {Math.Round(stopwatch.Elapsed.TotalMilliseconds)}");
}