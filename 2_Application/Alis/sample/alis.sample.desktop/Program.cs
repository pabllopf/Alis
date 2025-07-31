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
using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
using Alis.Core.Physic.Common;

namespace Alis.Sample.Desktop
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
            VideoGame.Create()
                .Settings(settings => settings
                    .General(general => general
                        .Name("Sample")
                        .Author("Pablo Perdomo Falcón")
                        .Icon("app.bmp")
                        .Debug(true)
                        .License("GNU General Public License v3.0")
                        .Description("Sample game")
                        .Version("0.0.1"))
                    .Audio(audioSettings => audioSettings
                        .Volume(100)
                        .IsMute(false))
                    .Graphic(graphicSettings => graphicSettings
                        .Resolution(640, 480)
                        .IsResizable(true)
                        .FrameRate(60))
                    .Physic(physic => physic
                        .Gravity(9.8f, 0))
                    .Input(inputSetting => inputSetting
                        .MouseSensitivity(0.1f))
                    .Network(networkSettings => networkSettings
                        .Ip("localhost"))
                )
                .World(world => world
                    .Add<Scene>(scene => scene
                        .Add<GameObject>(gameObject => gameObject
                            .WithComponent<Camera>(camera => camera
                                .Position(0, 0)
                                .Resolution(800, 480)
                            )
                        )
                        .Add<GameObject>(gameObject => gameObject
                            .Transform(transform => transform
                                .Position(-6, -2)
                                .Rotation(0)
                                .Scale(0.30f, 0.30f)
                            )
                            .WithComponent<Sprite>(sprite => sprite
                                .SetTexture("app.bmp")
                                .Depth(0)
                            )
                        )
                    )
                ).Run();
        }
    }
}