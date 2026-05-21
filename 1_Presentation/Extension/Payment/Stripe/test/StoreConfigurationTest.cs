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