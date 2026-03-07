// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StoreProductTest.cs
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
            // Act
            StoreProduct product = new StoreProduct();

            // Assert
            Assert.Equal("usd", product.Currency);
            Assert.True(product.IsEnabled);
        }

        /// <summary>
        ///     Tests that id can be set and retrieved
        /// </summary>
        [Fact]
        public void Id_CanBeSetAndRetrieved()
        {
            // Arrange
            StoreProduct product = new StoreProduct();
            string id = "prod_test_001";

            // Act
            product.Id = id;

            // Assert
            Assert.Equal(id, product.Id);
        }

        /// <summary>
        ///     Tests that name can be set and retrieved
        /// </summary>
        [Fact]
        public void Name_CanBeSetAndRetrieved()
        {
            // Arrange
            StoreProduct product = new StoreProduct();
            string name = "Premium Coins Pack";

            // Act
            product.Name = name;

            // Assert
            Assert.Equal(name, product.Name);
        }

        /// <summary>
        ///     Tests that description can be set and retrieved
        /// </summary>
        [Fact]
        public void Description_CanBeSetAndRetrieved()
        {
            // Arrange
            StoreProduct product = new StoreProduct();
            string description = "10,000 virtual coins for in-game purchases";

            // Act
            product.Description = description;

            // Assert
            Assert.Equal(description, product.Description);
        }

        /// <summary>
        ///     Tests that price in cents can be set and retrieved
        /// </summary>
        [Fact]
        public void PriceInCents_CanBeSetAndRetrieved()
        {
            // Arrange
            StoreProduct product = new StoreProduct();
            long price = 1999;

            // Act
            product.PriceInCents = price;

            // Assert
            Assert.Equal(price, product.PriceInCents);
        }

        /// <summary>
        ///     Tests that currency can be overridden
        /// </summary>
        [Fact]
        public void Currency_CanBeOverridden()
        {
            // Arrange
            StoreProduct product = new StoreProduct();

            // Act
            product.Currency = "eur";

            // Assert
            Assert.Equal("eur", product.Currency);
        }

        /// <summary>
        ///     Tests that is enabled can be disabled
        /// </summary>
        [Fact]
        public void IsEnabled_CanBeDisabled()
        {
            // Arrange
            StoreProduct product = new StoreProduct();

            // Act
            product.IsEnabled = false;

            // Assert
            Assert.False(product.IsEnabled);
        }

        /// <summary>
        ///     Tests that all properties can be set together
        /// </summary>
        [Fact]
        public void AllProperties_CanBeSetTogether()
        {
            // Arrange & Act
            StoreProduct product = new StoreProduct
            {
                Id = "starter_pack",
                Name = "Starter Pack",
                Description = "Everything you need to get started",
                PriceInCents = 499,
                Currency = "gbp",
                IsEnabled = true
            };

            // Assert
            Assert.Equal("starter_pack", product.Id);
            Assert.Equal("Starter Pack", product.Name);
            Assert.Equal("Everything you need to get started", product.Description);
            Assert.Equal(499, product.PriceInCents);
            Assert.Equal("gbp", product.Currency);
            Assert.True(product.IsEnabled);
        }
    }
}