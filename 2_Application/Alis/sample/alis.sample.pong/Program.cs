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

using Alis.Core.Ecs;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Pong
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
                        .Name("Pong")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Pong game")
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp"))
                    .Audio(audio => audio
                        .Volume(100))
                    .Graphic(graphic => graphic
                        .Resolution(1024, 640))
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f))
                )
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Add<GameObject>(mainCamera => mainCamera
                            .WithComponent<Camera>(camera => camera
                                .Resolution(1024, 640)
                                .Position(0, 0)
                            )
                        )
                        .Add<GameObject>(soundTrack => soundTrack
                            .WithComponent<AudioSource>(audioSource => audioSource
                                .File("soundtrack.wav")
                                .Loop(true)
                                .Mute(false)
                                .PlayOnAwake(true)
                                .Volume(100.0f)
                            )
                        )
                        .Add<GameObject>(player => player
                            .Transform(transform => transform
                                .Position(-15, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                            )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(0.5f, 2.5f)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(1f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                            )
                            .WithComponent(new PlayerController(1))
                        )
                        .Add<GameObject>(player => player
                            .Transform(transform => transform
                                .Position(15, 0)
                                .Scale(1, 1)
                                .Rotation(0))
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(0.5f, 2.5f)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(1.0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                            )
                            .WithComponent(new PlayerController(2))
                        )
                        .Add<GameObject>(ball => ball
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                            )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Dynamic)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(1, 1)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .LinearVelocity(-5.5f, -5)
                                .Mass(10.0f)
                                .Restitution(1.0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                               )
                           )
                        .Add<GameObject>(downWall => downWall
                            .Transform(transform => transform
                                .Position(0, -10)
                            )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(32, 1)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                            )
                        )
                        .Add<GameObject>(upWall => upWall
                            .Transform(transform => transform
                                .Position(0, 10)
                            )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(32, 1)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                            )
                        )
                        .Add<GameObject>(leftWall => leftWall
                            .Transform(transform => transform
                                .Position(-16, 0)
                            )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(1, 20)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                               )
                           )
                        .Add<GameObject>(rightWall => rightWall
                            .Transform(transform => transform
                                .Position(16, 0)
                            )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(1, 20)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                            )
                        )
                    )
                )
                .Run();
        }
    }
}