// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IsNotEmptyAttribute.cs
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

using System.Collections;
using System.Linq;
using Alis.Core.Aspect.Memory.Exceptions;

namespace Alis.Core.Aspect.Memory.Attributes
{
    /// <summary>
    ///     The not empty attribute class
    /// </summary>
    /// <seealso cref="IsValidationAttribute" />
    public class IsNotEmptyAttribute : IsValidationAttribute
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
                case string str when string.IsNullOrEmpty(str):
                    throw new NotEmptyException($"{name} can't be null or empty");
            }

            switch (value)
            {
                case IDictionary {Count: 0}:
                    throw new NotEmptyException($"{name} can't be null or empty");
                case IEnumerable enumerable:
                {
                    if (enumerable.Cast<object>().Any())
                    {
                        return;
                    }

                    throw new NotEmptyException($"{name} can't be null or empty");
                }
            }
        }
    }
}