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

using Alis.Core.Component.Collider;
using Alis.Core.Component.Render;
using Alis.Core.Entity;
using Alis.Core.Manager.Scene;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Collisions
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
                        .Name("Sample base collision")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Simple game to show physics module.")
                        .Build())
                    .Graphic(graphic => graphic
                        .Window(window => window
                            .Resolution(1024.0f, 720.0f)
                            .Build())
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0, 0.01f)
                        .Build())
                    .Build())
                .Manager<SceneManager>(sceneManager => sceneManager
                    .Add<Scene>(scene => scene
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Camera")
                            .AddComponent<Camera>(camera => camera
                                .Builder()
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Body 1")
                            .Transform(transform => transform
                                .Position(16.0f, 16.0f)
                                .Rotation(30f)
                                //.Scale(2,2)
                                .Build())
                            .AddComponent<BoxCollider>(box => box
                                .Builder()
                                .Size(24, 16)
                                .BodyType(BodyType.Static)
                                .LinearVelocity(0.0f, 0.0f)
                                .AngularVelocity(0.0f)
                                .FixedRotation(false)
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Body 2")
                            .Transform(transform => transform
                                .Position(0.0f, 0.0f)
                                .Rotation(0.0f)
                                //.Scale(2,2)
                                .Build())
                            .AddComponent<BoxCollider>(box => box
                                .Builder()
                                .BodyType(BodyType.Static)
                                .Size(8, 24)
                                .LinearVelocity(0.0f, 0.0f)
                                .AngularVelocity(0.0f)
                                .FixedRotation(false)
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Body 3")
                            .Transform(transform => transform
                                .Position(0.0f, 60.0f)
                                .Rotation(1.6f)
                                //.Scale(2,2)
                                .Build())
                            .AddComponent<BoxCollider>(box => box
                                .Builder()
                                .BodyType(BodyType.Static)
                                .Size(64, 8)
                                .LinearVelocity(0.0f, 0.0f)
                                .AngularVelocity(0.0f)
                                .FixedRotation(false)
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Body 4")
                            .Transform(transform => transform
                                .Position(4f, 12.0f)
                                .Rotation(4.9f)
                                //.Scale(2,2)
                                .Build())
                            .AddComponent<BoxCollider>(box => box
                                .Builder()
                                .BodyType(BodyType.Static)
                                .Size(4, 36)
                                .LinearVelocity(0.0f, 0.0f)
                                .AngularVelocity(0.0f)
                                .FixedRotation(false)
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Run();
        }

        /// <summary>
        /// Settings
        /// </summary>
        public static void Setting()
        {
            
        }
    }
}