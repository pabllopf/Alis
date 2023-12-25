// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: PolyClipError.cs
// 
//  Author: Pablo Perdomo Falcón
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

namespace Alis.Core.Physic.Tools.Cutting.Simple
{
    /// <summary>
    ///     The poly clip error enum
    /// </summary>
    public enum PolyClipError
    {
        /// <summary>
        ///     The none poly clip error
        /// </summary>
        None,

        /// <summary>
        ///     The degenerated output poly clip error
        /// </summary>
        DegeneratedOutput,

        /// <summary>
        ///     The non simple input poly clip error
        /// </summary>
        NonSimpleInput,

        /// <summary>
        ///     The broken result poly clip error
        /// </summary>
        BrokenResult
    }
}