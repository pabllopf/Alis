// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:XMLFragmentElement.cs
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

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     The xml fragment element class
    /// </summary>
    internal class XmlFragmentElement
    {
        /// <summary>
        ///     The xml fragment attribute
        /// </summary>
        private readonly List<XmlFragmentAttribute> _attributes = new List<XmlFragmentAttribute>();

        /// <summary>
        ///     The xml fragment element
        /// </summary>
        private readonly List<XmlFragmentElement> _elements = new List<XmlFragmentElement>();

        /// <summary>
        ///     Gets the value of the elements
        /// </summary>
        public IList<XmlFragmentElement> Elements => _elements;

        /// <summary>
        ///     Gets the value of the attributes
        /// </summary>
        public IList<XmlFragmentAttribute> Attributes => _attributes;

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     Gets or sets the value of the outer xml
        /// </summary>
        public string OuterXml { get; set; }

        /// <summary>
        ///     Gets or sets the value of the inner xml
        /// </summary>
        public string InnerXml { get; set; }
    }
}