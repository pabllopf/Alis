//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Component.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    /// <summary>Define a component</summary>
    public abstract class Component : GameObject
    {
        /// <summary>Initializes a new instance of the <see cref="Component" /> class.</summary>
        public Component() => Logger.Info();

        /// <summary>Awakes this instance.</summary>
        public  virtual void Awake() => Logger.Info();

        /// <summary>Called when [enable].</summary>
        public virtual void OnEnable() => Logger.Info();

        /// <summary>Starts this instance.</summary>
        public new abstract void Start();

        /// <summary>Afters the update.</summary>
        public virtual void BeforeUpdate() => Logger.Info();

        /// <summary>Updates this instance.</summary>
        public new abstract void Update();

        /// <summary>Fixeds the update.</summary>
        public virtual void FixedUpdate() => Logger.Info();

        /// <summary>Afters the update.</summary>
        public virtual void AfterUpdate() => Logger.Info();

        /// <summary>Called when [disable].</summary>
        public virtual void OnDisable() => Logger.Info();

        /// <summary>Called when [destroy].</summary>
        public virtual void OnDestroy() => Logger.Info();
    }
}