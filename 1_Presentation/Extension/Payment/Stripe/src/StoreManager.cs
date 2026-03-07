// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StoreManager.cs
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    ///     The store manager class
    /// </summary>
    public class StoreManager : AManager, IStoreManager, IDisposable
    {
        /// <summary>
        ///     The products
        /// </summary>
        private readonly Dictionary<string, StoreProduct> _products;

        /// <summary>
        ///     The stripe gateway client
        /// </summary>
        private readonly IStripeGatewayClient _stripeGatewayClient;

        /// <summary>
        ///     The configuration
        /// </summary>
        private StoreConfiguration _configuration;

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StoreManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public StoreManager(Context context) : this(context, new StripeGatewayClient())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StoreManager" /> class with a custom Stripe gateway client
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="stripeGatewayClient">Gateway abstraction for Stripe calls</param>
        public StoreManager(Context context, IStripeGatewayClient stripeGatewayClient) : base(context)
        {
            _stripeGatewayClient = stripeGatewayClient ?? throw new ArgumentNullException(nameof(stripeGatewayClient));
            _products = new Dictionary<string, StoreProduct>(StringComparer.OrdinalIgnoreCase);
            Name = "StoreManager";
            Tag = "Payment";
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StoreManager" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="tag">The tag</param>
        /// <param name="isEnable">The is enable</param>
        /// <param name="context">The context</param>
        [ExcludeFromCodeCoverage]
        public StoreManager(string id, string name, string tag, bool isEnable, Context context) : this(id, name, tag, isEnable, context, new StripeGatewayClient())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StoreManager" /> class with a custom Stripe gateway client
        /// </summary>
        public StoreManager(string id, string name, string tag, bool isEnable, Context context, IStripeGatewayClient stripeGatewayClient) : base(id, name, tag, isEnable, context)
        {
            _stripeGatewayClient = stripeGatewayClient ?? throw new ArgumentNullException(nameof(stripeGatewayClient));
            _products = new Dictionary<string, StoreProduct>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void Dispose()
        {
            OnDestroy();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Gets a value indicating whether the manager is initialized with Stripe configuration
        /// </summary>
        public bool IsInitialized => _configuration != null;

        /// <summary>
        ///     Initializes the store manager and configures Stripe client
        /// </summary>
        public Task InitializeAsync(StoreConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (string.IsNullOrWhiteSpace(configuration.SecretApiKey))
            {
                throw new ArgumentException("SecretApiKey cannot be null or empty.", nameof(configuration));
            }

            configuration.DefaultCurrency = NormalizeCurrency(configuration.DefaultCurrency);
            _stripeGatewayClient.Configure(configuration.SecretApiKey);
            _configuration = configuration;

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Registers a product that can be purchased
        /// </summary>
        public void RegisterProduct(StoreProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (string.IsNullOrWhiteSpace(product.Id))
            {
                throw new ArgumentException("Product id cannot be null or empty.", nameof(product));
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Product name cannot be null or empty.", nameof(product));
            }

            if (product.PriceInCents <= 0)
            {
                throw new ArgumentException("Product price must be greater than zero.", nameof(product));
            }

            product.Currency = NormalizeCurrency(string.IsNullOrWhiteSpace(product.Currency)
                ? _configuration != null ? _configuration.DefaultCurrency : "usd"
                : product.Currency);

            _products[product.Id] = product;
        }

        /// <summary>
        ///     Registers multiple products
        /// </summary>
        public void RegisterProducts(IEnumerable<StoreProduct> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            foreach (StoreProduct product in products)
            {
                RegisterProduct(product);
            }
        }

        /// <summary>
        ///     Tries to get a registered product by id
        /// </summary>
        public bool TryGetProduct(string productId, out StoreProduct product)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                product = null;
                return false;
            }

            return _products.TryGetValue(productId, out product);
        }

        /// <summary>
        ///     Gets all registered products
        /// </summary>
        public IReadOnlyCollection<StoreProduct> GetProducts() => new ReadOnlyCollection<StoreProduct>(new List<StoreProduct>(_products.Values));

        /// <summary>
        ///     Creates a hosted Stripe checkout session for a product
        /// </summary>
        public async Task<CheckoutSessionResult> CreateCheckoutSessionAsync(
            string productId,
            int quantity = 1,
            string customerEmail = null,
            IDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureInitialized();
            cancellationToken.ThrowIfCancellationRequested();

            StoreProduct product = GetRequiredActiveProduct(productId);

            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
            }

            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductDescription = product.Description,
                Currency = product.Currency,
                UnitAmount = product.PriceInCents,
                Quantity = quantity,
                SuccessUrl = _configuration.SuccessUrl,
                CancelUrl = _configuration.CancelUrl,
                CustomerEmail = customerEmail,
                Metadata = metadata
            };

            StripeCheckoutSessionResponse response = await _stripeGatewayClient.CreateCheckoutSessionAsync(request, cancellationToken).ConfigureAwait(false);

            return new CheckoutSessionResult
            {
                SessionId = response.SessionId,
                Url = response.Url,
                PaymentIntentId = response.PaymentIntentId,
                ProductId = product.Id,
                Quantity = quantity,
                UnitAmount = product.PriceInCents,
                Currency = product.Currency
            };
        }

        /// <summary>
        ///     Creates a Stripe payment intent for a product
        /// </summary>
        public async Task<PaymentIntentResult> CreatePaymentIntentAsync(
            string productId,
            int quantity = 1,
            string customerId = null,
            IDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureInitialized();
            cancellationToken.ThrowIfCancellationRequested();

            StoreProduct product = GetRequiredActiveProduct(productId);

            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
            }

            long totalAmount = product.PriceInCents * quantity;

            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                ProductId = product.Id,
                Amount = totalAmount,
                Currency = product.Currency,
                CustomerId = customerId,
                Description = string.Concat("Purchase of ", product.Name),
                Metadata = metadata,
                EnableAutomaticPaymentMethods = _configuration.EnableAutomaticPaymentMethods
            };

            StripePaymentIntentResponse response = await _stripeGatewayClient.CreatePaymentIntentAsync(request, cancellationToken).ConfigureAwait(false);

            return new PaymentIntentResult
            {
                PaymentIntentId = response.PaymentIntentId,
                ClientSecret = response.ClientSecret,
                ProductId = product.Id,
                Amount = totalAmount,
                Currency = product.Currency,
                Status = MapPaymentStatus(response.Status)
            };
        }

        /// <summary>
        ///     Gets the current status for a payment intent
        /// </summary>
        public async Task<PaymentStatus> GetPaymentStatusAsync(string paymentIntentId, CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureInitialized();
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(paymentIntentId))
            {
                throw new ArgumentException("Payment intent id cannot be null or empty.", nameof(paymentIntentId));
            }

            StripePaymentIntentResponse response = await _stripeGatewayClient.GetPaymentIntentAsync(paymentIntentId, cancellationToken).ConfigureAwait(false);
            return MapPaymentStatus(response.Status);
        }

        /// <summary>
        ///     Creates a refund for a payment intent
        /// </summary>
        public async Task<RefundResult> RefundPaymentAsync(
            string paymentIntentId,
            long? amountToRefundInCents = null,
            string reason = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureInitialized();
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(paymentIntentId))
            {
                throw new ArgumentException("Payment intent id cannot be null or empty.", nameof(paymentIntentId));
            }

            if (amountToRefundInCents.HasValue && (amountToRefundInCents.Value <= 0))
            {
                throw new ArgumentOutOfRangeException(nameof(amountToRefundInCents), "Refund amount must be greater than zero.");
            }

            StripeRefundResponse response = await _stripeGatewayClient.CreateRefundAsync(new StripeRefundRequest
            {
                PaymentIntentId = paymentIntentId,
                Amount = amountToRefundInCents,
                Reason = reason
            }, cancellationToken).ConfigureAwait(false);

            return new RefundResult
            {
                RefundId = response.RefundId,
                PaymentIntentId = paymentIntentId,
                AmountRefunded = response.AmountRefunded,
                Currency = response.Currency,
                Status = response.Status
            };
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        [ExcludeFromCodeCoverage]
        public override void OnDestroy()
        {
            if (_disposed)
            {
                base.OnDestroy();
                return;
            }

            _products.Clear();
            _configuration = null;
            _disposed = true;
            base.OnDestroy();
        }

        /// <summary>
        ///     Normalizes the currency using the specified currency
        /// </summary>
        /// <param name="currency">The currency</param>
        /// <returns>The string</returns>
        [ExcludeFromCodeCoverage]
        private static string NormalizeCurrency(string currency)
        {
            if (string.IsNullOrWhiteSpace(currency))
            {
                return "usd";
            }

            return currency.Trim().ToLowerInvariant();
        }

        /// <summary>
        ///     Maps the payment status using the specified status
        /// </summary>
        /// <param name="status">The status</param>
        /// <returns>The payment status</returns>
        private static PaymentStatus MapPaymentStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return PaymentStatus.Unknown;
            }

            switch (status.Trim().ToLowerInvariant())
            {
                case "requires_payment_method":
                    return PaymentStatus.RequiresPaymentMethod;
                case "requires_confirmation":
                    return PaymentStatus.RequiresConfirmation;
                case "requires_action":
                    return PaymentStatus.RequiresAction;
                case "processing":
                    return PaymentStatus.Processing;
                case "requires_capture":
                    return PaymentStatus.RequiresCapture;
                case "canceled":
                    return PaymentStatus.Canceled;
                case "succeeded":
                    return PaymentStatus.Succeeded;
                default:
                    return PaymentStatus.Unknown;
            }
        }

        /// <summary>
        ///     Gets the required active product using the specified product id
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ArgumentException">Product id cannot be null or empty. </exception>
        /// <returns>The product</returns>
        [ExcludeFromCodeCoverage]
        private StoreProduct GetRequiredActiveProduct(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException("Product id cannot be null or empty.", nameof(productId));
            }

            if (!_products.TryGetValue(productId, out StoreProduct product))
            {
                throw new KeyNotFoundException(string.Concat("Product not registered: ", productId));
            }

            if (!product.IsEnabled)
            {
                throw new InvalidOperationException(string.Concat("Product is disabled: ", productId));
            }

            return product;
        }

        /// <summary>
        ///     Ensures the initialized
        /// </summary>
        /// <exception cref="InvalidOperationException">StoreManager is not initialized. Call InitializeAsync first.</exception>
        private void EnsureInitialized()
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("StoreManager is not initialized. Call InitializeAsync first.");
            }
        }
    }
}