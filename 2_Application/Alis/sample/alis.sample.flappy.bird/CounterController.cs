// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:$FILENAME$
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
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Data;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Render;

namespace Alis.Sample.Flappy.Bird
{
    public class CounterController : Component
    {
        public int Counter { get; set; }
        
        public void Increment()
        {
            Counter++;
        }
        
        public void Reset()
        {
            Counter = 0;
        }
        
        public override string ToString()
        {
            return Counter.ToString();
        }

        public override void OnPressKey(SdlKeycode key)
        {
            if (key == SdlKeycode.SdlkUp)
            {
                Increment();
                GameObject.Get<Sprite>().Image = GetNumberSprite(Counter);
                GameObject.Get<AudioSource>().Play();
                Console.WriteLine("Value: " + Counter);
            }
        }
        
        public Image GetNumberSprite(int number)
        {
            if (number > 9)
            {
                number = 0;
                Counter = 0;
            }
            return new Image(AssetManager.Find($"{number}.png"));
        } 
    }
}