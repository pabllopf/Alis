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
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System;

namespace Alis.Sample.Egg
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
                        .Name("Egg game")
                        .Author("Pablo Perdomo Falcón y Luis")
                        .Description("Egg game.")
                        .License("GNU General Public License v3.0")
                        .Icon("app.jpeg")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Resolution(1024, 640)
                        .FrameRate(60)
                        .BackgroundColor(new Color(20, 23, 32, 255))
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(false)
                        .DebugColor(Color.Red)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Name("Main Scene")
                        
                        // CAMERA
                        .Add<GameObject>(mainCamera => mainCamera
                            .Name("Camera")
                            .WithTag("Camera")
                            .AddComponent<Camera>(camera => camera
                                .Builder()
                                .Resolution(1024, 640)
                                .Build())
                            .Build())
                        
                        .Add<GameObject>(sarten => sarten
                            .Transform(transform => transform
                                .Position(-6, -2)
                                .Rotation(0)
                                .Scale(0.30f, 0.30f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("sarten.jpeg")
                                .Depth(0)
                                .Build())
                            .Build())
                        
                        .Add<GameObject>(clara => clara
                            .Transform(transform => transform
                                .Position(-3, -1)
                                .Rotation(0)
                                .Scale(0.10f, 0.10f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("clara.jpeg")
                                .Depth(1)
                                .Build())
                            .Build())
                        
                        .Add<GameObject>(yema => yema
                            .Transform(transform => transform
                                .Position(-3, -1)
                                .Rotation(0)
                                .Scale(0.15f, 0.15f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("yema.jpeg")
                                .Depth(2)
                                .Build())
                            .Build())
                        
                        
                        .Add<GameObject>(sarten => sarten
                            .Transform(transform => transform
                                .Position(-4, 0)
                                .Rotation(0)
                                .Scale(0.40f, 0.40f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("vitro.jpeg")
                                .Depth(-2)
                                .Build())
                            .Build())
                        
                        .Add<GameObject>(sarten => sarten
                            .Transform(transform => transform
                                .Position(9, -8)
                                .Rotation(0)
                                .Scale(0.08f, 0.08f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("button.jpeg")
                                .Depth(-1)
                                .Build())
                            .Build())
                        
                        .Add<GameObject>(sarten => sarten
                            .Transform(transform => transform
                                .Position(13, -8)
                                .Rotation(0)
                                .Scale(0.08f, 0.08f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("button.jpeg")
                                .Depth(-1)
                                .Build())
                            .Build())
                        
                        .Build())
                    .Build())
                .Build()
                .Run();
        }
    }
}