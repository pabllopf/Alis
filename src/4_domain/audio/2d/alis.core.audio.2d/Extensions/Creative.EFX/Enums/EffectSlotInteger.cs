// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EffectSlotInteger.cs
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
    ///     A list of valid <see cref="int" /> AuxiliaryEffectSlot/GetAuxiliaryEffectSlot parameters.
    /// </summary>
    public enum EffectSlotInteger
    {
        /// <summary>
        ///     This property is used to attach an Effect object to the Auxiliary Effect Slot object. After the attachment,
        ///     the Auxiliary Effect Slot object will contain the effect type and have the same effect parameters that were
        ///     stored in the Effect object. Any Sources feeding the Auxiliary Effect Slot will immediate feed the new
        ///     effect type and new effect parameters.
        /// </summary>
        Effect = 0x0001,

        /// <summary>
        ///     This property is used to enable or disable automatic send adjustments based on the physical positions of the
        ///     sources and the listener. This property should be enabled when an application wishes to use a reverb effect
        ///     to simulate the environment surrounding a listener or a collection of Sources.
        /// </summary>
        AuxiliarySendAuto = 0x0003
    }
}