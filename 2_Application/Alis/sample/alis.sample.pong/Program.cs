// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Program.cs
// 
//  Author: Pablo Perdomo Falcón
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

using Alis.Core.Aspect.Data;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity.GameObject;
using Alis.Core.Ecs.Entity.Scene;
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
                .Builder()
                .Settings(setting => setting
                    .General(general => general
                        .Name("Pong")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Pong game")
                        .License("GNU General Public License v3.0")
                        .Icon(AssetManager.Find("app.png"))
                        .Build())
                    .Profile(profile=> profile
                        .LogLevel(LogLevel.Critical)
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Window(window => window
                            .Resolution(1024, 640)
                            .Background(Color.Black)
                            .Build())
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                        .DebugColor(Color.Red)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Add<GameObject>(cameraObj => cameraObj
                            .Name("Camera")
                            .AddComponent<Camera>(camera => camera
                                .Builder()
                                .Build())
                            .Build())
                        .Add<GameObject>(soundTrack => soundTrack
                            .Name("Soundtrack")
                            .AddComponent<AudioSource>(audioSource => audioSource
                                .Builder()
                                .PlayOnAwake(true)
                                .SetAudioClip(audioClip => audioClip
                                    .FilePath(AssetManager.Find("soundtrack.wav"))
                                    .Volume(100.0f)
                                    .Build())
                                .Build())
                            .Build())
                        .Add<GameObject>(player => player
                            .Name("Player 1")
                            .Transform(transform => transform
                                .Position(20, 320)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(10, 100)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(1.0f)
                                .Friction(0f)
                                .Density(0.5f)
                                .FixedRotation(true)
                                .GravityScale(0.0f)
                                .Build())
                            .AddComponent(new PlayerController(1))
                            .Build())
                        .Add<GameObject>(player => player
                            .Name("Player 2")
                            .Transform(transform => transform
                                .Position(1000, 320)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(10, 100)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(1.0f)
                                .Friction(0f)
                                .Density(1.0f)
                                .FixedRotation(true)
                                .GravityScale(0.0f)
                                .Build())
                            .AddComponent(new PlayerController(2))
                            .Build())
                        .Add<GameObject>(ball => ball
                            .Name("Ball")
                            .Transform(transform => transform
                                .Position(512, 320)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Dynamic)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(35, 35)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .LinearVelocity(-10, -5)
                                .Mass(10.0f)
                                .Restitution(1.0f)
                                .Friction(0f)
                                .Density(0.5f)
                                .FixedRotation(true)
                                .GravityScale(0.0f)
                                .Build())
                            .Build())
                        .Add<GameObject>(downWall => downWall
                            .Name("downWall")
                            .Transform(transform => transform
                                .Position(512, 635)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(1024, 10)
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
                        .Add<GameObject>(upWall => upWall
                            .Name("upWall")
                            .Transform(transform => transform
                                .Position(512, 0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(1024, 10)
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
                        .Add<GameObject>(leftWall => leftWall
                            .Name("leftWall")
                            .Transform(transform => transform
                                .Position(0, 320)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(10, 640)
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
                        .Add<GameObject>(rightWall => rightWall
                            .Name("rightWall")
                            .Transform(transform => transform
                                .Position(1024, 320)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(10, 640)
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
                        .Build())
                    .Build())
                .Run();
        }
    }
}