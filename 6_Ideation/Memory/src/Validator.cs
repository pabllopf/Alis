// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Validator.cs
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
using System.Diagnostics;
using System.Reflection;
using Alis.Core.Aspect.Memory.Attributes;

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    ///     The validator class
    /// </summary>
    public static class Validator
    {
        /// <summary>
        ///     Validates the input using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <param name="name"></param>
        [Conditional("DEBUG")]
        public static void Validate<T>(T value, string name)
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();
            Type callingType = methodBase.ReflectedType;

            ParameterInfo[] parameters = methodBase.GetParameters();
            if (parameters.Length > 0)
            {
                foreach (ParameterInfo parameter in parameters)
                {
                    if (parameter.Name != name) continue;
                    
                    object[] attributes = parameter.GetCustomAttributes(true);

                    foreach (object attribute in attributes)
                    {
                        if (attribute is IsValidationAttribute validationAttribute)
                        {
                            validationAttribute.Validate(value, $"type='{callingType}' method='{methodBase.Name}' param='{parameter.Name}'");
                        }
                    }
                }
            }
            
            if (callingType != null)
            {
                FieldInfo[] fields = callingType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (FieldInfo field in fields)
                {
                    if (field.Name != name) continue;

                    object[] attributes = field.GetCustomAttributes(true);

                    foreach (object attribute in attributes)
                    {
                        if (attribute is IsValidationAttribute validationAttribute)
                        {
                            validationAttribute.Validate(value, $"type='{callingType}' field='{field.Name}'");
                        }
                    }
                }
                
                PropertyInfo[] properties = callingType.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (PropertyInfo property in properties)
                {
                    if (property.Name != name) continue;
                    
                    object[] attributes = property.GetCustomAttributes(true);

                    foreach (object attribute in attributes)
                    {
                        if (attribute is IsValidationAttribute validationAttribute)
                        {
                            validationAttribute.Validate(value, $"type='{callingType}' property='{property.Name}'");
                        }
                    }
                }
            }
        }
    }
}