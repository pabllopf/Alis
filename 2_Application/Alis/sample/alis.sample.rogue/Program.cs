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
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Rogue
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
                        .Name("Rogue Legacy")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Sample of a rogue legacy game")
                        .Debug(true)
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                        .DebugColor(Color.Green)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Player")
                            .WithTag("Player")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tile000.bmp")
                                .Build())
                            .AddComponent<Camera>(camera => camera.Builder()
                                .Resolution(1024, 640)
                                .BackgroundColor(Color.Brown)
                                .Build())
                            .AddComponent<BoxCollider>(boxCollider => boxCollider
                                .Builder()
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(false)
                                .AutoTilling(true)
                                .Rotation(0.0f)
                                .Size(1, 1)
                                .Mass(1.0f)
                                .Restitution(0.0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(false)
                                .Build())
                            .AddComponent(new PlayerMovement())
                            .Build())

                        // Decoration tree-001
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-001")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(-2f, -2f)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())

                        // Decoration tree-001
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-002")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(-2f, 2f)
                                .Scale(2, 2)
                                .Rotation(90)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-001")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(2, 2)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-001")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(2f, -2f)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Build()
                .Run();
        }
    }
}