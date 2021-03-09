//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    /// <summary>Define a game object. </summary>
    public class GameObject
    {
        /// <summary>The name</summary>
        private string name;

        /// <summary>The transform</summary>
        private Transform transform;

        /// <summary>The components</summary>
        private List<Component> components;

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [JsonProperty]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the transform.</summary>
        /// <value>The transform.</value>
        [JsonProperty]
        public Transform Transform { get => transform; set => transform = value; }

        /// <summary>Gets or sets the components.</summary>
        /// <value>The components.</value>
        [JsonProperty]
        public List<Component> Components { get => components; set => components = value; }

        public GameObject() 
        { 
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        [JsonConstructor]
        public GameObject(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            transform = new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f));
            components = new List<Component>();
        }

        public GameObject(string name, Transform transform)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            transform = transform ?? throw new ArgumentNullException(nameof(transform));
            components = new List<Component>();
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        public GameObject(string name, Transform transform, params Component[] components)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.transform = transform ?? throw new ArgumentNullException(nameof(transform));
            this.components = new List<Component>(components ?? throw new ArgumentNullException(nameof(components)));
        }

        public void AddComponent(Component component)
        {
            for (int index = 0; index < components.Count; index++)
            {
                if (!components[index].GetType().Equals(component.GetType()))
                {
                    components.Add(component);
                }
            }
        }

        public void RemoveComponent(Component component)
        {
            for (int index = 0; index < components.Count; index++)
            {
                if (components[index].GetType().Equals(component.GetType()))
                {
                    components.Remove(component);
                }
            }
        }

        public T GetComponent<T>() where T : Component
        {
            for (int index = 0; index < components.Count; index++) 
            {
                if (components[index].GetType().Equals(typeof(T))) 
                {
                    return (T)components[index];
                }
            }

            return null;
        }

        internal void Start()
        {
            for (int index = 0; index < components.Count; index++) 
            {
                components[index].Start();
            }
        }

        internal void Update()
        {
            for (int index = 0; index < components.Count; index++)
            {
                components[index].Update();
            }
        }
    }
}