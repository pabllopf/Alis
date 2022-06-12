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

using System;
using System.Collections.Generic;
using System.Numerics;
using Sprite = Alis.Core.Components.Sprite;
using Transform = Alis.Core.Entities.Transform;

namespace Alis.Sample.D2.Roguelike
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
                .Settings(setting => setting
                    .General(general => general
                        .Author("Pedro Diaz")
                        .Name("The best game")
                        .Build())
                    .Window(window => window
                        .Resolution(640, 480)
                        .Build())
                    .Debug(debug => debug
                        .ShowPhysicBorders(true)
                        .Build())
                    .Build())
                .Manager(sceneManager => sceneManager
                    .Add<Scene>(scene => scene
                        .Name("The main menu.")
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Other Example").Transform((Transform) new Transform(new Vector3(1, 1, 0),
                                new Vector3(100, 100, 0), new Vector3(0)))
                            .Add(new Sprite(@$"{Environment.CurrentDirectory}/Assets/tile000.png"))
                            .Add(new BoxCollider2D
                            {
                                AutoTilling = true,
                                BodyType = BodyType.Dynamic,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0.1f,
                                Restitution = 0.0f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Other Example 2")
                            .Transform(new Transform(new Vector3(1, 1, 0), new Vector3(-100, -100, 0), new Vector3(0)))
                            .Add(new Sprite(
                                @$"{Environment.CurrentDirectory}/Assets/tile000.png"))
                            .Add(new BoxCollider2D
                            {
                                AutoTilling = true,
                                BodyType = BodyType.Kinematic,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0.1f,
                                Restitution = 0.0f,
                                FixedRotation = true,
                                GravityScale = 1.0f,
                                IsTrigger = false
                            })
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Other Example 3")
                            .Transform(new Transform(new Vector3(1, 1, 0), new Vector3(-100, 100, 0), new Vector3(0)))
                            .Add(new Sprite(
                                @$"{Environment.CurrentDirectory}/Assets/tile000.png"))
                            .Add(new BoxCollider2D
                            {
                                AutoTilling = true,
                                BodyType = BodyType.Static,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0.1f,
                                Restitution = 0.0f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Player")
                            .Add(new Simple2DMove())
                            .Add(new Sprite(@$"{Environment.CurrentDirectory}/Assets/tile000.png"))
                            .Add(new AudioSource(@$"{Environment.CurrentDirectory}/Assets/menu.wav"))
                            .Add(new Camera())
                            .Add(new BoxCollider2D
                            {
                                AutoTilling = true,
                                BodyType = BodyType.Dynamic,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0.1f,
                                Restitution = 0.0f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Add(new Animator(new List<Animation>
                            {
                                new Animation(new List<Texture>
                                {
                                    new Texture(
                                        @$"{Environment.CurrentDirectory}/Assets/tile000.png"),
                                    new Texture(
                                        @$"{Environment.CurrentDirectory}/Assets/tile001.png"),
                                    new Texture(
                                        @$"{Environment.CurrentDirectory}/Assets/tile002.png"),
                                    new Texture(
                                        @$"{Environment.CurrentDirectory}/Assets/tile003.png")
                                })
                                {
                                    Speed = 0.5f
                                },
                                new Animation()
                            }))
                            .Build())
                        .Build())
                    .Build())
                .Run();
        }
    }
}