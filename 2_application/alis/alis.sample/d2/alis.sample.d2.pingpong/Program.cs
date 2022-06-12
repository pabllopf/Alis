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

namespace Alis.Sample.D2.PingPong
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
                        .Author("Pablo Perdomo Falcón")
                        .Name("Ping Pong")
                        .Description("Classic game made in Alis")
                        .Build())
                    .Window(window => window
                        .Resolution(720, 480)
                        .Build())
                    .Debug(debug => debug
                        .ShowPhysicBorders(true)
                        .Build())
                    .Build())
                .Manager(sceneManager => sceneManager

                    //////////////
                    //  MAIN SCENE
                    //////////////
                    .Add<Scene>(mainScene => mainScene
                        .Name("Menu Scene")
                        .Add<GameObject>(camera => camera
                            .Name("Camera")
                            //.Add(Camera.Create())
                            .Build())
                        .Add<GameObject>(controller => controller
                            .Name("Main Controller")
                            .Add(new MainMenuController())
                            .Build())
                        .Add<GameObject>(background => background
                            .Name("Background")
                            .Transform(transform => transform
                                .Position(-444, -444, 1)
                                .Scale(55, 55, 55)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite($"{Environment.CurrentDirectory}/Assets/background.png", 0))
                            .Build())
                        .Add<GameObject>(soundtrack => soundtrack
                            .Name("Soundtrack")
                            .Add(new AudioSource($"{Environment.CurrentDirectory}/Assets/menu.wav"))
                            .Build())
                        .Add<GameObject>(startButton => startButton
                            .Name("StartButton")
                            .Transform(transform => transform
                                .Position(300, 200, 1)
                                .Scale(2, 2, 2)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite($"{Environment.CurrentDirectory}/Assets/start_button.png", 1))
                            .Build())
                        .Add<GameObject>(exitButton => exitButton
                            .Name("ExitButton")
                            .Transform(transform => transform
                                .Position(300, 250, 1)
                                .Scale(2, 2, 2)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite($"{Environment.CurrentDirectory}/Assets/exit_button.png", 1))
                            .Build())
                        .Add<GameObject>(oneButton => oneButton
                            .Name("1_Button")
                            .Transform(transform => transform
                                .Position(298, 195, 1)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite($"{Environment.CurrentDirectory}/Assets/1.png", 2))
                            .Add(new Animator(new List<Animation>
                            {
                                new Animation(new List<Texture>
                                {
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/1.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/1.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/11.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/11.png")
                                })
                                {
                                    Speed = 0.5f
                                },
                                new Animation()
                            }))
                            .Build())
                        .Add<GameObject>(twoButton => twoButton
                            .Name("2_Button")
                            .Transform(transform => transform
                                .Position(298, 245, 1)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite($"{Environment.CurrentDirectory}/Assets/2.png", 2))
                            .Add(new Animator(new List<Animation>
                            {
                                new Animation(new List<Texture>
                                {
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/2.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/2.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/22.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/22.png")
                                })
                                {
                                    Speed = 0.5f
                                },
                                new Animation()
                            }))
                            .Build())
                        .Build())

                    //////////////
                    //  GAME SCENE
                    //////////////
                    .Add<Scene>(gameScene => gameScene
                        .Name("Game Scene")
                        // SOUNDTRACK:
                        .Add<GameObject>(soundTrack => soundTrack
                            .Name("Soundtrack")
                            .Add(new AudioSource($"{Environment.CurrentDirectory}/Assets/ping.wav"))
                            .Build())
                        // CAMERA:
                        .Add<GameObject>(camera => camera
                            .Name("Camera")
                            .Add(new Camera())
                            .Build())

                        // BACKGROUND:
                        .Add<GameObject>(background => background
                            .Name("Background")
                            .Transform(transform => transform
                                .Position(-500, -500, 0)
                                .Scale(55, 55, 1)
                                .Rotation(0)
                                .Build())
                            //.Add(new Sprite($"{Environment.CurrentDirectory}/Assets/background.png", -1))
                            .Build())

                        // TopWall:
                        .Add<GameObject>(topWall => topWall
                            .Name("TopWall")
                            .Transform(transform => transform
                                .Position(0, -240, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new BoxCollider2D
                            {
                                Width = 720.0f,
                                Height = 20.0f,
                                BodyType = BodyType.Static,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0.1f,
                                Restitution = 0.2f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())

                        // DownWall:
                        .Add<GameObject>(downWall => downWall
                            .Name("DownWall")
                            .Transform(transform => transform
                                .Position(0, 240, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new BoxCollider2D
                            {
                                Width = 720.0f,
                                Height = 20.0f,
                                BodyType = BodyType.Static,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0.1f,
                                Restitution = 0.2f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())

                        // LeftWall:
                        .Add<GameObject>(leftWall => leftWall
                            .Name("LeftWall")
                            .Transform(transform => transform
                                .Position(-300, 0, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new BoxCollider2D
                            {
                                Width = 20.0f,
                                Height = 480.0f,
                                BodyType = BodyType.Static,
                                Density = 1f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0.1f,
                                Restitution = 0.2f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())

                        // rightWall:
                        .Add<GameObject>(rightWall => rightWall
                            .Name("RightWall")
                            .Transform(transform => transform
                                .Position(320, 0, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new BoxCollider2D
                            {
                                Width = 20.0f,
                                Height = 480.0f,
                                BodyType = BodyType.Static,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0.1f,
                                Restitution = 0.2f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())

                        // PLAYER 1:
                        .Add<GameObject>(player1 => player1
                            .Name("Player_1")
                            .Transform(transform => transform
                                .Position(-290, 0, 0)
                                .Scale(1, 1, 1)
                                .Rotation(90)
                                .Build())
                            /*.Add(new Sprite($"{Environment.CurrentDirectory}/Assets/player_1.png", 2))
                            .Add(new BoxCollider2D
                            {
                                Width = 720.0f,
                                Height = 20.0f,
                                BodyType = BodyType.Static,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0.1f,
                                Restitution = 0.2f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })*/
                            .Build())

                        // PLAYER 2:
                        .Add<GameObject>(player2 => player2
                            .Name("Player_2")
                            .Transform(transform => transform
                                .Position(310, 0, 0)
                                .Scale(1, 1, 1)
                                .Rotation(90)
                                .Build())
                            /*.Add(new Sprite($"{Environment.CurrentDirectory}/Assets/player_2.png", 2))
                             .Add(new BoxCollider2D
                             {
                                 Width = 720.0f,
                                 Height = 20.0f,
                                 BodyType = BodyType.Static,
                                 Density = 0.5f,
                                 Rotation = 0.0f,
                                 Mass = 10.0f,
                                 RelativePosition = Vector2.Zero,
                                 Friction = 0.1f,
                                 Restitution = 0.2f,
                                 FixedRotation = true,
                                 GravityScale = 0.0f,
                                 IsTrigger = false
                             })*/
                            .Build())

                        // BALL:
                        .Add<GameObject>(ball => ball
                            .Name("Ball")
                            .Transform(transform => transform
                                .Position(0, 0, 0)
                                .Scale(1, 1, 1)
                                .Rotation(90)
                                .Build())
                            .Add(new Sprite($"{Environment.CurrentDirectory}/Assets/ball.png", 2))
                            .Add(new BoxCollider2D
                            {
                                AutoTilling = true,
                                BodyType = BodyType.Dynamic,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                LinearVelocity = new Vector2(-10, 3),
                                Friction = 0.0f,
                                Restitution = 1.0f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())
                        .Build())
                    .Build())
                .Run();
        }
    }
}