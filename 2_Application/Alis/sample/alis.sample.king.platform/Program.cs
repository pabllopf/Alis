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

using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity.GameObject;
using Alis.Core.Ecs.Entity.Scene;
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
                        .Icon(AssetManager.Find("app.bmp"))
                        .Build())
                    .Profile(profile => profile
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
                                    .FilePath(AssetManager.Find("World_Theme.wav"))
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
                                .SetTexture(AssetManager.Find("tile023.bmp"))
                                .Build())
                            .AddComponent<Animator>(animator => animator
                                .Builder()
                                .AddAnimation(animation => animation
                                    .Name("Idle")
                                    .Order(0)
                                    .Speed(1f)
                                    .AddFrame(frame1 => frame1
                                        .FilePath(AssetManager.Find("tile023.bmp"))
                                        .Build())
                                    .AddFrame(frame2 => frame2
                                        .FilePath(AssetManager.Find("tile025.bmp"))
                                        .Build())
                                    .Build())
                                .AddAnimation(animation2 => animation2
                                    .Name("Run")
                                    .Order(1)
                                    .Speed(0.25f)
                                    .AddFrame(frame => frame
                                        .FilePath(AssetManager.Find("tile036.bmp"))
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(AssetManager.Find("tile038.bmp"))
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(AssetManager.Find("tile039.bmp"))
                                        .Build())
                                    .Build())
                                .AddAnimation(animation2 => animation2
                                    .Name("Jump")
                                    .Order(2)
                                    .Speed(0.25f)
                                    .AddFrame(frame => frame
                                        .FilePath(AssetManager.Find("tile027.bmp"))
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(AssetManager.Find("tile028.bmp"))
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(AssetManager.Find("tile029.bmp"))
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath(AssetManager.Find("tile030.bmp"))
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
                                .Density(0f)
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