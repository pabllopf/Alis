//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
  
    /// <summary>Define a game object. </summary>
    [System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class GameObject
    {
        /// <summary>The name</summary>
        private string name;

        /// <summary>The components</summary>
        private List<IComponent> components;

        private Transform transform;

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        [JsonConstructor]
        public GameObject(string name) 
        {
            this.name = name;
            transform = new Transform();
            components = new List<IComponent>
            {
                transform
            };

            Debug.Log("Created a new " + GetType() + "(" + name + ").");
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="component">The component.</param>
        public GameObject(string name, params IComponent[] component)
        {
            this.name = name;
            transform = new Transform();
            components = new List<IComponent>
            {
                transform
            };

            components.AddRange(component);

            Debug.Log("Created a new " + GetType() + "(" + name + ").");
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
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
            components.ForEach(i => i.Start(ref transform));
        }

        /// <summary>Updates this instance.</summary>
        public void Update() 
        {
            components.ForEach(i => i.Update());
            components.ForEach(i => i.Update(ref transform));
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}