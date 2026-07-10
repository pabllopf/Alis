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

        [Fact]
        public async Task GetPaymentIntentAsync_WithEmptyId_ThrowsArgumentException()
        {
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_dummy");

            await Assert.ThrowsAsync<ArgumentException>(() => gateway.GetPaymentIntentAsync("  "));
        }

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
    }
}
