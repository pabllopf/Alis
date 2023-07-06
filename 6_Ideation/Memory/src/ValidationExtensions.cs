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

using System;
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
            string parameterName = GetParameterName(method.DeclaringType, method.Name);
            IEnumerable<ValidationAttribute> attributes = method.GetParameters()
                .Where(p => p.Name == parameterName)
                .SelectMany(p => p.GetCustomAttributes<ValidationAttribute>(true));

            foreach (ValidationAttribute attribute in attributes)
            {
                attribute.Validate(value, parameterName);
            }

            return value;
        }

        /// <summary>
        ///     Gets the parameter name using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="methodName">The method name</param>
        /// <exception cref="ArgumentException">Unable to determine parameter name.</exception>
        /// <returns>The string</returns>
        private static string GetParameterName(Type type, string methodName)
        {
            MethodInfo methodInfo = type.GetMethod(methodName);
            if (methodInfo != null)
            {
                ParameterInfo[] parameters = methodInfo.GetParameters();
                if (parameters.Length == 1)
                {
                    return parameters[0].Name;
                }
            }

            throw new ArgumentException("Unable to determine parameter name.");
        }
    }
}