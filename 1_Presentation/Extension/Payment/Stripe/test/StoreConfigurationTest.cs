// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StoreConfigurationTest.cs
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

using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Tests for StoreConfiguration model
    /// </summary>
    public class StoreConfigurationTest
    {
        [Fact]
        public void Constructor_InitializesWithDefaultValues()
        {
            // Act
            StoreConfiguration config = new StoreConfiguration();

            // Assert
            Assert.Equal("usd", config.DefaultCurrency);
            Assert.Equal("https://example.com/payment/success", config.SuccessUrl);
            Assert.Equal("https://example.com/payment/cancel", config.CancelUrl);
            Assert.True(config.EnableAutomaticPaymentMethods);
        }

        [Fact]
        public void SecretApiKey_CanBeSetAndRetrieved()
        {
            // Arrange
            StoreConfiguration config = new StoreConfiguration();
            string apiKey = "sk_test_12345";

            // Act
            config.SecretApiKey = apiKey;

            // Assert
            Assert.Equal(apiKey, config.SecretApiKey);
        }

        [Fact]
        public void DefaultCurrency_CanBeOverridden()
        {
            // Arrange
            StoreConfiguration config = new StoreConfiguration();

            // Act
            config.DefaultCurrency = "eur";

            // Assert
            Assert.Equal("eur", config.DefaultCurrency);
        }

        [Fact]
        public void SuccessUrl_CanBeCustomized()
        {
            // Arrange
            StoreConfiguration config = new StoreConfiguration();
            string customUrl = "https://myapp.com/success";

            // Act
            config.SuccessUrl = customUrl;

            // Assert
            Assert.Equal(customUrl, config.SuccessUrl);
        }

        [Fact]
        public void CancelUrl_CanBeCustomized()
        {
            // Arrange
            StoreConfiguration config = new StoreConfiguration();
            string customUrl = "https://myapp.com/cancel";

            // Act
            config.CancelUrl = customUrl;

            // Assert
            Assert.Equal(customUrl, config.CancelUrl);
        }

        [Fact]
        public void EnableAutomaticPaymentMethods_CanBeDisabled()
        {
            // Arrange
            StoreConfiguration config = new StoreConfiguration();

            // Act
            config.EnableAutomaticPaymentMethods = false;

            // Assert
            Assert.False(config.EnableAutomaticPaymentMethods);
        }
    }
}

