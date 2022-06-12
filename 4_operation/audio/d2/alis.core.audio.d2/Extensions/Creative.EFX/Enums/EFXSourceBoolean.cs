// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EFXSourceBoolean.cs
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

namespace Alis.Core.Audio.D2.Extensions.Creative.EFX.Enums
{
    /// <summary>
    ///     A list of valid <see cref="bool" /> Source/GetSource parameters.
    /// </summary>
    public enum EFXSourceBoolean
    {
        /// <summary>
        ///     Default: True
        ///     If this Source property is set to True, this Source’s direct-path is automatically filtered
        ///     according to the orientation of the source relative to the listener and the setting of the Source property
        ///     Sourcef.ConeOuterGainHF.
        /// </summary>
        DirectFilterGainHighFrequencyAuto = 0x2000A,

        /// <summary>
        ///     Default: True
        ///     If this Source property is set to True, the intensity of this Source’s reflected sound is
        ///     automatically attenuated according to source-listener distance and source directivity (as determined by the cone
        ///     parameters). If it is False, the reflected sound is not attenuated according to distance and directivity.
        /// </summary>
        AuxiliarySendFilterGainAuto = 0x2000B,

        /// <summary>
        ///     Default: True
        ///     If this Source property is AL_TRUE (its default value), the intensity of this Source’s
        ///     reflected sound at high frequencies will be automatically attenuated according to the high-frequency source
        ///     directivity as set by the Sourcef.ConeOuterGainHF property. If this property is AL_FALSE, the Source’s reflected
        ///     sound is not filtered at all according to the Source’s directivity.
        /// </summary>
        AuxiliarySendFilterGainHighFrequencyAuto = 0x2000C
    }
}