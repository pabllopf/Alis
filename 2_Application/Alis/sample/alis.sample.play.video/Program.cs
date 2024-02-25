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

using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity.GameObject;
using Alis.Core.Ecs.Entity.Scene;

namespace Alis.Sample.Play.Video
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
                .Builder()
                .Settings(setting => setting
                    .General(general => general
                        .Name("Video sample")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Video camera game.")
                        .Debug(true)
                        .License("GNU General Public License v3.0")
                        .Icon(AssetManager.Find("app.bmp"))
                        .Build())
                    .Profile(profile => profile
                        .LogLevel(LogLevel.Critical)
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Window(window => window
                            .Resolution(1024, 640)
                            .Background(Color.Black)
                            .Build())
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                        .DebugColor(Color.Green)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        
                        // Play video
                        .Add<GameObject>(gameObject => gameObject
                            .Name("video")
                        .Build()) // End game object
                        
                    .Build()) // End scene
                .Build()) // End world
            .Run();
        }
    }
}