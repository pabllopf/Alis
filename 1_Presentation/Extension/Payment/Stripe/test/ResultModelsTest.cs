// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ResultModelsTest.cs
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
    ///     Tests for result models (CheckoutSessionResult, PaymentIntentResult, RefundResult)
    /// </summary>
    public class ResultModelsTest
    {
        #region CheckoutSessionResult Tests

        /// <summary>
        /// Tests that checkout session result can be instantiated
        /// </summary>
        [Fact]
        public void CheckoutSessionResult_CanBeInstantiated()
        {
            // Act
            CheckoutSessionResult result = new CheckoutSessionResult();

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that checkout session result all properties can be set
        /// </summary>
        [Fact]
        public void CheckoutSessionResult_AllPropertiesCanBeSet()
        {
            // Arrange & Act
            CheckoutSessionResult result = new CheckoutSessionResult
            {
                SessionId = "cs_test_123",
                Url = "https://checkout.stripe.com/c/pay/cs_test_123",
                PaymentIntentId = "pi_test_456",
                ProductId = "prod_001",
                Quantity = 3,
                UnitAmount = 1999,
                Currency = "usd"
            };

            // Assert
            Assert.Equal("cs_test_123", result.SessionId);
            Assert.Equal("https://checkout.stripe.com/c/pay/cs_test_123", result.Url);
            Assert.Equal("pi_test_456", result.PaymentIntentId);
            Assert.Equal("prod_001", result.ProductId);
            Assert.Equal(3, result.Quantity);
            Assert.Equal(1999, result.UnitAmount);
            Assert.Equal("usd", result.Currency);
        }

        #endregion

        #region PaymentIntentResult Tests

        /// <summary>
        /// Tests that payment intent result can be instantiated
        /// </summary>
        [Fact]
        public void PaymentIntentResult_CanBeInstantiated()
        {
            // Act
            PaymentIntentResult result = new PaymentIntentResult();

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that payment intent result all properties can be set
        /// </summary>
        [Fact]
        public void PaymentIntentResult_AllPropertiesCanBeSet()
        {
            // Arrange & Act
            PaymentIntentResult result = new PaymentIntentResult
            {
                PaymentIntentId = "pi_test_789",
                ClientSecret = "pi_test_789_secret_abc123",
                ProductId = "prod_002",
                Amount = 2999,
                Currency = "eur",
                Status = PaymentStatus.Succeeded
            };

            // Assert
            Assert.Equal("pi_test_789", result.PaymentIntentId);
            Assert.Equal("pi_test_789_secret_abc123", result.ClientSecret);
            Assert.Equal("prod_002", result.ProductId);
            Assert.Equal(2999, result.Amount);
            Assert.Equal("eur", result.Currency);
            Assert.Equal(PaymentStatus.Succeeded, result.Status);
        }

        /// <summary>
        /// Tests that payment intent result status defaults to unknown
        /// </summary>
        [Fact]
        public void PaymentIntentResult_StatusDefaultsToUnknown()
        {
            // Arrange & Act
            PaymentIntentResult result = new PaymentIntentResult();

            // Assert
            Assert.Equal(PaymentStatus.Unknown, result.Status);
        }

        #endregion

        #region RefundResult Tests

        /// <summary>
        /// Tests that refund result can be instantiated
        /// </summary>
        [Fact]
        public void RefundResult_CanBeInstantiated()
        {
            // Act
            RefundResult result = new RefundResult();

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that refund result all properties can be set
        /// </summary>
        [Fact]
        public void RefundResult_AllPropertiesCanBeSet()
        {
            // Arrange & Act
            RefundResult result = new RefundResult
            {
                RefundId = "re_test_001",
                PaymentIntentId = "pi_test_123",
                AmountRefunded = 1500,
                Currency = "gbp",
                Status = "succeeded"
            };

            // Assert
            Assert.Equal("re_test_001", result.RefundId);
            Assert.Equal("pi_test_123", result.PaymentIntentId);
            Assert.Equal(1500, result.AmountRefunded);
            Assert.Equal("gbp", result.Currency);
            Assert.Equal("succeeded", result.Status);
        }

        #endregion
    }
}

