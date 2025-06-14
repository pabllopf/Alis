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

namespace Alis.Sample.Flappy.Bird
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
            var game = VideoGame
                .Create()
                .Settings(settings => settings
                    .General(general => general
                        .Name("Flappy Bird")
                        .Author("Pablo Perdomo Falcón")
                        .Icon("app.bmp")
                        .Debug(true)
                    )
                    .Audio(audio => audio
                        .Volume(100)
                    )
                    .Graphic(graphic => graphic
                        .Resolution(800, 600)
                    )
                    .Network(network => network
                        .Ip("localhost")
                    )
                    .Physic(physic => physic
                        .Gravity(0, 9.8f)
                    )
                    .Input(input => input
                        .MouseSensitivity(1)
                    )
                )
                .World(world => world
                    .Add<Scene>(mainScene => mainScene
                        .Name("Main Scene")
                        .Add<GameObject>(gameObject => gameObject
                            .Transform(transform => transform
                                .Position(2, 2)
                            )
                        )
                    )
                )
                .Build();
            
            game.Run();
        }
    }
}