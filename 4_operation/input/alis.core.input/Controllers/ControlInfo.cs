// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ControlInfo.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace Alis.Core.Input.Controllers
{
    /// <summary>
    ///     Class ControlInfo is used to indicate the relationship between a <seealso cref="Input.Control" />
    ///     and a
    ///     property on a <seealso cref="Controller" />.  These are normally generated automatically, but can be created
    ///     manually when creating a custom controller.
    /// </summary>
    /// <seealso cref="Controller" />
    /// <seealso cref="Input.Control" />
    public class ControlInfo
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ControlInfo" /> class.
        /// </summary>
        /// <param name="type">The type of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="control">The control.</param>
        /// <param name="converter">The converter.</param>
        public ControlInfo(Type type, string propertyName, Control control, TypeConverter converter)
        {
            Type = type;
            PropertyName = propertyName;
            Control = control;
            Converter = converter;
        }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public Type Type { get; }

        /// <summary>
        ///     Gets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        public string PropertyName { get; }

        /// <summary>
        ///     Gets the control.
        /// </summary>
        /// <value>The control.</value>
        public Control Control { get; }

        /// <summary>
        ///     Gets the converter.
        /// </summary>
        /// <value>The converter.</value>
        public TypeConverter Converter { get; }
    }

    /// <summary>
    ///     Class ControlInfo. This class cannot be inherited.
    ///     Generic version of <seealso cref="ControlInfo" /> for conveniently defining control infos.
    /// </summary>
    /// <typeparam name="T">The property type.</typeparam>
    /// <seealso cref="ControlInfo" />
    public sealed class ControlInfo<T> : ControlInfo
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ControlInfo{T}" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="control">The control.</param>
        /// <param name="converter">The converter.</param>
        public ControlInfo(string propertyName, Control control, TypeConverter converter)
            : base(typeof(T), propertyName, control, converter)
        {
        }
    }
}