// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StripeGatewayClientRemainingCoverageTests.cs
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
using System.Threading.Tasks;
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Remaining coverage tests for StripeGatewayClient
    /// </summary>
    public class StripeGatewayClientRemainingCoverageTests
    {
        /// <summary>
        /// Tests that create refund async with duplicate reason should pass validation
        /// </summary>
        [Fact]
        public async Task CreateRefundAsync_WithDuplicateReason_ShouldPassValidation()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_valid",
                Reason = "duplicate"
            };

            var exception = await Record.ExceptionAsync(() => gateway.CreateRefundAsync(request));
            Assert.NotNull(exception);
            Assert.IsNotType<ArgumentException>(exception);
            Assert.IsNotType<ArgumentNullException>(exception);
            Assert.IsNotType<ArgumentOutOfRangeException>(exception);
        }

        /// <summary>
        /// Tests that create refund async with fraudulent reason should pass validation
        /// </summary>
        [Fact]
        public async Task CreateRefundAsync_WithFraudulentReason_ShouldPassValidation()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_valid",
                Reason = "fraudulent"
            };

            var exception = await Record.ExceptionAsync(() => gateway.CreateRefundAsync(request));
            Assert.NotNull(exception);
            Assert.IsNotType<ArgumentException>(exception);
            Assert.IsNotType<ArgumentNullException>(exception);
            Assert.IsNotType<ArgumentOutOfRangeException>(exception);
        }

        /// <summary>
        /// Tests that create refund async with requested by customer reason should pass validation
        /// </summary>
        [Fact]
        public async Task CreateRefundAsync_WithRequestedByCustomerReason_ShouldPassValidation()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_valid",
                Reason = "requested_by_customer"
            };

            var exception = await Record.ExceptionAsync(() => gateway.CreateRefundAsync(request));
            Assert.NotNull(exception);
            Assert.IsNotType<ArgumentException>(exception);
            Assert.IsNotType<ArgumentNullException>(exception);
            Assert.IsNotType<ArgumentOutOfRangeException>(exception);
        }

        /// <summary>
        /// Tests that create refund async with null reason should pass validation
        /// </summary>
        [Fact]
        public async Task CreateRefundAsync_WithNullReason_ShouldPassValidation()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_valid",
                Reason = null
            };

            var exception = await Record.ExceptionAsync(() => gateway.CreateRefundAsync(request));
            Assert.NotNull(exception);
            Assert.IsNotType<ArgumentException>(exception);
            Assert.IsNotType<ArgumentNullException>(exception);
            Assert.IsNotType<ArgumentOutOfRangeException>(exception);
        }

        /// <summary>
        /// Tests that create refund async with unknown reason should pass validation
        /// </summary>
        [Fact]
        public async Task CreateRefundAsync_WithUnknownReason_ShouldPassValidation()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_valid",
                Reason = "unknown_reason"
            };

            var exception = await Record.ExceptionAsync(() => gateway.CreateRefundAsync(request));
            Assert.NotNull(exception);
            Assert.IsNotType<ArgumentException>(exception);
            Assert.IsNotType<ArgumentNullException>(exception);
            Assert.IsNotType<ArgumentOutOfRangeException>(exception);
        }

        /// <summary>
        /// Tests that create refund async with amount specified should pass validation
        /// </summary>
        [Fact]
        public async Task CreateRefundAsync_WithAmountSpecified_ShouldPassValidation()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_valid",
                Amount = 500
            };

            var exception = await Record.ExceptionAsync(() => gateway.CreateRefundAsync(request));
            Assert.NotNull(exception);
            Assert.IsNotType<ArgumentException>(exception);
            Assert.IsNotType<ArgumentNullException>(exception);
            Assert.IsNotType<ArgumentOutOfRangeException>(exception);
        }

        /// <summary>
        /// Tests that create refund async with empty payment intent id throws argument exception
        /// </summary>
        [Fact]
        public async Task CreateRefundAsync_WithEmptyPaymentIntentId_ThrowsArgumentException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "  "
            };

            await Assert.ThrowsAsync<ArgumentException>(() => gateway.CreateRefundAsync(request));
        }

        /// <summary>
        /// Tests that create checkout session async with null success url throws argument exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithNullSuccessUrl_ThrowsArgumentException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 999,
                Quantity = 1,
                SuccessUrl = null,
                CancelUrl = new Uri("https://example.com/cancel")
            };

            await Assert.ThrowsAsync<ArgumentException>(() => gateway.CreateCheckoutSessionAsync(request));
        }

        /// <summary>
        /// Tests that create checkout session async with null cancel url throws argument exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithNullCancelUrl_ThrowsArgumentException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 999,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = null
            };

            await Assert.ThrowsAsync<ArgumentException>(() => gateway.CreateCheckoutSessionAsync(request));
        }

        /// <summary>
        /// Tests that create payment intent async with customer id should pass validation
        /// </summary>
        [Fact]
        public async Task CreatePaymentIntentAsync_WithCustomerId_ShouldPassValidation()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                Amount = 1000,
                Currency = "usd",
                CustomerId = "cus_test123"
            };

            var exception = await Record.ExceptionAsync(() => gateway.CreatePaymentIntentAsync(request));
            Assert.NotNull(exception);
            Assert.IsNotType<ArgumentException>(exception);
            Assert.IsNotType<ArgumentNullException>(exception);
            Assert.IsNotType<ArgumentOutOfRangeException>(exception);
        }

        /// <summary>
        /// Tests that get payment intent async with empty id throws argument exception
        /// </summary>
        [Fact]
        public async Task GetPaymentIntentAsync_WithEmptyId_ThrowsArgumentException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");

            await Assert.ThrowsAsync<ArgumentException>(() => gateway.GetPaymentIntentAsync("  "));
        }

        /// <summary>
        /// Tests that create payment intent async with negative amount throws argument out of range exception
        /// </summary>
        [Fact]
        public async Task CreatePaymentIntentAsync_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                Amount = -1,
                Currency = "usd"
            };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => gateway.CreatePaymentIntentAsync(request));
        }

        /// <summary>
        /// Tests that create checkout session async with null currency throws argument exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithNullCurrency_ThrowsArgumentException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = null,
                UnitAmount = 999,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            await Assert.ThrowsAsync<ArgumentException>(() => gateway.CreateCheckoutSessionAsync(request));
        }

        /// <summary>
        /// Tests that configure with empty key throws argument exception
        /// </summary>
        [Fact]
        public void Configure_WithEmptyKey_ThrowsArgumentException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();

            Assert.Throws<ArgumentException>(() => gateway.Configure("  "));
        }

        /// <summary>
        /// Tests that configure with null key throws argument exception
        /// </summary>
        [Fact]
        public void Configure_WithNullKey_ThrowsArgumentException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();

            Assert.Throws<ArgumentException>(() => gateway.Configure(null));
        }

        /// <summary>
        /// Tests that ensure configured when not configured throws invalid operation exception
        /// </summary>
        [Fact]
        public void EnsureConfigured_WhenNotConfigured_ThrowsInvalidOperationException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();

            Assert.Throws<InvalidOperationException>(() => gateway.EnsureConfigured());
        }

        /// <summary>
        /// Tests that create checkout session async with null request throws argument null exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithNullRequest_ThrowsArgumentNullException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");

            await Assert.ThrowsAsync<ArgumentNullException>(() => gateway.CreateCheckoutSessionAsync(null));
        }

        /// <summary>
        /// Tests that create checkout session async with null product name throws argument exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithNullProductName_ThrowsArgumentException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = null,
                Currency = "usd",
                UnitAmount = 999,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            await Assert.ThrowsAsync<ArgumentException>(() => gateway.CreateCheckoutSessionAsync(request));
        }

        /// <summary>
        /// Tests that create checkout session async with unit amount zero throws argument out of range exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithUnitAmountZero_ThrowsArgumentOutOfRangeException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 0,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => gateway.CreateCheckoutSessionAsync(request));
        }

        /// <summary>
        /// Tests that create checkout session async with unit amount negative throws argument out of range exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithUnitAmountNegative_ThrowsArgumentOutOfRangeException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = -1,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => gateway.CreateCheckoutSessionAsync(request));
        }

        /// <summary>
        /// Tests that create checkout session async with quantity zero throws argument out of range exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithQuantityZero_ThrowsArgumentOutOfRangeException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 999,
                Quantity = 0,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => gateway.CreateCheckoutSessionAsync(request));
        }

        /// <summary>
        /// Tests that create checkout session async with quantity negative throws argument out of range exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithQuantityNegative_ThrowsArgumentOutOfRangeException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 999,
                Quantity = -1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => gateway.CreateCheckoutSessionAsync(request));
        }

        /// <summary>
        /// Tests that create payment intent async with null request throws argument null exception
        /// </summary>
        [Fact]
        public async Task CreatePaymentIntentAsync_WithNullRequest_ThrowsArgumentNullException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");

            await Assert.ThrowsAsync<ArgumentNullException>(() => gateway.CreatePaymentIntentAsync(null));
        }

        /// <summary>
        /// Tests that create payment intent async with null currency throws argument exception
        /// </summary>
        [Fact]
        public async Task CreatePaymentIntentAsync_WithNullCurrency_ThrowsArgumentException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");
            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                Amount = 1000,
                Currency = null
            };

            await Assert.ThrowsAsync<ArgumentException>(() => gateway.CreatePaymentIntentAsync(request));
        }

        /// <summary>
        /// Tests that get payment intent async with null id throws argument exception
        /// </summary>
        [Fact]
        public async Task GetPaymentIntentAsync_WithNullId_ThrowsArgumentException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");

            await Assert.ThrowsAsync<ArgumentException>(() => gateway.GetPaymentIntentAsync(null));
        }

        /// <summary>
        /// Tests that create refund async with null request throws argument null exception
        /// </summary>
        [Fact]
        public async Task CreateRefundAsync_WithNullRequest_ThrowsArgumentNullException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");

            await Assert.ThrowsAsync<ArgumentNullException>(() => gateway.CreateRefundAsync(null));
        }
    }
}
