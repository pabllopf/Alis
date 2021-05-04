//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón </author>
// <copyright file="Main.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Example_Core
{

    using Alis.Core;
    using System;

    internal class Select : Component
    {


        public override void Start()
        {
            Input.OnPressKey += Input_OnPressKey;
        }

        public override void Update()
        {
        }

        private void Input_OnPressKey(object sender, Keyboard key)
        {
            if (key.Equals(Keyboard.Num1))
            {
                //SceneManager.Reset("Game");
                SceneManager.Load("Game");
                return;
            }

            if (key.Equals(Keyboard.Num2))
            {
                Environment.Exit(0);
                return;
            }
        }
    }
}