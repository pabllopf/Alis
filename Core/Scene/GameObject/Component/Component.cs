//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Component.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Define a component</summary>
    public abstract class Component 
    {
        /// <summary>The game object</summary>
        [NotNull]
        [JsonIgnore]
        private GameObject gameObject;

        /// <summary>The is enabled</summary>
        [NotNull]
        private bool active = true;

        /// <summary>Initializes a new instance of the <see cref="Component" /> class.</summary>
        [JsonConstructor]
        protected Component()
        {
            gameObject = new GameObject();

            OnCreate += Component_OnCreate;
            OnEnable += Component_OnEnable;
            OnDisable += Component_OnDisable;
            OnDestroy += Component_OnDestroy;

            OnCreate.Invoke(this, true);
            Create();
        }

        /// <summary>Finalizes an instance of the <see cref="Component" /> class.</summary>
        ~Component()
        {
            OnDestroy.Invoke(this, true);
            Destroy();
        }

        /// <summary>Occurs when [on create].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Occurs when [on enable].</summary>
        public event EventHandler<bool> OnEnable;

        /// <summary>Occurs when [on disable].</summary>
        public event EventHandler<bool> OnDisable;

        /// <summary>Occurs when [on destroy].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>Gets or sets a value indicating whether this <see cref="Component" /> is active.</summary>
        /// <value>
        /// <c>true</c> if active; otherwise, <c>false</c>.</value>
        [NotNull]
        public bool Active
        {
            get => active; 
            set
            {
                active = value;
                if (active)
                {
                    OnEnable.Invoke(this, true);
                    Enable();
                }
                else 
                {
                    OnDisable.Invoke(this, true);
                    Disable();
                }
            }
        }

        /// <summary>Creates this instance.</summary>
        public virtual void Create()
        {
        }

        /// <summary>Enable this instance.</summary>
        public virtual void Enable() 
        {
        }

        /// <summary>Awakes this instance.</summary>
        public virtual void Awake()
        {
        }

        /// <summary>Before the update.</summary>
        public virtual void BeforeUpdate() 
        {
        }

        /// <summary>Start this instance.</summary>
        public abstract void Start();

        /// <summary>Update this instance.</summary>
        public abstract void Update();

        /// <summary>After the update.</summary>
        public virtual void AfterUpdate() 
        {
        }

        /// <summary>Disable this instance.</summary>
        public virtual void Disable() 
        {
        }

        /// <summary>Destroy this instance.</summary>
        public virtual void Destroy() 
        {
        }


        /// <summary>Destroy this instance.</summary>
        public virtual void OnCollionEnter(Collision collision)
        {
        }

        /// <summary>Destroy this instance.</summary>
        public virtual void OnCollionExit(Collision collision)
        {
        }

        /// <summary>Destroy this instance.</summary>
        public virtual void OnCollionStay(Collision collision)
        {
        }


        /// <summary>Attaches to.</summary>
        /// <param name="gameObject">The game object.</param>
        internal void AttachTo([NotNull] GameObject gameObject) 
        {
            this.gameObject = gameObject;
        }

        public GameObject GetGameObject() 
        {
            return this.gameObject;
        }

        #region DefineEvents

        /// <summary>Components the on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Component_OnCreate([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Components the on enable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Component_OnEnable([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Components the on disable.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Component_OnDisable([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Components the on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Component_OnDestroy([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion

        public virtual int Priority()
        {
            return 8;
        }
    }
}