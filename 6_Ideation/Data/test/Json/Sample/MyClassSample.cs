// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MyClassSample.cs
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

namespace Alis.Core.Aspect.Data.Test.Json.Sample
{
    /// <summary>
    ///     The my class sample class
    /// </summary>
    public class MyClassSample
    {
        /// <summary>
        ///     The my field
        /// </summary>
        public readonly string MyField = "Sample";
        
        /// <summary>
        ///     The my field
        /// </summary>
        public string MyField2 = "Sample";
        
        /// <summary>
        ///     The my field
        /// </summary>
        public int MyField3 = 10;
        
        /// <summary>
        ///     Gets or sets the value of the my property
        /// </summary>
        public string MyProperty { get; set; } = "Sample";
        
        /// <summary>
        ///     Gets or sets the value of the my property 2
        /// </summary>
        public string MyProperty2 { get; set; } = "Sample";
        
        /// <summary>
        ///     Gets or sets the value of the my property 3
        /// </summary>
        public int MyProperty3 { get; set; } = 10;
    }
}