// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AlisObject.cs
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

namespace Alis.Core.Aspect.Base
{
    /// <summary>
    ///     The object base class
    /// </summary>
    public class AlisObject : object
    {
        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; } = "Default Name";

        /// <summary>
        /// The tag
        /// </summary>
        public string Tag  { get; set; } = "Default Tag";

        /// <summary>
        /// Gets or sets the value of the is active
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        ///     The object base class
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetHashCode(object obj) => obj?.GetHashCode() ?? 0;
    }
}