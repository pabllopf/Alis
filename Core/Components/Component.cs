//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Component.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core.Components
{
    using System;
    using Newtonsoft.Json;

    /// <summary>Define a component</summary>
    public abstract class Component 
    {
        /// <summary>The game object</summary>
        private GameObject gameObject;

        /// <summary>Occurs when [on create].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Occurs when [on enable].</summary>
        public event EventHandler<bool> OnEnable;

        /// <summary>Occurs when [on start].</summary>
        public event EventHandler<bool> OnStart;

        /// <summary>Occurs when [on before update].</summary>
        public event EventHandler<bool> OnBeforeUpdate;

        /// <summary>Occurs when [on update].</summary>
        public event EventHandler<bool> OnUpdate;

        /// <summary>Occurs when [on after update].</summary>
        public event EventHandler<bool> OnAfterUpdate;

        /// <summary>Occurs when [on disable].</summary>
        public event EventHandler<bool> OnDisable;

        /// <summary>Occurs when [on destroy].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>Gets or sets the game object.</summary>
        /// <value>The game object.</value>
        [JsonIgnore]
        public GameObject GameObject { get => gameObject; set => gameObject = value; }

        /// <summary>Enable this instance.</summary>
        public virtual void Enable() 
        {
            OnEnable?.Invoke(this, true);
        }

        /// <summary>Await this instance.</summary>
        public virtual void Await() 
        {
        }

        /// <summary>Before the update.</summary>
        public virtual void BeforeUpdate() 
        {
            OnBeforeUpdate?.Invoke(this, true);
        }

        /// <summary>Start this instance.</summary>
        public abstract void Start();

        /// <summary>Update this instance.</summary>
        public abstract void Update();

        /// <summary>After the update.</summary>
        public virtual void AfterUpdate() 
        {
            OnAfterUpdate?.Invoke(this, true);
        }

        /// <summary>Collision the enter.</summary>
        /// <param name="collision">The collision.</param>
        public virtual void CollisionEnter(Collision collision) 
        {
        }

        /// <summary>Collision the exit.</summary>
        /// <param name="collision">The collision.</param>
        public virtual void CollisionExit(Collision collision)
        {
        }

        /// <summary>Collision the state.</summary>
        /// <param name="collision">The collision.</param>
        public virtual void CollisionState(Collision collision)
        {
        }

        /// <summary>Disable this instance.</summary>
        public virtual void Disable() 
        {
            OnDisable?.Invoke(this, true);
        }

        /// <summary>Destroy this instance.</summary>
        public virtual void Destroy() 
        {
            OnDestroy?.Invoke(this, true);
        }
    }
}