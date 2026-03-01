// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StripeGatewayClientTest.cs
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
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Tests for StripeGatewayClient (Stripe SDK wrapper)
    /// </summary>
    public class StripeGatewayClientTest
    {
        [Fact]
        public void Configure_WithValidApiKey_SetsConfiguration()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();

            // Act
            gateway.Configure("sk_test_4eC39HqLyjWDarjtT1zdp7dc");

            // Assert - No exception thrown
            Assert.True(true);
        }

        [Fact]
        public void Configure_WithNullApiKey_ThrowsArgumentException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => gateway.Configure(null));
        }

        [Fact]
        public void Configure_WithEmptyApiKey_ThrowsArgumentException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => gateway.Configure("  "));
        }

        [Fact]
        public async Task CreateCheckoutSessionAsync_WithoutConfiguration_ThrowsInvalidOperationException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test Product",
                Currency = "usd",
                UnitAmount = 999,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                gateway.CreateCheckoutSessionAsync(request));
        }

        [Fact]
        public async Task CreateCheckoutSessionAsync_WithNullRequest_ThrowsArgumentNullException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_valid_key");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                gateway.CreateCheckoutSessionAsync(null));
        }

        [Fact]
        public async Task CreateCheckoutSessionAsync_WithNullProductName_ThrowsArgumentException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_valid_key");
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = null,
                Currency = "usd",
                UnitAmount = 999,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                gateway.CreateCheckoutSessionAsync(request));
        }

        [Fact]
        public async Task CreateCheckoutSessionAsync_WithZeroUnitAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_valid_key");
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 0,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                gateway.CreateCheckoutSessionAsync(request));
        }

        [Fact]
        public async Task CreateCheckoutSessionAsync_WithZeroQuantity_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_valid_key");
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 999,
                Quantity = 0,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                gateway.CreateCheckoutSessionAsync(request));
        }

        [Fact]
        public async Task CreatePaymentIntentAsync_WithoutConfiguration_ThrowsInvalidOperationException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                Amount = 1000,
                Currency = "usd"
            };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                gateway.CreatePaymentIntentAsync(request));
        }

        [Fact]
        public async Task CreatePaymentIntentAsync_WithNullRequest_ThrowsArgumentNullException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_valid_key");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                gateway.CreatePaymentIntentAsync(null));
        }

        [Fact]
        public async Task CreatePaymentIntentAsync_WithZeroAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_valid_key");
            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                Amount = 0,
                Currency = "usd"
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                gateway.CreatePaymentIntentAsync(request));
        }

        [Fact]
        public async Task GetPaymentIntentAsync_WithoutConfiguration_ThrowsInvalidOperationException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                gateway.GetPaymentIntentAsync("pi_test_123"));
        }

        [Fact]
        public async Task GetPaymentIntentAsync_WithNullId_ThrowsArgumentException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_valid_key");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                gateway.GetPaymentIntentAsync(null));
        }

        [Fact]
        public async Task CreateRefundAsync_WithoutConfiguration_ThrowsInvalidOperationException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_test_123"
            };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                gateway.CreateRefundAsync(request));
        }

        [Fact]
        public async Task CreateRefundAsync_WithNullRequest_ThrowsArgumentNullException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_valid_key");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                gateway.CreateRefundAsync(null));
        }

        [Fact]
        public async Task CreateRefundAsync_WithNullPaymentIntentId_ThrowsArgumentException()
        {
            // Arrange
            StripeGatewayClient gateway = new StripeGatewayClient();
            gateway.Configure("sk_test_valid_key");
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = null
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                gateway.CreateRefundAsync(request));
        }
    }
}

