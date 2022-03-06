// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Program.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Numerics;
using Alis;
using Alis.Core.Systems.Physics2D.Dynamics;

namespace PingPong2D
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
        {
            VideoGame.Create()
                .Settings(setting => setting
                    .General(general => general
                        .Author("Pedro Diaz")
                        .Name("The best game")
                        .Build())
                    .Window(window => window
                        .Resolution(640, 480)
                        .Build())
                    .Debug(debug => debug
                        .ShowPhysicBorders(true)
                        .Build())
                    .Build())
                .Manager(sceneManager => sceneManager
                    .Add<Scene>(scene => scene
                        .Name("The main menu.")
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Other Example")
                            .Transform(new Transform(new Vector3(1, 1, 0), new Vector3(100, 100, 0), new Vector3(0)))
                            .Add(new Sprite(@$"{Environment.CurrentDirectory}\Assets\tile000.png"))
                            .Add(new BoxCollider2D
                            {
                                Size = new Vector2(22, 22),
                                BodyType = BodyType.Kinematic,
                                AutoTiling = true,
                            })
                            .Build())
                        .Build())
                    .Build())
                .Run();
        }
    }


    
}