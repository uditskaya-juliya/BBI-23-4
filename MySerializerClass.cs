using Newtonsoft.Json;
using System;
using System.IO;

public abstract class MySerializeFormat<T>
{
    public abstract void Serialize(T obj, string filePath);
    public abstract T Deserialize(string filePath);
}

public class JsonSerializeFormat<T> : MySerializeFormat<T>
{
    public override void Serialize(T obj, string filePath)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All 
        };
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
        File.WriteAllText(filePath, json);
    }

    public override T Deserialize(string filePath)
    {
        string json = File.ReadAllText(filePath);
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All 
        };
        return JsonConvert.DeserializeObject<T>(json, settings);
    }
}
