namespace Alis.Core
{
    /// <summary>Represent a object of the videogame.</summary>
    public class GameObject : Fluent.IBuilder<GameObjectBuilder>
    {
        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        public GameObject(string name)
        {
            Name = new Fluent.Name(name);
            Tag = new Fluent.Tag("Default");
            IsActive = new Fluent.Active(true);
            IsStatic = new Fluent.Static(false);
            Transform = new Transform();
            Components = new Component[100];
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="isStatic">The is static.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        [System.Text.Json.Serialization.JsonConstructor]
        public GameObject(Fluent.Name name, Fluent.Tag tag, Fluent.Active isActive, Fluent.Static isStatic, Transform transform, Component[] components)
        {
            Name = name;
            Tag = tag;
            IsActive = isActive;
            IsStatic = isStatic;
            Transform = transform;
            Components = new Component[100];
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [System.Text.Json.Serialization.JsonPropertyName("_Name")]
        public Fluent.Name Name { get; set; }

        /// <summary>Gets or sets the tag.</summary>
        /// <value>The tag.</value>
        [System.Text.Json.Serialization.JsonPropertyName("_Tag")]
        public Fluent.Tag Tag { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [System.Text.Json.Serialization.JsonPropertyName("_IsActive")]
        public Fluent.Active IsActive { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is static.</summary>
        /// <value>
        /// <c>true</c> if this instance is static; otherwise, <c>false</c>.</value>
        [System.Text.Json.Serialization.JsonPropertyName("_IsStatic")]
        public Fluent.Static IsStatic { get; set; }

        /// <summary>Gets or sets the transform.</summary>
        /// <value>The transform.</value>
        [System.Text.Json.Serialization.JsonPropertyName("_Transform")]
        public Transform Transform { get; set; }

        /// <summary>Gets the components.</summary>
        /// <value>The components.</value>
        [System.Text.Json.Serialization.JsonPropertyName("_Components")]
        public Component[] Components { get; protected set; }

        #endregion

        #region Add Component

        /// <summary>Adds the specified component.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component">The component.</param>
        public void Add(Component component)
        {
            component.AttachTo(this);
            Components[0] = component;
        }

        #endregion

        #region Delete Component

        public bool Remove<T>() where T : Component
        {
            return false;
        }

        public bool Remove(Component component)
        {
            return false;
        }

        #endregion

        #region Get Component


        public Component Get<T>() where T : Component
        {
            return default;
        }

        #endregion

        #region Contains Component 

        public bool Contains<T>() where T : Component 
        {
            return false;
        }

        #endregion

        /// <summary>Awakes this instance.</summary>
        public void Awake()
        {
            for (int index = 0; index < Components?.Length; index++)
            {
                Components[index]?.Awake();
            }
        }

        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            for (int index = 0; index < Components?.Length; index++)
            {
                Components[index]?.Start();
            }
        }

        /// <summary>Befores the update.</summary>
        public void BeforeUpdate()
        {
            for (int index = 0; index < Components?.Length; index++)
            {
                Components[index]?.BeforeUpdate();
            }
        }

        /// <summary>Updates this instance.</summary>
        public void Update()
        {
            for (int index = 0; index < Components?.Length; index++)
            {
                Components[index]?.Update();
            }
        }

        /// <summary>Afters the update.</summary>
        public void AfterUpdate()
        {
            for (int index = 0; index < Components?.Length; index++)
            {
                Components[index]?.AfterUpdate();
            }
        }

        /// <summary>Afters the update.</summary>
        public void FixedUpdate()
        {
            for (int index = 0; index < Components?.Length; index++)
            {
                Components[index]?.FixedUpdate();
            }
        }

        /// <summary>Stops this instance.</summary>
        public void Stop()
        {
            for (int index = 0; index < Components?.Length; index++)
            {
                Components[index]?.Stop();
            }
        }

        /// <summary>Resets this instance.</summary>
        public void Reset()
        {
            for (int index = 0; index < Components?.Length; index++)
            {
                Components[index]?.Reset();
            }
        }

        /// <summary>Exits this instance.</summary>
        public void Exit()
        {
            for (int index = 0; index < Components?.Length; index++)
            {
                Components[index]?.Exit();
            }
        }

        #region Destructor

        /// <summary>Finalizes an instance of the <see cref="GameObject" /> class.</summary>
        ~GameObject() 
        {
        }

        #endregion
    }
}