// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CarBuilder.cs
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

using Alis.Core.Aspect.Fluent.Words;

namespace Alis.Core.Aspect.Fluent.Sample
{
    /// <summary>
    ///     The sample builder class
    /// </summary>
    public class CarBuilder :
        IBuild<Car>,
        IWithName<CarBuilder, string>,
        IWithModel<CarBuilder, string>,
        IWithColor<CarBuilder, string>
    {
        /// <summary>
        ///     The car
        /// </summary>
        private readonly Car _car = new Car("default", "default", "default");

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The car</returns>
        public Car Build() => _car;

        /// <summary>
        ///     Adds the color using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The car builder</returns>
        public CarBuilder WithColor(string value)
        {
            _car.Model = value;
            return this;
        }

        /// <summary>
        ///     Adds the model using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The car builder</returns>
        public CarBuilder WithModel(string value)
        {
            _car.Color = value;
            return this;
        }

        /// <summary>
        ///     Adds the name using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The car builder</returns>
        public CarBuilder WithName(string value)
        {
            _car.Name = value;
            return this;
        }
    }
}