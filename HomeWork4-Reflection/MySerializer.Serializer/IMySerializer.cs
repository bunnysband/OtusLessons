namespace MySerializer.Serializer;

public interface IMySerializer
{
    T? Deserialize<T>(string value) where T : class, new();
    string Serialize<T>(T obj) where T : class;
}
