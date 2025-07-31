// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneralSetting.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Ecs.Systems.Configuration.General
{
    /// <summary>
    /// The general setting class
    /// </summary>
    /// <seealso cref="IGeneralSetting"/>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GeneralSetting(
        bool debug = false,
        string name = "Default Name",
        string description = "Default Description",
        string version = "0.0.0",
        string author = "Pablo Perdomo Falcón",
        string license = "GPL-3.0 license",
        string icon = "app.jpeg") : IGeneralSetting, IJsonSerializable, IJsonDesSerializable<GeneralSetting>
    {
        public GeneralSetting() : this(false, "Default Name", "Default Description", "0.0.0", "Pablo Perdomo Falcón", "GPL-3.0 license", "app.jpeg")
        {
        }
        
        public bool Debug { get; set; } = debug;
        
        public string Name { get; set; } = name;
        
        public string Description { get; set; } = description;
        
        public string Version { get; set; } = version;
        
        public string Author { get; set; } = author;
        
        public string License { get; set; } = license;
        
        public string Icon { get; set; } = icon;

        internal void OnSave() => TinyJson.SerializeToFile(this, nameof(GeneralSetting), "Data");
        
        internal GeneralSetting OnLoad() => TinyJson.DeserializeFromFile<GeneralSetting>(nameof(GeneralSetting), "Data");
        
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Debug), Debug.ToString());
            yield return (nameof(Name), Name);
            yield return (nameof(Description), Description);
            yield return (nameof(Version), Version);
            yield return (nameof(Author), Author);
            yield return (nameof(License), License);
            yield return (nameof(Icon), Icon);
        }
        
        public GeneralSetting CreateFromProperties(Dictionary<string, string> properties)
        {
            return new GeneralSetting(
                debug: properties.TryGetValue(nameof(Debug), out string debugValue) && bool.TryParse(debugValue, out bool debug) && debug,
                name: properties.TryGetValue(nameof(Name), out string name) ? name : "Default Name",
                description: properties.TryGetValue(nameof(Description), out string description) ? description : "Default Description",
                version: properties.TryGetValue(nameof(Version), out string version) ? version : "0.0.0", 
                author: properties.TryGetValue(nameof(Author), out string author) ? author : "Pablo Perdomo Falcón", 
                license: properties.TryGetValue(nameof(License), out string license) ? license : "GPL-3.0 license",
                icon: properties.TryGetValue(nameof(Icon), out string icon) ? icon : "app.jpeg"
            );
        }
    }

    public interface IJsonDesSerializable<out T>
    {
        T CreateFromProperties(Dictionary<string, string> properties);
    }

    public interface IJsonSerializable
    {
        IEnumerable<(string PropertyName, string Value)> GetSerializableProperties();
    }


    public static class TinyJson
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