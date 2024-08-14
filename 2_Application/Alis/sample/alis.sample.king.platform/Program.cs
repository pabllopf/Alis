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
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.King.Platform
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
                        .Name("King Game")
                        .Author("Pablo Perdomo Falcón")
                        .Description("King platform 2d game.")
                        .Debug(true)
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp")
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
                        .DebugColor(Color.Green)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        /*.Add<GameObject>(soundTrack => soundTrack
                            .Name("Soundtrack")
                            .AddComponent<AudioSource>(audioSource => audioSource
                                .Builder()
                                .PlayOnAwake(true)
                                .SetAudioClip(audioClip => audioClip
                                    .FilePath("World_Theme.wav"))
                                    .Volume(100.0f)
                                    .Build())
                                .Build())
                            .Build())*/
                        
                        // PLAYER
                        .Add<GameObject>(player => player
                            .Name("King")
                            .WithTag("player")
                            .Transform(transform => transform
                                .Position(50, 0)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .Depth(1)
                                .SetTexture("tile023.bmp")
                                .Build())
                            .AddComponent<Animator>(animator => animator
                                .Builder()
                                .AddAnimation(animation => animation
                                    .Name("Idle")
                                    .Order(0)
                                    .Speed(1f)
                                    .AddFrame(frame1 => frame1
                                        .FilePath("tile023.bmp")
                                        .Build())
                                    .AddFrame(frame2 => frame2
                                        .FilePath("tile025.bmp")
                                        .Build())
                                    .Build())
                                .AddAnimation(animation2 => animation2
                                    .Name("Run")
                                    .Order(1)
                                    .Speed(0.25f)
                                    .AddFrame(frame => frame
                                        .FilePath("tile036.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath("tile038.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath("tile039.bmp")
                                        .Build())
                                    .Build())
                                .AddAnimation(animation2 => animation2
                                    .Name("Jump")
                                    .Order(2)
                                    .Speed(0.25f)
                                    .AddFrame(frame => frame
                                        .FilePath("tile027.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath("tile028.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath("tile029.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath("tile030.bmp")
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
                                .Mass(5.0f)
                                .Restitution(0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .GravityScale(0.1f)
                                .Build())
                            .AddComponent(new PlayerMovement())
                            .AddComponent<Camera>(camera => camera.Builder()
                                .BackgroundColor(Color.Brown)
                                .Resolution(1024, 640)
                                .Build())
                            .Build())
                        
                        // FLOOR
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Floor")
                            .WithTag("Floor Down")
                            .Transform(transform => transform
                                .Position(512, 500)
                                .Scale(1, 1)
                                .Rotation(0)
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
                                .FixedRotation(true)
                                .GravityScale(0.0f)
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Build()
                .Run();
        }
    }
}