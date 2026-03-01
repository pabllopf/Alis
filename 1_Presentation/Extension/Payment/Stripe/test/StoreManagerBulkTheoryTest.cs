using System;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     High-volume theory tests for StoreManager product and currency behavior.
    /// </summary>
    public class StoreManagerBulkTheoryTest
    {
        private static StoreConfiguration CreateConfiguration(string currency)
        {
            return new StoreConfiguration
            {
                SecretApiKey = "sk_test_bulk",
                DefaultCurrency = currency,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel"),
                EnableAutomaticPaymentMethods = true
            };
        }

        [Theory]
        [MemberData(nameof(StripeTheoryData.ProductRegistrationCases), MemberType = typeof(StripeTheoryData))]
        public void RegisterProduct_BulkCases_ShouldPersistValues(string productId, string productName, long priceInCents, string currency)
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(new Context(), gateway.Object);

            StoreProduct product = new StoreProduct
            {
                Id = productId,
                Name = productName,
                Description = "Bulk generated product",
                PriceInCents = priceInCents,
                Currency = currency,
                IsEnabled = true
            };

            manager.RegisterProduct(product);

            bool found = manager.TryGetProduct(productId, out StoreProduct stored);

            Assert.True(found);
            Assert.NotNull(stored);
            Assert.Equal(productId, stored.Id);
            Assert.Equal(productName, stored.Name);
            Assert.Equal(priceInCents, stored.PriceInCents);
            Assert.Equal(currency, stored.Currency);
            Assert.True(stored.IsEnabled);
        }

        [Theory]
        [MemberData(nameof(StripeTheoryData.CurrencyNormalizationCases), MemberType = typeof(StripeTheoryData))]
        public async Task RegisterProduct_BulkCurrencyNormalization_ShouldUseNormalizedDefault(int caseId, string rawCurrency, string expectedCurrency)
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            StoreManager manager = new StoreManager(new Context(), gateway.Object);

            await manager.InitializeAsync(CreateConfiguration(rawCurrency));

            StoreProduct product = new StoreProduct
            {
                Id = string.Concat("currency_product_", caseId),
                Name = "Currency Product",
                Description = "Uses default currency",
                PriceInCents = 250,
                Currency = null,
                IsEnabled = true
            };

            manager.RegisterProduct(product);

            bool found = manager.TryGetProduct(product.Id, out StoreProduct stored);

            Assert.True(found);
            Assert.NotNull(stored);
            Assert.Equal(expectedCurrency, stored.Currency);
        }
    }
}
