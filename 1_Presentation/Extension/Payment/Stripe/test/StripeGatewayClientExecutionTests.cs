// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StripeGatewayClientExecutionTests.cs
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
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Stripe;
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Executes the success paths of <see cref="StripeGatewayClient" /> against an in-process
    ///     stub <see cref="IHttpClient" /> so that no network access is performed. This mirrors the
    ///     Stripe SDK's own mock-http test technique.
    /// </summary>
    public class StripeGatewayClientExecutionTests : IDisposable
    {
        /// <summary>
        ///     The original stripe client
        /// </summary>
        private readonly IStripeClient _originalStripeClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StripeGatewayClientExecutionTests"/> class
        /// </summary>
        public StripeGatewayClientExecutionTests()
        {
            _originalStripeClient = StripeConfiguration.StripeClient;
        }

        /// <summary>
        ///     Restores the original stripe client
        /// </summary>
        public void Dispose()
        {
            StripeConfiguration.StripeClient = _originalStripeClient;
        }

        /// <summary>
        ///     Installs a stub stripe client for the given response json
        /// </summary>
        /// <param name="responseJson">The response json</param>
        private static void InstallStubClient(string responseJson)
        {
            StripeClient client = new StripeClient("sk_test_4eC39HqLyjWDarjtT1zdp7dc", null, new StubHttpClient(responseJson), null, null, null, null);
            StripeConfiguration.StripeClient = client;
        }

        /// <summary>
        ///     The stub http client class
        /// </summary>
        /// <seealso cref="IHttpClient"/>
        private sealed class StubHttpClient : IHttpClient
        {
            /// <summary>
            ///     The response json
            /// </summary>
            private readonly string _responseJson;

            /// <summary>
            ///     Initializes a new instance of the <see cref="StubHttpClient"/> class
            /// </summary>
            /// <param name="responseJson">The response json</param>
            public StubHttpClient(string responseJson)
            {
                _responseJson = responseJson;
            }

            /// <summary>
            ///     Makes the request async
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <returns>The stripe response</returns>
            public Task<StripeResponse> MakeRequestAsync(StripeRequest request, CancellationToken cancellationToken)
            {
                StripeResponse response = new StripeResponse(HttpStatusCode.OK, null, _responseJson);
                return Task.FromResult(response);
            }

            /// <summary>
            ///     Makes the streaming request async
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <returns>The stripe response</returns>
            public Task<StripeStreamedResponse> MakeStreamingRequestAsync(StripeRequest request, CancellationToken cancellationToken)
            {
                StripeStreamedResponse response = new StripeStreamedResponse(HttpStatusCode.OK, null, new System.IO.MemoryStream());
                return Task.FromResult(response);
            }
        }

        /// <summary>
        ///     Tests that create checkout session async with valid request returns the session response.
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithValidRequest_ReturnsSessionResponse()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_4eC39HqLyjWDarjtT1zdp7dc");
            InstallStubClient("{ \"id\": \"cs_test_1\", \"url\": \"https://checkout.stripe.com/c/pay/cs_test_1\", \"payment_intent\": \"pi_123\" }");

            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test Product",
                ProductDescription = "Description",
                Currency = "usd",
                UnitAmount = 5000,
                Quantity = 2,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel"),
                CustomerEmail = "buyer@example.com",
                Metadata = new System.Collections.Generic.Dictionary<string, string> { { "order", "42" } }
            };

            StripeCheckoutSessionResponse response = await gateway.CreateCheckoutSessionAsync(request);

            Assert.Equal("cs_test_1", response.SessionId);
            Assert.Equal("https://checkout.stripe.com/c/pay/cs_test_1", response.Url.ToString());
            Assert.Equal("pi_123", response.PaymentIntentId);
        }

        /// <summary>
        ///     Tests that create payment intent async with valid request returns the payment intent response.
        /// </summary>
        [Fact]
        public async Task CreatePaymentIntentAsync_WithValidRequest_ReturnsPaymentIntentResponse()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_4eC39HqLyjWDarjtT1zdp7dc");
            InstallStubClient("{ \"id\": \"pi_456\", \"client_secret\": \"pi_456_secret_xyz\", \"status\": \"requires_payment_method\" }");

            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                Amount = 5000,
                Currency = "usd",
                Description = "Order 42",
                CustomerId = "cus_789",
                EnableAutomaticPaymentMethods = true,
                Metadata = new System.Collections.Generic.Dictionary<string, string> { { "order", "42" } }
            };

            StripePaymentIntentResponse response = await gateway.CreatePaymentIntentAsync(request);

            Assert.Equal("pi_456", response.PaymentIntentId);
            Assert.Equal("pi_456_secret_xyz", response.ClientSecret);
            Assert.Equal("requires_payment_method", response.Status);
        }

        /// <summary>
        ///     Tests that get payment intent async with valid id returns the payment intent response.
        /// </summary>
        [Fact]
        public async Task GetPaymentIntentAsync_WithValidId_ReturnsPaymentIntentResponse()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_4eC39HqLyjWDarjtT1zdp7dc");
            InstallStubClient("{ \"id\": \"pi_456\", \"client_secret\": \"pi_456_secret_xyz\", \"status\": \"succeeded\" }");

            StripePaymentIntentResponse response = await gateway.GetPaymentIntentAsync("pi_456");

            Assert.Equal("pi_456", response.PaymentIntentId);
            Assert.Equal("pi_456_secret_xyz", response.ClientSecret);
            Assert.Equal("succeeded", response.Status);
        }

        /// <summary>
        ///     Tests that create refund async with valid request returns the refund response.
        /// </summary>
        [Fact]
        public async Task CreateRefundAsync_WithValidRequest_ReturnsRefundResponse()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_4eC39HqLyjWDarjtT1zdp7dc");
            InstallStubClient("{ \"id\": \"re_111\", \"amount\": 5000, \"currency\": \"usd\", \"status\": \"succeeded\" }");

            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_456",
                Amount = 5000,
                Reason = "duplicate"
            };

            StripeRefundResponse response = await gateway.CreateRefundAsync(request);

            Assert.Equal("re_111", response.RefundId);
            Assert.Equal(5000, response.AmountRefunded);
            Assert.Equal("usd", response.Currency);
            Assert.Equal("succeeded", response.Status);
        }
    }
}
