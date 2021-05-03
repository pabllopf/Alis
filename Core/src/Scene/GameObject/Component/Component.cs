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
        /// <summary>The default icon</summary>
        private string defaultIcon = "\uf1c9";

        /// <summary>The game object</summary>
        [AllowNull]
        [JsonIgnore]
        private GameObject gameObject;

        /// <summary>The is enabled</summary>
        [NotNull]
        private bool active;

        /// <summary>Initializes a new instance of the <see cref="Component" /> class.</summary>
        protected Component() => active = true;

        /// <summary>Initializes a new instance of the <see cref="Component" /> class.</summary>
        /// <param name="active">if set to <c>true</c> [active].</param>
        [JsonConstructor]
        protected Component(bool active) => this.active = active;

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
        [JsonIgnore]
        public GameObject GameObject { get => gameObject; }
        
        public virtual string GetIcon() 
        {
            return defaultIcon;
        }

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

        /// <summary>Fixed the update.</summary>
        public virtual void FixedUpdate()
        {
        }

        /// <summary>Disable this instance.</summary>
        public virtual void Disable() 
        {
        }

        /// <summary>Called when [collision enter].</summary>
        /// <param name="collision">The collision.</param>
        public virtual void OnCollionEnter(Component collision)
        {
        }

        /// <summary>Called when [collision exit].</summary>
        /// <param name="collision">The collision.</param>
        public virtual void OnCollionExit(Component collision)
        {
        }

        /// <summary>Called when [collision stay].</summary>
        /// <param name="collision">The collision.</param>
        public virtual void OnCollionStay(Component collision)
        {
        }

        /// <summary>Stops this instance.</summary>
        public virtual void Stop()
        {
        }

        /// <summary>Exits this instance.</summary>
        public virtual void Exit()
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