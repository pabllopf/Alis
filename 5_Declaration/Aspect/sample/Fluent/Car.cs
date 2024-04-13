// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Car.cs
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

using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Aspect.Sample.Fluent
{
    /// <summary>
    ///     The car class
    /// </summary>
    /// <seealso cref="IBuilder{CarBuilder}" />
    public class Car : IBuilder<CarBuilder>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Car" /> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="model">The model</param>
        /// <param name="color">The color</param>
        public Car(string name, string model, string color)
        {
            Name = name;
            Model = model;
            Color = color;
        }
        
        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the model
        /// </summary>
        public string Model { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the color
        /// </summary>
        public string Color { get; set; }
        
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The car builder</returns>
        public CarBuilder Builder() => new CarBuilder();
        
        /// <summary>
        ///     Creates
        /// </summary>
        /// <returns>The car builder</returns>
        public static CarBuilder Create() => new CarBuilder();
    }
}