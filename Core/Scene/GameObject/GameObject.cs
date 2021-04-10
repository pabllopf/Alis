//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Define a game object.</summary>
    public class GameObject
    {
        /// <summary>The maximum number components</summary>
        [NotNull]
        private const int MaxNumComponents = 10;

        /// <summary>The transform</summary>
        [NotNull]
        private readonly Transform transform;

        /// <summary>The span</summary>
        [NotNull]
        private readonly Memory<Component> components;

        /// <summary>The name</summary>
        [NotNull]
        private string name;

        /// <summary>The active</summary>
        [NotNull]
        private bool isActive;

        /// <summary>The is static</summary>
        [NotNull]
        private bool isStatic;

        /// <summary>The component returned</summary>
        [AllowNull]
        private Component componentReturned;

        /// <summary>The last component deleted</summary>
        [AllowNull]
        private Component componentDeleted;

        /// <summary>The last component deleted</summary>
        [AllowNull]
        private Component componentAdded;

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isStatic">if set to <c>true</c> [is static].</param>
        /// <param name="components">The components.</param>
        /// <exception cref="ArgumentException">The limit size of components[] is 10.</exception>
        [JsonConstructor]
        public GameObject([NotNull] string name, [NotNull] Transform transform, [NotNull] bool isActive, [NotNull] bool isStatic, [NotNull] Component[] components)
        {
            if (components.Length > 10)
            {
                throw new ArgumentException("The limit size of components[] is 10. ");
            }

            this.name = name;
            this.transform = transform;
            this.components = new Memory<Component>(new Component[MaxNumComponents]);

            Span<Component> span = this.components.Span;
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != null) 
                {
                    span[i] = components[i];
                    span[i].AttachTo(this);
                }
            }

            componentAdded = span.Length > 0 ? span[(span.Length - 1)] : null;
            componentDeleted = span.Length > 0 ? span[0] : null;
            componentReturned = span.Length > 0 ? span[0] : null;

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
            components = new Memory<Component>(new Component[MaxNumComponents]);

            isActive = true;
            isStatic = false;

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;

            IsActive = true;
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        public GameObject([NotNull] string name)
        {
            this.name = name;
            transform = new Transform();
            components = new Memory<Component>(new Component[MaxNumComponents]);

            isActive = true;
            isStatic = false;

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
            
            IsActive = true;
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
            components = new Memory<Component>(new Component[MaxNumComponents]);

            isActive = true;
            isStatic = false;

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;

            IsActive = true;
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        public GameObject([NotNull] string name, [NotNull] Transform transform, [NotNull] params Component[] components)
        {
            if (components.Length > MaxNumComponents) 
            {
                throw new ArgumentException("The limit size of components[] is " + MaxNumComponents);
            }

            this.name = name;
            this.transform = transform;
            this.components = new Memory<Component>(new Component[MaxNumComponents]);

            Span<Component> span = this.components.Span;
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != null)
                {
                    span[i] = components[i];
                    span[i].AttachTo(this);
                }
            }

            componentAdded = span.Length > 0 ? span[span.Length - 1] : null;
            componentDeleted = span.Length > 0 ? span[0] : null;
            componentReturned = span.Length > 0 ? span[0] : null;

            isActive = true;
            isStatic = false;

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;

            IsActive = true;
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

        /// <summary>Gets the transform.</summary>
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
        public Component[] Components { get => components.ToArray(); }

        /// <summary>Determines whether this instance contains the object.</summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <returns>
        /// <c>true</c> if [contains]; otherwise, <c>false</c>.</returns>
        public bool Contains<T>() where T : Component
        {
            Span<Component> span = components.Span;
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] != null)
                {
                    if (span[i].GetType().Equals(typeof(T)) && span[i].IsActive) 
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>Adds the specified component.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component">The component.</param>
        public void Add<T>([NotNull] T component) where T : Component
        {
            if (componentAdded != null && componentAdded.GetType().Equals(component.GetType())) 
            {
                Logger.Error("Component '" + component.GetType().Name + "' already exists on gameobject '" + name + "' (CASE: previously component added)");
            }

            if (Contains<T>())
            {
                Logger.Error("Component '" + component.GetType().Name + "' already exists on gameobject '" + name + "' (CASE: getting previously component returned)");
            }

            Span<Component> span = components.Span;
            for (int i = 0; i < components.Length; i++) 
            {
                if (span[i] is null || !span[i].IsActive)
                {
                    span[i] = component;
                    componentAdded = span[i];
                    span[i].IsActive = true;
                    return;
                }
            }

            Logger.Error("Gameobject '" + name + "' is FULL, the limit size of components[] is " + MaxNumComponents);
        }

        /// <summary>Removes this instance.</summary>
        /// <typeparam name="T">general type</typeparam>
        public void Delete<T>() where T : Component
        {
            if (componentDeleted != null && componentDeleted.GetType().Equals(typeof(T)))
            {
                Logger.Warning("Can`t delete the component '" + componentDeleted.GetType().Name + "' of gameobject '" + name + "' that was deleted previously");
                componentDeleted.IsActive = false;
                return;
            }

            if (componentReturned != null && componentReturned.GetType().Equals(typeof(T)) && componentReturned.IsActive)
            {
                Logger.Log("the component '" + componentReturned.GetType().Name + "' was deleted from gameobject '" + name + "'" + " (CASE: getting previously component returned)");
                componentReturned.IsActive = false;
                componentDeleted = componentReturned;
                return;
            }

            if (componentAdded != null && componentAdded.GetType().Equals(typeof(T)) && componentAdded.IsActive)
            {
                Logger.Log("the component '" + componentAdded.GetType().Name + "' was deleted from gameobject '" + name + "'" + " (CASE: getting previously component added)");
                componentAdded.IsActive = false;
                componentDeleted = componentAdded;
                return;
            }

            Span<Component> span = components.Span;
            for (int i = 0; i < components.Length; i++) 
            {
                if (span[i] != null)
                {
                    if (span[i].GetType().Equals(typeof(T))) 
                    {
                        if (span[i].IsActive)
                        {
                            Logger.Log("the component '" + span[i].GetType().Name + "' was deleted from gameobject '" + name + "'" + " (CASE: deleting component by search)");
                            componentDeleted = span[i];
                            span[i].IsActive = false;
                        }
                        else
                        {
                            Logger.Warning("'" + typeof(T).Name + "'" + " can`t delete a '" + name + "' that was deleted previously " + " (CASE: component not active)");
                            return;
                        }
                    }
                }
            }

            Logger.Warning("'" + name + "'" + " dont`t contains " + typeof(T).Name + " (CASE: didn't find anything)");
        }

        /// <summary>Gets the component.</summary>
        /// <typeparam name="T">general type</typeparam>
        /// <returns>Return the component</returns>
        [return: MaybeNull]
        public T? Get<T>() where T : Component
        {
            if (componentReturned != null && componentReturned.IsActive && componentReturned.GetType().Equals(typeof(T))) 
            {
                Logger.Log("the component '" + componentReturned.GetType().Name + "' was obtained from gameobject '" + name + "'" + " (CASE: getting previously component returned)");
                return (T?)componentReturned;
            }

            if (componentAdded != null && componentAdded.IsActive && componentAdded.GetType().Equals(typeof(T)))
            {
                Logger.Log("the component '" + componentAdded.GetType().Name + "' was obtained from gameobject '" + name + "'" + " (CASE: getting previously component added)");
                return (T?)componentAdded;
            }

            Span<Component> span = components.Span;
            for (int i = 0; i < components.Length; i++) 
            {
                if (span[i] != null && span[i].GetType().Equals(typeof(T))) 
                {
                    if (span[i].IsActive)
                    {
                        Logger.Log("the component '" + span[i].GetType().Name + "' was obtained from gameobject '" + name + "'" + " (CASE: getting component by search)");
                        componentReturned = span[i];
                        return (T?)span[i];
                    }
                    else 
                    {
                        Logger.Warning("'" + typeof(T).Name + "'" + " exits on gameobject '" + name + "' but it`s NOT active " + " (CASE: component not active)");
                        return null;
                    }
                }
            }

            Logger.Warning("'" + name + "'" + " dont`t contains " + typeof(T).Name + " (CASE: didn't find anything)");
            return null;
        }

        /// <summary>Awake this instance.</summary>
        public void Awake()
        {
            Span<Component> span = components.Span;
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] != null)
                {
                    span[i].Awake();
                    Logger.Log("AWAKE:  the component(" + span[i].GetType().Name + ") '");
                }
            }
        }

        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            Span<Component> span = components.Span;
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] != null)
                {
                    span[i].Start();
                    Logger.Log("START:  the component(" + span[i].GetType().Name + ") '");
                }
            }
        }

        /// <summary>Updates this instance.</summary>
        public void Update()
        {
            if (isActive && !isStatic)
            {
                Span<Component> span = components.Span;
                for (int i = 0; i < span.Length; i++)
                {
                    span[i]?.Update();
                }
            }
        }

        /// <summary>Fixed Update this instance.</summary>
        public void FixedUpdate()
        {
            if (isActive && !isStatic)
            {
                Span<Component> span = components.Span;
                for (int i = 0; i < span.Length; i++)
                {
                    span[i]?.FixedUpdate();
                }
            }
        }

        /// <summary>Stops this instance.</summary>
        internal void Stop()
        {
            Span<Component> span = components.Span;
            for (int i = 0; i < span.Length; i++)
            {
                span[i]?.Stop();
            }
        }

        /// <summary>Exits this instance.</summary>
        internal void Exit()
        {
            Span<Component> span = components.Span;
            for (int i = 0; i < span.Length; i++)
            {
                span[i]?.Exit();
            }
        }

        #region DefineEvents

        /// <summary>Games the object on enable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void GameObject_OnEnable([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Games the object on disable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void GameObject_OnDisable([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}