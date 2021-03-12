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
                var indented = Formatting.Indented;
                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                string serialized = JsonConvert.SerializeObject(data, indented, settings);

                File.WriteAllText(file, serialized, Encoding.UTF8);
            }
        }

        /// <summary>Saves the specified name.</summary>
        /// <typeparam name="T">Type data</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="directory"></param>
        /// <param name="data">The data.</param>
        public static void Save<T>(string name, string directory, T data)
        {
            string nameFile = name + ".json";
            string file = directory + "/" + nameFile;

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
                var indented = Formatting.Indented;
                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                string serialized = JsonConvert.SerializeObject(data, indented, settings);

                File.WriteAllText(file, serialized, Encoding.UTF8);
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

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            if (IsPrimitive(typeof(T)))
            {
                return (T)Convert.ChangeType(File.ReadAllText(file, Encoding.UTF8), typeof(T));
            }
            else
            {
                if (File.Exists(file))
                {
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings);
                }
                else 
                {
                    Save<T>(name, default);
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings);
                }
            }
        }

        /// <summary>Loads the specified name.</summary>
        /// <typeparam name="T">Type data</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="directory"></param>
        /// <returns>Return the value data.</returns>
        public static T Load<T>(string name, string directory)
        {
            string nameFile = name + ".json";
            string file = directory + "/" + nameFile;

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            if (IsPrimitive(typeof(T)))
            {
                return (T)Convert.ChangeType(File.ReadAllText(file, Encoding.UTF8), typeof(T));
            }
            else
            {
                if (File.Exists(file))
                {
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings);
                }
                else
                {
                    Save<T>(name, default);
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings);
                }
            }
        }
    }
}
