// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CounterManager.cs
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
using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Sample.Asteroid
{
    /// <summary>
    /// The counter manager class
    /// </summary>
    public class CounterManager : IInitable , IUpdateable
    {
        /*
        /// <summary>
        /// The counter
        /// </summary>
        public int counter = 10;
        
        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
            //fontManager = Context.GraphicManager.FontManager;
            //fontManager.LoadFont("MONO", 16, AssetManager.Find("mono.bmp"));
        }
        
        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
        }
        
        /// <summary>
        ///     Ons the gui
        /// </summary>
        public override void OnGui()
        {
            if(this.Context.SceneManager.CurrentScene.GetByTag("HealthController").Get<HealthController>().health > 0)
            {
                //fontManager.RenderText("MONO", counter.ToString("D3"), -10, -10, Color.White, 32);
            }
        }
        
        /// <summary>
        ///     Increments this instance
        /// </summary>
        public void Increment()
        {
            counter += 10;
        }
        
        /// <summary>
        /// Decrements this instance
        /// </summary>
        public void Decrement()
        {
            counter -= 1;
            if (counter < 0)
            {
                counter = 15;
                this.Context.SceneManager.CurrentScene.GetByTag("HealthController").Get<HealthController>().Decrement();
            }
        }

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            counter = 0;
        }*/


        public void Init(IGameObject self)
        {
            
        }

        public void Update(IGameObject self)
        {
            
        }
    }
}