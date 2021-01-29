//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>Define a game object. </summary>
    [System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class GameObject
    {
        /// <summary>The name</summary>
        private string name;

        /// <summary>The components</summary>
        private List<IComponent> components;

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        [JsonConstructor]
        public GameObject(string name) 
        {
            this.name = name;
            components = new List<IComponent>
            {
                new Transform()
            };

            Debug.Log("Created a new " + GetType() + "(" + name + ").");
        }

        public string Name { get => name; set => name = value; }
        
        /// <summary>Gets or sets the components.</summary>
        /// <value>The components.</value>
        public List<IComponent> Components { get => components; set => components = value; }



        /// <summary>Adds the specified component.</summary>
        /// <param name="component">The component.</param>
        public void Add(IComponent component) 
        {
            if (components.Exists(i => i.GetType() == component.GetType()))
            {
                Debug.Warning("This component (" + component.GetType() + ") already exists in the GameObject(" + name + ").");
            }
            else 
            {
                components.Add(component);
            }
        }

        /// <summary>Starts this instance.</summary>
        public void Start() 
        {
            components.ForEach(i => i.Start());
        }

        /// <summary>Updates this instance.</summary>
        public void Update() 
        {
            components.ForEach(i => i.Update());
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}