//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Input.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>Manage the inputs of game.</summary>
    public class Input 
    {
        private Config config;

        /// <summary>The keys</summary>
        private static List<Keyboard> keys = new List<Keyboard>();

        /// <summary>Occurs when [on press key].</summary>
        public static event EventHandler<Keyboard> OnPressKey;

        /// <summary>Occurs when [on press once].</summary>
        public static event EventHandler<Keyboard> OnPressKeyOnce;

        public Input(Config config)
        {
            this.config = config;
        }

        public virtual Task Awake() { return Task.Run(() => { }); }

        public virtual Task Start() { return Task.Run(() => { }); }

        public virtual Task Update() { return Task.Run(() => { }); }

        public virtual Task FixedUpdate() { return Task.Run(() => { }); }

        /// <summary>Polls the events.</summary>
        internal void PollEvents()
        {
            foreach (Keyboard key in Enum.GetValues(typeof(Keyboard)))
            {
                if (IsKeyPressed(key) && !keys.Contains(key))
                {
                    keys.Add(key);
                    OnPressKeyOnce?.Invoke(key, key);
                }

                if (IsKeyPressed(key))
                {
                    OnPressKey?.Invoke(key, key);
                }

                if (!IsKeyPressed(key) && keys.Contains(key))
                {
                    keys.Remove(key);
                }
            }
        }

        internal virtual bool IsKeyPressed(Keyboard key) { return true; }

        internal virtual Task Stop() { return Task.Run(()=> { }); }

        internal virtual Task Exit() { return Task.Run(() => { }); }
    }
}