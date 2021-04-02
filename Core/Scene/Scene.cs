//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Scene.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Define a scene.</summary>
    public class Scene
    {
        /// <summary>The name</summary>
        [NotNull]
        private string name;

        /// <summary>The game objects</summary>
        [NotNull]
        private List<GameObject> gameObjects;

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="gameObjects">The game objects.</param>
        [JsonConstructor]
        public Scene([NotNull] string name, [NotNull] List<GameObject> gameObjects) 
        {
            this.name = name;
            this.gameObjects = gameObjects;

            OnCreate += Scene_OnCreate;
            OnDestroy += Scene_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="gameObjects">The game objects.</param>
        public Scene([NotNull] string name, [NotNull] params GameObject[] gameObjects)
        {
            this.name = name;
            this.gameObjects = new List<GameObject>(gameObjects);

            OnCreate += Scene_OnCreate;
            OnDestroy += Scene_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Finalizes an instance of the <see cref="Scene" /> class.</summary>
        ~Scene() => OnDestroy.Invoke(this, true);

        /// <summary>Occurs when [on create].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Called when [destroy].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [NotNull]
        [JsonProperty]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the game objects.</summary>
        /// <value>The game objects.</value>
        [NotNull]
        [JsonProperty]
        public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }

        /// <summary>Adds the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        public void Add([NotNull] GameObject gameObject) 
        {
            if (gameObjects.Find(i => i.Name.Equals(gameObject.Name)) is null) 
            {
                gameObjects.Add(gameObject);
            }
        }

        /// <summary>Removes the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        public void Remove([NotNull] GameObject gameObject) 
        {
            if (gameObjects.Find(i => i.Name.Equals(gameObject.Name)) != null)
            {
                gameObjects.Remove(gameObject);
            }
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        public Task Start()
        {
            return Task.Run(() =>
            {
                List<Task> tasks = new List<Task>();

                foreach (GameObject obj in gameObjects) 
                {
                    tasks.Add(StartObject(obj));
                }

                Task.WaitAll(tasks.ToArray());
            });
        }

        private Task StartObject(GameObject gameObject) => Task.Run(() => gameObject.Start());


        [return: NotNull]
        public Task Update() => Task.Run(() => gameObjects.ForEach(i => i.Update()));

        #region DefineEvents

        /// <summary>Scenes the on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Scene_OnCreate([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Scenes the on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Scene_OnDestroy([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}