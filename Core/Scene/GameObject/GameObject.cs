//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>Define a game object.</summary>
    public class GameObject
    {
        /// <summary>The name</summary>
        [NotNull]
        private string name;

        /// <summary>The active</summary>
        [NotNull]
        private bool active = true;

        /// <summary>The transform</summary>
        [NotNull]
        private Transform transform;

        /// <summary>The components</summary>
        [NotNull]
        private List<Component> components;

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        [JsonConstructor]
        public GameObject([NotNull] string name, [NotNull] Transform transform, [NotNull] List<Component> components)
        {
            this.name = name;
            this.transform = transform;
            this.components = components;
            this.components.ForEach(i => i.AttachTo(this));

            OnCreate += GameObject_OnCreate;
            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
            OnDestroy += GameObject_OnDestroy;

            OnCreate.Invoke(this, true);
        }


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
                    components[index].AttachTo(this);
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
        [NotNull]
        [JsonProperty]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the transform.</summary>
        /// <value>The transform.</value>
        [NotNull]
        [JsonProperty]
        public Transform Transform { get => transform; set => transform = value; }

        /// <summary>Gets or sets a value indicating whether this <see cref="GameObject" /> is active.</summary>
        /// <value>
        /// <c>true</c> if active; otherwise, <c>false</c>.</value>
        [NotNull]
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

        /// <summary>Gets or sets the components.</summary>
        /// <value>The components.</value>
        public List<Component> Components { get => components; set => components = value; }



        /// <summary>Adds the component.</summary>
        /// <param name="component">The component.</param>
        public void Add([NotNull] Component component)
        {
            if (components.Find(i => i.GetType().Equals(component.GetType())) == null) 
            {
                component.AttachTo(this);
                components.Add(component);
                Console.WriteLine("Add new component " + component.GetType());
            }
        }

        /// <summary>Removes the component.</summary>
        /// <param name="component">The component.</param>
        public void Remove([NotNull] Component component)
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
        [return: MaybeNull]
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
        [return: NotNull]
        internal void Start()
        {
            components = components.OrderBy(i => i.Priority()).ToList();

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
        [return: NotNull]
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
        private void GameObject_OnCreate([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Games the object on enable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void GameObject_OnEnable([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Games the object on disable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void GameObject_OnDisable([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Games the object on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void GameObject_OnDestroy([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}