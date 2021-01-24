//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Scene.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System.Collections.Generic;

    /// <summary>Define a scene.</summary>
    [System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Scene
    {
        /// <summary>The name</summary>
        private readonly string name;

        /// <summary>The game objects</summary>
        private List<GameObject> gameObjects;

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        public Scene(string name)
        {
            this.name = name;
            gameObjects = new List<GameObject>();
            Debug.Log("Created a new " + GetType() + "(" + name + ").");
        }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        public string Name => name;

        /// <summary>Adds the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        public void Add(GameObject gameObject) 
        {
            if (!gameObjects.Contains(gameObject))
            {
                Debug.Log("Added a new GameObject(" + gameObject.Name + ") in the Scene(" + name + ")");
                gameObjects.Add(gameObject);
            }
            else 
            {
                Debug.Warning("This GameObject(" + gameObject.Name + ") already exists in the Scene(" + name + ").");
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
            gameObjects.ForEach(i => i.Start());
        }

        /// <summary>Updates this instance.</summary>
        public void Update()
        {
            gameObjects.ForEach(i => i.Update());
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}