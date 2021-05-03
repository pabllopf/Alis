//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="LocalData.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
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
        public static void Save<T>(string name,  T data)
        {
            if (data == null)
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
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
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
        public static void Save<T>( string name,  string directory,  T data)
        {
            if (data == null)
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
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
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
        
        public static T Load<T>( string name)
        {
            string nameFile = name + ".json";
            string directory = Environment.CurrentDirectory + "/Data/";
            string file = directory + nameFile;

            if (!Directory.Exists(directory)) 
            {
                Directory.CreateDirectory(directory);
            }

            var settings = new JsonSerializerSettings
            {
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                TypeNameHandling = TypeNameHandling.All
            };

            if (IsPrimitive(typeof(T)))
            {
                Logger.Log("Load: " + file);
                return (T)Convert.ChangeType(File.ReadAllText(file, Encoding.UTF8), typeof(T)) ?? throw new NullReferenceException("Reading a empty file (primitive var)" + typeof(T).GetType().FullName);
            }
            else
            {
                if (File.Exists(file))
                {
                    Logger.Log("Load: " + file);
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings);
                }
                else 
                {
                    Logger.Warning("File dont exits. " + file);
                    return default;
                }
            }
        }

        /// <summary>Loads the specified name.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Return the value data.</returns>
        /// <exception cref="NullReferenceException">Reading a empty file (primitive var)" + typeof(T).GetType().FullName</exception>
        public static T Load<T>( string name, T defaultValue)
        {
            string nameFile = name + ".json";
            string directory = Environment.CurrentDirectory + "/Data/";
            string file = directory + nameFile;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var settings = new JsonSerializerSettings
            {
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                TypeNameHandling = TypeNameHandling.All
            };

            if (IsPrimitive(typeof(T)))
            {
                if (File.Exists(file))
                {
                    Logger.Log("Load: " + file);
                    return (T)Convert.ChangeType(File.ReadAllText(file, Encoding.UTF8), typeof(T)) ?? throw new NullReferenceException("Reading a empty file (primitive var)" + typeof(T).GetType().FullName);
                }
                else 
                {
                    Save<T>(name, defaultValue);
                    return (T)Convert.ChangeType(File.ReadAllText(file, Encoding.UTF8), typeof(T)) ?? throw new NullReferenceException("Reading a empty file (primitive var)" + typeof(T).GetType().FullName);
                }
            }
            else
            {
                if (File.Exists(file))
                {
                    Logger.Log("Load: " + file);
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings);
                }
                else
                {
                    Save<T>(name, defaultValue);
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings);
                }
            }
        }

        /// <summary>Loads the specified name.</summary>
        /// <typeparam name="T">Type data</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="directory">The directory.</param>
        /// <returns>Return data</returns>
        /// <exception cref="NullReferenceException">When try to load null data</exception>
        public static T Load<T>( string name,  string directory)
        {
            string nameFile = name + ".json";
            string file = directory + "/" + nameFile;

            var settings = new JsonSerializerSettings
            {
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
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
                    return default;
                }
            }
        }

        
        public static T Load<T>( string name,  string directory, T defaultdata)
        {
            string nameFile = name + ".json";
            string file = directory + "/" + nameFile;

            var settings = new JsonSerializerSettings
            {
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
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
                    Save<T>(name, defaultdata);
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(file), settings) ?? throw new NullReferenceException(typeof(T).GetType().FullName);
                }
            }
        }

        /// <summary>Determines whether the specified type is primitive.</summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// <c>true</c> if the specified type is primitive; otherwise, <c>false</c>.</returns>
        
        private static bool IsPrimitive(Type type) => type.IsPrimitive || type == typeof(string);
    }
}
