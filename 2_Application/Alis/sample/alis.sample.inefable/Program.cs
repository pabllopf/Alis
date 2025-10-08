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
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;

namespace Alis.Sample.Inefable
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
                        .Name("Inefable")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Roguelike 2D multiplayer with RPG and arcade components")
                        .Debug(false)
                        .License("GNU General Public License v3.0")
                        .Icon("app.ico")
                        .Build()
                    )
                    .Audio(audio => audio
                        .Volume(100)
                    )
                    .Graphic(graphic => graphic
                        .Resolution(1024, 768)
                    )
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                    )
                )
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Name("Dungeon Entrance")
                        
                        .Add<GameObject>(camera => camera
                            .Name("Main Camera")
                            .Transform(trasform => trasform
                                .Position(0, 0)
                                .Rotation(0)
                                .Scale(1.0f, 1.0f)
                            )
                            .WithComponent<Camera>(cam => cam
                                .Resolution(1024, 768)
                            )
                        )
                        
                        .Add<GameObject>(background => background
                            .Name("Background")
                            .Tag("Environment")
                            .Transform(trasform => trasform
                                .Position(0, 0)
                                .Rotation(0)
                                .Scale(1.0f, 1.0f)
                            )
                            .WithComponent<Sprite>(sprite => sprite
                                .Depth(-3)
                                .SetTexture("Draw001.bmp")
                                .Build()
                            )
                        )
                    )
                )
                .Run();
        }
    }
}