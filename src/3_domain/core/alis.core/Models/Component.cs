namespace Alis.Core
{
    using FluentApi;

    /// <summary>Define a general component.</summary>
    public abstract class Component 
    {
        public Active IsActive { get; set; } = new(true);

        internal bool Destroyed { get; set; } = false;

        public GameObject GameObject { get; internal set; } = new GameObject();

        public void AttachTo(GameObject gameObject) => GameObject = gameObject;

        internal void OnDestroy()
        {
            Destroyed = true;
            IsActive.Value = false;
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

        public virtual void Destroy() 
        {
        
        }

        /// <summary>Exits this instance.</summary>
        public virtual void Exit()
        {
        }
    }
}