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
                // Si el value empieza por { o [, NO poner comillas
                if (value != null && (value.StartsWith("{") || value.StartsWith("[")))
                    jsonBuilder.Append($"\"{propertyName}\":{value},");
                else
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

    public static T Deserialize<T>(string json)
    where T : IJsonSerializable, IJsonDesSerializable<T>, new()
{
    var properties = ParseJsonToDictionary(json);
    return new T().CreateFromProperties(properties);
}

public static Dictionary<string, string> ParseJsonToDictionary(string json)
    {
        var dict = new Dictionary<string, string>();
        if (string.IsNullOrEmpty(json)) return dict;

        int i = 0;
        int n = json.Length;

        SkipWhitespace(json, ref i);
        // skip optional leading '{'
        if (i < n && json[i] == '{') i++;

        while (true)
        {
            SkipWhitespace(json, ref i);
            if (i >= n) break;
            if (json[i] == '}') { i++; break; }

            // find key (must be a JSON string)
            while (i < n && json[i] != '"') i++;
            if (i >= n) break;
            string key = ReadJsonString(json, ref i);

            SkipWhitespace(json, ref i);
            // skip colon
            while (i < n && json[i] != ':') i++;
            if (i < n && json[i] == ':') i++;
            SkipWhitespace(json, ref i);

            string value;

            if (i < n && (json[i] == '{' || json[i] == '['))
            {
                // raw object/array
                value = ReadRawJsonValue(json, ref i);
            }
            else if (i < n && json[i] == '"')
            {
                // a JSON string: read and unescape it
                string inner = ReadJsonString(json, ref i);
                // if the inner string *contains* JSON (starts with { or [), keep it as-is (unescaped)
                value = inner;
            }
            else
            {
                // primitive (number, true, false, null)
                int startVal = i;
                while (i < n && json[i] != ',' && json[i] != '}') i++;
                value = json.Substring(startVal, i - startVal).Trim();
            }

            dict[key] = value;

            // move past comma if present
            SkipWhitespace(json, ref i);
            if (i < n && json[i] == ',') i++;
        }

        return dict;
    }

    private static void SkipWhitespace(string s, ref int i)
    {
        while (i < s.Length && char.IsWhiteSpace(s[i])) i++;
    }

    private static bool IsEscaped(string s, int pos)
    {
        // cuenta backslashes justo antes de pos
        int cnt = 0;
        int j = pos - 1;
        while (j >= 0 && s[j] == '\\') { cnt++; j--; }
        return (cnt % 2) == 1;
    }

    private static string ReadJsonString(string s, ref int i)
    {
        if (s[i] != '"') throw new InvalidOperationException("Expected '\"' at start of JSON string.");
        i++; // skip opening quote
        var sb = new StringBuilder();
        int n = s.Length;

        while (i < n)
        {
            char c = s[i];
            if (c == '"' && !IsEscaped(s, i))
            {
                i++; // skip closing quote
                break;
            }

            if (c == '\\') // escape sequence
            {
                i++;
                if (i >= n) break;
                char esc = s[i];
                switch (esc)
                {
                    case '"': sb.Append('"'); break;
                    case '\\': sb.Append('\\'); break;
                    case '/': sb.Append('/'); break;
                    case 'b': sb.Append('\b'); break;
                    case 'f': sb.Append('\f'); break;
                    case 'n': sb.Append('\n'); break;
                    case 'r': sb.Append('\r'); break;
                    case 't': sb.Append('\t'); break;
                    case 'u':
                        // \uXXXX
                        if (i + 4 < n)
                        {
                            string hex = s.Substring(i + 1, 4);
                            if (int.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out int code))
                                sb.Append((char)code);
                            i += 4;
                        }
                        break;
                    default:
                        // unknown escape — keep literally
                        sb.Append(esc);
                        break;
                }
                i++;
            }
            else
            {
                sb.Append(c);
                i++;
            }
        }

        return sb.ToString();
    }

    private static string ReadRawJsonValue(string s, ref int i)
    {
        // s[i] == '{' or '['
        char open = s[i];
        char close = open == '{' ? '}' : ']';
        int start = i;
        int n = s.Length;
        int depth = 0;
        bool inString = false;

        while (i < n)
        {
            char c = s[i];
            if (c == '"' && !IsEscaped(s, i))
            {
                inString = !inString;
                i++;
                continue;
            }

            if (!inString)
            {
                if (c == open) depth++;
                else if (c == close)
                {
                    depth--;
                    i++;
                    if (depth == 0) break;
                    continue;
                }
            }

            i++;
        }

        // substring from start to i (i already points after matching close)
        if (i > start)
            return s.Substring(start, i - start);
        return "";
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