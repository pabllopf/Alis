//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Input.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Alis.Tools;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    /// <summary>Manage the inputs of game.</summary>
    public class Input
    {
        /// <summary>The configuration</summary>
        [NotNull]
        private Config config;

        /// <summary>The keys</summary>
        [AllowNull]
        private static List<Keyboard> keys;

        /// <summary>Initializes the <see cref="Input" /> class.</summary>
        static Input() 
        {
            Keys = new List<Keyboard>();
            OnPressKey += Input_OnPressKey;
            OnPressKeyOnce += Input_OnPressKeyOnce;
        }

        /// <summary>Initializes a new instance of the <see cref="Input" /> class.</summary>
        /// <param name="config">The configuration.</param>
        public Input(Config config)
        {
            this.config = config;
        }

        /// <summary>Occurs when [on press key].</summary>
        public static event EventHandler<Keyboard> OnPressKey;

        /// <summary>Occurs when [on press once].</summary>
        public static event EventHandler<Keyboard> OnPressKeyOnce;

        /// <summary>Gets or sets the keys.</summary>
        /// <value>The keys.</value>
        public static List<Keyboard> Keys { get => keys; set => keys = value; }

        /// <summary>Awakes this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual Task Awake() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual Task Start() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual Task Update() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Fixed the update.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual Task FixedUpdate() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Stops this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual Task Stop() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Exits this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual Task Exit() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Polls the events.</summary>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual void PollEvents() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Presses the key.</summary>
        /// <param name="key">The key.</param>
        public void PressKey(Keyboard key) => OnPressKey?.Invoke(this, key);

        /// <summary>Presses the key once.</summary>
        /// <param name="key">The key.</param>
        public void PressKeyOnce(Keyboard key) => OnPressKeyOnce?.Invoke(this, key);

        #region Define Events

        /// <summary>Inputs the on press key.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keyboard">The keyboard.</param>
        private static void Input_OnPressKey([NotNull] object sender, [NotNull] Keyboard keyboard) => Logger.Info();

        /// <summary>Inputs the on press key once.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keyboard">The keyboard.</param>
        private static void Input_OnPressKeyOnce([NotNull] object sender, [NotNull] Keyboard keyboard) => Logger.Info();

        #endregion
    }
}