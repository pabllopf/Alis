// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerInfo.cs
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Alis.Core.Input.Attributes;
using DevDecoder.HIDDevices;

namespace Alis.Core.Input.Controllers
{
    /// <summary>
    ///     The controller class
    /// </summary>
    public partial class Controller
    {
        /// <summary>
        ///     The controller info class
        /// </summary>
        private class ControllerInfo
        {
            /// <summary>
            ///     The create controller
            /// </summary>
            public readonly CreateControllerDelegate<Controller> CreateController;

            /// <summary>
            ///     Initializes a new instance of the <see cref="ControllerInfo" /> class
            /// </summary>
            /// <param name="createControllerDelegate">The create controller delegate</param>
            private ControllerInfo(
                CreateControllerDelegate<Controller> createControllerDelegate)
                => CreateController = createControllerDelegate;

            /// <summary>
            ///     Initializes a new instance of the <see cref="ControllerInfo" /> class
            /// </summary>
            /// <param name="constructor">The constructor</param>
            /// <param name="deviceAttributes">The device attributes</param>
            /// <param name="propertyData">The property data</param>
            private ControllerInfo(
                ConstructorInfo constructor,
                IReadOnlyList<DeviceAttribute> deviceAttributes,
                IReadOnlyDictionary<string, PropertyData> propertyData)
            {
                CreateController = device =>
                {
                    ControlInfo[] mapping = GetMapping(device, deviceAttributes, propertyData);
                    return mapping is null ||
                           !(constructor.Invoke(new object[] {device, mapping}) is Controller controller)
                        ? null
                        : controller;
                };
            }

            /// <summary>
            ///     The controller info
            /// </summary>
            private static readonly ConcurrentDictionary<Type, ControllerInfo> s_infos =
                new ConcurrentDictionary<Type, ControllerInfo>();

            /// <summary>
            ///     The control info
            /// </summary>
            private static readonly Type[] s_constructorTypes = {typeof(Device), typeof(ControlInfo[])};

            // ReSharper disable once MemberHidesStaticFromOuterClass
            /// <summary>
            ///     Registers the type
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="createControllerDelegate">The create controller delegate</param>
            public static void Register(
                Type type,
                CreateControllerDelegate<Controller> createControllerDelegate)
            {
                s_infos[type] = new ControllerInfo(createControllerDelegate);
            }

            /// <summary>
            ///     Gets
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <returns>The controller info</returns>
            public static ControllerInfo Get<T>() where T : Controller => Get(typeof(T));

            /// <summary>
            ///     Gets the type
            /// </summary>
            /// <param name="type">The type</param>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            /// <returns>The controller info</returns>
            public static ControllerInfo Get(Type type)
            {
                if (s_infos.TryGetValue(type, out ControllerInfo controllerInfo))
                {
                    return controllerInfo;
                }

                if (!typeof(Controller).IsAssignableFrom(type))
                {
                    throw new ArgumentOutOfRangeException(nameof(type),
                        string.Format(Resources.ControllerInvalidType, type.Name, nameof(Controller)));
                }

                // Check for a valid constructor on the type
                ConstructorInfo constructor = type.GetConstructor(
                    BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                    null,
                    s_constructorTypes,
                    null);

                if (constructor is null)
                {
                    throw new ArgumentOutOfRangeException(nameof(type),
                        string.Format(Resources.ControllerInvalidConstructor, type));
                }

                IReadOnlyList<DeviceAttribute> deviceAttributes = (IReadOnlyList<DeviceAttribute>) type
                    .GetCustomAttributes(typeof(DeviceAttribute), true)
                    .OfType<DeviceAttribute>()
                    .ToArray();

                // Grab all attributes on control properties
                IReadOnlyDictionary<string, PropertyData> propertyData = (IReadOnlyDictionary<string, PropertyData>) type
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .ToDictionary(property => property.Name, property => new PropertyData(property));

                return s_infos.GetOrAdd(type, new ControllerInfo(constructor, deviceAttributes, propertyData));
            }

            /// <summary>
            ///     Gets the mapping using the specified device
            /// </summary>
            /// <param name="device">The device</param>
            /// <param name="deviceAttributes">The device attributes</param>
            /// <param name="controlPropertyAttributes">The control property attributes</param>
            /// <returns>The control info array</returns>
            private ControlInfo[] GetMapping(
                Device device,
                IReadOnlyList<DeviceAttribute> deviceAttributes,
                IReadOnlyDictionary<string, PropertyData> controlPropertyAttributes)
            {
                // Confirm device matches
                if (!deviceAttributes.Any(da => da.Matches(device)))
                {
                    return null;
                }

                int controlCount = device.Count;
                List<ControlInfo> mapping = new List<ControlInfo>(controlCount);
                Dictionary<Control, uint> controlScores = new Dictionary<Control, uint>(controlCount);
                foreach ((string propertyName, PropertyData attributes) in controlPropertyAttributes)
                {
                    foreach (Control control in device.Keys)
                    {
                        foreach (ControlAttribute controlAttribute in attributes.Controls.Where(controlAttribute =>
                                     controlAttribute.Matches(control)))
                        {
                            if (!controlScores.TryGetValue(control, out uint score))
                            {
                                score = 0;
                            }

                            controlScores[control] = score + controlAttribute.Weight;
                        }
                    }

                    Control bestMatch = controlScores
                        .Where(kvp => kvp.Value > 0)
                        .OrderByDescending(kvp => kvp.Value)
                        .Select(kvp => kvp.Key)
                        .FirstOrDefault();

                    if (bestMatch != null)
                    {
                        mapping.Add(new ControlInfo(attributes.ReturnType, propertyName, bestMatch,
                            attributes.Converter));
                    }
                    else if (attributes.IsRequired)
                    {
                        // Required control missing
                        return null;
                    }

                    controlScores.Clear();
                }

                return mapping.ToArray();
            }

            /// <summary>
            ///     The property data class
            /// </summary>
            private class PropertyData
            {
                /// <summary>
                ///     The controls
                /// </summary>
                public readonly IReadOnlyList<ControlAttribute> Controls;

                /// <summary>
                ///     The converter
                /// </summary>
                public readonly TypeConverter Converter;

                /// <summary>
                ///     The is required
                /// </summary>
                public readonly bool IsRequired;

                /// <summary>
                ///     The return type
                /// </summary>
                public readonly Type ReturnType;

                /// <summary>
                ///     Initializes a new instance of the <see cref="PropertyData" /> class
                /// </summary>
                /// <param name="propertyInfo">The property info</param>
                public PropertyData(PropertyInfo propertyInfo)
                {
                    ReturnType = propertyInfo.PropertyType;

                    Type converterType = propertyInfo.GetCustomAttributes(typeof(TypeConverterAttribute), true)
                        .OfType<TypeConverterAttribute>()
                        .Select(attribute => Type.GetType(attribute.ConverterTypeName))
                        .FirstOrDefault();

                    if (converterType != null)
                    {
                        Converter = s_converterCache.GetOrAdd(converterType, t =>
                        {
                            // Optimisation, look for a static field called 'Instance' that returns an IControlConverter.
                            FieldInfo instanceFieldInfo =
                                t.GetField("Instance", BindingFlags.Public | BindingFlags.Static);
                            TypeConverter typeConverter = null;
                            if ((instanceFieldInfo != null) &&
                                typeof(TypeConverter).IsAssignableFrom(instanceFieldInfo.FieldType))
                            {
                                // Try to get the converter from the static instance
                                typeConverter = instanceFieldInfo.GetValue(null) as TypeConverter;
                            }

                            // Otherwise, try to create a new instance of the type.
                            typeConverter = Activator.CreateInstance(t, true) as TypeConverter;
                            return typeConverter;
                        });

                        if (Converter?.CanConvertFrom(typeof(double)) != true)
                        {
                            Converter = null;
                        }
                    }

                    // If we don't have a converter get the default from type converter.
                    if (Converter is null)
                    {
                        Converter = TypeDescriptor.GetConverter(ReturnType);
                        if (Converter?.CanConvertFrom(typeof(double)) != true)
                        {
                            Converter = null;
                        }
                    }

                    Controls = propertyInfo.GetCustomAttributes(typeof(ControlAttribute), true)
                        .OfType<ControlAttribute>()
                        .Where(a => a.Weight > 0)
                        .ToArray();
                    IsRequired = propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), true)
                        .OfType<RequiredAttribute>()
                        .Any();
                }

                /// <summary>
                ///     The type converter
                /// </summary>
                private static readonly ConcurrentDictionary<Type, TypeConverter> s_converterCache =
                    new ConcurrentDictionary<Type, TypeConverter>();
            }
        }
    }
}