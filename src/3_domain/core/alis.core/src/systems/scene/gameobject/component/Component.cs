using Alis.Fluent;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core
{
    /// <summary>Define a general component.</summary>
    public abstract class Component : IDisposable
    {
        /// <summary>The is active</summary>
        [NotNull]
        private bool isActive;

        /// <summary>The game object</summary>
        [MaybeNull]
        private GameObject gameObject;

        /// <summary>The game object</summary>
        [MaybeNull]
        private Tag tag;

        /// <summary>The game object</summary>
        [MaybeNull]
        private Transform transform;

        /// <summary>Initializes a new instance of the <see cref="Component" /> class.</summary>
        protected Component()
        {
            isActive = true;
            OnEnable += Component_OnEnable;
            OnDisable += Component_OnDisable;
        }

        /// <summary>Initializes a new instance of the <see cref="Component" /> class.</summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        [JsonConstructor]
        protected Component(bool isActive)
        {
            this.isActive = isActive;

            OnEnable += Component_OnEnable;
            OnDisable += Component_OnDisable;
        }

        /// <summary>Occurs when [on enable].</summary>
        public event EventHandler<bool> OnEnable;

        /// <summary>Occurs when [on disable].</summary>
        public event EventHandler<bool> OnDisable;

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [JsonProperty("_IsActive")]
        [NotNull]
        public bool IsActive
        {
            get => isActive; 
            set
            {
                isActive = value;
                if (isActive)
                {
                    OnEnable.Invoke(this, true);
                }
                else
                {
                    OnDisable.Invoke(this, true);
                }
            }
        }

        /// <summary>Gets or sets the game object.</summary>
        /// <value>The game object.</value>
        [JsonIgnore]
        [MaybeNull]
        public GameObject GameObject { get => gameObject;  }

        /// <summary>Gets the tag.</summary>
        /// <value>The tag.</value>
        [JsonIgnore]
        [MaybeNull]
        public Tag Tag { get => tag; }

        /// <summary>Gets the transform.</summary>
        /// <value>The transform.</value>
        [JsonIgnore]
        [MaybeNull]
        public Transform Transform { get => transform; }

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

        /// <summary>Stops this instance.</summary>
        public virtual void Stop() 
        {
        }

        /// <summary>Resets this instance.</summary>
        public virtual void Reset() 
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
            if (this.gameObject is not null) 
            {
                this.gameObject.Remove(this);
                this.gameObject = gameObject;
                this.gameObject.Add(this);

                transform = this.gameObject.Transform;
                tag = this.gameObject.Tag;
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public virtual void Dispose()
        {
        }

        #region Events

        /// <summary>Components the on enable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        [return: NotNull]
        private void Component_OnEnable([NotNull] object sender, [NotNull] bool e) => Enable();

        /// <summary>Components the on disable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        [return: NotNull]
        private void Component_OnDisable([NotNull] object sender, [NotNull] bool e) => Disable();

        #endregion

        #region Validations

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

        #endregion
    }
}