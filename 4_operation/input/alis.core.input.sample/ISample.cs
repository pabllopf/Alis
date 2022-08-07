// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ISample.cs
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

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Core.Input.Sample
{
    /// <summary>
    ///     The sample interface
    /// </summary>
    public interface ISample
    {
        /// <summary>
        ///     Gets the value of the full name
        /// </summary>
        string FullName { get; }

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        string Description { get; }

        /// <summary>
        ///     Gets the value of the short names
        /// </summary>
        IReadOnlyCollection<string> ShortNames { get; }

        /// <summary>
        ///     Executes the token
        /// </summary>
        /// <param name="token">The token</param>
        Task ExecuteAsync(CancellationToken token = default);
    }
}