using Newtonsoft.Json;
using System;
using System.IO;

public abstract class MySerializeFormat
{
    public abstract void Serialize(object obj, string filePath);
    public abstract object Deserialize(string filePath, Type type);
}

public class JsonSerializeFormat : MySerializeFormat
{
    public override void Serialize(object obj, string filePath)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All // Включить информацию о типах
        };
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
        File.WriteAllText(filePath, json);
    }

    public override object Deserialize(string filePath, Type type)
    {
        string json = File.ReadAllText(filePath);
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All // Использовать информацию о типах при десериализации
        };
        return JsonConvert.DeserializeObject(json, type, settings);
    }
}
