//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="LocalStore.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------
namespace Alis.Store
{
    using System;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>Manage local store</summary>
    public class LocalStore
    {
        /// <summary>Tests this.</summary>
        public static void Test() 
        {
            Console.WriteLine("Test of c#");
        }

        /// <summary>Saves the specified data.</summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="nameFile">The name file.</param>
        /// <param name="path">The path.</param>
        public static void Save<T>(T data, string nameFile, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string pathFile = path + "/" + nameFile + ".json";

            if (IsPrimitive(typeof(T)))
            {
                File.WriteAllText(pathFile, data.ToString(), Encoding.UTF8);
            }
            else
            {
                string dataJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(pathFile, dataJson, Encoding.UTF8);
            }
        }

        /// <summary>Loads the specified name file.</summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="nameFile">The name file.</param>
        /// <param name="path">The path.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Return the local data.</returns>
        public static T Load<T>(string nameFile, string path, T defaultValue)
        {
            string pathFile = path + "/" + nameFile + ".json";

            if (File.Exists(pathFile))
            {
                if (IsPrimitive(typeof(T)))
                {
                    return (T)Convert.ChangeType(File.ReadAllText(pathFile, Encoding.UTF8), typeof(T));
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(pathFile));
                }
            }
            else
            {
                Save<T>(defaultValue, nameFile, path);
                return defaultValue;
            }
        }

        /// <summary>Loads the specified file.</summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="file">The file.</param>
        /// <returns>Return local data</returns>
        public static T Load<T>(string file)
        {
            if (IsPrimitive(typeof(T)))
            {
                return (T)Convert.ChangeType(File.ReadAllText(file, Encoding.UTF8), typeof(T));
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
            }
        }

        /// <summary>Determines whether the specified type is primitive.</summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// <c>true</c> if the specified type is primitive; otherwise, <c>false</c>.</returns>
        private static bool IsPrimitive(Type type) => type == typeof(int) || type == typeof(string);
    }
}
