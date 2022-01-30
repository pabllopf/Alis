// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EFXListenerFloat.cs
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

namespace Alis.Core.Audio.Extensions.Creative.EFX.Enums
{
    /// <summary>
    ///     A list of valid <see cref="float" /> Listener/GetListener parameters.
    /// </summary>
    public enum EFXListenerFloat
    {
        /// <summary>
        ///     centimeters 0.01f
        ///     meters 1.0f
        ///     kilometers 1000.0f
        ///     Range [float.MinValue .. float.MaxValue]
        ///     Default: 1.0f.
        ///     This setting is critical if Air Absorption effects are enabled because the amount of Air
        ///     Absorption applied is directly related to the real-world distance between the Source and the Listener.
        /// </summary>
        EfxMetersPerUnit = 0x20004
    }
}