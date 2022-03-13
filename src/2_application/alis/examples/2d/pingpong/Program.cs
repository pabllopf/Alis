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
using Alis;
using Alis.Core.Components;
using SFML.Graphics;
using Animator = Alis.Animator;
using AudioSource = Alis.AudioSource;
using Camera = Alis.Camera;
using Sprite = Alis.Sprite;

namespace PingPong
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
                            .Add<Sprite>(new Sprite($"{Environment.CurrentDirectory}/Assets/exit_button.png", 1))
                            .Build())
                        .Add<GameObject>(oneButton => oneButton
                            .Name("1_Button")
                            .Transform(transform => transform
                                .Position(298, 195, 1)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite($"{Environment.CurrentDirectory}/Assets/1.png", 2))
                            .Add(new Animator(new List<Animation>()
                            {
                                new Animation(new List<Texture>()
                                {
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/1.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/1.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/11.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/11.png")
                                })
                                {
                                    Speed = 0.5f,
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
                            .Add(new Animator(new List<Animation>()
                            {
                                new Animation(new List<Texture>()
                                {
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/2.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/2.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/22.png"),
                                    new Texture(@$"{Environment.CurrentDirectory}/Assets/22.png")
                                })
                                {
                                    Speed = 0.5f,
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
                        
                        .Build())
                    
                    .Build())
                .Run();
        }
    }
}