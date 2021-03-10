//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using Newtonsoft.Json;

    /// <summary>Define a game object. </summary>
    public class GameObject
    {
        /// <summary>The name</summary>
        [JsonProperty]
        private string name;

        /// <summary>The transform</summary>
        [JsonProperty]
        private Transform transform;

        /// <summary>The components</summary>
        [JsonProperty]
        private List<Component> components;

        public string Name { get => name; set => name = value; }
        
        public Transform Transform { get => transform; set => transform = value; }
        
        public List<Component> Components { get => components; set => components = value; }

        public event EventHandler<bool> OnCreate;

        /// <summary>Called when [enable].</summary>
        public event EventHandler<bool> OnEnable;

        /// <summary>Afters the update.</summary>
        public event EventHandler<bool> OnBeforeUpdate;

        /// <summary>Afters the update.</summary>
        public event EventHandler<bool> OnAfterUpdate;

        /// <summary>Called when [disable].</summary>
        public event EventHandler<bool> OnDisable;

        /// <summary>Called when [destroy].</summary>
        public event EventHandler<bool> OnDestroy;

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