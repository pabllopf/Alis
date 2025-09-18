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
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
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
                    )
                    .Audio(audio => audio
                        .Volume(0)
                    )
                    .Graphic(graphic => graphic
                        .FrameRate(60)
                    )
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                    )
                    )
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Name("Main Scene")
                        
                        // CAMERA
                        .Add<GameObject>(mainCamera => mainCamera
                            .Name("Camera")
                            .Tag("Camera")
                            .WithComponent<Camera>(camera => camera
                                .Resolution(1024, 640)
                                .BackgroundColor(Color.Black)
                                )
                            )
                        
                        // SPAWN POINT ASTEROID
                        .Add<GameObject>(spawnPointAsteroid => spawnPointAsteroid
                            .Name("Spawn Point Asteroid")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                                )
                            .WithComponent(new SpawnAsteroid())
                            )
                        
                        .Add<GameObject>(counterPoints => counterPoints
                            .Name("Counter")
                            .Tag("Points")
                            .WithComponent(new CounterManager())
                            )
                        
                        .Add<GameObject>(counterPoints => counterPoints
                            .Name("HealthController")
                            .Tag("HealthController")
                            .WithComponent(new HealthController())
                            )
                        
                        // SOUNDTRACK
                        .Add<GameObject>(soundTrack => soundTrack
                            .Name("Soundtrack")
                            .Tag("Soundtrack")
                            .WithComponent<AudioSource>(audioSource => audioSource
                                
                                .PlayOnAwake(true)
                                .Loop(true)
                                .File("soundtrack.wav")
                                )
                            )
                        
                        // PLAYER
                        .Add<GameObject>(player => player
                            .Name("Player")
                            .Tag("Player")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(1.3f, 1.3f)
                                .Rotation(0)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                .SetTexture("player.bmp")
                                .Depth(1)
                                )
                            .WithComponent<AudioSource>(audioSource => audioSource
                                .PlayOnAwake(false)
                                .File("fire.wav")
                                )
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
                                .IsActive(true)
                                .BodyType(BodyType.Dynamic)
                                .IsTrigger(false)
                                .AutoTilling(true)
                                .Rotation(0.0f)
                                .Size(0.5f, 0.5f)
                                .Mass(1.0f)
                                .Restitution(0.0f)
                                .Friction(0f)
                                .FixedRotation(false)
                                .IgnoreGravity(true)
                                )
                            .WithComponent<Player>(new Player())
                            )
                        
                        .Add<GameObject>(sound => sound
                            .Name("SoundPlayer")
                            .Tag("SoundPlayer")
                            .WithComponent<AudioSource>(audioSource => audioSource
                                
                                .PlayOnAwake(false)
                                .File("bangLarge.wav")
                                )
                            )
                            
                        
                        // ASTEROID
                        .Add<GameObject>(asteroid => asteroid
                            .Name("Asteroid")
                            .Tag("Asteroid")
                            .Transform(transform => transform
                                .Position(6, 6)
                                .Scale(3, 3)
                                .Rotation(0)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                .SetTexture("asteroid_0.bmp")
                                .Depth(1)
                                )
                            .WithComponent(new Asteroid())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
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
                                )
                            )
                        
                        // ASTEROID
                        .Add<GameObject>(asteroid => asteroid
                            .Name("Asteroid")
                            .Tag("Asteroid")
                            .Transform(transform => transform
                                .Position(-6, -6)
                                .Scale(3, 3)
                                .Rotation(0)
                                )
                            .WithComponent<Sprite>(sprite => sprite
                                .SetTexture("asteroid_0.bmp")
                                .Depth(1)
                                )
                            .WithComponent(new Asteroid())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
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
                                )
                            )
                        
                        // WALLS
                        .Add<GameObject>(downWall => downWall
                            .Name("downWall")
                            .Tag("Wall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(0, -11)
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
                            .Name("upWall")
                            .Tag("Wall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(0, 11)
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
                            .Name("leftWall")
                            .Tag("Wall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(-17, 0)
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
                            .Name("rightWall")
                            .Tag("Wall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(17, 0)
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