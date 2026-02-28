// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TestComponent.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     The test component
    /// </summary>
    internal struct TestComponent: IOnInit, IOnUpdate
    {
        /// <summary>
        /// The value
        /// </summary>
        public int Value;
        /// <summary>
        /// The name
        /// </summary>
        public string Name;
        /// <summary>
        /// Ons the init using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnInit(IGameObject self)
        {
            
        }

        /// <summary>
        /// Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
           
        }
    }
}