//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Define a game object.</summary>
    public class GameObject
    {
        #region Const Messages

        /// <summary>The don't find component</summary>
        private const string DontFindComponent = "Don't find the component '{0}' on the gameobject '{1}'.";

        /// <summary>The find component</summary>
        private const string FindComponent = "Find the component '{0}' on the gameobject '{1}'.";

        /// <summary>The limit number component</summary>
        private const string LimitNumComponent = "Limit of component in the gameobject '{0}' is {1} components.";

        /// <summary>The delete component</summary>
        private const string DeleteComponent = "Delete the component '{0}' on the gameobject '{1}'.";

        /// <summary>The don't delete component</summary>
        private const string DontDeleteComponent = "Can't delete the component '{0}' on the gameobject '{1}' because don`t exits on the gameobject.";

        /// <summary>The add component</summary>
        private const string AddComponent = "Add the component '{0}' on the gameobject '{1}'.";

        /// <summary>The contains component</summary>
        private const string ContainsComponent = "Exits the component '{0}' on the gameobject '{1}'.";

        /// <summary>The don't contains component</summary>
        private const string DontContainsComponent = "Dont`t exits the component '{0}' on the gameobject '{1}'.";

        /// <summary>The don't add same component</summary>
        private const string DontAddSameComponent = "Component '{0}' alredy exits on the gameobject '{1}'. You can not add two identical component to the gameobject.";

        #endregion

        /// <summary>The maximum number components</summary>
        [NotNull]
        private const int MaxNumComponents = 10;

        /// <summary>The transform</summary>
        [NotNull]
        private Transform transform;

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
                throw Logger.Error("The limit size of components[] is " + MaxNumComponents);
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

            this.isActive = isActive;
            this.isStatic = isStatic;

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;

            Logger.Info();
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

            Logger.Info();
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

            Logger.Info();
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

            Logger.Info();
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        public GameObject([NotNull] string name, [NotNull] Transform transform, [NotNull] params Component[] components)
        {
            if (components.Length > MaxNumComponents) 
            {
                throw Logger.Error("The limit size of components[] is " + MaxNumComponents);
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

            isActive = true;
            isStatic = false;

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;

            IsActive = true;

            Logger.Info();
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
                if (span[i] != null && span[i].IsActive && span[i].GetType().Equals(typeof(T)))
                {
                    Logger.Log(string.Format(ContainsComponent, typeof(T).FullName, this.name));
                    return true;
                }
            }

            Logger.Log(string.Format(DontContainsComponent, typeof(T).FullName, this.name));
            return false;
        }

        public bool Contains(Component component) 
        {
            Span<Component> span = components.Span;
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] != null && span[i].IsActive && span[i].GetType().Equals(component.GetType()))
                {
                    Logger.Log(string.Format(ContainsComponent, component.GetType().FullName, this.name));
                    return true;
                }
            }

            Logger.Log(string.Format(DontContainsComponent, component.GetType().FullName, this.name));
            return false;
        }

        /// <summary>Adds the specified component.</summary>
        /// <typeparam name="T">Type component</typeparam>
        /// <param name="component">The component.</param>
        public void Add<T>([NotNull] T component) where T : Component
        {
            if (Contains<T>())
            {
                throw Logger.Error(string.Format(DontAddSameComponent, typeof(T).FullName, this.name));
            }

            Span<Component> span = components.Span;
            for (int i = 0; i < components.Length; i++) 
            {
                if (span[i] is null || !span[i].IsActive)
                {
                    span[i] = component;
                    span[i].IsActive = true;
                    Logger.Log(string.Format(AddComponent, typeof(T).FullName, this.name));
                    return;
                }
            }

            Logger.Warning(string.Format(LimitNumComponent, typeof(T).FullName, this.name));
        }

        /// <summary>Removes this instance.</summary>
        /// <typeparam name="T">general type</typeparam>
        public void Delete<T>() where T : Component
        {
            Span<Component> span = components.Span;
            for (int i = 0; i < components.Length; i++) 
            {
                if (span[i] != null && span[i].IsActive && span[i].GetType().Equals(typeof(T)))
                {
                    Logger.Log(string.Format(DeleteComponent, typeof(T).FullName, this.name));
                    span[i] = null;
                    return;
                }
            }

            Logger.Warning(string.Format(DontDeleteComponent, typeof(T).FullName, this.name));
        }

        public void Delete(Component component) 
        {
            Span<Component> span = components.Span;
            for (int i = 0; i < components.Length; i++)
            {
                if (span[i] != null && span[i].IsActive && span[i].GetType().Equals(component.GetType()))
                {
                    Logger.Log(string.Format(DeleteComponent, component.GetType().FullName, this.name));
                    span[i] = null;
                    return;
                }
            }

            Logger.Warning(string.Format(DontDeleteComponent, component.GetType().FullName, this.name));
        }


        /// <summary>Gets the component.</summary>
        /// <typeparam name="T">general type</typeparam>
        /// <returns>Return the component</returns>
        [return: MaybeNull]
        public T? Get<T>() where T : Component
        {
            Span<Component> span = components.Span;
            for (int i = 0; i < components.Length; i++) 
            {
                if (span[i] != null && span[i].IsActive && span[i].GetType().Equals(typeof(T))) 
                {
                    Logger.Log(string.Format(FindComponent, typeof(T).FullName, this.name));
                    return (T?)span[i];
                }
            }

            Logger.Warning(string.Format(DontFindComponent, typeof(T).FullName, this.name));
            return null;
        }

        /// <summary>Gets the component.</summary>
        /// <typeparam name="T">general type</typeparam>
        /// <returns>Return the component</returns>
        [return: MaybeNull]
        public Component Get(Component component)
        {
            Span<Component> span = components.Span;
            for (int i = 0; i < components.Length; i++)
            {
                if (span[i] != null && span[i].IsActive && span[i].GetType().Equals(component.GetType()))
                {
                    Logger.Log(string.Format(FindComponent, component.GetType().FullName, this.name));
                    return span[i];
                }
            }

            Logger.Warning(string.Format(DontFindComponent, component.GetType().FullName, this.name));
            return null;
        }

        [return: MaybeNull]
        public void Set(Component component, int pos)
        {
            components.Span[pos] = component;
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


        public static GameObjectBuilder Builder() => new GameObjectBuilder();

        public class GameObjectBuilder
        {
            /// <summary>The current</summary>
            [AllowNull]
            private GameObjectBuilder current;

            /// <summary>The name</summary>
            [AllowNull]
            private string name;

            /// <summary>The transform</summary>
            [AllowNull]
            private Transform transform;

            /// <summary>The components</summary>
            [AllowNull]
            private List<Component> components;

            /// <summary>Initializes a new instance of the <see cref="VideoGameBuilder" /> class.</summary>
            public GameObjectBuilder() => current ??= this;

            /// <summary>Sets the name.</summary>
            /// <param name="name">The name.</param>
            /// <returns>return game object.</returns>
            public GameObjectBuilder Name(string name)
            {
                current.name = name;
                return current;
            }

            /// <summary>Adds the component.</summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="component">The component.</param>
            /// <returns>return game object.</returns>
            public GameObjectBuilder Component<T>(T component) where T : Component 
            {
                current.components ??= new List<Component>();
                current.components.Add(component);
                return current;
            }

            /// <summary>Transforms the specified transform.</summary>
            /// <param name="transform">The transform.</param>
            /// <returns> </returns>
            public GameObjectBuilder Transform(Transform transform) 
            {
                current.transform = transform;
                return current;
            }

            /// <summary>Builds this instance.</summary>
            /// <returns>Return the build. </returns>
            public GameObject Build()
            {
                current.name ??= "GameObject";
                current.transform ??= new Transform();
                current.components ??= new List<Component>();

                return new GameObject(current.name, current.transform, current.components.ToArray());
            }
        }
    }
}