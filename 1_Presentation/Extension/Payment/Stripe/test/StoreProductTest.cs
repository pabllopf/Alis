

using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Tests for StoreProduct model
    /// </summary>
    public class StoreProductTest
    {
        /// <summary>
        ///     Tests that constructor initializes with default values
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithDefaultValues()
        {
            StoreProduct product = new StoreProduct();

            Assert.Equal("usd", product.Currency);
            Assert.True(product.IsEnabled);
        }

        /// <summary>
        ///     Tests that id can be set and retrieved
        /// </summary>
        [Fact]
        public void Id_CanBeSetAndRetrieved()
        {
            StoreProduct product = new StoreProduct();
            string id = "prod_test_001";

            product.Id = id;

            Assert.Equal(id, product.Id);
        }

        /// <summary>
        ///     Tests that name can be set and retrieved
        /// </summary>
        [Fact]
        public void Name_CanBeSetAndRetrieved()
        {
            StoreProduct product = new StoreProduct();
            string name = "Premium Coins Pack";

            product.Name = name;

            Assert.Equal(name, product.Name);
        }

        /// <summary>
        ///     Tests that description can be set and retrieved
        /// </summary>
        [Fact]
        public void Description_CanBeSetAndRetrieved()
        {
            StoreProduct product = new StoreProduct();
            string description = "10,000 virtual coins for in-game purchases";

            product.Description = description;

            Assert.Equal(description, product.Description);
        }

        /// <summary>
        ///     Tests that price in cents can be set and retrieved
        /// </summary>
        [Fact]
        public void PriceInCents_CanBeSetAndRetrieved()
        {
            StoreProduct product = new StoreProduct();
            long price = 1999;

            product.PriceInCents = price;

            Assert.Equal(price, product.PriceInCents);
        }

        /// <summary>
        ///     Tests that currency can be overridden
        /// </summary>
        [Fact]
        public void Currency_CanBeOverridden()
        {
            StoreProduct product = new StoreProduct();

            product.Currency = "eur";

            Assert.Equal("eur", product.Currency);
        }

        /// <summary>
        ///     Tests that is enabled can be disabled
        /// </summary>
        [Fact]
        public void IsEnabled_CanBeDisabled()
        {
            StoreProduct product = new StoreProduct();

            product.IsEnabled = false;

            Assert.False(product.IsEnabled);
        }

        /// <summary>
        ///     Tests that all properties can be set together
        /// </summary>
        [Fact]
        public void AllProperties_CanBeSetTogether()
        {
            StoreProduct product = new StoreProduct
            {
                Id = "starter_pack",
                Name = "Starter Pack",
                Description = "Everything you need to get started",
                PriceInCents = 499,
                Currency = "gbp",
                IsEnabled = true
            };

            Assert.Equal("starter_pack", product.Id);
            Assert.Equal("Starter Pack", product.Name);
            Assert.Equal("Everything you need to get started", product.Description);
            Assert.Equal(499, product.PriceInCents);
            Assert.Equal("gbp", product.Currency);
            Assert.True(product.IsEnabled);
        }
    }
}