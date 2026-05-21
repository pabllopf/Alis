// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IStoreManager.cs
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
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    ///     Public contract for in-game store payments
    /// </summary>
    public interface IStoreManager
    {
        /// <summary>
        ///     Gets the value of the is initialized
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        ///     Initializes the configuration
        /// </summary>
        /// <param name="configuration">The configuration</param>
        /// <param name="cancellationToken">The cancellation token</param>
        Task InitializeAsync(StoreConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Registers the product using the specified product
        /// </summary>
        /// <param name="product">The product</param>
        void RegisterProduct(StoreProduct product);

        /// <summary>
        ///     Registers the products using the specified products
        /// </summary>
        /// <param name="products">The products</param>
        void RegisterProducts(IEnumerable<StoreProduct> products);

        /// <summary>
        ///     Tries the get product using the specified product id
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="product">The product</param>
        /// <returns>The bool</returns>
        bool TryGetProduct(string productId, out StoreProduct product);

        /// <summary>
        ///     Gets the products
        /// </summary>
        /// <returns>A read only collection of store product</returns>
        IReadOnlyCollection<StoreProduct> GetProducts();

        /// <summary>
        ///     Creates the checkout session using the specified product id
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="quantity">The quantity</param>
        /// <param name="customerEmail">The customer email</param>
        /// <param name="metadata">The metadata</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the checkout session result</returns>
        Task<CheckoutSessionResult> CreateCheckoutSessionAsync(
            string productId,
            int quantity = 1,
            string customerEmail = null,
            IDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Creates the payment intent using the specified product id
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="quantity">The quantity</param>
        /// <param name="customerId">The customer id</param>
        /// <param name="metadata">The metadata</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the payment intent result</returns>
        Task<PaymentIntentResult> CreatePaymentIntentAsync(
            string productId,
            int quantity = 1,
            string customerId = null,
            IDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Gets the payment status using the specified payment intent id
        /// </summary>
        /// <param name="paymentIntentId">The payment intent id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the payment status</returns>
        Task<PaymentStatus> GetPaymentStatusAsync(string paymentIntentId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Refunds the payment using the specified payment intent id
        /// </summary>
        /// <param name="paymentIntentId">The payment intent id</param>
        /// <param name="amountToRefundInCents">The amount to refund in cents</param>
        /// <param name="reason">The reason</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the refund result</returns>
        Task<RefundResult> RefundPaymentAsync(
            string paymentIntentId,
            long? amountToRefundInCents = null,
            string reason = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}