//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Scene.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Collections.Generic;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Define a scene.</summary>
    [System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Scene
    {
        /// <summary>The name</summary>
        private string name;

        /// <summary>The game objects</summary>
        private List<GameObject> gameObjects;

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        [JsonConstructor]
        public Scene(string name)
        {
            this.name = name;
            gameObjects = new List<GameObject>();
        }

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="gameObject">The game object.</param>
        public Scene(string name, params GameObject[] gameObject)
        {
            this.name = name;
            gameObjects = new List<GameObject>(gameObject);
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the game objects.</summary>
        /// <value>The game objects.</value>
        public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }

        /// <summary>Adds the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        public void Add(GameObject gameObject) 
        {
            if (!gameObjects.Contains(gameObject))
            {
                GameObject obj = gameObjects.Find(i => i.Name.Equals(gameObject.Name));

                if (obj != null)
                {
                    int i = 0;
                    while (gameObjects.Find(j => j.Name.Equals(obj.Name + " " + i)) != null)
                    {
                        i++;
                    }

                    gameObject.Name += " " + i;
                    gameObjects.Add(gameObject);
                }
                else 
                {
                    gameObjects.Add(gameObject);
                }
            }
            else 
            {
                
            }
        }

        /// <summary>Removes the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        public void Remove(GameObject gameObject) 
        {
            if (gameObjects.Contains(gameObject))
            {
                gameObjects.Remove(gameObject);
            }
        }

        /// <summary>Starts this instance.</summary>
        public void Start() 
        {
            //gameObjects.ForEach(i => i.Start());
        }

        /// <summary>Updates this instance.</summary>
        public void Update()
        {
            Logger.Log("Example");
           //gameObjects.ForEach(i => i.Update());
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}