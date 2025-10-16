// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CounterController.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Audio;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The counter controller class
    /// </summary>
    
    public class CounterController : IOnStart, IOnUpdate, IOnCollisionEnter, IOnCollisionExit
    {
        /// <summary>
        ///     The audio source
        /// </summary>
        private AudioSource audioSource;
        
        //private FontManager fontManager;

        /// <summary>
        ///     The is enter
        /// </summary>
        private bool isEnter;

        /// <summary>
        ///     Gets or sets the value of the counter
        /// </summary>
        public int Counter { get; set; }

        /// <summary>
        ///     Increments this instance
        /// </summary>
        public void Increment()
        {
            Counter++;
        }

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            Counter = 0;
        }

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => Counter.ToString();

        /// <summary>
        /// Ons the collision exit using the specified other
        /// </summary>
        /// <param name="other">The other</param>
        public void OnCollisionExit(IGameObject other)
        {
            Logger.Log($"Collision exit with");
            Info info = other.Get<Info>();
            if ((info.Tag == "Player") && isEnter)
            {
                isEnter = false;
                Logger.Info("Player exit");
            }
        }

        /// <summary>
        /// Ons the collision enter using the specified other
        /// </summary>
        /// <param name="other">The other</param>
        public void OnCollisionEnter(IGameObject other)
        {
            Logger.Log($"Collision enter with");
            
            Info info = other.Get<Info>();
            if ((info.Tag == "Player") && !isEnter)
            {
                Increment();
                audioSource.Play();
                Logger.Info("Value: " + Counter);
                isEnter = true;
            }
            
        }

        /// <summary>
        /// Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
            
        }

        /// <summary>
        /// Ons the start using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            audioSource = self.Get<AudioSource>();    
        }
        

        /*
        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            audioSource = GameObject.Get<AudioSource>();
            //fontManager = Context.GraphicManager.FontManager;
            //fontManager.LoadFont("MONO", 16, AssetManager.Find("mono.bmp"));
        }

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public override void OnGui()
        {
            //fontManager.RenderText("MONO", $"{Counter}", -0.5f, -7, Color.White, 32);
        }

        /// <summary>
        ///     Ons the collision enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public override void OnCollisionEnter(GameObject gameObject)
        {
            if ((gameObject.Tag == "Player") && !isEnter)
            {
                Increment();
                audioSource.Play();
                Logger.Info("Value: " + Counter);
                isEnter = true;
            }
        }

        /// <summary>
        ///     Ons the collision exit using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public override void OnCollisionExit(GameObject gameObject)
        {
            if ((gameObject.Tag == "Player") && isEnter)
            {
                isEnter = false;
            }
        }*/
    }
}