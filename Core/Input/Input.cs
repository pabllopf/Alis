//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Input.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>Manage the inputs of game.</summary>
    public class Input
    {
        /// <summary>The keys</summary>
        private static List<SFML.Window.Keyboard.Key> keys = new List<SFML.Window.Keyboard.Key>();

        /// <summary>Occurs when [on press key].</summary>
        public static event EventHandler<SFML.Window.Keyboard.Key> OnPressKey;

        /// <summary>Occurs when [on press once].</summary>
        public static event EventHandler<SFML.Window.Keyboard.Key> OnPressKeyOnce;

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