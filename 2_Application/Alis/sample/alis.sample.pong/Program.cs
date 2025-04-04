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

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.EcsOld.Component.Audio;
using Alis.Core.EcsOld.Component.Collider;
using Alis.Core.EcsOld.Component.Render;
using Alis.Core.EcsOld.Entity;
using Alis.Core.EcsOld.System;
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
                        .Icon("app.bmp")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Resolution(1024, 640)
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                        .DebugColor(Color.Red)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Add<GameObject>(mainCamera => mainCamera
                            .Name("Camera")
                            .WithTag("Camera")
                            .AddComponent<Camera>(camera => camera
                                .Builder()
                                .Resolution(1024, 640)
                                .BackgroundColor(Color.Black)
                                .Build())
                            .Build())
                        .Add<GameObject>(soundTrack => soundTrack
                            .Name("Soundtrack")
                            .AddComponent<AudioSource>(audioSource => audioSource
                                .Builder()
                                .PlayOnAwake(true)
                                .SetAudioClip(audioClip => audioClip
                                    .FilePath("soundtrack.wav")
                                    .Volume(100.0f)
                                    .Build())
                                .Build())
                            .Build())
                        .Add<GameObject>(player => player
                            .Name("Player 1")
                            .Transform(transform => transform
                                .Position(-15, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
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
                                .Build())
                            .AddComponent(new PlayerController(1))
                            .Build())
                        .Add<GameObject>(player => player
                            .Name("Player 2")
                            .Transform(transform => transform
                                .Position(15, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
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
                                .Build())
                            .AddComponent(new PlayerController(2))
                            .Build())
                        .Add<GameObject>(ball => ball
                            .Name("Ball")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
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
                                .Build())
                            .Build())
                        .Add<GameObject>(downWall => downWall
                            .Name("downWall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(0, -10)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
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
                                .Build())
                            .Build())
                        .Add<GameObject>(upWall => upWall
                            .Name("upWall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(0, 10)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
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
                                .Build())
                            .Build())
                        .Add<GameObject>(leftWall => leftWall
                            .Name("leftWall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(-16, 0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
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
                                .Build())
                            .Build())
                        .Add<GameObject>(rightWall => rightWall
                            .Name("rightWall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(16, 0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
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
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Build()
                .Run();
        }
    }
}