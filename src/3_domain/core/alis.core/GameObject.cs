namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    /// <summary>Represent a object of the videogame.</summary>
    public class GameObject : IDisposable
    {
        /// <summary>The name</summary>
        [NotNull]
        private Name name;

        /// <summary>The tag</summary>
        [NotNull]
        private Tag tag;

        /// <summary>The is active</summary>
        [NotNull]
        private IsActive isActive;

        /// <summary>The is static</summary>
        [NotNull]
        private IsStatic isStatic;

        /// <summary>The transform</summary>
        [NotNull]
        private Transform transform;

        /// <summary>The components</summary>
        [NotNull]
        private List<Component> components;

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        public GameObject()
        {
            name = new Name("Default");
            tag = new Tag("Default");
            isActive = new IsActive(true);
            isStatic = new IsStatic(false);
            transform = new Transform();
            components = new List<Component>();

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        public GameObject([NotNull] string name)
        {
            name ??= "Default";

            this.name = new Name(name);
            tag = new Tag("Default");
            isActive = new IsActive(true);
            isStatic = new IsStatic(false);
            transform = new Transform();
            components = new List<Component>();

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        public GameObject([NotNull] string name, [NotNull] Transform transform)
        {
            name ??= "Default";
            transform ??= new Transform();

            this.name = new Name(name);
            tag = new Tag("Default");
            isActive = new IsActive(true);
            isStatic = new IsStatic(false);
            this.transform = transform;
            components = new List<Component>();

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        public GameObject([NotNull] string name, [NotNull] Transform transform, [NotNull] params Component[] components)
        {
            name ??= "Default";
            transform ??= new Transform();
            components ??= new Component[0];

            this.name = new Name(name);
            tag = new Tag("Default");
            isActive = new IsActive(true);
            isStatic = new IsStatic(false);
            this.transform = transform;
            this.components = new List<Component>(components);

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="isActive"></param>
        /// <param name="isStatic"></param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        [JsonConstructor]
        public GameObject([NotNull] Name name, [NotNull] Tag tag, [NotNull] IsActive isActive, [NotNull] IsStatic isStatic, [NotNull] Transform transform, [NotNull] params Component[] components)
        {
            name ??= new Name("Default");
            tag ??= new Tag("Default");
            transform ??= new Transform();
            components ??= new Component[0];

            isActive ??= new IsActive(true);
            isStatic ??= new IsStatic(true);

            this.name = name;
            this.tag = tag;
            this.isActive = isActive;
            this.isStatic = isStatic;
            this.transform = transform;
            this.components = new List<Component>(components);

            this.components.ForEach(component => component.AttachTo(this));

            OnEnable += GameObject_OnEnable;
            OnDisable += GameObject_OnDisable;
        }

        #endregion

        /// <summary>Occurs when [on enable].</summary>
        public event EventHandler<bool> OnEnable;

        /// <summary>Occurs when [on disable].</summary>
        public event EventHandler<bool> OnDisable;

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [NotNull]
        [JsonProperty("_Name")]
        public Name Name { get => name; set => name = value; }

        /// <summary>Gets or sets the tag.</summary>
        /// <value>The tag.</value>
        [NotNull]
        [JsonProperty("_Tag")]
        public Tag Tag { get => tag; set => tag = value; }

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [NotNull]
        [JsonProperty("_IsActive")]
        public IsActive IsActive
        {
            get => isActive; 
            set
            {
                isActive = value;
                if (isActive.Value)
                {
                    OnEnable.Invoke(this, true);
                }
                else 
                {
                    OnDisable.Invoke(this, true);
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether this instance is static.</summary>
        /// <value>
        /// <c>true</c> if this instance is static; otherwise, <c>false</c>.</value>
        [NotNull]
        [JsonProperty("_IsStatic")]
        public IsStatic IsStatic { get => isStatic; set => isStatic = value; }

        /// <summary>Gets or sets the transform.</summary>
        /// <value>The transform.</value>
        [NotNull]
        [JsonProperty("_Transform")]
        public Transform Transform { get => transform; set => transform = value; }

        /// <summary>Gets the components.</summary>
        /// <value>The components.</value>
        [NotNull]
        [JsonProperty("_Components")]
        public Component[] Components { get => components.ToArray(); }
       
        /// <summary>Adds the specified component.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component">The component.</param>
        /// <exception cref="System.Exception">Alredy exits the same type of component on '{name}' gameobject.</exception>
        /// <exception cref="System.NullReferenceException">Component param is NULL on '{name}' gameobject.
        /// or
        /// 'Components' LIST is NULL on '{name}' gameobject.</exception>
        [return: NotNull]
        public void Add<T>([NotNull] T component) where T : Component
        {
            if (components is not null)
            {
                if (component is not null)
                {
                    for (int index = 0; index < components.Count; index++)
                    {
                        if (components[index].GetType().Equals(typeof(T)))
                        {
                            throw new Exception($"Alredy exits the same type of component on '{name}' gameobject.");
                        }
                    }

                    component.AttachTo(this);
                    components.Add(component);
                }
                else 
                {
                    throw new NullReferenceException($"Component param is NULL on '{name}' gameobject.");
                }
            }
            else 
            {
                throw new NullReferenceException($"'Components' LIST is NULL on '{name}' gameobject.");
            }   
        }

        /// <summary>Removes this instance.</summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.NullReferenceException">'Components' LIST is NULL on '{name}' gameobject.</exception>
        [return: NotNull]
        public bool Remove<T>() where T : Component
        {
            if (components is not null)
            {
                if (components.Count > 0)
                {
                    for (int index = 0; index < components.Count; index++)
                    {
                        if (components[index].GetType().Equals(typeof(T)))
                        {
                            components.RemoveAt(index);
                            return true;
                        }
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            else 
            {
                throw new NullReferenceException($"'Components' LIST is NULL on '{name}' gameobject.");
            }
        }

        /// <summary>Removes the specified component.</summary>
        /// <param name="component">The component.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.NullReferenceException">'Components' LIST is NULL on '{name}' gameobject.</exception>
        public bool Remove(Component component) 
        {
            if (components is not null)
            {
                if (components.Count > 0)
                {
                    for (int index = 0; index < components.Count; index++)
                    {
                        if (components[index].GetType().Equals(component.GetType()))
                        {
                            components.RemoveAt(index);
                            return true;
                        }
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new NullReferenceException($"'Components' LIST is NULL on '{name}' gameobject.");
            }
        }

        /// <summary>Gets this instance.</summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.NullReferenceException">'Components' LIST is NULL on '{name}' gameobject.</exception>
        [return: MaybeNull]
        public Component Get<T>() where T : Component
        {
            if (components is not null)
            {
                if (components.Count > 0)
                {
                    for (int index = 0; index < components.Count; index++)
                    {
                        if (components[index].GetType().Equals(typeof(T)))
                        {
                            return components[index];
                        }
                    }

                    return null;
                }
                else
                {
                    return null;
                }
            }
            else 
            {
                throw new NullReferenceException($"'Components' LIST is NULL on '{name}' gameobject.");
            }
        }

        /// <summary>Determines whether this instance contains the object.</summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///   <c>true</c> if [contains]; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.NullReferenceException">'Components' LIST is NULL on '{name}' gameobject.</exception>
        [return: NotNull]
        public bool Contains<T>() where T : Component
        {
            if (components is not null)
            {
                if (components.Count > 0)
                {
                    for (int index = 0; index < components.Count; index++)
                    {
                        if (components[index].GetType().Equals(typeof(T)))
                        {
                            return true;
                        }
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new NullReferenceException($"'Components' LIST is NULL on '{name}' gameobject.");
            }
        }

        /// <summary>Enables this instance.</summary>
        public void Enable() => components.ForEach(component => component.Enable());

        /// <summary>Disables this instance.</summary>
        public void Disable() => components.ForEach(component => component.Disable());

        /// <summary>Awakes this instance.</summary>
        public void Awake()
        {
            if (isActive.Value) 
            {
                components.ForEach(component =>
                {
                    if (component.IsActive)
                    {
                        component.Awake();
                    }
                });
            }
        }

        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            if (isActive.Value)
            {
                components.ForEach(component =>
                {
                    if (component.IsActive)
                    {
                        component.Start();
                    }
                });
            }
        }

        /// <summary>Befores the update.</summary>
        public void BeforeUpdate()
        {
            if (isActive.Value && !isStatic.Value)
            {
                components.ForEach(component =>
                {
                    if (component.IsActive)
                    {
                        component.BeforeUpdate();
                    }
                });
            }
        }

        /// <summary>Updates this instance.</summary>
        public void Update()
        {
            if (isActive.Value && !isStatic.Value)
            {
                components.ForEach(component =>
                {
                    if (component.IsActive)
                    {
                        component.Update();
                    }
                });
            }
        }

        /// <summary>Afters the update.</summary>
        public void AfterUpdate()
        {
            if (isActive.Value && !isStatic.Value)
            {
                components.ForEach(component =>
                {
                    if (component.IsActive)
                    {
                        component.AfterUpdate();
                    }
                });
            }
        }

        /// <summary>Afters the update.</summary>
        public void FixedUpdate()
        {
            if (isActive.Value && !isStatic.Value)
            {
                components.ForEach(component =>
                {
                    if (component.IsActive)
                    {
                        component.FixedUpdate();
                    }
                });
            }
        }

        /// <summary>Stops this instance.</summary>
        public void Stop()
        {
            if (isActive.Value && !isStatic.Value) 
            {
                components.ForEach(component =>
                {
                    if (component.IsActive)
                    {
                        component.Stop();
                    }
                });
            }
        }

        /// <summary>Resets this instance.</summary>
        public void Reset()
        {
            if (isActive.Value) 
            {
                components.ForEach(component =>
                {
                    if (component.IsActive)
                    {
                        component.Reset();
                    }
                });
            }
        }

        /// <summary>Exits this instance.</summary>
        public void Exit() => components.ForEach(component => component.Exit());

        #region Events

        /// <summary>Games the object on enable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        [return: NotNull]
        private void GameObject_OnEnable([NotNull] object sender, [NotNull] bool e) { }

        /// <summary>Games the object on disable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        [return: NotNull]
        private void GameObject_OnDisable([NotNull] object sender, [NotNull] bool e) { }

        #endregion

        #region Validatios

        /// <summary>Determines whether the specified <see cref="System.Object" />, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        [return: NotNull]
        public override bool Equals([NotNull] object obj) => base.Equals(obj);

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        [return: NotNull]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        [return: NotNull]
        public override string ToString() => base.ToString();

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        [return: NotNull]
        public void Dispose() => Exit();

        #endregion

        /// <summary>Builders this instance.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public static GameObjectBuilder Create() => new GameObjectBuilder();

        public static GameObject Create(string name) => new GameObject(name);


        #region Destructor

        /// <summary>Finalizes an instance of the <see cref="GameObject" /> class.</summary>
        ~GameObject() => Console.WriteLine($"Destroyed gameobject '{name}'.");

        #endregion
    }
}