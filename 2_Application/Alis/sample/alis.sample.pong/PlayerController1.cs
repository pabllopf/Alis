// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerController1.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Component;
using Alis.Core.Component.Collider;
using Alis.Core.Graphic;
using Alis.Core.Graphic.SFML.Windows;

namespace Alis.Sample.Pong
{
    /// <summary>
    ///     The player controller class
    /// </summary>
    public class PlayerController1 : ComponentBase
    {
        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            boxCollider = GameObject.GetComponent<BoxCollider>();
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(Key key)
        {
            Vector2F velocity = boxCollider.Body.LinearVelocity;

            switch (key)
            {
                case Key.W:
                    velocity = new Vector2F(velocity.X, 0);
                    
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case Key.S:
                    velocity = new Vector2F(velocity.X, 0);
                    boxCollider.Body.LinearVelocity = velocity;
                    break;
            }
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(Key key)
        {
            Vector2F velocity = boxCollider.Body.LinearVelocity;

            switch (key)
            {
                case Key.W:
                    velocity = new Vector2F(velocity.X, -5);
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case Key.S:
                    velocity = new Vector2F(velocity.X, 5);
                    boxCollider.Body.LinearVelocity = velocity;
                    break;
            }
        }

        /// <summary>
        ///     Ons the press button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="device">The device</param>
        public override void OnPressDownButton(Button button, int device)
        {
            //Console.WriteLine($"OnPressDownButton Device={device} | button={button}");

            if (device == 0)
            {
                Vector2F velocity = boxCollider.Body.LinearVelocity;

                switch (button)
                {
                    case Button.A:
                        velocity = new Vector2F(velocity.X, 5);
                        boxCollider.Body.LinearVelocity = velocity;
                        return;
                    case Button.Y:
                        velocity = new Vector2F(velocity.X, -5);
                        boxCollider.Body.LinearVelocity = velocity;
                        break;
                }
            }
        }

        /// <summary>
        ///     Ons the release button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="device">The device</param>
        public override void OnReleaseButton(Button button, int device)
        {
            //Console.WriteLine($"OnReleaseButton Device={device} | button={button}");

            if (device == 0)
            {
                Vector2F velocity = boxCollider.Body.LinearVelocity;

                switch (button)
                {
                    case Button.A:
                        velocity = new Vector2F(velocity.X, 0);
                        boxCollider.Body.LinearVelocity = velocity;
                        return;
                    case Button.Y:
                        velocity = new Vector2F(velocity.X, 0);
                        boxCollider.Body.LinearVelocity = velocity;
                        break;
                }
            }
        }

        /// <summary>
        ///     Ons the press button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="device">The device</param>
        public override void OnPressButton(Button button, int device)
        {
            //Console.WriteLine($"OnPressButton Device={device} | button={button}");
        }
    }
}