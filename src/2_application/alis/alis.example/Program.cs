// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Program.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Entities;

namespace Alis.Example
{
    /// <summary>
    ///     The program class
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            VideoGame.Create()
                /*.Settings(setting => setting
                    .General(general => general
                        .Author("Pedro Diaz")
                        .Name("The best game")
                        .Build())
                    .Window(window => window
                        .Resolution(640, 480)
                        .ScreenMode(ScreenMode.Default)
                        .Build())
                    .Debug(debug => debug
                        .LogLevel(LogLevel.Info)
                        .ShowPhysicBorders(true)
                        .Build())
                    .Build())*/
                /*.Manager(sceneManager => sceneManager
                    .Add<Scene>(scene => scene
                        .Name("The main menu.")
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Other Example")
                            .Transform(new Transform(new Vector3(1, 1, 0), new Vector3(100, 100, 0), new Vector3(0)))
                            //.Add<Sprite>(new Sprite(@"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile000.png"))
                            /*.Add<BoxCollider2D>(new BoxCollider2D
                            {
                                BodyType = BodyType.Static,
                                AutoTiling = true
                            })
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Other Example 2")
                            .Transform(new Transform(new Vector3(1, 1, 0), new Vector3(-100, -100, 0), new Vector3(0)))
                            //.Add<Sprite>(new Sprite(@"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile000.png"))
                            /*.Add<BoxCollider2D>(new BoxCollider2D
                            {
                                BodyType = BodyType.Dynamic,
                                AutoTiling = true
                            })
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Other Example 3")
                            .Transform(new Transform(new Vector3(1, 1, 0), new Vector3(-100, 100, 0), new Vector3(0)))
                            //.Add<Sprite>(new Sprite(@"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile000.png"))
                            /*.Add<BoxCollider2D>(new BoxCollider2D
                            {
                                BodyType = BodyType.Kinematic,
                                AutoTiling = true
                            })
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Player")
                            .Add<SimpleMove>(new SimpleMove())
                            //.Add<Sprite>(new Sprite(@"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile000.png"))
                            //.Add<AudioSource>(new AudioSource(@"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\menu.wav"))
                            //.Add<Camera>(Camera.CreateInstance())
                            /*.Add<BoxCollider2D>(new BoxCollider2D
                            {
                                BodyType = BodyType.Dynamic,
                                AutoTiling = true
                            })*/
                /*.Add<Animator>(new Animator(new List<Animation>
                {
                    new Animation(new List<Texture>
                    {
                        new Texture(
                            @"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile000.png"),
                        new Texture(
                            @"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile001.png"),
                        new Texture(
                            @"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile002.png"),
                        new Texture(
                            @"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile003.png")
                    }),
                    //new Animation()
                }))
                .Build())
            .Build())
        .Build())*/
                .Run();
        }
    }


    /// <summary>
    ///     The simple move class
    /// </summary>
    /// <seealso cref="Component" />
    public class SimpleMove : Component
    {
        /// <summary>
        ///     The box collider
        /// </summary>
        //private BoxCollider2D boxCollider2D;

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            //boxCollider2D = (BoxCollider2D) GameObject.Get<BoxCollider2D>();


            //InputManager.OnPressKey += InputManagerOnOnPressKey;
            //InputManager.OnPressDownKey += InputManagerOnOnPressDownKey;
            //InputManager.OnReleaseKey += InputManagerOnOnReleaseKey;
        }

        /// <summary>
        ///     Inputs the manager on on release key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="key">The key</param>
        private void InputManagerOnOnReleaseKey(object? sender, Keyboard key)
        {
            //Vector2 velocity = boxCollider2D.Body.LinearVelocity;

            if (key == Keyboard.D)
            {
                //    velocity.X = 0;
                //    boxCollider2D.Body.LinearVelocity = velocity;
            }

            if (key == Keyboard.A)
            {
                // velocity.X = 0;
                // boxCollider2D.Body.LinearVelocity = velocity;
            }

            if (key == Keyboard.W)
            {
                //velocity.Y = 0;
                //boxCollider2D.Body.LinearVelocity = velocity;
            }

            if (key == Keyboard.S)
            {
                //velocity.Y = 0;
                //boxCollider2D.Body.LinearVelocity = velocity;
            }
        }

        /// <summary>
        ///     Inputs the manager on on press down key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void InputManagerOnOnPressDownKey(object? sender, Keyboard e)
        {
        }

        /// <summary>
        ///     Inputs the manager on on press key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="key">The key</param>
        private void InputManagerOnOnPressKey(object? sender, Keyboard key)
        {
            /*
            Vector2 velocity = boxCollider2D.Body.LinearVelocity;
            if (key == Keyboard.D)
            {
                velocity.X = 5;
                boxCollider2D.Body.LinearVelocity = velocity;
                return;
            }

            if (key == Keyboard.A)
            {
                velocity.X = -5;
                boxCollider2D.Body.LinearVelocity = velocity;
                return;
            }

            if (key == Keyboard.W)
            {
                velocity.Y = -5;
                boxCollider2D.Body.LinearVelocity = velocity;
                return;
            }

            if (key == Keyboard.S)
            {
                velocity.Y = 5;
                boxCollider2D.Body.LinearVelocity = velocity;
            }*/
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
        }
    }
}