// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StoreManagerRemainingCoverageTests.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    /// The store manager remaining coverage tests class
    /// </summary>
    public class StoreManagerRemainingCoverageTests
    {
        /// <summary>
        /// Creates the context
        /// </summary>
        /// <returns>The context</returns>
        private static Context CreateContext() => new Context();

        /// <summary>
        /// Creates the valid configuration
        /// </summary>
        /// <returns>The store configuration</returns>
        private static StoreConfiguration CreateValidConfiguration() => new StoreConfiguration
        {
            SecretApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc",
            DefaultCurrency = "USD",
            SuccessUrl = new Uri("https://example.com/success"),
            CancelUrl = new Uri("https://example.com/cancel"),
            EnableAutomaticPaymentMethods = true
        };

        /// <summary>
        /// Creates the product using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="priceInCents">The price in cents</param>
        /// <returns>The store product</returns>
        private static StoreProduct CreateProduct(string id = "test_product", long priceInCents = 999) => new StoreProduct
        {
            Id = id,
            Name = "Test Product",
            Description = "A test product description",
            PriceInCents = priceInCents,
            Currency = "usd",
            IsEnabled = true
        };

        /// <summary>
        /// Tests that constructor with id name tag is enable context creates instance successfully
        /// </summary>
        [Fact]
        public void Constructor_WithIdNameTagIsEnableContext_CreatesInstanceSuccessfully()
        {
            StoreManager manager = new StoreManager("custom_id", "CustomStore", "Store", true, CreateContext());

            Assert.NotNull(manager);
            Assert.Equal("custom_id", manager.Id);
            Assert.Equal("CustomStore", manager.Name);
            Assert.Equal("Store", manager.Tag);
            Assert.True(manager.IsEnable);
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        /// Tests that dispose called disposes successfully
        /// </summary>
        [Fact]
        public void Dispose_Called_DisposesSuccessfully()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            manager.Dispose();
        }

        /// <summary>
        /// Tests that dispose called multiple times does not throw
        /// </summary>
        [Fact]
        public void Dispose_CalledMultipleTimes_DoesNotThrow()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            manager.Dispose();
            manager.Dispose();
        }

        /// <summary>
        /// Tests that on destroy when not disposed clears products and configuration
        /// </summary>
        [Fact]
        public void OnDestroy_WhenNotDisposed_ClearsProductsAndConfiguration()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            manager.RegisterProduct(CreateProduct("prod1"));

            manager.OnDestroy();

            Assert.False(manager.TryGetProduct("prod1", out _));
        }

        /// <summary>
        /// Tests that on destroy called twice second call succeeds
        /// </summary>
        [Fact]
        public void OnDestroy_CalledTwice_SecondCallSucceeds()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            manager.OnDestroy();
            manager.OnDestroy();
        }

        /// <summary>
        /// Tests that create checkout session async with zero quantity throws argument out of range exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithZeroQuantity_ThrowsArgumentOutOfRangeException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreateCheckoutSessionAsync(It.IsAny<StripeCheckoutSessionRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripeCheckoutSessionResponse
                {
                    SessionId = "cs_test_123",
                    Url = new Uri("https://checkout.stripe.com/c/pay/cs_test_123"),
                    PaymentIntentId = "pi_test_456"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product1"));

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                manager.CreateCheckoutSessionAsync("product1", 0));
        }

        /// <summary>
        /// Tests that create checkout session async with negative quantity throws argument out of range exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithNegativeQuantity_ThrowsArgumentOutOfRangeException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreateCheckoutSessionAsync(It.IsAny<StripeCheckoutSessionRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripeCheckoutSessionResponse
                {
                    SessionId = "cs_test_123",
                    Url = new Uri("https://checkout.stripe.com/c/pay/cs_test_123"),
                    PaymentIntentId = "pi_test_456"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product1"));

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                manager.CreateCheckoutSessionAsync("product1", -1));
        }

        /// <summary>
        /// Tests that create checkout session async with cancelled token throws operation canceled exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithCancelledToken_ThrowsOperationCanceledException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreateCheckoutSessionAsync(It.IsAny<StripeCheckoutSessionRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripeCheckoutSessionResponse
                {
                    SessionId = "cs_test_123",
                    Url = new Uri("https://checkout.stripe.com/c/pay/cs_test_123"),
                    PaymentIntentId = "pi_test_456"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product1"));

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            await Assert.ThrowsAsync<OperationCanceledException>(() =>
                manager.CreateCheckoutSessionAsync("product1", cancellationToken: cts.Token));
        }

        /// <summary>
        /// Tests that create payment intent async with cancelled token throws operation canceled exception
        /// </summary>
        [Fact]
        public async Task CreatePaymentIntentAsync_WithCancelledToken_ThrowsOperationCanceledException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreatePaymentIntentAsync(It.IsAny<StripePaymentIntentRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripePaymentIntentResponse
                {
                    PaymentIntentId = "pi_test_789",
                    ClientSecret = "secret",
                    Status = "requires_payment_method"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product1"));

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            await Assert.ThrowsAsync<OperationCanceledException>(() =>
                manager.CreatePaymentIntentAsync("product1", cancellationToken: cts.Token));
        }

        /// <summary>
        /// Tests that get payment status async with cancelled token throws operation canceled exception
        /// </summary>
        [Fact]
        public async Task GetPaymentStatusAsync_WithCancelledToken_ThrowsOperationCanceledException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.GetPaymentIntentAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripePaymentIntentResponse
                {
                    PaymentIntentId = "pi_test",
                    ClientSecret = "secret",
                    Status = "processing"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            await Assert.ThrowsAsync<OperationCanceledException>(() =>
                manager.GetPaymentStatusAsync("pi_test", cts.Token));
        }

        /// <summary>
        /// Tests that refund payment async with cancelled token throws operation canceled exception
        /// </summary>
        [Fact]
        public async Task RefundPaymentAsync_WithCancelledToken_ThrowsOperationCanceledException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreateRefundAsync(It.IsAny<StripeRefundRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripeRefundResponse
                {
                    RefundId = "re_test_001",
                    AmountRefunded = 500,
                    Currency = "usd",
                    Status = "succeeded"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            await Assert.ThrowsAsync<OperationCanceledException>(() =>
                manager.RefundPaymentAsync("pi_123", 500, cancellationToken: cts.Token));
        }

        /// <summary>
        /// Tests that create checkout session async with null product id throws argument exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithNullProductId_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreateCheckoutSessionAsync(It.IsAny<StripeCheckoutSessionRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripeCheckoutSessionResponse
                {
                    SessionId = "cs_test_123",
                    Url = new Uri("https://checkout.stripe.com/c/pay/cs_test_123"),
                    PaymentIntentId = "pi_test_456"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.CreateCheckoutSessionAsync(null));
        }

        /// <summary>
        /// Tests that create checkout session async with empty product id throws argument exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithEmptyProductId_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.CreateCheckoutSessionAsync("  "));
        }

        /// <summary>
        /// Tests that constructor with null gateway throws argument null exception
        /// </summary>
        [Fact]
        public void Constructor_WithNullGateway_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new StoreManager("id", "name", "tag", true, CreateContext(), null));
        }

        /// <summary>
        /// Tests that refund payment without amount delegates to gateway
        /// </summary>
        [Fact]
        public void RefundPayment_WithoutAmount_DelegatesToGateway()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway.Setup(g => g.CreateRefundAsync(It.IsAny<StripeRefundRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripeRefundResponse { Status = "succeeded" });
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            manager.InitializeAsync(CreateValidConfiguration()).GetAwaiter().GetResult();

            RefundResult result = manager.RefundPaymentAsync("pi_123", null).GetAwaiter().GetResult();

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that refund payment with zero amount throws argument out of range exception
        /// </summary>
        [Fact]
        public void RefundPayment_WithZeroAmount_ThrowsArgumentOutOfRangeException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            manager.InitializeAsync(CreateValidConfiguration()).GetAwaiter().GetResult();

            Assert.Throws<ArgumentOutOfRangeException>(() => manager.RefundPaymentAsync("pi_123", 0).GetAwaiter().GetResult());
        }
    }
}
