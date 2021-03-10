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
        private GameObject gameObject;

        [JsonIgnore]
        public GameObject GameObject { get => gameObject; set => gameObject = value; }

        /// <summary>Starts this instance.</summary>
        public abstract void Start();

        /// <summary>Updates this instance.</summary>
        public abstract void Update();

        public event EventHandler<bool> OnCreate;

        /// <summary>Called when [enable].</summary>
        public event EventHandler<bool> OnEnable;

        public event EventHandler<bool> OnStart;

        /// <summary>Afters the update.</summary>
        public event EventHandler<bool> OnBeforeUpdate;

        public event EventHandler<bool> OnUpdate;

        /// <summary>Afters the update.</summary>
        public event EventHandler<bool> OnAfterUpdate;

        /// <summary>Called when [disable].</summary>
        public event EventHandler<bool> OnDisable;

        /// <summary>Called when [destroy].</summary>
        public event EventHandler<bool> OnDestroy;
    }
}