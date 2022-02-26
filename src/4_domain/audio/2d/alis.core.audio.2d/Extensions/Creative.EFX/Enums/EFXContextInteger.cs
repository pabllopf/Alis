// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EFXContextInteger.cs
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
    ///     Defines new integer properties on the OpenAL context.
    /// </summary>
    public enum EFXContextInteger
    {
        /// <summary>
        ///     This property can be used by the application to retrieve the Major version number of the
        ///     Effects Extension supported by this OpenAL implementation. As this is a Context property is should be
        ///     retrieved using alcGetIntegerv.
        /// </summary>
        EFXMajorVersion = 0x20001,

        /// <summary>
        ///     This property can be used by the application to retrieve the Minor version number of the
        ///     Effects Extension supported by this OpenAL implementation. As this is a Context property is should be
        ///     retrieved using alcGetIntegerv.
        /// </summary>
        EFXMinorVersion = 0x20002,

        /// <summary>
        ///     Default: 2
        ///     This Context property can be passed to OpenAL during Context creation (alcCreateContext) to
        ///     request a maximum number of Auxiliary Sends desired on each Source. It is not guaranteed that the desired
        ///     number of sends will be available, so an application should query this property after creating the context
        ///     using alcGetIntergerv.
        /// </summary>
        MaxAuxiliarySends = 0x20003
    }
}