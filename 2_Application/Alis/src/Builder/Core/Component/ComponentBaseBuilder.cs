// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentBaseBuilder.cs
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
using Alis.Core.Ecs;

namespace Alis.Builder.Core.Component
{
    /// <summary>
    ///     The component base builder class
    /// </summary>
    public class ComponentBaseBuilder
    {
        /// <summary>
        ///     The component base
        /// </summary>
        private ComponentBase componentBase;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentBaseBuilder" /> class
        /// </summary>
        /// <param name="componentBase">The component base</param>
        public ComponentBaseBuilder(ComponentBase componentBase) => this.componentBase = componentBase;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentBaseBuilder" /> class
        /// </summary>
        public ComponentBaseBuilder()
        {
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The component base</returns>
        public ComponentBase Build() => (ComponentBase) Activator.CreateInstance(componentBase.GetType());
    }
}