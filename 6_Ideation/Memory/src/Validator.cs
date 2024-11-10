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
        [Conditional("DEBUGGER")]
        public static void Validate<T>(T value, string name)
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(1)?.GetMethod() ?? throw new InvalidOperationException();
            if (methodBase.ReflectedType != null)
            {
                Type callingType = methodBase.ReflectedType;
                
                if (callingType != null)
                {
                    ValidateParameter(value, name, callingType, methodBase);
                    ValidateField(value, name, callingType);
                    ValidateProperty(value, name, callingType);
                }
            }
        }

        /// <summary>
        ///     Validates the property using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <param name="name">The name</param>
        /// <param name="callingType">The calling type</param>
        internal static void ValidateProperty<T>(T value, string name, Type callingType)
        {
            if (callingType != null)
            {
                PropertyInfo[] properties = callingType.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (PropertyInfo property in properties)
                {
                    if (property.Name != name)
                    {
                        continue;
                    }

                    object[] attributes = property.GetCustomAttributes(true);

                    foreach (object attribute in attributes)
                    {
                        if (attribute is IsValidationAttribute validationAttribute)
                        {
                            if (value != null)
                            {
                                validationAttribute.Validate(value, $"type='{callingType}' property='{property.Name}'");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Validates the field using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <param name="name">The name</param>
        /// <param name="callingType">The calling type</param>
        internal static void ValidateField<T>(T value, string name, Type callingType)
        {
            if (callingType != null)
            {
                FieldInfo[] fields = callingType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (FieldInfo field in fields)
                {
                    if (field.Name != name)
                    {
                        continue;
                    }

                    object[] attributes = field.GetCustomAttributes(true);

                    foreach (object attribute in attributes)
                    {
                        if (attribute is IsValidationAttribute validationAttribute)
                        {
                            if (value != null)
                            {
                                validationAttribute.Validate(value, $"type='{callingType}' field='{field.Name}'");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Validates the parameter using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <param name="name">The name</param>
        /// <param name="callingType">The calling type</param>
        /// <param name="methodBase">The method base</param>
        internal static void ValidateParameter<T>(T value, string name, Type callingType, MethodBase methodBase)
        {
            ParameterInfo[] parameters = methodBase.GetParameters();
            if (parameters.Length > 0)
            {
                foreach (ParameterInfo parameter in parameters)
                {
                    if (parameter.Name != name)
                    {
                        continue;
                    }

                    object[] attributes = parameter.GetCustomAttributes(true);

                    foreach (object attribute in attributes)
                    {
                        if (attribute is IsValidationAttribute validationAttribute)
                        {
                            if (value != null)
                            {
                                validationAttribute.Validate(value, $"type='{callingType}' method='{methodBase.Name}' param='{parameter.Name}'");
                            }
                        }
                    }
                }
            }
        }
    }
}