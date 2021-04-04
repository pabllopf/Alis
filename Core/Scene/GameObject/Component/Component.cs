//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Component.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    /// <summary>Define a component</summary>
    public abstract class Component 
    {
        /// <summary>The game object</summary>
        [AllowNull]
        [JsonIgnore]
        private GameObject gameObject;

        /// <summary>The is enabled</summary>
        [NotNull]
        private bool active;

        /// <summary>Initializes a new instance of the <see cref="Component" /> class.</summary>
        protected Component()
        {
            this.active = true;
        }

        /// <summary>Initializes a new instance of the <see cref="Component" /> class.</summary>
        [JsonConstructor]
        protected Component(bool active)
        {
            this.active = active;
        }

        /// <summary>Gets or sets a value indicating whether this <see cref="Component" /> is active.</summary>
        /// <value>
        /// <c>true</c> if active; otherwise, <c>false</c>.</value>
        [NotNull]
        [JsonProperty("_IsActive")]
        public bool IsActive
        {
            get => active; 
            set
            {
                active = value;
                if (active)
                {
                    Enable();
                }
                else 
                {
                    Disable();
                }
            }
        }

        /// <summary>Gets the game object.</summary>
        /// <value>The game object.</value>
        public GameObject GameObject { get => gameObject; }

        /// <summary>Enable this instance.</summary>
        public virtual void Enable() 
        {
        }

        /// <summary>Awakes this instance.</summary>
        public virtual void Awake()
        {
        }

        /// <summary>Start this instance.</summary>
        public abstract void Start();

        /// <summary>Update this instance.</summary>
        public abstract void Update();

        /// <summary>Fixeds the update.</summary>
        public virtual void FixedUpdate()
        {
        }

        /// <summary>Disable this instance.</summary>
        public virtual void Disable() 
        {
        }

        /// <summary>Destroy this instance.</summary>
        public virtual void OnCollionEnter(Component collision)
        {
        }

        /// <summary>Destroy this instance.</summary>
        public virtual void OnCollionExit(Component collision)
        {
        }

        /// <summary>Destroy this instance.</summary>
        public virtual void OnCollionStay(Component collision)
        {
        }

        /// <summary>Attaches to.</summary>
        /// <param name="gameObject">The game object.</param>
        internal void AttachTo([NotNull] GameObject gameObject) 
        {
            this.gameObject = gameObject;
        }
    }
}