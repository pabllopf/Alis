// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VariadicAttribute.cs
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

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The variadic attribute class
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class VariadicAttribute : Attribute
    {
        /// <summary>
        ///     The count
        /// </summary>
        private readonly int _count;

        /// <summary>
        ///     The from
        /// </summary>
        private readonly string _from;

        /// <summary>
        ///     The pattern
        /// </summary>
        private readonly string _pattern;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VariadicAttribute" /> class
        /// </summary>
        /// <param name="from">The from</param>
        /// <param name="pattern">The pattern</param>
        /// <param name="count">The count</param>
        public VariadicAttribute(string from, string pattern, int count = 16)
        {
            _from = from;
            _pattern = pattern;
            _count = count;
        }
    }
}