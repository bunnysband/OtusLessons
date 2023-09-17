using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace MySerializer.Serializer;

public class MyCsvSerializer : IMySerializer
{
    private const string DefaultSeparator = ";";
    private readonly SerializeOptions _serializeOptions;

    public MyCsvSerializer()
    {
        _serializeOptions = new SerializeOptions(DefaultSeparator);
    }

    public MyCsvSerializer(SerializeOptions serializeOptions)
    {
        _serializeOptions = serializeOptions;
    }

    public string Serialize<T>(T obj) where T : class
    {
        var separator = _serializeOptions.Separator;
        var value = new StringBuilder();
        var type = typeof(T);

        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        var fieldNames = fields.Select(f => f.Name);
        var fieldValues = fields.Select(f => f.GetValue(obj)?.ToString() ?? string.Empty);
        var propNames = props.Select(p => p.Name);
        var propValues = props.Select(p => p.GetValue(obj)?.ToString() ?? string.Empty);

        return value
            .AppendJoin(separator, fieldNames.Union(propNames))
            .AppendLine()
            .AppendJoin(separator, fieldValues.Union(propValues))
            .ToString();
    }

    public T? Deserialize<T>(string value) where T : class, new()
    {
        var separator = _serializeOptions.Separator;
        var splitLines = value.Split(Environment.NewLine);
        var names = splitLines[0].Split(separator);
        var values = splitLines[1].Split(separator);

        var type = typeof(T);
        T? obj = new();

        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach ( var name in names )
        {
            var objValue = values[Array.IndexOf(names, name)];
            var field = fields.SingleOrDefault(f => f.Name == name);           

            if ( field is not null)
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(field.FieldType);
                object fieldValue = typeConverter.ConvertFromString(objValue)
                    ?? throw new InvalidOperationException($"Couldn't convert sting value {objValue} to {nameof(field.FieldType)} type");
                field.SetValue(obj, fieldValue);
            }
            else
            {
                var prop = props.SingleOrDefault(p => p.Name == name) 
                    ?? throw new InvalidOperationException($"Couldn't find any property of field with name {name} in {nameof(type)} type");

                TypeConverter typeConverter = TypeDescriptor.GetConverter(prop.PropertyType);
                object propValue = typeConverter.ConvertFromString(objValue)
                    ?? throw new InvalidOperationException($"Couldn't convert sting value {objValue} to {nameof(field.FieldType)} type");
                prop.SetValue(obj, objValue);
            }
        }

        return obj;
    }
}
