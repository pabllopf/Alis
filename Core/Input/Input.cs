//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Input.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using SFML.Window;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>Manage the inputs of game.</summary>
    public class Input 
    {
        /// <summary>The keys</summary>
        private static List<Keyboard.Key> keys = new List<Keyboard.Key>();

        /// <summary>Occurs when [on press key].</summary>
        public static event EventHandler<Keyboard.Key> OnPressKey;

        /// <summary>Occurs when [on press once].</summary>
        public static event EventHandler<Keyboard.Key> OnPressKeyOnce;

        public Input(Config config)
        {
        }

        internal Task Awake() 
        {
            return Task.Run(() => 
            {
            });
        }

        internal Task Start()
        {
            return Task.Run(() =>
            {
            });
        }

        internal Task Update() 
        {
            return Task.Run(() =>
            {
                PollEvents();
            });
        }

        internal Task FixedUpdate()
        {
            return Task.Run(() =>
            {
            });
        }

        internal Task Exit()
        {
            return Task.Run(() =>
            {
            });
        }

        /// <summary>Polls the events.</summary>
        internal static void PollEvents()
        {
            foreach (Keyboard.Key key in Enum.GetValues(typeof(Keyboard.Key)))
            {
                if (Keyboard.IsKeyPressed(key) && !keys.Contains(key))
                {
                    keys.Add(key);
                    OnPressKeyOnce?.Invoke(key, key);
                }

                if (Keyboard.IsKeyPressed(key))
                {
                    OnPressKey?.Invoke(key, key);
                }
               
                if (!Keyboard.IsKeyPressed(key) && keys.Contains(key))
                {
                    keys.Remove(key);
                }
            }
        }


        internal Task Stop()
        {
            return Task.Run(() =>
            {
            });
        }
    }
}