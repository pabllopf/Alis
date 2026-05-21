// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CheckoutSessionResult.cs
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

using System;

namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    ///     The checkout session result class
    /// </summary>
    public class CheckoutSessionResult
    {
        /// <summary>
        ///     Gets or sets the value of the session id
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        ///     Gets or sets the value of the url
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        ///     Gets or sets the value of the payment intent id
        /// </summary>
        public string PaymentIntentId { get; set; }

        /// <summary>
        ///     Gets or sets the value of the product id
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Gets or sets the value of the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the value of the unit amount
        /// </summary>
        public long UnitAmount { get; set; }

        /// <summary>
        ///     Gets or sets the value of the currency
        /// </summary>
        public string Currency { get; set; }
    }
}