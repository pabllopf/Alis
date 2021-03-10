//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using Alis.Core.Components;
    using Newtonsoft.Json;

    /// <summary>Define a game object.</summary>
    public class GameObject
    {
        /// <summary>The name</summary>
        [JsonProperty]
        private string name;

        /// <summary>The active</summary>
        private bool active = true;

        /// <summary>The transform</summary>
        [JsonProperty]
        private Transform transform;

        /// <summary>The components</summary>
        [JsonProperty]
        private List<Component> components;

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        public GameObject() 
        {
            OnCreate?.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">name exception</exception>
        [JsonConstructor]
        public GameObject(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            transform = new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f));
            components = new List<Component>();
            
            OnCreate?.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <exception cref="ArgumentNullException">name
        /// or
        /// transform</exception>
        public GameObject(string name, Transform transform)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.transform = transform ?? throw new ArgumentNullException(nameof(transform));
            components = new List<Component>();
            
            OnCreate?.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        public GameObject(string name, Transform transform, params Component[] components)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.transform = transform ?? throw new ArgumentNullException(nameof(transform));
            this.components = new List<Component>();

            for (int index = 0; index < components.Length; index++) 
            {
                if (this.components.Find(i => i.GetType().Equals(components[index].GetType())) is null) 
                {
                    components[index].GameObject = this;
                    this.components.Add(components[index]);
                }
            }

            OnCreate?.Invoke(this, true);
        }

        /// <summary>Finalizes an instance of the <see cref="GameObject" /> class.</summary>
        ~GameObject()
        {
            OnDestroy?.Invoke(this, true);
        }

        /// <summary>Occurs when [on create].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Called when [enable].</summary>
        public event EventHandler<bool> OnEnable;

        /// <summary>Called when [disable].</summary>
        public event EventHandler<bool> OnDisable;

        /// <summary>Called when [destroy].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the transform.</summary>
        /// <value>The transform.</value>
        public Transform Transform { get => transform; set => transform = value; }
        
        /// <summary>Gets or sets a value indicating whether this <see cref="GameObject" /> is active.</summary>
        /// <value>
        /// <c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active
        {
            get => active; 
            set
            {
                active = value;
                if (active)
                {
                    OnEnable?.Invoke(this, true);
                }
                else 
                {
                    OnDisable?.Invoke(this, true);
                }
            }
        }

        /// <summary>Adds the component.</summary>
        /// <param name="component">The component.</param>
        public void AddComponent(Component component)
        {
            for (int index = 0; index < components.Count; index++)
            {
                if (!components[index].GetType().Equals(component.GetType()))
                {
                    component.GameObject = this;
                    components.Add(component);
                }
            }
        }

        /// <summary>Removes the component.</summary>
        /// <param name="component">The component.</param>
        public void RemoveComponent(Component component)
        {
            for (int index = 0; index < components.Count; index++)
            {
                if (components[index].GetType().Equals(component.GetType()))
                {
                    components.Remove(component);
                    component.GameObject = null;
                }
            }
        }

        /// <summary>Gets the component.</summary>
        /// <typeparam name="T">general type</typeparam>
        /// <returns>Return the component</returns>
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

        /// <summary>Starts this instance.</summary>
        internal void Start()
        {
            for (int index = 0; index < components.Count; index++) 
            {
                if (components[index].Active)
                {
                    components[index].Awake();
                    components[index].Start();
                }
            }
        }

        /// <summary>Updates this instance.</summary>
        internal void Update()
        {
            for (int index = 0; index < components.Count; index++)
            {
                if (components[index].Active) 
                {
                    components[index].BeforeUpdate();
                    components[index].Update();
                    components[index].AfterUpdate();
                }
            }
        }
    }
}