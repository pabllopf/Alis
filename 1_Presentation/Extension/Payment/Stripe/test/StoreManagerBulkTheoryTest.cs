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
        /// <summary>
        /// Creates the configuration using the specified currency
        /// </summary>
        /// <param name="currency">The currency</param>
        /// <returns>The store configuration</returns>
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

        /// <summary>
        /// Tests that register product bulk cases should persist values
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="productName">The product name</param>
        /// <param name="priceInCents">The price in cents</param>
        /// <param name="currency">The currency</param>
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

        /// <summary>
        /// Tests that register product bulk currency normalization should use normalized default
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="rawCurrency">The raw currency</param>
        /// <param name="expectedCurrency">The expected currency</param>
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
