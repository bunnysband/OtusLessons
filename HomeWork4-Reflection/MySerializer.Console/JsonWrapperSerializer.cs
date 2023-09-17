using MySerializer.Serializer;
using System.Text.Json;

namespace MySerializer.Console
{
    internal class JsonWrapperSerializer : IMySerializer
    {
        private readonly JsonSerializerOptions jsonSerializerOptions;
        public JsonWrapperSerializer()
        {
            jsonSerializerOptions = new JsonSerializerOptions
            {
                IncludeFields = true,
            };
        }

        public T? Deserialize<T>(string value) where T : class, new() => JsonSerializer.Deserialize<T>(value, jsonSerializerOptions);

        public string Serialize<T>(T obj) where T : class => JsonSerializer.Serialize(obj, jsonSerializerOptions);
    }
}
