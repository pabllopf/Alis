// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PaymentStatus.cs
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

namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    ///     The payment status enum
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        ///     The unknown payment status
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     The requires payment method payment status
        /// </summary>
        RequiresPaymentMethod = 1,

        /// <summary>
        ///     The requires confirmation payment status
        /// </summary>
        RequiresConfirmation = 2,

        /// <summary>
        ///     The requires action payment status
        /// </summary>
        RequiresAction = 3,

        /// <summary>
        ///     The processing payment status
        /// </summary>
        Processing = 4,

        /// <summary>
        ///     The requires capture payment status
        /// </summary>
        RequiresCapture = 5,

        /// <summary>
        ///     The canceled payment status
        /// </summary>
        Canceled = 6,

        /// <summary>
        ///     The succeeded payment status
        /// </summary>
        Succeeded = 7
    }
}