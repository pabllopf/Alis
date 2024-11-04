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
    internal class XMLFragmentElement
    {
        /// <summary>
        ///     The xml fragment attribute
        /// </summary>
        private readonly List<XMLFragmentAttribute> _attributes = new List<XMLFragmentAttribute>();
        
        /// <summary>
        ///     The xml fragment element
        /// </summary>
        private readonly List<XMLFragmentElement> _elements = new List<XMLFragmentElement>();
        
        /// <summary>
        ///     Gets the value of the elements
        /// </summary>
        public IList<XMLFragmentElement> Elements => _elements;
        
        /// <summary>
        ///     Gets the value of the attributes
        /// </summary>
        public IList<XMLFragmentAttribute> Attributes => _attributes;
        
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