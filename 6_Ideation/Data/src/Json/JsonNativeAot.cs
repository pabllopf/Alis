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
         var properties = ParseJsonToDictionary(json);
         return instance.CreateFromProperties(properties);
     }
     
     // Parser simple que respeta objetos y arrays anidados
     private static Dictionary<string, string> ParseJsonToDictionary(string json)
     {
         var dict = new Dictionary<string, string>();
         int i = 0;
         while (i < json.Length)
         {
             // Buscar clave
             while (i < json.Length && json[i] != '\"') i++;
             if (i >= json.Length) break;
             int startKey = ++i;
             while (i < json.Length && json[i] != '\"') i++;
             string key = json.Substring(startKey, i - startKey);
             i++; // Saltar comilla
     
             // Buscar dos puntos
             while (i < json.Length && json[i] != ':') i++;
             i++; // Saltar dos puntos
     
             // Buscar valor (puede ser string, objeto o array)
             while (i < json.Length && char.IsWhiteSpace(json[i])) i++;
             int startValue = i;
             if (json[i] == '\"')
             {
                 // Valor string
                 startValue++;
                 i++;
                 while (i < json.Length && json[i] != '\"') i++;
                 string value = json.Substring(startValue, i - startValue);
                 dict[key] = value;
                 i++;
             }
             else if (json[i] == '{' || json[i] == '[')
             {
                 // Valor objeto o array
                 char open = json[i];
                 char close = open == '{' ? '}' : ']';
                 int depth = 0;
                 int valueStart = i;
                 do
                 {
                     if (json[i] == open) depth++;
                     if (json[i] == close) depth--;
                     i++;
                 } while (i < json.Length && depth > 0);
                 string value = json.Substring(valueStart, i - valueStart);
                 dict[key] = value;
             }
             else
             {
                 // Valor simple (número, bool)
                 int valueStart = i;
                 while (i < json.Length && json[i] != ',' && json[i] != '}') i++;
                 string value = json.Substring(valueStart, i - valueStart).Trim();
                 dict[key] = value;
             }
     
             // Saltar coma
             while (i < json.Length && (json[i] == ',' || char.IsWhiteSpace(json[i]))) i++;
         }
         return dict;
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