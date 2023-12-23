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

using Alis.Core.Aspect.Data;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity.GameObject;
using Alis.Core.Ecs.Entity.Scene;

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
            VideoGame
                .Builder()
                .Settings(setting => setting
                    .General(general => general
                        .Name("Flappy Bird")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Flappy Bird game.")
                        .License("GNU General Public License v3.0")
                        .Icon(AssetManager.Find("app.png"))
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Window(window => window
                            .Resolution(288,512)
                            .Background(Color.Black)
                            .Build())
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    
                    ////////////////////////////////////////
                    // MAIN MENU SCENE:
                    ////////////////////////////////////////
                    .Add<Scene>(gameScene => gameScene
                        .Name("Main Menu")
                        
                        ////////////////////////////////////////
                        // MAIN MENU SCENE: BACKGROUND
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Background")
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture(AssetManager.Find("background-day.png"))
                                .Depth(0)
                                .Build())
                            .Build())
                        
                        ////////////////////////////////////////
                        // MAIN MENU SCENE: FLOOR
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Floor")
                            .Transform(transform => transform
                                .Position(0, 400)
                                .Rotation(0)
                                .Scale(2f, 1.0f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture(AssetManager.Find("base.png"))
                                .Depth(1)
                                .Build())
                            .AddComponent(new FloorAnimation())
                            .Build())
                        
                        ////////////////////////////////////////
                        // MAIN MENU SCENE: MESSAGE MENU
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Message Menu")
                            .Transform(transform => transform
                                .Position(52, 82.0f)
                                .Rotation(0)
                                .Scale(1f, 1.0f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture(AssetManager.Find("message.png"))
                                .Depth(2)
                                .Build())
                            .Build())
                        
                        ////////////////////////////////////////
                        // MAIN MENU SCENE: BIRD
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Bird")
                            .Transform(transform => transform
                                .Position(72, 270.0f)
                                .Rotation(0)
                                .Scale(1f, 1.0f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture(AssetManager.Find("bluebird-down_flap.png"))
                                .Depth(2)
                                .Build())
                            .Build())
                        
                        ////////////////////////////////////////
                        // MAIN MENU SCENE: COUNTER
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Counter")
                            .Transform(transform => transform
                                .Position(132, 28f)
                                .Rotation(0)
                                .Scale(1f, 1.0f)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite
                                .Builder()
                                .SetTexture(AssetManager.Find("0.png"))
                                .Depth(3)
                                .Build())
                            .Build())
                        
                        ////////////////////////////////////////
                        // MAIN MENU SCENE: SOUNDTRACK
                        ////////////////////////////////////////
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Soundtrack")
                            .AddComponent<AudioSource>( audioSource => audioSource
                                .Builder()
                                .SetAudioClip(audioClip => audioClip
                                    .FilePath(AssetManager.Find("main_theme.mp3"))
                                    .Build())
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Run();
        }
    }
}