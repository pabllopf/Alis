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

using System.Reflection;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Component.Ui;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            VideoGame game = VideoGame
                .Create()
                .Settings(setting => setting
                    .General(general => general
                        .Name("Flappy Bird 2")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Flappy Bird game.")
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp")
                        .Version(Assembly.GetExecutingAssembly().GetName().Version?.ToString())
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Target("OpenGL")
                        .Resolution(288, 512)
                        .BackgroundColor(new Color(141,212,247,255))
                        .FrameRate(30)
                        .IsResizable(false)
                        .Build())
                    .Physic(physic => physic
                        .Debug(false)
                        .DebugColor(Color.Red)
                        .Gravity(0.0f, -4.5f)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager

                    ////////////////////////////////////////
                    // MAIN MENU SCENE:
                    ////////////////////////////////////////
                    .Add<Scene>(gameScene => gameScene
                        .Name("Main_Menu")
                        .Add<GameObject>(mainCamera => mainCamera
                            .Name("Camera")
                            .WithTag("Camera")
                            .Transform(position => position
                                .Position(0, 0)
                                .Build())
                            .AddComponent<Camera>(camera => camera
                                .Builder()
                                .Resolution(288, 512)
                                .BackgroundColor(Color.Black)
                                .Build())
                            .Build())

                        ////////////////////////////////////////
                        // MAIN MENU SCENE: BACKGROUND
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Background")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture("background-day.bmp")
                                .Depth(0)
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("UI")
                            .AddComponent<Canvas>(canvas => canvas
                                .Builder()
                                .Build())
                            .Build())

                        ////////////////////////////////////////
                        // MAIN MENU SCENE: FLOOR
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Floor")
                            .Transform(transform => transform
                                .Position(0, -6.5f)
                                .Rotation(0)
                                .Scale(2f, 1f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture("base.bmp")
                                .Depth(1)
                                .Build())
                            .AddComponent(new FloorAnimation())
                            .Build())

                        ////////////////////////////////////////
                        // MAIN MENU SCENE: MESSAGE MENU
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Message Menu")
                            .Transform(transform => transform
                                .Position(-0.15f, 1.5f)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture("message.bmp")
                                .Depth(2)
                                .Build())
                            .AddComponent(new MainMenuController())
                            .Build())

                        ////////////////////////////////////////
                        // MAIN MENU SCENE: COUNTER
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Counter")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Rotation(0)
                                .Scale(1f, 1.0f)
                                .Build())
                            .Build())

                        ////////////////////////////////////////
                        // MAIN MENU SCENE: BIRD
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Bird")
                            .Transform(transform => transform
                                .Position(-1.5f, 0f)
                                .Rotation(0)
                                .Scale(1f, 1.0f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture("bluebird-down_flap.bmp")
                                .Depth(4)
                                .Build())
                            .AddComponent<Animator>(animator => animator
                                .Builder()
                                .AddAnimation(animation => animation
                                    .Name("Fly")
                                    .Speed(0.2f)
                                    .Order(0)
                                    .AddFrame(frame1 => frame1
                                        .FilePath("bluebird-down_flap.bmp")
                                        .Build())
                                    .AddFrame(frame2 => frame2
                                        .FilePath("bluebird-mid_flap.bmp")
                                        .Build())
                                    .AddFrame(frame3 => frame3
                                        .FilePath("bluebird-up_flap.bmp")
                                        .Build())
                                    .Build())
                                .Build())
                            .AddComponent(new BirdIdle())
                            .Build())

                        ////////////////////////////////////////
                        // MAIN MENU SCENE: SOUNDTRACK
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Soundtrack")
                            .AddComponent<AudioSource>(audioSource => audioSource
                                .Builder()
                                .PlayOnAwake(true)
                                .SetAudioClip(audioClip => audioClip
                                    .FilePath("main_theme.wav")
                                    .Build())
                                .Build())
                            .Build())
                        .Build())

                    ////////////////////////////////////////
                    // GAME SCENE:
                    ////////////////////////////////////////
                    .Add<Scene>(gameScene => gameScene
                        .Name("Game_Scene")
                        .Add<GameObject>(mainCamera => mainCamera
                            .Name("Camera")
                            .WithTag("Camera")
                            .Transform(position => position
                                .Position(0, 0)
                                .Build())
                            .AddComponent<Camera>(camera => camera
                                .Builder()
                                .Resolution(288, 512)
                                .BackgroundColor(Color.Black)
                                .Build())
                            .Build())

                        ////////////////////////////////////////
                        // GAME SCENE: BACKGROUND
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Background")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture("background-day.bmp")
                                .Depth(0)
                                .Build())
                            .Build())

                        ////////////////////////////////////////
                        // GAME SCENE: FLOOR
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Floor")
                            .Transform(transform => transform
                                .Position(0, -6.5f)
                                .Rotation(0)
                                .Scale(2f, 1f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture("base.bmp")
                                .Depth(2)
                                .Build())
                            .AddComponent(new FloorAnimation())
                            .Build())

                        ////////////////////////////////////////
                        // GAME SCENE: FLOOR COLLISION
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Floor Collision")
                            .Transform(transform => transform
                                .Position(0, -6.5f)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(9, 3.5f)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(false)
                                .Build())
                            .AddComponent(new DeathZone())
                            .Build())

                        ////////////////////////////////////////
                        // GAME SCENE: SKY COLLISION
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Sky Collision")
                            .Transform(transform => transform
                                .Position(0, 8)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(9, 1)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(false)
                                .Build())
                            .AddComponent(new DeathZone())
                            .Build())

                        ////////////////////////////////////////
                        // GAME SCENE: COUNTER
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Counter")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                .Build())
                            .Build())

                        ////////////////////////////////////////
                        // GAME SCENE: PIPELINE UP
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Pipeline UP")
                            .Transform(transform => transform
                                .Position(6, 7f)
                                .Rotation(180)
                                .Scale(1f, 1f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture("pipe-green.bmp")
                                .Depth(1)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(true)
                                .AutoTilling(true)
                                .Rotation(180)
                                .Size(2, 10)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(false)
                                .Build())
                            .AddComponent(new PipelineController())
                            .AddComponent(new DeathZone())
                            .Build())

                        ////////////////////////////////////////
                        // GAME SCENE: PIPELINE MIDDLE
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Pipeline Middle")
                            .Transform(transform => transform
                                .Position(6, 0)
                                .Rotation(0)
                                .Scale(1f, 1.0f)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(true)
                                .AutoTilling(false)
                                .Size(2, 2)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(false)
                                .Build())
                            .AddComponent<AudioSource>(audioSource => audioSource
                                .Builder()
                                .PlayOnAwake(false)
                                .SetAudioClip(audioClip => audioClip
                                    .FilePath("point.wav")
                                    .Build())
                                .Build())
                            .AddComponent(new PipelineController())
                            .AddComponent(new CounterController())
                            .Build())

                        ////////////////////////////////////////
                        // GAME SCENE: PIPELINE DOWN
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Pipeline Down")
                            .Transform(transform => transform
                                .Position(6, -7.0f)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture("pipe-green.bmp")
                                .Depth(1)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(true)
                                .AutoTilling(true)
                                .Rotation(0.0f)
                                .Size(2, 10)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                                .Build())
                            .AddComponent(new PipelineController())
                            .AddComponent(new DeathZone())
                            .Build())

                        ////////////////////////////////////////
                        // GAME SCENE: BIRD
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Bird")
                            .WithTag("Player")
                            .Transform(transform => transform
                                .Position(-3, 0f)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture("bluebird-down_flap.bmp")
                                .Depth(0)
                                .Build())
                            .AddComponent<AudioSource>(audioSource => audioSource
                                .Builder()
                                .PlayOnAwake(false)
                                .SetAudioClip(audioClip => audioClip
                                    .FilePath("wing.wav")
                                    .Build())
                                .Build())
                            .AddComponent<Animator>(animator => animator
                                .Builder()
                                .AddAnimation(animation => animation
                                    .Name("Fly")
                                    .Speed(0.2f)
                                    .Order(0)
                                    .AddFrame(frame1 => frame1
                                        .FilePath("bluebird-down_flap.bmp")
                                        .Build())
                                    .AddFrame(frame2 => frame2
                                        .FilePath("bluebird-mid_flap.bmp")
                                        .Build())
                                    .AddFrame(frame3 => frame3
                                        .FilePath("bluebird-up_flap.bmp")
                                        .Build())
                                    .Build())
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Dynamic)
                                .IsTrigger(false)
                                .AutoTilling(true)
                                .Rotation(0.0f)
                                .Size(1, 1)
                                .RelativePosition(0, 0)
                                .Mass(1.0f)
                                .Restitution(0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(false)
                                .Build())
                            .AddComponent(new BirdController())
                            .Build()) // end bird 
                        .Build()) // end scene manager
                    .Build()) // end video game
                .Build();

            game.Run();
        }
    }
}