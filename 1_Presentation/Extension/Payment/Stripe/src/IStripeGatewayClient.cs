// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IStripeGatewayClient.cs
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

using System.Threading;
using System.Threading.Tasks;

namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    ///     The stripe gateway client interface
    /// </summary>
    public interface IStripeGatewayClient
    {
        /// <summary>
        ///     Configures the secret api key
        /// </summary>
        /// <param name="secretApiKey">The secret api key</param>
        void Configure(string secretApiKey);

        /// <summary>
        ///     Creates the checkout session using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe checkout session response</returns>
        Task<StripeCheckoutSessionResponse> CreateCheckoutSessionAsync(
            StripeCheckoutSessionRequest request,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Creates the payment intent using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe payment intent response</returns>
        Task<StripePaymentIntentResponse> CreatePaymentIntentAsync(
            StripePaymentIntentRequest request,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Gets the payment intent using the specified payment intent id
        /// </summary>
        /// <param name="paymentIntentId">The payment intent id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe payment intent response</returns>
        Task<StripePaymentIntentResponse> GetPaymentIntentAsync(
            string paymentIntentId,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Creates the refund using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe refund response</returns>
        Task<StripeRefundResponse> CreateRefundAsync(
            StripeRefundRequest request,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}