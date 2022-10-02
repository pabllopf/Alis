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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Builder.Component.Render;
using Alis.Core.Component.Audio;
using Alis.Core.Component.Render;
using Alis.Core.Entity;
using Alis.Core.Manager;

namespace Alis.Sample.Rogue
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
            Console.WriteLine("Start game");
            
            VideoGame.Builder()
                .Manager<SceneManager>(sceneManager => sceneManager
                    .Add<Scene>(scene => scene
                        .Name("Main Menu")
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Player")
                            .Transform(transform => transform
                                .Position(100, 100)
                                .Rotation(180)
                                .Scale(3,3)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture(Environment.CurrentDirectory +  "/Assets/tile000.png")
                                .Depth(2)
                                .Build())
                            .Build())
                        .Add<GameObject>(gb=> gb
                            .Name("Player 2")
                            .WithTag("Players")
                            .Transform(i => i
                                .Position(100, 100)
                                .Rotation(90)
                                .Scale(3, 3)
                                .Build())
                            .AddComponent<Sprite>(i => i
                                .Builder()
                                .SetTexture(Environment.CurrentDirectory +  "/Assets/tile003.png")
                                .Depth(0)
                                .Build())
                            .AddComponent<PlayerMovement>(i => i
                                .Builder()
                                .Build())
                            .AddComponent<AudioSource>(audioSource => audioSource
                                .Builder()
                                .IsActive(true)
                                .PlayOnAwake(true)
                                .SetAudioClip(audioClip => audioClip
                                    .FilePath(Environment.CurrentDirectory +  "/Assets/menu.wav")
                                    .Volume(100.0f)
                                    .Mute(false)
                                    .Build())
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Run();
                
            

            Console.WriteLine("End game");
        }
    }
}