//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Input.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Manage the inputs of game.</summary>
    public class Input
    {
        #region Const Messages

        /// <summary>The message</summary>
        [NotNull]
        private const string ErrorMessage = "Implement the method {0}";

        #endregion

        /// <summary>
        /// The current
        /// </summary>
        private static Input current;

        /// <summary>
        /// Gets or sets the value of the current
        /// </summary>
        [JsonIgnore]

        public static Input Current { get => current; set => current = value; }

        /// <summary>The keys</summary>
        [AllowNull]
        private static List<Keyboard> keys;

        /// <summary>The configuration</summary>
        [NotNull]
        private readonly Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class
        /// </summary>
        static Input()
        {
            OnPressKey += Input_OnPressKey;
            OnReleaseOnce += Input_OnReleaseOnce;
        }

        /// <summary>Initializes a new instance of the <see cref="Input" /> class.</summary>
        /// <param name="config">The configuration.</param>
        public Input(Config config)
        {
            this.config = config;
            current ??= this;
            Logger.Info();

            keys ??= new List<Keyboard>();
        }

        /// <summary>Occurs when [on press key].</summary>
        public static event EventHandler<Keyboard> OnPressKey;

        /// <summary>Occurs when [on release once].</summary>
        public static event EventHandler<Keyboard> OnReleaseOnce;

        /// <summary>Gets or sets the keys.</summary>
        /// <value>The keys.</value>
        public static List<Keyboard> Keys { get => keys; set => keys = value; }

        /// <summary>Gets the configuration.</summary>
        /// <value>The configuration.</value>
        [NotNull]
        [JsonIgnore]
        public Config Config => config;

        /// <summary>Awakes this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="Logger.Error">Not Implemented</exception>
        public virtual void Awake() => throw Logger.Error(string.Format(ErrorMessage, GetType().FullName));

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="Logger.Error">Not Implemented</exception>
        public virtual void Start() => throw Logger.Error(string.Format(ErrorMessage, GetType().FullName));

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="Logger.Error">Not Implemented</exception>
        public virtual void Update() => throw Logger.Error(string.Format(ErrorMessage, GetType().FullName));

        /// <summary>Fixed the update.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="Logger.Error">Not Implemented</exception>
        public virtual void FixedUpdate() => throw Logger.Error(string.Format(ErrorMessage, GetType().FullName));

        /// <summary>Stops this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="Logger.Error">Not Implemented</exception>
        public virtual void Stop() => throw Logger.Error(string.Format(ErrorMessage, GetType().FullName));

        /// <summary>Exits this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="Logger.Error">Not Implemented</exception>
        public virtual void Exit() => throw Logger.Error(string.Format(ErrorMessage, GetType().FullName));

        /// <summary>Polls the events.</summary>
        /// <exception cref="Logger.Error">Not Implemented</exception>
        public virtual void PollEvents() => throw Logger.Error(string.Format(ErrorMessage, string.Format(ErrorMessage, GetType().FullName)));

        /// <summary>Presses the key.</summary>
        /// <param name="key">The key.</param>
        public void PressKey(Keyboard key) => OnPressKey?.Invoke(this, key);

        /// <summary>Releases the key.</summary>
        /// <param name="key">The key.</param>
        public void ReleaseKey(Keyboard key) => OnReleaseOnce?.Invoke(this, key);

        #region Define Events

        /// <summary>Inputs the on press key.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keyboard">The keyboard.</param>
        private static void Input_OnPressKey([NotNull] object sender, [NotNull] Keyboard keyboard) => Logger.Info();

        /// <summary>Inputs the on press key once.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keyboard">The keyboard.</param>
        private static void Input_OnPressKeyOnce([NotNull] object sender, [NotNull] Keyboard keyboard) => Logger.Info();


        /// <summary>
        /// Inputs the on release once using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void Input_OnReleaseOnce(object sender, Keyboard e) => Logger.Info();


        /// <summary>
        /// Clears
        /// </summary>
        public static void Clear()
        {
            Logger.Warning("Clean inputs");
        }

        #endregion
    }
}