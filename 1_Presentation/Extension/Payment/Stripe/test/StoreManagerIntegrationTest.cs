

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
    ///     Integration tests for StoreManager with complex workflows
    /// </summary>
    public class StoreManagerIntegrationTest
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
            SecretApiKey = "sk_test_valid",
            DefaultCurrency = "usd",
            SuccessUrl = new Uri("https://example.com/success"),
            CancelUrl = new Uri("https://example.com/cancel"),
            EnableAutomaticPaymentMethods = true
        };

        /// <summary>
        ///     Tests that complete payment workflow payment intent succeeds
        /// </summary>
        [Fact]
        public async Task CompletePaymentWorkflow_PaymentIntent_Succeeds()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreatePaymentIntentAsync(It.IsAny<StripePaymentIntentRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripePaymentIntentResponse
                {
                    PaymentIntentId = "pi_integration_test",
                    ClientSecret = "pi_integration_test_secret_xyz",
                    Status = "requires_payment_method"
                });

            gateway
                .Setup(x => x.GetPaymentIntentAsync("pi_integration_test", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripePaymentIntentResponse
                {
                    PaymentIntentId = "pi_integration_test",
                    ClientSecret = "pi_integration_test_secret_xyz",
                    Status = "succeeded"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            manager.RegisterProduct(new StoreProduct
            {
                Id = "coins_1000",
                Name = "1000 Coins",
                Description = "1000 virtual coins",
                PriceInCents = 999,
                Currency = "usd"
            });

            PaymentIntentResult createResult = await manager.CreatePaymentIntentAsync("coins_1000");
            PaymentStatus statusResult = await manager.GetPaymentStatusAsync("pi_integration_test");

            Assert.Equal("pi_integration_test", createResult.PaymentIntentId);
            Assert.Equal(PaymentStatus.RequiresPaymentMethod, createResult.Status);
            Assert.Equal(PaymentStatus.Succeeded, statusResult);
        }

        /// <summary>
        ///     Tests that complete payment workflow refund succeeds
        /// </summary>
        [Fact]
        public async Task CompletePaymentWorkflow_Refund_Succeeds()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreateRefundAsync(It.IsAny<StripeRefundRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripeRefundResponse
                {
                    RefundId = "re_integration_test",
                    AmountRefunded = 999,
                    Currency = "usd",
                    Status = "succeeded"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            RefundResult result = await manager.RefundPaymentAsync("pi_test", 999, "requested_by_customer");

            Assert.Equal("re_integration_test", result.RefundId);
            Assert.Equal(999, result.AmountRefunded);
            Assert.Equal("usd", result.Currency);
            Assert.Equal("succeeded", result.Status);
        }

        /// <summary>
        ///     Tests that multiple product workflow registers and queried succeeds
        /// </summary>
        [Fact]
        public async Task MultipleProductWorkflow_RegistersAndQueried_Succeeds()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            List<StoreProduct> products = new List<StoreProduct>
            {
                new StoreProduct {Id = "coins_500", Name = "500 Coins", PriceInCents = 499},
                new StoreProduct {Id = "coins_1000", Name = "1000 Coins", PriceInCents = 899},
                new StoreProduct {Id = "coins_5000", Name = "5000 Coins", PriceInCents = 3999},
                new StoreProduct {Id = "bundle_premium", Name = "Premium Bundle", PriceInCents = 9999}
            };

            manager.RegisterProducts(products);

            IReadOnlyCollection<StoreProduct> allProducts = manager.GetProducts();
            bool findCoins1000 = manager.TryGetProduct("coins_1000", out StoreProduct coins1000);
            bool findBundle = manager.TryGetProduct("bundle_premium", out StoreProduct bundle);
            bool findNonexistent = manager.TryGetProduct("nonexistent", out StoreProduct nonexistent);

            Assert.Equal(4, allProducts.Count);
            Assert.True(findCoins1000);
            Assert.Equal("1000 Coins", coins1000.Name);
            Assert.Equal(899, coins1000.PriceInCents);
            Assert.True(findBundle);
            Assert.Equal(9999, bundle.PriceInCents);
            Assert.False(findNonexistent);
            Assert.Null(nonexistent);
        }

        /// <summary>
        ///     Tests that currency handling defaults and overrides work correctly
        /// </summary>
        [Fact]
        public async Task CurrencyHandling_DefaultsAndOverrides_WorkCorrectly()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.CreateCheckoutSessionAsync(It.IsAny<StripeCheckoutSessionRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripeCheckoutSessionResponse
                {
                    SessionId = "cs_curr_test",
                    Url = new Uri("https://test.com"),
                    PaymentIntentId = "pi_curr_test"
                });

            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);

            StoreConfiguration eurConfig = CreateValidConfiguration();
            eurConfig.DefaultCurrency = "EUR";
            await manager.InitializeAsync(eurConfig);

            StoreProduct productWithoutCurrency = new StoreProduct
            {
                Id = "eur_product",
                Name = "EUR Product",
                PriceInCents = 1000,
                Currency = null
            };
            manager.RegisterProduct(productWithoutCurrency);

            StoreProduct productWithCurrency = new StoreProduct
            {
                Id = "gbp_product",
                Name = "GBP Product",
                PriceInCents = 1000,
                Currency = "GBP"
            };
            manager.RegisterProduct(productWithCurrency);

            bool foundEurProduct = manager.TryGetProduct("eur_product", out StoreProduct eurProduct);
            bool foundGbpProduct = manager.TryGetProduct("gbp_product", out StoreProduct gbpProduct);

            Assert.True(foundEurProduct);
            Assert.Equal("eur", eurProduct.Currency);

            Assert.True(foundGbpProduct);
            Assert.Equal("gbp", gbpProduct.Currency);
        }

        /// <summary>
        ///     Tests that state management product disabling works correctly
        /// </summary>
        [Fact]
        public async Task StateManagement_ProductDisabling_WorksCorrectly()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(CreateContext(), gateway.Object);
            await manager.InitializeAsync(CreateValidConfiguration());

            StoreProduct product = new StoreProduct
            {
                Id = "disableable",
                Name = "Test Product",
                PriceInCents = 500,
                IsEnabled = true
            };
            manager.RegisterProduct(product);

            bool foundInitially = manager.TryGetProduct("disableable", out StoreProduct initialProduct);
            initialProduct.IsEnabled = false;

            manager.RegisterProduct(initialProduct);

            Assert.True(foundInitially);
            Assert.True(!initialProduct.IsEnabled);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.CreateCheckoutSessionAsync("disableable"));
        }

        /// <summary>
        ///     Tests that manager properties reflect configuration correctly
        /// </summary>
        [Fact]
        public async Task ManagerProperties_ReflectConfiguration_Correctly()
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager("custom_id", "CustomStore", "Payment", true, CreateContext(), gateway.Object);

            Assert.False(manager.IsInitialized);
            Assert.Equal("custom_id", manager.Id);
            Assert.Equal("CustomStore", manager.Name);
            Assert.Equal("Payment", manager.Tag);
            Assert.True(manager.IsEnable);

            await manager.InitializeAsync(CreateValidConfiguration());

            Assert.True(manager.IsInitialized);
        }
    }
}