// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: CounterController.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Audio;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The counter controller class
    /// </summary>
    /// <seealso cref="Component" />
    public class CounterController : Component
    {
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
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(SdlKeycode key)
        {
            if (key == SdlKeycode.SdlkUp)
            {
                Increment();
                GameObject.Get<AudioSource>().Play();
                Console.WriteLine("Value: " + Counter);
            }
        }
    }
}