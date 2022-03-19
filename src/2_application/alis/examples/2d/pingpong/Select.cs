//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón </author>
// <copyright file="Main.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------

using Alis;
using Alis.Core.Components;
using Alis.Core.Input;

namespace PingPong
{
    /// <summary>
    /// The select class
    /// </summary>
    /// <seealso cref="Component"/>
    public class Select : Component
    {
        /// <summary>
        /// Starts this instance
        /// </summary>
        public override void Start()
        {
            //Input.OnPressKey += Input_OnPressKeyOnce;
        }

        /// <summary>
        /// Inputs the on press key once using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="key">The key</param>
        private void Input_OnPressKeyOnce(object sender, Keyboard key)
        {
            /*
            if (key.Equals(Keyboard.Num1))
            {
                SceneManager.Load("Game");
                return;
            }

            if (key.Equals(Keyboard.Num2))
            {
                Environment.Exit(0);
                return;
            }*/
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public override void Update()
        {
        }
    }
}