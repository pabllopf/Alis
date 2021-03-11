//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    /// <summary>Define a game object.</summary>
    public class GameObject
    {
        /// <summary>The name</summary>
        [JsonProperty]
        private string name;

        /// <summary>The active</summary>
        [JsonProperty]
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
            name = "GameObject";
            transform = new Transform();
            components = new List<Component>();

            OnCreate += GameObject_OnCreate;
            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
            OnDestroy += GameObject_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">name exception</exception>
        [JsonConstructor]
        public GameObject([NotNull] string name)
        {
            this.name = name;
            transform = new Transform();
            components = new List<Component>();

            OnCreate += GameObject_OnCreate;
            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
            OnDestroy += GameObject_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <exception cref="ArgumentNullException">name
        /// or
        /// transform</exception>
        public GameObject([NotNull] string name, [NotNull] Transform transform)
        {
            this.name = name;
            this.transform = transform;
            components = new List<Component>();

            OnCreate += GameObject_OnCreate;
            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
            OnDestroy += GameObject_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        public GameObject([NotNull] string name, [NotNull] Transform transform, [NotNull] params Component[] components)
        {
            this.name = name;
            this.transform = transform;
            this.components = new List<Component>();

            for (int index = 0; index < components.Length; index++) 
            {
                if (this.components.Find(i => i.GetType().Equals(components[index].GetType())) is null) 
                {
                    components[index].GameObject = this;
                    this.components.Add(components[index]);
                }
            }

            OnCreate += GameObject_OnCreate;
            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
            OnDestroy += GameObject_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Finalizes an instance of the <see cref="GameObject" /> class.</summary>
        ~GameObject() => OnDestroy?.Invoke(this, true);

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
                }
            }
        }

        /// <summary>Gets the component.</summary>
        /// <typeparam name="T">general type</typeparam>
        /// <returns>Return the component</returns>
        public T? GetComponent<T>() where T : Component
        {
            for (int index = 0; index < components.Count; index++) 
            {
                if (components[index].GetType().Equals(typeof(T))) 
                {
                    return (T)components[index];
                }
            }

            return default;
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

        #region DefineEvents

        /// <summary>Games the object on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void GameObject_OnCreate(object sender, bool e) => Logger.Info();

        /// <summary>Games the object on enable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void GameObject_OnEnable(object sender, bool e) => Logger.Info();

        /// <summary>Games the object on disable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void GameObject_OnDisable(object sender, bool e) => Logger.Info();

        /// <summary>Games the object on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void GameObject_OnDestroy(object sender, bool e) => Logger.Info();

        #endregion
    }
}