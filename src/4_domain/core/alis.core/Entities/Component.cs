namespace Alis.Core.Entities
{
    /// <summary>Define a general component.</summary>
    public abstract class Component
    {
        /// <summary>
        /// Gets or sets the value of the is active
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the value of the destroyed
        /// </summary>
        internal bool Destroyed { get; set; }

        /// <summary>
        /// Gets or sets the value of the game object
        /// </summary>
        public GameObject GameObject { get; internal set; } = new();

        /// <summary>
        /// Attaches the to using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void AttachTo(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        /// <summary>
        /// Ons the destroy
        /// </summary>
        internal void OnDestroy()
        {
            Destroyed = true;
            IsActive = false;
        }

        /// <summary>Enables this instance.</summary>
        public virtual void Enable()
        {
        }

        /// <summary>Disables this instance.</summary>
        public virtual void Disable()
        {
        }

        /// <summary>Awakes this instance.</summary>
        public virtual void Awake()
        {
        }

        /// <summary>Starts this instance.</summary>
        public abstract void Start();

        /// <summary>Befores the update.</summary>
        public virtual void BeforeUpdate()
        {
        }

        /// <summary>Updates this instance.</summary>
        public abstract void Update();

        /// <summary>Afters the update.</summary>
        public virtual void AfterUpdate()
        {
        }

        /// <summary>Fixeds the update.</summary>
        public virtual void FixedUpdate()
        {
        }

        /// <summary>
        /// Dispatches the events
        /// </summary>
        public virtual void DispatchEvents()
        {
        }

        /// <summary>Stops this instance.</summary>
        public virtual void Stop()
        {
        }

        /// <summary>Resets this instance.</summary>
        public virtual void Reset()
        {
        }

        /// <summary>
        /// Destroys this instance
        /// </summary>
        public virtual void Destroy()
        {
        }

        /// <summary>Exits this instance.</summary>
        public virtual void Exit()
        {
        }
    }
}