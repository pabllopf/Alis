

using System;
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Tests for StoreConfiguration model
    /// </summary>
    public class StoreConfigurationTest
    {
        /// <summary>
        ///     Tests that constructor initializes with default values
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithDefaultValues()
        {
            StoreConfiguration config = new StoreConfiguration();

            Assert.Equal("usd", config.DefaultCurrency);
            Assert.Null(config.SuccessUrl);
            Assert.Null(config.CancelUrl);
            Assert.True(config.EnableAutomaticPaymentMethods);
        }

        /// <summary>
        ///     Tests that secret api key can be set and retrieved
        /// </summary>
        [Fact]
        public void SecretApiKey_CanBeSetAndRetrieved()
        {
            StoreConfiguration config = new StoreConfiguration();
            string apiKey = "sk_test_12345";

            config.SecretApiKey = apiKey;

            Assert.Equal(apiKey, config.SecretApiKey);
        }

        /// <summary>
        ///     Tests that default currency can be overridden
        /// </summary>
        [Fact]
        public void DefaultCurrency_CanBeOverridden()
        {
            StoreConfiguration config = new StoreConfiguration();

            config.DefaultCurrency = "eur";

            Assert.Equal("eur", config.DefaultCurrency);
        }

        /// <summary>
        ///     Tests that success url can be customized
        /// </summary>
        [Fact]
        public void SuccessUrl_CanBeCustomized()
        {
            StoreConfiguration config = new StoreConfiguration();
            string customUrl = "https://myapp.com/success";

            config.SuccessUrl = new Uri(customUrl);

            Assert.Equal(customUrl, config.SuccessUrl.ToString());
        }

        /// <summary>
        ///     Tests that cancel url can be customized
        /// </summary>
        [Fact]
        public void CancelUrl_CanBeCustomized()
        {
            StoreConfiguration config = new StoreConfiguration();
            string customUrl = "https://myapp.com/cancel";

            config.CancelUrl = new Uri(customUrl);

            Assert.Equal(customUrl, config.CancelUrl.ToString());
        }

        /// <summary>
        ///     Tests that enable automatic payment methods can be disabled
        /// </summary>
        [Fact]
        public void EnableAutomaticPaymentMethods_CanBeDisabled()
        {
            StoreConfiguration config = new StoreConfiguration();

            config.EnableAutomaticPaymentMethods = false;

            Assert.False(config.EnableAutomaticPaymentMethods);
        }
    }
}