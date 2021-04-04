//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    /// <summary>Define a game object.</summary>
    public class GameObject
    {
        /// <summary>The transform</summary>
        [NotNull]
        private readonly Transform transform;

        /// <summary>The components</summary>
        [AllowNull]
        private readonly Component[] components;

        /// <summary>The name</summary>
        [NotNull]
        private string name;

        /// <summary>The active</summary>
        [NotNull]
        private bool isActive;

        /// <summary>The is static</summary>
        [NotNull]
        private bool isStatic;

        /// <summary>The last component</summary>
        [AllowNull]
        private Component lastComponentReturned;

        /// <summary>The last component deleted</summary>
        [AllowNull]
        private Component lastComponentDeleted;

        /// <summary>The last component deleted</summary>
        [AllowNull]
        private Component lastComponentAdded;

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        [JsonConstructor]
        public GameObject([NotNull] string name, [NotNull] Transform transform, [NotNull] bool isActive, [NotNull] bool isStatic, [NotNull] Component[] components)
        {
            if (components.Length > 10)
            {
                throw new ArgumentException("The limit size of components[] is 10. ");
            }

            this.name = name;
            this.transform = transform;
            this.components = new Component[10];

            for (int i = 0; i < components.Length; i++) 
            {
                this.components[i] = components[i];
                this.components[i].AttachTo(this);
            }

            this.isActive = isActive;
            this.isStatic = isStatic;

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        public GameObject()
        {
            name = "GameObject";
            transform = new Transform();
            components = new Component[10];

            isActive = true;
            isStatic = true;

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        public GameObject([NotNull] string name)
        {
            this.name = name;
            transform = new Transform();
            components = new Component[10];

            isActive = true;
            isStatic = true;
            
            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
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
            components = new Component[10];

            isActive = true;
            isStatic = true;

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        public GameObject([NotNull] string name, [NotNull] Transform transform, [NotNull] params Component[] components)
        {
            if (components.Length > 10) 
            {
                throw new ArgumentException("The limit size of components[] is " + 10);
            }

            this.name = name;
            this.transform = transform;
            this.components = new Component[10];

            for (int i = 0; i < components.Length; i++)
            {
                this.components[i] = components[i];
                this.components[i].AttachTo(this);
            }

            isActive = true;
            isStatic = false;

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
        }

        /// <summary>Called when [enable].</summary>
        public event EventHandler<bool> OnEnable;

        /// <summary>Called when [disable].</summary>
        public event EventHandler<bool> OnDisable;

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [NotNull]
        [JsonProperty("_Name")]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the transform.</summary>
        /// <value>The transform.</value>
        [NotNull]
        [JsonProperty("_Transform")]
        public Transform Transform { get => transform; }

        /// <summary>Gets or sets a value indicating whether this <see cref="GameObject" /> is active.</summary>
        /// <value>
        /// <c>true</c> if active; otherwise, <c>false</c>.</value>
        [NotNull]
        [JsonProperty("_IsActive")]
        public bool IsActive
        {
            get => isActive; 
            set
            {
                isActive = value;
                if (isActive)
                {
                    OnEnable?.Invoke(this, true);
                }
                else 
                {
                    OnDisable?.Invoke(this, true);
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether this instance is static.</summary>
        /// <value>
        /// <c>true</c> if this instance is static; otherwise, <c>false</c>.</value>
        [NotNull]
        [JsonProperty("_IsStatic")]
        public bool IsStatic { get => isStatic; set => isStatic = value; }

        /// <summary>Gets the components.</summary>
        /// <value>The components.</value>
        [NotNull]
        [JsonProperty("_Components")]
        public Component[] Components { get => components; }

        /// <summary>Determines whether this instance contains the object.</summary>
        /// <typeparam name="T">component to contais</typeparam>
        public bool Contains<T>() where T : Component
        {
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] is not null)
                {
                    if (components[i].GetType().Equals(typeof(T))) 
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>Adds the specified component.</summary>
        /// <typeparam name="T">general type</typeparam>
        /// <param name="component">The component.</param>
        /// <exception cref="ArgumentException">You can`t add a component that alredy exits in the gameobject.
        /// or
        /// This gameobject is FULL, the limit size of components[] is 10.</exception>
        public void Add<T>([NotNull] T component) where T : Component
        {
            if (lastComponentAdded is not null && lastComponentAdded.GetType().Equals(component.GetType())) 
            {
                throw new ArgumentException("You can`t add a component that alredy exits in the gameobject.");
            }

            if (Contains<T>())
            {
                throw new ArgumentException("You can`t add a component that alredy exits in the gameobject.");
            }

            for (int i = 0; i < components.Length; i++) 
            {
                if (components[i] is null || !components[i].IsActive)
                {
                    components[i] = component;
                    lastComponentAdded = components[i];
                    components[i].IsActive = true;
                    return;
                }
            }

            throw new ArgumentException("This gameobject is FULL, the limit size of components[] is 10.");
        }

        /// <summary>Removes this instance.</summary>
        /// <typeparam name="T">general type</typeparam>
        public void Remove<T>() where T : Component
        {
            if (lastComponentDeleted is not null && lastComponentDeleted.GetType().Equals(typeof(T)))
            {
                lastComponentDeleted.IsActive = false;
                return;
            }

            for (int i = 0; i < components.Length; i++) 
            {
                if (components[i] is not null)
                {
                    if (components[i].GetType().Equals(typeof(T))) 
                    {
                        lastComponentDeleted = components[i];
                        components[i].IsActive = false;
                    }
                }
            }
        }

        /// <summary>Gets the component.</summary>
        /// <typeparam name="T">general type</typeparam>
        /// <returns>Return the component</returns>
        [return: MaybeNull]
        public T Get<T>() where T : Component
        {
            if (lastComponentReturned is not null && lastComponentReturned.GetType().Equals(typeof(T))) 
            {
                return (T)lastComponentReturned;
            }

            if (lastComponentAdded is not null && lastComponentAdded.GetType().Equals(typeof(T)))
            {
                return (T)lastComponentAdded;
            }

            if (lastComponentDeleted is not null && lastComponentDeleted.GetType().Equals(typeof(T)))
            {
                return (T)lastComponentDeleted;
            }

            for (int i = 0; i < components.Length;i++) 
            {
                if (components[i].GetType().Equals(typeof(T))) 
                {
                    lastComponentReturned = components[i];
                    return (T)components[i];
                }
            }

            return null;
        }

        /// <summary>Awake this instance.</summary>
        public void Awake()
        {
            if (isActive)
            {
                for (int i = 0; i < components.Length; i++)
                {
                    if (components[i] is not null)
                    {
                        components[i].Awake();
                    }
                }
            }
        }

        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            if (isActive)
            {
                for (int i = 0; i < components.Length; i++)
                {
                    if (components[i] is not null)
                    {
                        components[i].Start();
                    }
                }
            }
        }

        /// <summary>Updates this instance.</summary>
        public void Update()
        {
            if (isActive && !isStatic)
            {
                for (int i = 0; i < components.Length; i++)
                {
                    if (components[i] is not null)
                    {
                        components[i].Update();
                    }
                }
            }
        }

        /// <summary>Fixed Update this instance.</summary>
        public void FixedUpdate()
        {
            if (isActive && !isStatic)
            {
                for (int i = 0; i < components.Length; i++)
                {
                    if (components[i] is not null)
                    {
                        components[i].FixedUpdate();
                    }
                }
            }
        }

        #region DefineEvents

        /// <summary>Games the object on enable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void GameObject_OnEnable([NotNull] object sender, [NotNull] bool e) 
        {
        }

        /// <summary>Games the object on disable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void GameObject_OnDisable([NotNull] object sender, [NotNull] bool e) 
        {
        }

        #endregion
    }
}