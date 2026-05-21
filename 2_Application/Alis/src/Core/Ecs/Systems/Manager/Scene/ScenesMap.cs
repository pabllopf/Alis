

using System.Collections.Generic;

namespace Alis.Core.Ecs.Systems.Manager.Scene
{
    /// <summary>
    ///     The scenes map class
    /// </summary>
    public class ScenesMap
    {
        /// <summary>
        ///     Gets or sets the value of the scenes
        /// </summary>

        public List<int> Scenes { get; set; } = new List<int>();

        /// <summary>
        ///     Adds the scene using the specified scene id
        /// </summary>
        /// <param name="sceneId">The scene id</param>
        public void AddScene(int sceneId) => Scenes.Add(sceneId);

        /// <summary>
        ///     Removes the scene using the specified scene id
        /// </summary>
        /// <param name="sceneId">The scene id</param>
        public void RemoveScene(int sceneId) => Scenes.Remove(sceneId);

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear() => Scenes.Clear();

        /// <summary>
        ///     Loads this instance
        /// </summary>
        /// <returns>The scenes map</returns>
        public static ScenesMap Load() =>
            /*
            string pathFile = Path.Combine(Environment.CurrentDirectory, "Data", "ScenesMap.json");
            if (!File.Exists(pathFile))
            {
                string json = JsonSerializer.Serialize(this, new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });

                if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Data")))
                {
                    Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Data"));
                }

                File.WriteAllText(pathFile, json);

                return this;
            }

            return JsonSerializer.Deserialize<ScenesMap>(File.ReadAllText(pathFile), new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            });*/
            new ScenesMap();

        /// <summary>
        ///     Saves this instance
        /// </summary>
        public void Save()
        {
            /*
            string pathFile = Path.Combine(Environment.CurrentDirectory, "Data", "ScenesMap.json");

            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Data")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Data"));
            }

            string json = JsonSerializer.Serialize(this, new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            });

            File.WriteAllText(pathFile, json);*/
        }
    }
}