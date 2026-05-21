

using System;
using System.Collections.Generic;
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
        /// <summary>
        ///     Creates the context
        /// </summary>
        /// <returns>The context</returns>
        private static Context CreateContext() => new Context();

        /// <summary>
        ///     Creates the valid configuration
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
        ///     Creates the product using the specified id
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
        ///     Tests that constructor with context creates instance successfully
        /// </summary>
        [Fact]
        public void Constructor_WithContext_CreatesInstanceSuccessfully()
        {
            StoreManager manager = new StoreManager(CreateContext());

            Assert.NotNull(manager);
            Assert.False(manager.IsInitialized);
            Assert.Equal("StoreManager", manager.Name);
            Assert.Equal("Payment", manager.Tag);
        }

        /// <summary>
        ///     Tests that constructor with context and gateway creates instance successfully
        /// </summary>
        [Fact]
        public void Constructor_WithContextAndGateway_CreatesInstanceSuccessfully()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            Assert.NotNull(manager);
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that constructor with null gateway throws argument null exception
        /// </summary>
        [Fact]
        public void Constructor_WithNullGateway_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new StoreManager(CreateContext(), null));
        }

        /// <summary>
        ///     Tests that constructor with all parameters creates instance successfully
        /// </summary>
        [Fact]
        public void Constructor_WithAllParameters_CreatesInstanceSuccessfully()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();

            StoreManager manager = new StoreManager("custom_id", "CustomStore", "Store", true, CreateContext(), gateway.Object);

            Assert.NotNull(manager);
            Assert.Equal("custom_id", manager.Id);
            Assert.Equal("CustomStore", manager.Name);
            Assert.Equal("Store", manager.Tag);
            Assert.True(manager.IsEnable);
        }


        /// <summary>
        ///     Tests that initialize async with valid configuration initializes successfully
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithValidConfiguration_InitializesSuccessfully()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreConfiguration config = CreateValidConfiguration();

            await manager.InitializeAsync(config);

            Assert.True(manager.IsInitialized);
            gateway.Verify(x => x.Configure("sk_test_4eC39HqLyjWDarjtT1zdp7dc"), Times.Once);
        }

        /// <summary>
        ///     Tests that initialize async with null configuration throws argument null exception
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithNullConfiguration_ThrowsArgumentNullException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => manager.InitializeAsync(null));
        }

        /// <summary>
        ///     Tests that initialize async with null api key throws argument exception
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithNullApiKey_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreConfiguration config = CreateValidConfiguration();
            config.SecretApiKey = null;

            await Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(config));
        }

        /// <summary>
        ///     Tests that initialize async with empty api key throws argument exception
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithEmptyApiKey_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreConfiguration config = CreateValidConfiguration();
            config.SecretApiKey = "   ";

            await Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(config));
        }

        /// <summary>
        ///     Tests that initialize async normalizes currency to lowercase
        /// </summary>
        [Fact]
        public async Task InitializeAsync_NormalizesCurrencyToLowercase()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreConfiguration config = CreateValidConfiguration();
            config.DefaultCurrency = "EUR";

            await manager.InitializeAsync(config);

            Assert.Equal("eur", config.DefaultCurrency);
        }

        /// <summary>
        ///     Tests that initialize async with cancellation token respects cancellation
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithCancellationToken_RespectsCancellation()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreConfiguration config = CreateValidConfiguration();
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            await Assert.ThrowsAsync<OperationCanceledException>(() => manager.InitializeAsync(config, cts.Token));
        }


        /// <summary>
        ///     Tests that register product with valid product registers successfully
        /// </summary>
        [Fact]
        public async Task RegisterProduct_WithValidProduct_RegistersSuccessfully()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            StoreProduct product = CreateProduct();

            manager.RegisterProduct(product);

            bool exists = manager.TryGetProduct(product.Id, out StoreProduct retrieved);
            Assert.True(exists);
            Assert.Equal(product.Id, retrieved.Id);
        }

        /// <summary>
        ///     Tests that register product with null product throws argument null exception
        /// </summary>
        [Fact]
        public void RegisterProduct_WithNullProduct_ThrowsArgumentNullException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            Assert.Throws<ArgumentNullException>(() => manager.RegisterProduct(null));
        }

        /// <summary>
        ///     Tests that register product with null id throws argument exception
        /// </summary>
        [Fact]
        public void RegisterProduct_WithNullId_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.Id = null;

            Assert.Throws<ArgumentException>(() => manager.RegisterProduct(product));
        }

        /// <summary>
        ///     Tests that register product with empty id throws argument exception
        /// </summary>
        [Fact]
        public void RegisterProduct_WithEmptyId_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.Id = "  ";

            Assert.Throws<ArgumentException>(() => manager.RegisterProduct(product));
        }

        /// <summary>
        ///     Tests that register product with null name throws argument exception
        /// </summary>
        [Fact]
        public void RegisterProduct_WithNullName_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.Name = null;

            Assert.Throws<ArgumentException>(() => manager.RegisterProduct(product));
        }

        /// <summary>
        ///     Tests that register product with zero price throws argument exception
        /// </summary>
        [Fact]
        public void RegisterProduct_WithZeroPrice_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.PriceInCents = 0;

            Assert.Throws<ArgumentException>(() => manager.RegisterProduct(product));
        }

        /// <summary>
        ///     Tests that register product with negative price throws argument exception
        /// </summary>
        [Fact]
        public void RegisterProduct_WithNegativePrice_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.PriceInCents = -100;

            Assert.Throws<ArgumentException>(() => manager.RegisterProduct(product));
        }

        /// <summary>
        ///     Tests that register product without currency uses default from configuration
        /// </summary>
        [Fact]
        public async Task RegisterProduct_WithoutCurrency_UsesDefaultFromConfiguration()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            StoreProduct product = CreateProduct();
            product.Currency = null;

            manager.RegisterProduct(product);

            bool exists = manager.TryGetProduct(product.Id, out StoreProduct retrieved);
            Assert.True(exists);
            Assert.Equal("usd", retrieved.Currency);
        }

        /// <summary>
        ///     Tests that register product before initialization uses default usd currency
        /// </summary>
        [Fact]
        public void RegisterProduct_BeforeInitialization_UsesDefaultUsdCurrency()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct();
            product.Currency = null;

            manager.RegisterProduct(product);

            bool exists = manager.TryGetProduct(product.Id, out StoreProduct retrieved);
            Assert.True(exists);
            Assert.Equal("usd", retrieved.Currency);
        }

        /// <summary>
        ///     Tests that register product overwrites existing product
        /// </summary>
        [Fact]
        public async Task RegisterProduct_OverwritesExistingProduct()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            StoreProduct product1 = CreateProduct("same_id", 100);
            StoreProduct product2 = CreateProduct("same_id", 200);

            manager.RegisterProduct(product1);
            manager.RegisterProduct(product2);

            bool exists = manager.TryGetProduct("same_id", out StoreProduct retrieved);
            Assert.True(exists);
            Assert.Equal(200, retrieved.PriceInCents);
        }


        /// <summary>
        ///     Tests that register products with multiple products registers all successfully
        /// </summary>
        [Fact]
        public async Task RegisterProducts_WithMultipleProducts_RegistersAllSuccessfully()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            List<StoreProduct> products = new List<StoreProduct>
            {
                CreateProduct("prod1", 100),
                CreateProduct("prod2", 200),
                CreateProduct("prod3", 300)
            };

            manager.RegisterProducts(products);

            Assert.True(manager.TryGetProduct("prod1", out _));
            Assert.True(manager.TryGetProduct("prod2", out _));
            Assert.True(manager.TryGetProduct("prod3", out _));
        }

        /// <summary>
        ///     Tests that register products with null collection throws argument null exception
        /// </summary>
        [Fact]
        public void RegisterProducts_WithNullCollection_ThrowsArgumentNullException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            Assert.Throws<ArgumentNullException>(() => manager.RegisterProducts(null));
        }

        /// <summary>
        ///     Tests that register products with empty collection does not throw
        /// </summary>
        [Fact]
        public async Task RegisterProducts_WithEmptyCollection_DoesNotThrow()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            manager.RegisterProducts(new List<StoreProduct>());

            Assert.True(true);
        }


        /// <summary>
        ///     Tests that try get product with existing product returns true
        /// </summary>
        [Fact]
        public async Task TryGetProduct_WithExistingProduct_ReturnsTrue()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            StoreProduct product = CreateProduct("existing");
            manager.RegisterProduct(product);

            bool result = manager.TryGetProduct("existing", out StoreProduct retrieved);

            Assert.True(result);
            Assert.NotNull(retrieved);
            Assert.Equal("existing", retrieved.Id);
        }

        /// <summary>
        ///     Tests that try get product with non existing product returns false
        /// </summary>
        [Fact]
        public void TryGetProduct_WithNonExistingProduct_ReturnsFalse()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            bool result = manager.TryGetProduct("nonexistent", out StoreProduct retrieved);

            Assert.False(result);
            Assert.Null(retrieved);
        }

        /// <summary>
        ///     Tests that try get product with null id returns false
        /// </summary>
        [Fact]
        public void TryGetProduct_WithNullId_ReturnsFalse()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            bool result = manager.TryGetProduct(null, out StoreProduct retrieved);

            Assert.False(result);
            Assert.Null(retrieved);
        }

        /// <summary>
        ///     Tests that try get product is case insensitive
        /// </summary>
        [Fact]
        public void TryGetProduct_IsCaseInsensitive()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            StoreProduct product = CreateProduct("MixedCase");
            manager.RegisterProduct(product);

            bool result = manager.TryGetProduct("mixedcase", out StoreProduct retrieved);

            Assert.True(result);
            Assert.NotNull(retrieved);
        }


        /// <summary>
        ///     Tests that get products returns all registered products
        /// </summary>
        [Fact]
        public async Task GetProducts_ReturnsAllRegisteredProducts()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("prod1"));
            manager.RegisterProduct(CreateProduct("prod2"));
            manager.RegisterProduct(CreateProduct("prod3"));

            IReadOnlyCollection<StoreProduct> products = manager.GetProducts();

            Assert.Equal(3, products.Count);
            Assert.Contains(products, p => p.Id == "prod1");
            Assert.Contains(products, p => p.Id == "prod2");
            Assert.Contains(products, p => p.Id == "prod3");
        }

        /// <summary>
        ///     Tests that get products with no products returns empty collection
        /// </summary>
        [Fact]
        public void GetProducts_WithNoProducts_ReturnsEmptyCollection()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            IReadOnlyCollection<StoreProduct> products = manager.GetProducts();

            Assert.Empty(products);
        }


        /// <summary>
        ///     Tests that create checkout session async with valid product returns result
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithValidProduct_ReturnsResult()
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

            CheckoutSessionResult result = await manager.CreateCheckoutSessionAsync("product1", 2);

            Assert.NotNull(result);
            Assert.Equal("cs_test_123", result.SessionId);
            Assert.Equal("https://checkout.stripe.com/c/pay/cs_test_123", result.Url.ToString());
            Assert.Equal("pi_test_456", result.PaymentIntentId);
            Assert.Equal("product1", result.ProductId);
            Assert.Equal(2, result.Quantity);
            Assert.Equal(999, result.UnitAmount);
        }

        /// <summary>
        ///     Tests that create checkout session async without initialization throws invalid operation exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.CreateCheckoutSessionAsync("product1"));
        }

        /// <summary>
        ///     Tests that create checkout session async with non existent product throws key not found exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithNonExistentProduct_ThrowsKeyNotFoundException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                manager.CreateCheckoutSessionAsync("nonexistent"));
        }

        /// <summary>
        ///     Tests that create checkout session async with disabled product throws invalid operation exception
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_WithDisabledProduct_ThrowsInvalidOperationException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            StoreProduct product = CreateProduct("disabled_product");
            product.IsEnabled = false;
            manager.RegisterProduct(product);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.CreateCheckoutSessionAsync("disabled_product"));
        }


        /// <summary>
        ///     Tests that create checkout session async passes metadata to gateway
        /// </summary>
        [Fact]
        public async Task CreateCheckoutSessionAsync_PassesMetadataToGateway()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StripeCheckoutSessionRequest capturedRequest = null;
            gateway
                .Setup(x => x.CreateCheckoutSessionAsync(It.IsAny<StripeCheckoutSessionRequest>(), It.IsAny<CancellationToken>()))
                .Callback<StripeCheckoutSessionRequest, CancellationToken>((req, ct) => capturedRequest = req)
                .ReturnsAsync(new StripeCheckoutSessionResponse
                {
                    SessionId = "cs_123",
                    Url = new Uri("https://test.com"),
                    PaymentIntentId = "pi_123"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product1"));

            Dictionary<string, string> metadata = new Dictionary<string, string>
            {
                {"user_id", "user_123"},
                {"order_type", "digital"}
            };

            await manager.CreateCheckoutSessionAsync("product1", metadata: metadata);

            Assert.NotNull(capturedRequest);
            Assert.Equal(metadata, capturedRequest.Metadata);
        }


        /// <summary>
        ///     Tests that create payment intent async with valid product returns result
        /// </summary>
        [Fact]
        public async Task CreatePaymentIntentAsync_WithValidProduct_ReturnsResult()
        {
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

            PaymentIntentResult result = await manager.CreatePaymentIntentAsync("product2", 3);

            Assert.NotNull(result);
            Assert.Equal("pi_test_789", result.PaymentIntentId);
            Assert.Equal("pi_test_789_secret_abc", result.ClientSecret);
            Assert.Equal("product2", result.ProductId);
            Assert.Equal(4500, result.Amount); // 1500 * 3
            Assert.Equal(PaymentStatus.RequiresPaymentMethod, result.Status);
        }

        /// <summary>
        ///     Tests that create payment intent async with succeeded status maps correctly
        /// </summary>
        [Fact]
        public async Task CreatePaymentIntentAsync_WithSucceededStatus_MapsCorrectly()
        {
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

            PaymentIntentResult result = await manager.CreatePaymentIntentAsync("product3");

            Assert.Equal(PaymentStatus.Succeeded, result.Status);
        }

        /// <summary>
        ///     Tests that create payment intent async without initialization throws invalid operation exception
        /// </summary>
        [Fact]
        public async Task CreatePaymentIntentAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.CreatePaymentIntentAsync("product1"));
        }

        /// <summary>
        ///     Tests that create payment intent async with negative quantity throws argument out of range exception
        /// </summary>
        [Fact]
        public async Task CreatePaymentIntentAsync_WithNegativeQuantity_ThrowsArgumentOutOfRangeException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());
            manager.RegisterProduct(CreateProduct("product1"));

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                manager.CreatePaymentIntentAsync("product1", -1));
        }


        /// <summary>
        ///     Tests that get payment status async with valid payment intent returns status
        /// </summary>
        [Fact]
        public async Task GetPaymentStatusAsync_WithValidPaymentIntent_ReturnsStatus()
        {
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

            PaymentStatus status = await manager.GetPaymentStatusAsync("pi_valid");

            Assert.Equal(PaymentStatus.Processing, status);
        }

        /// <summary>
        ///     Tests that get payment status async with null id throws argument exception
        /// </summary>
        [Fact]
        public async Task GetPaymentStatusAsync_WithNullId_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.GetPaymentStatusAsync(null));
        }

        /// <summary>
        ///     Tests that get payment status async with empty id throws argument exception
        /// </summary>
        [Fact]
        public async Task GetPaymentStatusAsync_WithEmptyId_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.GetPaymentStatusAsync("  "));
        }

        /// <summary>
        ///     Tests that get payment status async without initialization throws invalid operation exception
        /// </summary>
        [Fact]
        public async Task GetPaymentStatusAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.GetPaymentStatusAsync("pi_123"));
        }


        /// <summary>
        ///     Tests that refund payment async with valid request returns result
        /// </summary>
        [Fact]
        public async Task RefundPaymentAsync_WithValidRequest_ReturnsResult()
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

            RefundResult result = await manager.RefundPaymentAsync("pi_123", 500, "requested_by_customer");

            Assert.NotNull(result);
            Assert.Equal("re_test_001", result.RefundId);
            Assert.Equal("pi_123", result.PaymentIntentId);
            Assert.Equal(500, result.AmountRefunded);
            Assert.Equal("usd", result.Currency);
            Assert.Equal("succeeded", result.Status);
        }

        /// <summary>
        ///     Tests that refund payment async with null payment intent id throws argument exception
        /// </summary>
        [Fact]
        public async Task RefundPaymentAsync_WithNullPaymentIntentId_ThrowsArgumentException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.RefundPaymentAsync(null, 100));
        }

        /// <summary>
        ///     Tests that refund payment async with zero amount throws argument out of range exception
        /// </summary>
        [Fact]
        public async Task RefundPaymentAsync_WithZeroAmount_ThrowsArgumentOutOfRangeException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                manager.RefundPaymentAsync("pi_123", 0));
        }

        /// <summary>
        ///     Tests that refund payment async with negative amount throws argument out of range exception
        /// </summary>
        [Fact]
        public async Task RefundPaymentAsync_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                manager.RefundPaymentAsync("pi_123", -100));
        }

        /// <summary>
        ///     Tests that refund payment async without initialization throws invalid operation exception
        /// </summary>
        [Fact]
        public async Task RefundPaymentAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.RefundPaymentAsync("pi_123", 100));
        }


        /// <summary>
        ///     Tests that payment status mapping handles all cases
        /// </summary>
        /// <param name="stripeStatus">The stripe status</param>
        /// <param name="expectedStatus">The expected status</param>
        [Theory, InlineData("requires_payment_method", PaymentStatus.RequiresPaymentMethod), InlineData("requires_confirmation", PaymentStatus.RequiresConfirmation), InlineData("requires_action", PaymentStatus.RequiresAction), InlineData("processing", PaymentStatus.Processing), InlineData("requires_capture", PaymentStatus.RequiresCapture), InlineData("canceled", PaymentStatus.Canceled),
         InlineData("succeeded", PaymentStatus.Succeeded), InlineData("unknown_status", PaymentStatus.Unknown), InlineData("", PaymentStatus.Unknown), InlineData(null, PaymentStatus.Unknown)]
        public async Task PaymentStatusMapping_HandlesAllCases(string stripeStatus, PaymentStatus expectedStatus)
        {
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

            PaymentStatus status = await manager.GetPaymentStatusAsync("pi_test");

            Assert.Equal(expectedStatus, status);
        }
    }
}