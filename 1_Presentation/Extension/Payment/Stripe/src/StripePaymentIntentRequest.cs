// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StripePaymentIntentRequest.cs
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

using System.Collections.Generic;

namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    ///     The stripe payment intent request class
    /// </summary>
    public class StripePaymentIntentRequest
    {
        /// <summary>
        ///     Gets or sets the value of the product id
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Gets or sets the value of the amount
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        ///     Gets or sets the value of the currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        ///     Gets or sets the value of the customer id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        ///     Gets or sets the value of the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the value of the metadata
        /// </summary>
        public IDictionary<string, string> Metadata { get; set; }

        /// <summary>
        ///     Gets or sets the value of the enable automatic payment methods
        /// </summary>
        public bool EnableAutomaticPaymentMethods { get; set; }
    }
}