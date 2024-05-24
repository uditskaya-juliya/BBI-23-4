using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

public abstract class MySerializeFormat
{
    public abstract void Serialize(object obj, string filePath);
    public abstract object Deserialize(string filePath, Type type);
}

public class JsonSerializeFormat : MySerializeFormat
{
    public override void Serialize(object obj, string filePath)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public override object Deserialize(string filePath, Type type)
    {
        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject(json, type);
    }
}

public class XmlSerializeFormat : MySerializeFormat
{
    public override void Serialize(object obj, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(obj.GetType());
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, obj);
        }
    }

    public override object Deserialize(string filePath, Type type)
    {
        XmlSerializer serializer = new XmlSerializer(type);
        using (StreamReader reader = new StreamReader(filePath))
        {
            return serializer.Deserialize(reader);
        }
    }
}

public class BinarySerializeFormat : MySerializeFormat
{
    public override void Serialize(object obj, string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, obj);
        }
    }

    public override object Deserialize(string filePath, Type type)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            return formatter.Deserialize(stream);
        }
    }
}
