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
using Alis.Core.Component.Audio;
using Alis.Core.Component.Collider;
using Alis.Core.Component.Render;
using Alis.Core.Entity;
using Alis.Core.Graphic.D2.SFML.Graphics;
using Alis.Core.Manager.Scene;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.GeometryDash
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
        {VideoGame
                .Builder()
                .Settings(setting => setting
                    .General(general => general
                        .Name("GeometryDash")
                        .Author("Pablo Perdomo Falcón")
                        .Description("GeometryDash game")
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
                    .Add<Scene>(gameScene=>gameScene
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
                                    .FilePath($"{Environment.CurrentDirectory}/Assets/Music/menu_1.wav")
                                    .Volume(100.0f)
                                    .Build())
                                .Build())
                            .Build())
                        
                        .Add<GameObject>(downWall => downWall
                            .Name("downWall")
                            .Transform(transform=> transform
                                .Position(0, 324)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
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
                            .Transform(transform=> transform
                                .Position(0, -324)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
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
                            .Transform(transform=> transform
                                .Position(-517, 0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
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
                            .Transform(transform=> transform
                                .Position(517, 0)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
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