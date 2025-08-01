using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Alis.Core.Aspect.Data.Json
{
    public static class JsonNativeAot
    {
        public static string Serialize<T>(T instance) where T : IJsonSerializable
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");

            foreach ((string propertyName, string value) in instance.GetSerializableProperties())
            {
                jsonBuilder.Append($"\"{propertyName}\":\"{value}\",");
            }

            if (jsonBuilder.Length > 1)
            {
                jsonBuilder.Length--;
            }

            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        
        public static void SerializeToFile<T>(T instance, string nameFile, string relativePath) where T : IJsonSerializable
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");

            foreach ((string propertyName, string value) in instance.GetSerializableProperties())
            {
                jsonBuilder.Append($"\"{propertyName}\":\"{value}\",");
            }

            if (jsonBuilder.Length > 1)
            {
                jsonBuilder.Length--;
            }

            jsonBuilder.Append("}");
            string json = jsonBuilder.ToString();
            string path = Path.Combine(Environment.CurrentDirectory, relativePath);
            string filePath = Path.Combine(path, $"{nameFile}.json");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Serialized {typeof(T).Name} to {filePath}");
        }

        public static T Deserialize<T>(string json) where T : IJsonSerializable, IJsonDesSerializable<T>, new()
        {
            T instance = new T();
            Dictionary<string, string> properties = new Dictionary<string, string>();
            string[] parts = json.Trim('{', '}').Split(',');

            foreach (string part in parts)
            {
                string[] keyValue = part.Split(':');
                string key = keyValue[0].Trim('"');
                string value = keyValue[1].Trim('"');
                properties[key] = value;
            }
            
            return instance.CreateFromProperties(properties);
        }

        public static T DeserializeFromFile<T>(string generalSettingName, string data) where T : IJsonSerializable, IJsonDesSerializable<T>, new()
        {
            string path = Path.Combine(Environment.CurrentDirectory, data);
            string filePath = Path.Combine(path, $"{generalSettingName}.json");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File {filePath} not found.");
            }

            string json = File.ReadAllText(filePath);
            return Deserialize<T>(json);
        }
    }
}