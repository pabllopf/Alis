// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ValidationExtensions.cs
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

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Alis.Core.Aspect.Memory.Attributes;

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    ///     The validation extensions class
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        ///     Validates the attributes using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The value</returns>
        public static T Validate<T>(this T value)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase method = stackFrame.GetMethod();
           
            
           if (method.DeclaringType != null)
            {
                MethodInfo methodInfo = method.DeclaringType.GetMethod(method.Name);
                if (methodInfo != null)
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    foreach (ParameterInfo parameter in parameters)
                    {
                        IEnumerable<ValidationAttribute> attributes = method.GetParameters()
                            .Where(p => p.Name == parameter.Name)
                            .SelectMany(p => p.GetCustomAttributes<ValidationAttribute>(true));
                        
                        foreach (ValidationAttribute attribute in attributes)
                        {
                            attribute.Validate(value, parameter.Name);
                        }
                    }
                }
            }
           
            return value;
        }
    }
}