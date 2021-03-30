//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="LocalData.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>Manage the local data game.</summary>
    public class LocalData
    {
        /// <summary>Saves the specified name.</summary>
        /// <typeparam name="T">Type data</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="data">The data.</param>
        public static void Save<T>([NotNull] string name, [NotNull] T data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(typeof(T).GetType().FullName);
            }

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

                var settings = new JsonSerializerSettings
                {
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
                    TypeNameHandling = TypeNameHandling.All
                };

                string serialized = JsonConvert.SerializeObject(data, indented, settings);

                File.WriteAllText(file, serialized, Encoding.UTF8);
            }
        }

        /// <summary>Saves the specified name.</summary>
        /// <typeparam name="T">Type data</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="directory">directory to load file</param>
        /// <param name="data">The data.</param>
        public static void Save<T>([NotNull] string name, [NotNull] string directory, [NotNull] T data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(typeof(T).GetType().FullName);
            }

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
                var settings = new JsonSerializerSettings
                {
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
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
        /// <exception cref="NullReferenceException">When try to load null data</exception>
        [return: NotNull]
        public static T Load<T>([NotNull] string name)
        {
            string nameFile = name + ".json";
            string directory = Environment.CurrentDirectory + "/Data/";
            string file = directory + nameFile;

            var settings = new JsonSerializerSettings
            {
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
                TypeNameHandling = TypeNameHandling.All
            };

            if (IsPrimitive(typeof(T)))
            {
                return (T)Convert.ChangeType(File.ReadAllText(file, Encoding.UTF8), typeof(T)) ?? throw new NullReferenceException(typeof(T).GetType().FullName);
            }
            else
            {
                if (File.Exists(file))
                {
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings) ?? throw new NullReferenceException(typeof(T).GetType().FullName);
                }
                else 
                {
                    Save<T>(name, (T)Activator.CreateInstance(typeof(T).GetType()));
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings) ?? throw new NullReferenceException(typeof(T).GetType().FullName);
                }
            }
        }

        /// <summary>Loads the specified name.</summary>
        /// <typeparam name="T">Type data</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="directory">The directory.</param>
        /// <returns>Return data</returns>
        /// <exception cref="NullReferenceException">When try to load null data</exception>
        [return: NotNull]
        public static T Load<T>([NotNull] string name, [NotNull] string directory)
        {
            string nameFile = name + ".json";
            string file = directory + "/" + nameFile;

            var settings = new JsonSerializerSettings
            {
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
                TypeNameHandling = TypeNameHandling.All
            };

            if (IsPrimitive(typeof(T)))
            {
                return (T)Convert.ChangeType(File.ReadAllText(file, Encoding.UTF8), typeof(T)) ?? throw new NullReferenceException(typeof(T).GetType().FullName);
            }
            else
            {
                if (File.Exists(file))
                {
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings) ?? throw new NullReferenceException(typeof(T).GetType().FullName);
                }
                else
                {
                    Save<T>(name, (T)Activator.CreateInstance(typeof(T).GetType()));
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings) ?? throw new NullReferenceException(typeof(T).GetType().FullName);
                }
            }
        }

        /// <summary>Determines whether the specified type is primitive.</summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// <c>true</c> if the specified type is primitive; otherwise, <c>false</c>.</returns>
        [return: NotNull]
        private static bool IsPrimitive([NotNull] Type type) => type.IsPrimitive || type == typeof(string);
    }
}
