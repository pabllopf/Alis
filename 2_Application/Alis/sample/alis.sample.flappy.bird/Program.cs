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
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
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
            VideoGame
                .Create()
                .Settings(setting => setting
                    .General(general => general
                        .Name("Flappy Bird")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Flappy Bird game.")
                        .License("GNU General Public License v3.0")
                        .Icon("app.ico")
                        .Version("1.0.0")
                        )
                    .Audio(audio => audio
                            .Volume(50)
                        )
                    .Graphic(graphic => graphic
                        .Target("OpenGL")
                        .Resolution(288, 512)
                        .BackgroundColor(new Color(141,212,247,255))
                        .FrameRate(30)
                        .IsResizable(false)
                        )
                    .Physic(physic => physic
                            #if DEBUG
                        .Debug(true)
                        #else
                        .Debug(false)
                        #endif
                        .DebugColor(Color.Red)
                        .Gravity(0.0f, -4.5f)
                        )
                    )
                .World(sceneManager => sceneManager

                    ////////////////////////////////////////
                    // MAIN MENU SCENE:
                    ////////////////////////////////////////
                    .Add<Scene>(gameScene => gameScene
                        .Name("Main_Menu")
                        .Add<GameObject>(mainCamera => mainCamera
                            .Name("Camera")
                            .Tag("Camera")
                            .Transform(position => position
                                .Position(0, 0)
                                )
                            .WithComponent<Camera>(camera => camera
                                
                                .Resolution(288, 512)
                                .BackgroundColor(Color.Black)
                                )
                            )

                        ////////////////////////////////////////
                        // MAIN MENU SCENE: BACKGROUND
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Background")
                            .Transform(transform => transform
                                .Position(0, -3f)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                .SetTexture("background-day.bmp")
                                .Depth(0)
                                )
                            )
                        ////////////////////////////////////////
                        // MAIN MENU SCENE: FLOOR
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Floor")
                            .Transform(transform => transform
                                .Position(0, -6.5f)
                                .Rotation(0)
                                .Scale(2f, 1f)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                
                                .SetTexture("base.bmp")
                                .Depth(1)
                                )
                            .WithComponent(new FloorAnimation())
                            )

                        ////////////////////////////////////////
                        // MAIN MENU SCENE: MESSAGE MENU
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Message Menu")
                            .Transform(transform => transform
                                .Position(-0.15f, 1.5f)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                
                                .SetTexture("message.bmp")
                                .Depth(2)
                                )
                            .WithComponent(new MainMenuController())
                            )

                        ////////////////////////////////////////
                        // MAIN MENU SCENE: COUNTER
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Counter")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Rotation(0)
                                .Scale(1f, 1.0f)
                                )
                            )

                        ////////////////////////////////////////
                        // MAIN MENU SCENE: BIRD
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Bird")
                            .Transform(transform => transform
                                .Position(-1.5f, 0f)
                                .Rotation(0)
                                .Scale(1f, 1.0f)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                
                                .SetTexture("bluebird-down_flap.bmp")
                                .Depth(4)
                                )
                            .WithComponent<Animator>(animator => animator
                                .AddAnimation(animation => animation
                                    .Name("Fly")
                                    .Speed(0.2f)
                                    .Order(0)
                                    .AddFrame(frame1 => frame1
                                        .File("bluebird-down_flap.bmp")
                                        .Build()
                                        )
                                    .AddFrame(frame2 => frame2
                                        .File("bluebird-mid_flap.bmp")
                                        .Build()
                                        )
                                    .AddFrame(frame3 => frame3
                                        .File("bluebird-up_flap.bmp")
                                        .Build()
                                        )
                                    .Build()
                                    )
                                )
                            .WithComponent(new BirdIdle())
                            )

                        ////////////////////////////////////////
                        // MAIN MENU SCENE: SOUNDTRACK
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Soundtrack")
                            .WithComponent<AudioSource>(audioSource => audioSource
                                .PlayOnAwake(true)
                                .Loop(true)
                                .File("main_theme.wav")
                            ) 
                        ) // end soundtrack
                    ) // end main menu scene

                    ////////////////////////////////////////
                    // GAME SCENE:
                    ////////////////////////////////////////
                    .Add<Scene>(gameScene => gameScene
                        .Name("Game_Scene")
                        .Add<GameObject>(mainCamera => mainCamera
                            .Name("Camera")
                            .Tag("Camera")
                            .Transform(position => position
                                .Position(0, 0)
                                )
                            .WithComponent<Camera>(camera => camera
                                
                                .Resolution(288, 512)
                                .BackgroundColor(Color.Black)
                                )
                            )

                        ////////////////////////////////////////
                        // GAME SCENE: BACKGROUND
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Background")
                            .Transform(transform => transform
                                .Position(0, -3f)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                
                                .SetTexture("background-day.bmp")
                                .Depth(0)
                                )
                            )

                        ////////////////////////////////////////
                        // GAME SCENE: FLOOR
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Floor")
                            .Transform(transform => transform
                                .Position(0, -6.5f)
                                .Rotation(0)
                                .Scale(2f, 1f)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                
                                .SetTexture("base.bmp")
                                .Depth(2)
                                )
                            .WithComponent(new FloorAnimation())
                            )

                        ////////////////////////////////////////
                        // GAME SCENE: FLOOR COLLISION
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Floor Collision")
                            .Transform(transform => transform
                                .Position(0, -6.5f)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
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
                                )
                            .WithComponent(new DeathZone())
                            )

                        ////////////////////////////////////////
                        // GAME SCENE: SKY COLLISION
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Sky Collision")
                            .Transform(transform => transform
                                .Position(0, 8)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
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
                                )
                            .WithComponent(new DeathZone())
                            )

                        ////////////////////////////////////////
                        // GAME SCENE: COUNTER
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Counter")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                )
                            )

                        ////////////////////////////////////////
                        // GAME SCENE: PIPELINE UP
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Pipeline UP")
                            .Transform(transform => transform
                                .Position(6, 7f)
                                .Rotation(180)
                                .Scale(1f, 1f)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                
                                .SetTexture("pipe-green.bmp")
                                .Depth(1)
                                )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
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
                                )
                            .WithComponent(new PipelineController())
                            .WithComponent(new DeathZone())
                            )

                        ////////////////////////////////////////
                        // GAME SCENE: PIPELINE MIDDLE
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Pipeline Middle")
                            .Transform(transform => transform
                                .Position(6, 0)
                                .Rotation(0)
                                .Scale(1f, 1.0f)
                                )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
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
                            )
                            .WithComponent<AudioSource>(audioSource => audioSource
                                .PlayOnAwake(false)
                                .File("point.wav")
                            )
                            .WithComponent(new PipelineController())
                            .WithComponent(new CounterController())
                            )

                        ////////////////////////////////////////
                        // GAME SCENE: PIPELINE DOWN
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Pipeline Down")
                            .Transform(transform => transform
                                .Position(6, -7.0f)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                .SetTexture("pipe-green.bmp")
                                .Depth(1)
                                )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
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
                                )
                            .WithComponent(new PipelineController())
                            .WithComponent(new DeathZone())
                            )

                        ////////////////////////////////////////
                        // GAME SCENE: BIRD
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Bird")
                            .Tag("Player")
                            .Transform(transform => transform
                                .Position(-3, 0f)
                                .Rotation(0)
                                .Scale(1f, 1f)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                .SetTexture("bluebird-down_flap.bmp")
                                .Depth(0)
                            )
                            .WithComponent<AudioSource>(audioSource => audioSource
                                .PlayOnAwake(false)
                                .File("wing.wav")
                            )
                            .WithComponent<Animator>(animator => animator
                                .AddAnimation(animation => animation
                                    .Name("Fly")
                                    .Speed(0.2f)
                                    .Order(0)
                                    .AddFrame(frame1 => frame1
                                        .File("bluebird-down_flap.bmp").Build()
                                        )
                                    .AddFrame(frame2 => frame2
                                        .File("bluebird-mid_flap.bmp").Build()
                                        )
                                    .AddFrame(frame3 => frame3
                                        .File("bluebird-up_flap.bmp").Build()
                                        )
                                    .Build()
                                    )
                                )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
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
                                )
                            .WithComponent(new BirdController())
                            ) // end bird 
                        ) // end scene manager
                    ) // end video game
                .Run();
        }
    }
}