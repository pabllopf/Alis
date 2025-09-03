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
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
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
            VideoGame game = VideoGame
                .Create()
                .Settings(setting => setting
                    .General(general => general
                        .Name("King Game")
                        .Author("Pablo Perdomo Falcón")
                        .Description("King platform 2d game.")
                        .Debug(false)
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Resolution(640, 480)
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene

                        // PLAYER
                        .Add<GameObject>(player => player
                            .Transform(transform => transform
                                .Position(0, 2)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .WithComponent<Sprite>(sprite => sprite
                                .Depth(1)
                                .SetTexture("tile023.bmp")
                                .Build())
                            .WithComponent<Animator>(animator => animator
                                .AddAnimation(animation => animation
                                    .Name("Run")
                                    .Order(0)
                                    .Speed(0.125f)
                                    .AddFrame(frame => frame
                                        .File("tile036.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .File("tile038.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .File("tile039.bmp")
                                        .Build())
                                    .Build())
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Dynamic)
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
                            .WithComponent(new PlayerMovement())
                            .WithComponent<Camera>(camera => camera
                                .Resolution(640, 480))
                            .Build())

                        // FLOOR
                        .Add<GameObject>(gameObject => gameObject
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(20, 1)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .FixedRotation(true)
                                .IgnoreGravity(false)
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Build();

            game.Save();

            game.Run();
        }
    }
}