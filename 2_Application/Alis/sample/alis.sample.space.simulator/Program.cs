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
using Alis.Core.Ecs.System;



namespace Alis.Sample.Space.Simulator
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
                        .Name("T-Rex Dino Game")
                        .Author("Pablo Perdomo Falcón")
                        .Description("T-Rex Dino Game")
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Resolution(800, 600)
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Add<GameObject>(soundTrack => soundTrack
                            .Name("Soundtrack")
                            .Build())
                        .Build())
                    .Build())
                .Build()
                .Run();
        }
    }
}