//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Input.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    /// <summary>Manage the inputs of game.</summary>
    public class Input
    {
        /// <summary>The keys</summary>
        private static List<SFML.Window.Keyboard.Key> keys = new List<SFML.Window.Keyboard.Key>();

        /// <summary>Occurs when [on press key].</summary>
        public static event EventHandler<SFML.Window.Keyboard.Key> OnPressKey;

        /// <summary>Occurs when [on press once].</summary>
        public static event EventHandler<SFML.Window.Keyboard.Key> OnPressKeyOnce;

        public Input(Config config)
        {
        }

        internal Task Start()
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                watch.Stop();
                Logger.Log($"  Time to Start INPUT: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        internal Task Update() 
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                PollEvents();

                watch.Stop();
                Logger.Log($"  Time to UPDATE INPUT: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        /// <summary>Polls the events.</summary>
        internal static void PollEvents()
        {
            foreach (SFML.Window.Keyboard.Key key in Enum.GetValues(typeof(SFML.Window.Keyboard.Key)))
            {
                if (SFML.Window.Keyboard.IsKeyPressed(key))
                {
                    if (!keys.Contains(key))
                    {
                        keys.Add(key);
                        if (OnPressKeyOnce != null)
                        {
                            OnPressKeyOnce.Invoke(null, key);
                        }
                    }
                }

                if (SFML.Window.Keyboard.IsKeyPressed(key))
                {
                    if (OnPressKey != null)
                    {
                        OnPressKey.Invoke(null, key);
                    }
                }

                if (!SFML.Window.Keyboard.IsKeyPressed(key) && keys.Contains(key))
                {
                    keys.Remove(key);
                }
            }
        }
    }
}