namespace Alis.Core.Systems
{
    /// <summary>Define a system.</summary>
    public abstract class System
    {
        /// <summary>Awakes this instance.</summary>
        public abstract void Awake();

        /// <summary>Starts this instance.</summary>
        public abstract void Start();

        /// <summary>Befores the update.</summary>
        public abstract void BeforeUpdate();

        /// <summary>Updates this instance.</summary>
        public abstract void Update();

        /// <summary>Afters the update.</summary>
        public abstract void AfterUpdate();

        /// <summary>Fixeds the update.</summary>
        public abstract void FixedUpdate();

        /// <summary>Dispatches the events.</summary>
        public abstract void DispatchEvents();

        /// <summary>Resets this instance.</summary>
        public abstract void Reset();

        /// <summary>Stops this instance.</summary>
        public abstract void Stop();

        /// <summary>Exits this instance.</summary>
        public abstract void Exit();
    }
}