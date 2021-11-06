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

using System.Collections.Generic;
using Alis.Core.Entities;
using Alis.Core.Sfml.Components;
using SFML.Graphics;
using Sprite = Alis.Core.Sfml.Components.Sprite;

namespace Alis.Example
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
                        .ScreenMode(ScreenMode.Default)
                        .Build())
                    .Build())
                .Manager(sceneManager => sceneManager
                    .Add<Scene>(scene => scene
                        .Name("The main menu.")
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Player")
                            .Add<Sprite>(new Sprite(
                                @"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile000.png"))
                            .Add<AudioSource>(new AudioSource(
                                @"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\menu.wav"))
                            .Add<Camera>(Camera.CreateInstance())
                            .Add<BoxCollider2D>(new BoxCollider2D())
                            .Add<Animator>(new Animator(new List<Animation>()
                            {
                                new Animation(new List<Texture>()
                                {
                                    new Texture(@"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile000.png"),
                                    new Texture(@"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile001.png"),
                                    new Texture(@"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile002.png"),
                                    new Texture(@"C:\Users\wwwam\Documents\Repos\Alis\src\2_application\alis.example\Assets\tile003.png")
                                }),
                                new Animation()
                            }))
                            .Build())
                        .Build())
                    .Build())
                .Run();
        }
    }
}