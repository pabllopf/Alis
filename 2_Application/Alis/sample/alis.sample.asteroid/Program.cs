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
using Alis.Core.Audio;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Asteroid
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
                        .Name("Asteroids")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Asteroids game")
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Window(window => window
                            .IsResizable(true)
                            .Background(Color.Black)
                            .Build())
                        .FrameRate(60)
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                        .DebugColor(Color.Red)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Name("Main Scene")
                        
                        // CAMERA
                        .Add<GameObject>(mainCamera => mainCamera
                            .Name("Camera")
                            .WithTag("Camera")
                            .AddComponent<Camera>(camera => camera
                                .Builder()
                                .Resolution(1024, 640)
                                .BackgroundColor(Color.Black)
                                .Build())
                            .Build())
                        
                        // SPAWN POINT ASTEROID
                        .Add<GameObject>(spawnPointAsteroid => spawnPointAsteroid
                            .Name("Spawn Point Asteroid")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .AddComponent(new SpawnAsteroid())
                            .Build())
                        
                        // SOUNDTRACK
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
                        
                        // PLAYER
                        .Add<GameObject>(player => player
                            .Name("Player 1")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(1f, 1f)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("player.bmp")
                                .Depth(1)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Dynamic)
                                .IsTrigger(false)
                                .AutoTilling(true)
                                .Rotation(0.0f)
                                .Size(1, 1)
                                .Mass(1.0f)
                                .Restitution(0.0f)
                                .Friction(0f)
                                .FixedRotation(false)
                                .IgnoreGravity(true)
                                .Build())
                            .AddComponent(new Player())
                            .Build())
                        
                        // ASTEROID
                        .Add<GameObject>(asteroid => asteroid
                            .Name("Asteroid")
                            .WithTag("Asteroid")
                            .Transform(transform => transform
                                .Position(6, 6)
                                .Scale(3, 3)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("asteroid_0.bmp")
                                .Depth(1)
                                .Build())
                            .AddComponent(new Asteroid())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Dynamic)
                                .IsTrigger(false)
                                .AutoTilling(true)
                                .Rotation(0.0f)
                                .LinearVelocity(-3f, -1)
                                .Size(0.7F, 0.7F)
                                .Mass(1.0f)
                                .Restitution(0.9f)
                                .Friction(0.5f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                                .Build())
                            .Build())
                        
                        // ASTEROID
                        .Add<GameObject>(asteroid => asteroid
                            .Name("Asteroid")
                            .WithTag("Asteroid")
                            .Transform(transform => transform
                                .Position(-6, -6)
                                .Scale(3, 3)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("asteroid_0.bmp")
                                .Depth(1)
                                .Build())
                            .AddComponent(new Asteroid())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Dynamic)
                                .IsTrigger(false)
                                .AutoTilling(true)
                                .Rotation(0.0f)
                                .LinearVelocity(3f, 1)
                                .Size(0.7F, 0.7F)
                                .Mass(1.0f)
                                .Restitution(0.9f)
                                .Friction(0.5f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                                .Build())
                            .Build())
                        
                        // WALLS
                        .Add<GameObject>(downWall => downWall
                            .Name("downWall")
                            .WithTag("Wall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(0, -11)
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
                            .WithTag("Wall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(0, 11)
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
                            .WithTag("Wall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(-17, 0)
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
                            .WithTag("Wall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(17, 0)
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