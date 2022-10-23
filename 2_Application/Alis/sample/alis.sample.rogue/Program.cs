// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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

using System;
using Alis.Core.Aspect.Math;
using Alis.Core.Component.Audio;
using Alis.Core.Component.Collider;
using Alis.Core.Component.Render;
using Alis.Core.Entity;
using Alis.Core.Graphic.D2.SFML.Graphics;
using Alis.Core.Manager.Scene;
using Alis.Core.Systems.Physics2D.Dynamics;
using Sprite = Alis.Core.Component.Render.Sprite;

namespace Alis.Sample.Rogue
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
            Console.WriteLine("Start game");

            VideoGame.Builder()
                .Settings(setting => setting
                    .General(general => general
                        .Name("Rogue Sample")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Simple rogue game")
                        .Icon(Environment.CurrentDirectory + "/Assets/logo.png")
                        .SplashScreen(screen => screen
                            .IsActive(true)
                            .Style(Style.Dark)
                            .FilePath(Environment.CurrentDirectory + "/Assets/tile000.png")
                            .Build())
                        .Build())
                    .Debug(debug => debug
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Window(window => window
                            .Resolution(1024, 640)
                            .Background(Color.Black)
                            .Build())
                        .Build())
                    .Build())
                .Manager<SceneManager>(sceneManager => sceneManager
                    .Add<Scene>(scene => scene
                        .Name("Main Menu")
                        .Add<GameObject>(go => go
                            .Name("Player")
                            .Transform(transform => transform
                                .Position(100, 100)
                                .Rotation(0)
                                .Scale(2, 2)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture(Environment.CurrentDirectory + "/Assets/tile000.png")
                                .Depth(2)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .IsDynamic(false)
                                .IsTrigger(false)
                                .AutoTilling(true)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .Density(0.5f)
                                .FixedRotation(true)
                                .GravityScale(0.0f)
                                .Build())
                            .Build())
                        
                        .Add<GameObject>(go => go
                            .Name("Floor")
                            .Transform(transform => transform
                                .Position(50, 200)
                                .Rotation(0)
                                .Scale(1, 1)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .IsDynamic(false)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(100, 10)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .Density(0.5f)
                                .FixedRotation(true)
                                .GravityScale(0.0f)
                                .Build())
                            .Build())
                        
                        .Add<GameObject>(go => go
                            .Name("Player 2")
                            .WithTag("Players")
                            .Transform(i => i
                                .Position(0, 0)
                                .Rotation(0)
                                .Scale(2, 2)
                                .Build())
                            .AddComponent(new Camera())
                            .AddComponent<Sprite>(i => i
                                .Builder()
                                .SetTexture(Environment.CurrentDirectory + "/Assets/tile003.png")
                                .Depth(0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .IsDynamic(true)
                                .IsTrigger(false)
                                .AutoTilling(true)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .Density(0.5f)
                                .FixedRotation(true)
                                .GravityScale(0.0f)
                                .Build())
                            .AddComponent<PlayerMovement>(playerMovement => playerMovement
                                .Builder()
                                .Build())
                            .AddComponent<AudioSource>(audioSource => audioSource
                                .Builder()
                                .IsActive(true)
                                .PlayOnAwake(true)
                                .SetAudioClip(audioClip => audioClip
                                    .FilePath(Environment.CurrentDirectory + "/Assets/menu.wav")
                                    .Volume(100.0f)
                                    .Mute(false)
                                    .Build())
                                .Build())
                            .AddComponent<Animator>(animator => animator
                                .Builder()
                                .AddAnimation(animation => animation
                                    .Name("Idle")
                                    .Speed(0.25f)
                                    .Order(0)
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile000.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile002.png")
                                        .Build())
                                    .Build())
                                .AddAnimation(animation => animation
                                    .Name("WalkDown")
                                    .Speed(0.25f)
                                    .Order(1)
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile000.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile001.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile002.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile003.png")
                                        .Build())
                                    .Build())
                                .AddAnimation(animation => animation
                                    .Name("WalkUp")
                                    .Speed(0.25f)
                                    .Order(2)
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile034.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile035.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile036.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile037.png")
                                        .Build())
                                    .Build())
                                .AddAnimation(animation => animation
                                    .Name("WalkRight")
                                    .Speed(0.25f)
                                    .Order(3)
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile017.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile018.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile019.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile020.png")
                                        .Build())
                                    .Build())
                                .AddAnimation(animation => animation
                                    .Name("WalkLeft")
                                    .Speed(0.25f)
                                    .Order(4)
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile051.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile052.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile053.png")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(Environment.CurrentDirectory + "/Assets/tile054.png")
                                        .Build())
                                    .Build())
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Run();


            Console.WriteLine("End game");
        }
    }
}