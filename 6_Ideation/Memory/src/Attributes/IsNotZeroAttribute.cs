// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IsNotZeroAttribute.cs
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

using Alis.Core.Aspect.Memory.Exceptions;

namespace Alis.Core.Aspect.Memory.Attributes
{
    /// <summary>
    ///     The not null attribute class
    /// </summary>
    /// <seealso cref="IsValidationAttribute" />
    public class IsNotZeroAttribute : IsValidationAttribute
    {
        /// <summary>
        ///     Validates the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="name">The name</param>
        public override void Validate(object value, string name)
        {
            switch (value)
            {
                case int i when i == 0:
                    throw new NotZeroException($"The value of {name} can't be zero");
                case long l when l == 0:
                    throw new NotZeroException($"The value of {name} can't be zero");
                case decimal d when d == 0:
                    throw new NotZeroException($"The value of {name} can't be zero");
                case float f when f == 0:
                    throw new NotZeroException($"The value of {name} can't be zero");
                case double db when db == 0:
                    throw new NotZeroException($"The value of {name} can't be zero");
                case short s when s == 0:
                    throw new NotZeroException($"The value of {name} can't be zero");
                case byte b when b == 0:
                    throw new NotZeroException($"The value of {name} can't be zero");
                case sbyte sb when sb == 0:
                    throw new NotZeroException($"The value of {name} can't be zero");
                case ushort us when us == 0:
                    throw new NotZeroException($"The value of {name} can't be zero");
                case uint ui when ui == 0:
                    throw new NotZeroException($"The value of {name} can't be zero");
                case ulong ul when ul == 0:
                    throw new NotZeroException($"The value of {name} can't be zero");
            }
        }
    }
}