// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HealthController.cs
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
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.System.Manager.Fonts;

namespace Alis.Sample.Asteroid
{
    /// <summary>
    /// The health controller class
    /// </summary>
    /// <seealso cref="AComponent"/>
    public class HealthController : AComponent
    {
        /// <summary>
        /// The font manager
        /// </summary>
        public FontManager fontManager;

        /// <summary>
        /// The health
        /// </summary>
        public int health = 1;
        
        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        { 
            fontManager = Context.GraphicManager.FontManager;
            fontManager.LoadFont("MONO", 16, AssetManager.Find("mono.bmp"));
        }

        /// <summary>
        /// Ons the gui
        /// </summary>
        public override void OnGui()
        {
            if (fontManager == null) return;
            
            if (health == 3)
            {
                fontManager.RenderText("MONO", $"^", -10.1f, -9, Color.White, 32);
                fontManager.RenderText("MONO", $"^", -9.3f, -9, Color.White, 32);
                fontManager.RenderText("MONO", $"^", -8.5f, -9, Color.White, 32);
                return;
            }
            
            if (health == 2)
            {
                fontManager.RenderText("MONO", $"^", -10.1f, -9, Color.White, 32);
                fontManager.RenderText("MONO", $"^", -9.3f, -9, Color.White, 32);
                return;
            }
            
            if (health == 1)
            {
                fontManager.RenderText("MONO", $"^", -10.1f, -9, Color.White, 32);
                return;
            }
            
            if (health >= 0)
            {
                fontManager.RenderText("MONO", $"GAME OVER", -2.8f, -0.5f, Color.White, 32);
                fontManager.RenderText("MONO", $"^^^ Press START ^^^", -2f, 0.8f, Color.White, 12);
                Context.SceneManager.CurrentScene.GetByTag("Soundtrack").Get<AudioSource>().Stop();
            }
        }

        /// <summary>
        /// Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(KeyCodes key)
        {
            if (health <= 0 && key != KeyCodes.Space && key != KeyCodes.S && key != KeyCodes.W && key != KeyCodes.A && key != KeyCodes.D)
            {
                Context.SceneManager.LoadScene(0);
                Console.WriteLine("Restarting game");
            }
        }

        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (health <= 0)
            {
                Context.SceneManager.CurrentScene.GetByTag("Points").Get<CounterManager>().counter = 0;
                Context.SceneManager.DestroyGameObject(Context.SceneManager.CurrentScene.GetByTag("Player"));
            }
        }

        /// <summary>
        /// Decrements this instance
        /// </summary>
        public void Decrement()
        {
            health--;
        }
    }
}