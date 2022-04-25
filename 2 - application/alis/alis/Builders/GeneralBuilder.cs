// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GeneralBuilder.cs
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

using Alis.Core;
using Alis.Core.Configurations;
using Alis.Core.FluentApi;
using Alis.Core.FluentApi.Words;

namespace Alis.Builders
{
    /// <summary>Define a builder.</summary>
    public class GeneralBuilder :
        IBuild<General>,
        IName<GeneralBuilder, string>,
        IAuthor<GeneralBuilder, string>,
        IDescription<GeneralBuilder, string>
    {
        /// <summary>Sets the author.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <br />
        /// </returns>
        public GeneralBuilder Author(string value)
        {
            Game.Setting.General.Author = value;
            return this;
        }

        /// <summary>Builds this instance.</summary>
        /// <returns> </returns>
        public General Build()
        {
            return Game.Setting.General;
        }

        /// <summary>
        ///     Descriptions the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general builder</returns>
        public GeneralBuilder Description(string value)
        {
            Game.Setting.General.Description = value;
            return this;
        }

        /// <summary>Sets the name.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <br />
        /// </returns>
        public GeneralBuilder Name(string value)
        {
            Game.Setting.General.Name = value;
            return this;
        }
    }
}