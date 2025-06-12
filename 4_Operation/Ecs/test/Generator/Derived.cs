// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Derived.cs
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

namespace Alis.Core.Ecs.Test.Generator
{
    /// <summary>
    /// The derived class
    /// </summary>
    /// <seealso cref="InGlobalNamespace"/>
    public partial class Derived : InGlobalNamespace
    {
        /// <summary>
        /// The derived inner class
        /// </summary>
        /// <seealso cref="Derived"/>
        /// <seealso cref="IInitable"/>
        public class DerivedInner : Derived, IInitable
        {
            /// <summary>
            /// Inits the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <exception cref="InitalizeException"></exception>
            public void Init(IGameObject self)
            {
                throw new InitalizeException();
            }
        }

        /// <summary>
        /// The warning class
        /// </summary>
        /// <seealso cref="IComponent"/>
        /// <seealso cref="IUniformComponent{int}"/>
        protected partial class Warning : IComponent, IComponent<int>
        {
            /// <summary>
            /// Updates this instance
            /// </summary>
            /// <exception cref="UpdateException"></exception>
            public void Update()
            {
                throw new UpdateException();
            }

            /// <summary>
            /// Updates the uniform
            /// </summary>
            /// <param name="uniform">The uniform</param>
            /// <exception cref="UpdateException"></exception>
            public void Update(ref int uniform)
            {
                throw new UpdateException();
            }
        }
    }
}