//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Component.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using Newtonsoft.Json;

    /// <summary>Define a component</summary>
    public abstract class Component
    {
        /// <summary>Initializes a new instance of the <see cref="Component" /> class.</summary>
        public Component() => OnCreate?.Invoke(null, true);

        ~Component() => OnDestroy?.Invoke(null, true);

        public event EventHandler<bool> OnCreate;

        /// <summary>Called when [enable].</summary>
        public event EventHandler<bool> OnEnable;

        /// <summary>Starts this instance.</summary>
        public new abstract void Start();

        /// <summary>Afters the update.</summary>
        public event EventHandler<bool> OnBeforeUpdate;

        /// <summary>Updates this instance.</summary>
        public new abstract void Update();

        /// <summary>Afters the update.</summary>
        public event EventHandler<bool> OnAfterUpdate;

        /// <summary>Called when [disable].</summary>
        public event EventHandler<bool> OnDisable;

        /// <summary>Called when [destroy].</summary>
        public event EventHandler<bool> OnDestroy;
    }
}