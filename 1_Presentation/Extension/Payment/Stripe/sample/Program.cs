// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Extension.Payment.Stripe.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main
        /// </summary>
        public static async Task Main()
        {
            Logger.Info("Stripe payment sample (offline)");
            Logger.Info("================================");

            Context context = new Context();
            IStripeGatewayClient fakeGateway = new FakeStripeGatewayClient();
            StoreManager storeManager = new StoreManager(context, fakeGateway);

            await storeManager.InitializeAsync(new StoreConfiguration
            {
                SecretApiKey = "",
                DefaultCurrency = "eur",
                SuccessUrl = new Uri("https://game.local/payment/success"),
                CancelUrl = new Uri("https://game.local/payment/cancel"),
                EnableAutomaticPaymentMethods = true
            });

            storeManager.RegisterProducts(new[]
            {
                new StoreProduct
                {
                    Id = "coins_pack_1",
                    Name = "Coins Pack",
                    Description = "1000 virtual coins",
                    PriceInCents = 499
                },
                new StoreProduct
                {
                    Id = "starter_bundle",
                    Name = "Starter Bundle",
                    Description = "Character skin + 500 gems",
                    PriceInCents = 999
                }
            });

            await SampleCheckoutSessionAsync(storeManager);
            await SamplePaymentIntentAsync(storeManager);
            await SampleRefundAsync(storeManager);

            storeManager.Dispose();
            Logger.Info("End Program...");
        }

        /// <summary>
        /// Samples the checkout session using the specified store manager
        /// </summary>
        /// <param name="storeManager">The store manager</param>
        private static async Task SampleCheckoutSessionAsync(StoreManager storeManager)
        {
            Logger.Info("\nSample 1 - Checkout session");

            CheckoutSessionResult session = await storeManager.CreateCheckoutSessionAsync(
                "coins_pack_1",
                quantity: 2,
                customerEmail: "player@example.com",
                metadata: new Dictionary<string, string>
                {
                    { "player_id", "player-42" },
                    { "platform", "pc" }
                });

            Logger.Info($"SessionId: {session.SessionId}");
            Logger.Info($"CheckoutUrl: {session.Url}");
            Logger.Info($"PaymentIntentId: {session.PaymentIntentId}");
        }

        /// <summary>
        /// Samples the payment intent using the specified store manager
        /// </summary>
        /// <param name="storeManager">The store manager</param>
        private static async Task SamplePaymentIntentAsync(StoreManager storeManager)
        {
            Logger.Info("\nSample 2 - Payment intent");

            PaymentIntentResult intent = await storeManager.CreatePaymentIntentAsync(
                "starter_bundle",
                quantity: 1,
                customerId: "cus_local_001",
                metadata: new Dictionary<string, string>
                {
                    { "order_type", "in_game" }
                });

            Logger.Info($"IntentId: {intent.PaymentIntentId}");
            Logger.Info($"ClientSecret: {intent.ClientSecret}");
            Logger.Info($"Status: {intent.Status}");

            PaymentStatus status = await storeManager.GetPaymentStatusAsync(intent.PaymentIntentId);
            Logger.Info($"Status (query): {status}");
        }

        /// <summary>
        /// Samples the refund using the specified store manager
        /// </summary>
        /// <param name="storeManager">The store manager</param>
        private static async Task SampleRefundAsync(StoreManager storeManager)
        {
            Logger.Info("\nSample 3 - Refund");

            RefundResult refund = await storeManager.RefundPaymentAsync(
                "pi_local_123",
                amountToRefundInCents: 499,
                reason: "requested_by_customer");

            Logger.Info($"RefundId: {refund.RefundId}");
            Logger.Info($"AmountRefunded: {refund.AmountRefunded}");
            Logger.Info($"Currency: {refund.Currency}");
            Logger.Info($"Status: {refund.Status}");
        }

        /// <summary>
        ///     Fake Stripe gateway for local/offline samples.
        /// </summary>
        private sealed class FakeStripeGatewayClient : IStripeGatewayClient
        {
            /// <summary>
            /// The configured
            /// </summary>
            private bool _configured;

            /// <summary>
            /// Configures the secret api key
            /// </summary>
            /// <param name="secretApiKey">The secret api key</param>
            public void Configure(string secretApiKey)
            {
                _configured = !string.IsNullOrWhiteSpace(secretApiKey);
            }

            /// <summary>
            /// Creates the checkout session using the specified request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <returns>A task containing the stripe checkout session response</returns>
            public Task<StripeCheckoutSessionResponse> CreateCheckoutSessionAsync(StripeCheckoutSessionRequest request, CancellationToken cancellationToken = default)
            {
                EnsureConfigured();
                cancellationToken.ThrowIfCancellationRequested();

                return Task.FromResult(new StripeCheckoutSessionResponse
                {
                    SessionId = "cs_local_123",
                    Url = new Uri("https://checkout.local/session/cs_local_123"),
                    PaymentIntentId = "pi_local_123"
                });
            }

            /// <summary>
            /// Creates the payment intent using the specified request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <returns>A task containing the stripe payment intent response</returns>
            public Task<StripePaymentIntentResponse> CreatePaymentIntentAsync(StripePaymentIntentRequest request, CancellationToken cancellationToken = default)
            {
                EnsureConfigured();
                cancellationToken.ThrowIfCancellationRequested();

                return Task.FromResult(new StripePaymentIntentResponse
                {
                    PaymentIntentId = "pi_local_456",
                    ClientSecret = "pi_local_456_secret_xxx",
                    Status = "succeeded"
                });
            }

            /// <summary>
            /// Gets the payment intent using the specified payment intent id
            /// </summary>
            /// <param name="paymentIntentId">The payment intent id</param>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <returns>A task containing the stripe payment intent response</returns>
            public Task<StripePaymentIntentResponse> GetPaymentIntentAsync(string paymentIntentId, CancellationToken cancellationToken = default)
            {
                EnsureConfigured();
                cancellationToken.ThrowIfCancellationRequested();

                return Task.FromResult(new StripePaymentIntentResponse
                {
                    PaymentIntentId = paymentIntentId,
                    ClientSecret = "pi_local_456_secret_xxx",
                    Status = "succeeded"
                });
            }

            /// <summary>
            /// Creates the refund using the specified request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <returns>A task containing the stripe refund response</returns>
            public Task<StripeRefundResponse> CreateRefundAsync(StripeRefundRequest request, CancellationToken cancellationToken = default)
            {
                EnsureConfigured();
                cancellationToken.ThrowIfCancellationRequested();

                return Task.FromResult(new StripeRefundResponse
                {
                    RefundId = "re_local_001",
                    AmountRefunded = request.Amount ?? 0,
                    Currency = "eur",
                    Status = "succeeded"
                });
            }

            /// <summary>
            /// Ensures the configured
            /// </summary>
            /// <exception cref="InvalidOperationException">Fake gateway not configured.</exception>
            private void EnsureConfigured()
            {
                if (!_configured)
                {
                    throw new InvalidOperationException("Fake gateway not configured.");
                }
            }
        }
    }
}