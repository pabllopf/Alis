//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="LocalData.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Text;

    /// <summary>Manage the local data game.</summary>
    public class LocalData
    {
        /// <summary>Determines whether the specified type is primitive.</summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// <c>true</c> if the specified type is primitive; otherwise, <c>false</c>.</returns>
        private static bool IsPrimitive(Type type) => type.IsPrimitive || type == typeof(string);

        /// <summary>Saves the specified name.</summary>
        /// <typeparam name="T">Type data</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="data">The data.</param>
        public static void Save<T>(string name, T data)
        {
            string nameFile = name + ".json";
            string directory = Environment.CurrentDirectory + "/Data/";
            string file = directory + nameFile;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (IsPrimitive(typeof(T)))
            {
                File.WriteAllText(file, data.ToString(), Encoding.UTF8);
            }
            else
            {
                string dataJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(file, dataJson, Encoding.UTF8);
            }
        }

        /// <summary>Loads the specified name.</summary>
        /// <typeparam name="T">Type data</typeparam>
        /// <param name="name">The name.</param>
        /// <returns>Return the value data.</returns>
        public static T Load<T>(string name)
        {
            string nameFile = name + ".json";
            string directory = Environment.CurrentDirectory + "/Data/";
            string file = directory + nameFile;

            if (IsPrimitive(typeof(T)))
            {
                return (T)Convert.ChangeType(File.ReadAllText(file, Encoding.UTF8), typeof(T));
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
            }
        }
    }
}
