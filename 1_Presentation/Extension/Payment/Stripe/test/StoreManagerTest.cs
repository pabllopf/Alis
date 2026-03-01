// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StoreManagerTest.cs
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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Comprehensive unit tests for StoreManager.
    /// </summary>
    public class StoreManagerTest
    {
        private static Context CreateContext() => new Context();

        private static StoreConfiguration CreateValidConfiguration()
        {
            return new StoreConfiguration
            {
                SecretApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc",
                DefaultCurrency = "USD",
                SuccessUrl = "https://example.com/success",
                CancelUrl = "https://example.com/cancel",
                EnableAutomaticPaymentMethods = true
            };
        }

        private static StoreProduct CreateProduct(string id = "test_product", long priceInCents = 999)
        {
            return new StoreProduct
            {
                Id = id,
                Name = "Test Product",
                Description = "A test product description",
                PriceInCents = priceInCents,
                Currency = "usd",
                IsEnabled = true
            };
        }

        #region Constructor Tests

        [Fact]
        public void Constructor_WithContext_CreatesInstanceSuccessfully()
        {
            // Arrange & Act
            StoreManager manager = new StoreManager(CreateContext());

            // Assert
            Assert.NotNull(manager);
            Assert.False(manager.IsInitialized);
            Assert.Equal("StoreManager", manager.Name);
            Assert.Equal("Payment", manager.Tag);
        }

        [Fact]
        public void Constructor_WithContextAndGateway_CreatesInstanceSuccessfully()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();

            // Act
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Assert
            Assert.NotNull(manager);
            Assert.False(manager.IsInitialized);
        }

        [Fact]
        public void Constructor_WithNullContext_ThrowsArgumentNullException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new StoreManager(null));
        }

        [Fact]
        public void Constructor_WithNullGateway_ThrowsArgumentNullException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new StoreManager(CreateContext(), null));
        }

        [Fact]
        public void Constructor_WithAllParameters_CreatesInstanceSuccessfully()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();

            // Act
            StoreManager manager = new StoreManager("custom_id", "CustomStore", "Store", true, CreateContext(), gateway.Object);

            // Assert
            Assert.NotNull(manager);
            Assert.Equal("custom_id", manager.Id);
            Assert.Equal("CustomStore", manager.Name);
            Assert.Equal("Store", manager.Tag);
            Assert.True(manager.IsEnable);
        }

        #endregion

        #region InitializeAsync Tests

        [Fact]
        public async Task InitializeAsync_WithValidConfiguration_InitializesSuccessfully()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreConfiguration config = CreateValidConfiguration();

            // Act
            await manager.InitializeAsync(config);

            // Assert
            Assert.True(manager.IsInitialized);
            gateway.Verify(x => x.Configure("sk_test_4eC39HqLyjWDarjtT1zdp7dc"), Times.Once);
        }

        [Fact]
        public async Task InitializeAsync_WithNullConfiguration_ThrowsArgumentNullException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => manager.InitializeAsync(null));
        }

        [Fact]
        public async Task InitializeAsync_WithNullApiKey_ThrowsArgumentException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreConfiguration config = CreateValidConfiguration();
            config.SecretApiKey = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(config));
        }

        [Fact]
        public async Task InitializeAsync_WithEmptyApiKey_ThrowsArgumentException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreConfiguration config = CreateValidConfiguration();
            config.SecretApiKey = "   ";

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(config));
        }

        [Fact]
        public async Task InitializeAsync_NormalizesCurrencyToLowercase()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreConfiguration config = CreateValidConfiguration();
            config.DefaultCurrency = "EUR";

            // Act
            await manager.InitializeAsync(config);

            // Assert
            Assert.Equal("eur", config.DefaultCurrency);
        }

        [Fact]
        public async Task InitializeAsync_WithCancellationToken_RespectsCancellation()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreConfiguration config = CreateValidConfiguration();
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => manager.InitializeAsync(config, cts.Token));
        }

        #endregion

        #region RegisterProduct Tests

        [Fact]
        public async Task RegisterProduct_WithValidProduct_RegistersSuccessfully()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            StoreProduct product = CreateProduct();

            // Act
            manager.RegisterProduct(product);

            // Assert
            bool exists = manager.TryGetProduct(product.Id, out StoreProduct retrieved);
            Assert.True(exists);
            Assert.Equal(product.Id, retrieved.Id);
        }

        [Fact]
        public void RegisterProduct_WithNullProduct_ThrowsArgumentNullException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => manager.RegisterProduct(null));
        }

        [Fact]
        public void RegisterProduct_WithNullId_ThrowsArgumentException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.Id = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => manager.RegisterProduct(product));
        }

        [Fact]
        public void RegisterProduct_WithEmptyId_ThrowsArgumentException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.Id = "  ";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => manager.RegisterProduct(product));
        }

        [Fact]
        public void RegisterProduct_WithNullName_ThrowsArgumentException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.Name = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => manager.RegisterProduct(product));
        }

        [Fact]
        public void RegisterProduct_WithZeroPrice_ThrowsArgumentException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.PriceInCents = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => manager.RegisterProduct(product));
        }

        [Fact]
        public void RegisterProduct_WithNegativePrice_ThrowsArgumentException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.PriceInCents = -100;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => manager.RegisterProduct(product));
        }

        [Fact]
        public async Task RegisterProduct_WithoutCurrency_UsesDefaultFromConfiguration()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            StoreProduct product = CreateProduct();
            product.Currency = null;

            // Act
            manager.RegisterProduct(product);

            // Assert
            bool exists = manager.TryGetProduct(product.Id, out StoreProduct retrieved);
            Assert.True(exists);
            Assert.Equal("usd", retrieved.Currency);
        }

        [Fact]
        public void RegisterProduct_BeforeInitialization_UsesDefaultUsdCurrency()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.Currency = null;

            // Act
            manager.RegisterProduct(product);

            // Assert
            bool exists = manager.TryGetProduct(product.Id, out StoreProduct retrieved);
            Assert.True(exists);
            Assert.Equal("usd", retrieved.Currency);
        }

        [Fact]
        public async Task RegisterProduct_OverwritesExistingProduct()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            StoreProduct product1 = CreateProduct("same_id", 100);
            StoreProduct product2 = CreateProduct("same_id", 200);

            // Act
            manager.RegisterProduct(product1);
            manager.RegisterProduct(product2);

            // Assert
            bool exists = manager.TryGetProduct("same_id", out StoreProduct retrieved);
            Assert.True(exists);
            Assert.Equal(200, retrieved.PriceInCents);
        }

        #endregion

        #region RegisterProducts Tests

        [Fact]
        public async Task RegisterProducts_WithMultipleProducts_RegistersAllSuccessfully()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            List<StoreProduct> products = new List<StoreProduct>
            {
                CreateProduct("prod1", 100),
                CreateProduct("prod2", 200),
                CreateProduct("prod3", 300)
            };

            // Act
            manager.RegisterProducts(products);

            // Assert
            Assert.True(manager.TryGetProduct("prod1", out _));
            Assert.True(manager.TryGetProduct("prod2", out _));
            Assert.True(manager.TryGetProduct("prod3", out _));
        }

        [Fact]
        public void RegisterProducts_WithNullCollection_ThrowsArgumentNullException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => manager.RegisterProducts(null));
        }

        [Fact]
        public async Task RegisterProducts_WithEmptyCollection_DoesNotThrow()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            // Act
            manager.RegisterProducts(new List<StoreProduct>());

            // Assert - no exception
            Assert.True(true);
        }

        #endregion

        #region TryGetProduct Tests

        [Fact]
        public async Task TryGetProduct_WithExistingProduct_ReturnsTrue()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            StoreProduct product = CreateProduct("existing");
            manager.RegisterProduct(product);

            // Act
            bool result = manager.TryGetProduct("existing", out StoreProduct retrieved);

            // Assert
            Assert.True(result);
            Assert.NotNull(retrieved);
            Assert.Equal("existing", retrieved.Id);
        }

        [Fact]
        public void TryGetProduct_WithNonExistingProduct_ReturnsFalse()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Act
            bool result = manager.TryGetProduct("nonexistent", out StoreProduct retrieved);

            // Assert
            Assert.False(result);
            Assert.Null(retrieved);
        }

        [Fact]
        public void TryGetProduct_WithNullId_ReturnsFalse()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Act
            bool result = manager.TryGetProduct(null, out StoreProduct retrieved);

            // Assert
            Assert.False(result);
            Assert.Null(retrieved);
        }

        [Fact]
        public void TryGetProduct_IsCaseInsensitive()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct("MixedCase");
            manager.RegisterProduct(product);

            // Act
            bool result = manager.TryGetProduct("mixedcase", out StoreProduct retrieved);

            // Assert
            Assert.True(result);
            Assert.NotNull(retrieved);
        }

        #endregion

        #region GetProducts Tests

        [Fact]
        public async Task GetProducts_ReturnsAllRegisteredProducts()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("prod1"));
            manager.RegisterProduct(CreateProduct("prod2"));
            manager.RegisterProduct(CreateProduct("prod3"));

            // Act
            IReadOnlyCollection<StoreProduct> products = manager.GetProducts();

            // Assert
            Assert.Equal(3, products.Count);
            Assert.Contains(products, p => p.Id == "prod1");
            Assert.Contains(products, p => p.Id == "prod2");
            Assert.Contains(products, p => p.Id == "prod3");
        }

        [Fact]
        public void GetProducts_WithNoProducts_ReturnsEmptyCollection()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Act
            IReadOnlyCollection<StoreProduct> products = manager.GetProducts();

            // Assert
            Assert.Empty(products);
        }

        #endregion

        #region CreateCheckoutSessionAsync Tests

        [Fact]
        public async Task CreateCheckoutSessionAsync_WithValidProduct_ReturnsResult()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreateCheckoutSessionAsync(It.IsAny<StripeCheckoutSessionRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripeCheckoutSessionResponse
                {
                    SessionId = "cs_test_123",
                    Url = "https://checkout.stripe.com/c/pay/cs_test_123",
                    PaymentIntentId = "pi_test_456"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product1", 999));

            // Act
            CheckoutSessionResult result = await manager.CreateCheckoutSessionAsync("product1", quantity: 2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("cs_test_123", result.SessionId);
            Assert.Equal("https://checkout.stripe.com/c/pay/cs_test_123", result.Url);
            Assert.Equal("pi_test_456", result.PaymentIntentId);
            Assert.Equal("product1", result.ProductId);
            Assert.Equal(2, result.Quantity);
            Assert.Equal(999, result.UnitAmount);
        }

        [Fact]
        public async Task CreateCheckoutSessionAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.CreateCheckoutSessionAsync("product1"));
        }

        [Fact]
        public async Task CreateCheckoutSessionAsync_WithNonExistentProduct_ThrowsKeyNotFoundException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                manager.CreateCheckoutSessionAsync("nonexistent"));
        }

        [Fact]
        public async Task CreateCheckoutSessionAsync_WithDisabledProduct_ThrowsInvalidOperationException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            StoreProduct product = CreateProduct("disabled_product");
            product.IsEnabled = false;
            manager.RegisterProduct(product);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.CreateCheckoutSessionAsync("disabled_product"));
        }

        [Fact]
        public async Task CreateCheckoutSessionAsync_WithZeroQuantity_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product1"));

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                manager.CreateCheckoutSessionAsync("product1", quantity: 0));
        }

        [Fact]
        public async Task CreateCheckoutSessionAsync_PassesMetadataToGateway()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StripeCheckoutSessionRequest capturedRequest = null;
            gateway
                .Setup(x => x.CreateCheckoutSessionAsync(It.IsAny<StripeCheckoutSessionRequest>(), It.IsAny<CancellationToken>()))
                .Callback<StripeCheckoutSessionRequest, CancellationToken>((req, ct) => capturedRequest = req)
                .ReturnsAsync(new StripeCheckoutSessionResponse
                {
                    SessionId = "cs_123",
                    Url = "https://test.com",
                    PaymentIntentId = "pi_123"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product1"));

            Dictionary<string, string> metadata = new Dictionary<string, string>
            {
                { "user_id", "user_123" },
                { "order_type", "digital" }
            };

            // Act
            await manager.CreateCheckoutSessionAsync("product1", metadata: metadata);

            // Assert
            Assert.NotNull(capturedRequest);
            Assert.Equal(metadata, capturedRequest.Metadata);
        }

        #endregion

        #region CreatePaymentIntentAsync Tests

        [Fact]
        public async Task CreatePaymentIntentAsync_WithValidProduct_ReturnsResult()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreatePaymentIntentAsync(It.IsAny<StripePaymentIntentRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripePaymentIntentResponse
                {
                    PaymentIntentId = "pi_test_789",
                    ClientSecret = "pi_test_789_secret_abc",
                    Status = "requires_payment_method"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product2", 1500));

            // Act
            PaymentIntentResult result = await manager.CreatePaymentIntentAsync("product2", quantity: 3);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("pi_test_789", result.PaymentIntentId);
            Assert.Equal("pi_test_789_secret_abc", result.ClientSecret);
            Assert.Equal("product2", result.ProductId);
            Assert.Equal(4500, result.Amount); // 1500 * 3
            Assert.Equal(PaymentStatus.RequiresPaymentMethod, result.Status);
        }

        [Fact]
        public async Task CreatePaymentIntentAsync_WithSucceededStatus_MapsCorrectly()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreatePaymentIntentAsync(It.IsAny<StripePaymentIntentRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripePaymentIntentResponse
                {
                    PaymentIntentId = "pi_succeeded",
                    ClientSecret = "secret",
                    Status = "succeeded"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product3"));

            // Act
            PaymentIntentResult result = await manager.CreatePaymentIntentAsync("product3");

            // Assert
            Assert.Equal(PaymentStatus.Succeeded, result.Status);
        }

        [Fact]
        public async Task CreatePaymentIntentAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.CreatePaymentIntentAsync("product1"));
        }

        [Fact]
        public async Task CreatePaymentIntentAsync_WithNegativeQuantity_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product1"));

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                manager.CreatePaymentIntentAsync("product1", quantity: -1));
        }

        #endregion

        #region GetPaymentStatusAsync Tests

        [Fact]
        public async Task GetPaymentStatusAsync_WithValidPaymentIntent_ReturnsStatus()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.GetPaymentIntentAsync("pi_valid", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripePaymentIntentResponse
                {
                    PaymentIntentId = "pi_valid",
                    ClientSecret = "secret",
                    Status = "processing"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            // Act
            PaymentStatus status = await manager.GetPaymentStatusAsync("pi_valid");

            // Assert
            Assert.Equal(PaymentStatus.Processing, status);
        }

        [Fact]
        public async Task GetPaymentStatusAsync_WithNullId_ThrowsArgumentException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.GetPaymentStatusAsync(null));
        }

        [Fact]
        public async Task GetPaymentStatusAsync_WithEmptyId_ThrowsArgumentException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.GetPaymentStatusAsync("  "));
        }

        [Fact]
        public async Task GetPaymentStatusAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.GetPaymentStatusAsync("pi_123"));
        }

        #endregion

        #region RefundPaymentAsync Tests

        [Fact]
        public async Task RefundPaymentAsync_WithValidRequest_ReturnsResult()
        {
            // Arrange
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

            // Act
            RefundResult result = await manager.RefundPaymentAsync("pi_123", 500, "requested_by_customer");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("re_test_001", result.RefundId);
            Assert.Equal("pi_123", result.PaymentIntentId);
            Assert.Equal(500, result.AmountRefunded);
            Assert.Equal("usd", result.Currency);
            Assert.Equal("succeeded", result.Status);
        }

        [Fact]
        public async Task RefundPaymentAsync_WithNullAmount_RefundsFullAmount()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StripeRefundRequest capturedRequest = null;
            gateway
                .Setup(x => x.CreateRefundAsync(It.IsAny<StripeRefundRequest>(), It.IsAny<CancellationToken>()))
                .Callback<StripeRefundRequest, CancellationToken>((req, ct) => capturedRequest = req)
                .ReturnsAsync(new StripeRefundResponse
                {
                    RefundId = "re_full",
                    AmountRefunded = 1000,
                    Currency = "usd",
                    Status = "succeeded"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            // Act
            await manager.RefundPaymentAsync("pi_123", null);

            // Assert
            Assert.NotNull(capturedRequest);
            Assert.Null(capturedRequest.Amount);
        }

        [Fact]
        public async Task RefundPaymentAsync_WithNullPaymentIntentId_ThrowsArgumentException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.RefundPaymentAsync(null, 100));
        }

        [Fact]
        public async Task RefundPaymentAsync_WithZeroAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                manager.RefundPaymentAsync("pi_123", 0));
        }

        [Fact]
        public async Task RefundPaymentAsync_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                manager.RefundPaymentAsync("pi_123", -100));
        }

        [Fact]
        public async Task RefundPaymentAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.RefundPaymentAsync("pi_123", 100));
        }

        #endregion

        #region Dispose Tests

        [Fact]
        public void Dispose_ClearsProductsAndConfiguration()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            manager.RegisterProduct(CreateProduct("prod1"));

            // Act
            manager.Dispose();

            // Assert
            Assert.False(manager.IsInitialized);
            Assert.Throws<ObjectDisposedException>(() => manager.GetProducts());
        }

        [Fact]
        public void Dispose_CanBeCalledMultipleTimes()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            // Act
            manager.Dispose();
            manager.Dispose();

            // Assert - no exception
            Assert.True(true);
        }

        [Fact]
        public void OperationsAfterDispose_ThrowObjectDisposedException()
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            manager.Dispose();

            // Act & Assert
            Assert.Throws<ObjectDisposedException>(() => manager.GetProducts());
            Assert.Throws<ObjectDisposedException>(() => manager.RegisterProduct(CreateProduct()));
            Assert.ThrowsAsync<ObjectDisposedException>(() => manager.InitializeAsync(CreateValidConfiguration()));
        }

        #endregion

        #region PaymentStatus Mapping Tests

        [Theory]
        [InlineData("requires_payment_method", PaymentStatus.RequiresPaymentMethod)]
        [InlineData("requires_confirmation", PaymentStatus.RequiresConfirmation)]
        [InlineData("requires_action", PaymentStatus.RequiresAction)]
        [InlineData("processing", PaymentStatus.Processing)]
        [InlineData("requires_capture", PaymentStatus.RequiresCapture)]
        [InlineData("canceled", PaymentStatus.Canceled)]
        [InlineData("succeeded", PaymentStatus.Succeeded)]
        [InlineData("unknown_status", PaymentStatus.Unknown)]
        [InlineData("", PaymentStatus.Unknown)]
        [InlineData(null, PaymentStatus.Unknown)]
        public async Task PaymentStatusMapping_HandlesAllCases(string stripeStatus, PaymentStatus expectedStatus)
        {
            // Arrange
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.GetPaymentIntentAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripePaymentIntentResponse
                {
                    PaymentIntentId = "pi_test",
                    ClientSecret = "secret",
                    Status = stripeStatus
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            // Act
            PaymentStatus status = await manager.GetPaymentStatusAsync("pi_test");

            // Assert
            Assert.Equal(expectedStatus, status);
        }

        #endregion
    }
}

