// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StripeRequestResponseModelsTest.cs
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
using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Comprehensive tests for all Stripe request and response models
    /// </summary>
    public class StripeRequestResponseModelsTest
    {
        #region StripeCheckoutSessionRequest Tests

        /// <summary>
        /// Tests that stripe checkout session request properties initialize correctly
        /// </summary>
        [Fact]
        public void StripeCheckoutSessionRequest_PropertiesInitializeCorrectly()
        {
            // Arrange & Act
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductId = "prod_123",
                ProductName = "Test Product",
                ProductDescription = "Test Description",
                Currency = "usd",
                UnitAmount = 1000,
                Quantity = 2,
                SuccessUrl = new Uri("https://success.com"),
                CancelUrl = new Uri("https://cancel.com"),
                CustomerEmail = "test@example.com",
                Metadata = new Dictionary<string, string> { { "key", "value" } }
            };

            // Assert
            Assert.Equal("prod_123", request.ProductId);
            Assert.Equal("Test Product", request.ProductName);
            Assert.Equal("Test Description", request.ProductDescription);
            Assert.Equal("usd", request.Currency);
            Assert.Equal(1000, request.UnitAmount);
            Assert.Equal(2, request.Quantity);
            Assert.Equal("https://success.com/", request.SuccessUrl.ToString());
            Assert.Equal("https://cancel.com/", request.CancelUrl.ToString());
            Assert.Equal("test@example.com", request.CustomerEmail);
            Assert.NotNull(request.Metadata);
        }
        
        
        
        /// <summary>
        /// Tests that stripe checkout session request metadata can be null
        /// </summary>
        [Fact]
        public void StripeCheckoutSessionRequest_MetadataCanBeNull()
        {
            // Arrange & Act
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductId = "prod_123",
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 500,
                Quantity = 1,
                SuccessUrl = new Uri("https://success.com"),
                CancelUrl = new Uri("https://cancel.com"),
                Metadata = null
            };

            // Assert
            Assert.Null(request.Metadata);
        }

        #endregion

        #region StripeCheckoutSessionResponse Tests

        /// <summary>
        /// Tests that stripe checkout session response properties initialize correctly
        /// </summary>
        [Fact]
        public void StripeCheckoutSessionResponse_PropertiesInitializeCorrectly()
        {
            // Arrange & Act
            StripeCheckoutSessionResponse response = new StripeCheckoutSessionResponse
            {
                SessionId = "cs_test_123",
                Url = new Uri("https://checkout.stripe.com"),
                PaymentIntentId = "pi_test_456"
            };

            // Assert
            Assert.Equal("cs_test_123", response.SessionId);
            Assert.Equal("https://checkout.stripe.com/", response.Url.ToString());
            Assert.Equal("pi_test_456", response.PaymentIntentId);
        }

        /// <summary>
        /// Tests that stripe checkout session response supports null properties
        /// </summary>
        [Fact]
        public void StripeCheckoutSessionResponse_SupportsNullProperties()
        {
            // Arrange & Act
            StripeCheckoutSessionResponse response = new StripeCheckoutSessionResponse
            {
                SessionId = null,
                Url = null,
                PaymentIntentId = null
            };

            // Assert
            Assert.Null(response.SessionId);
            Assert.Null(response.Url);
            Assert.Null(response.PaymentIntentId);
        }

        #endregion

        #region StripePaymentIntentRequest Tests

        /// <summary>
        /// Tests that stripe payment intent request properties initialize correctly
        /// </summary>
        [Fact]
        public void StripePaymentIntentRequest_PropertiesInitializeCorrectly()
        {
            // Arrange & Act
            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                ProductId = "prod_456",
                Amount = 5000,
                Currency = "eur",
                CustomerId = "cus_123",
                Description = "Test Payment",
                Metadata = new Dictionary<string, string> { { "order_id", "order_789" } },
                EnableAutomaticPaymentMethods = true
            };

            // Assert
            Assert.Equal("prod_456", request.ProductId);
            Assert.Equal(5000, request.Amount);
            Assert.Equal("eur", request.Currency);
            Assert.Equal("cus_123", request.CustomerId);
            Assert.Equal("Test Payment", request.Description);
            Assert.NotNull(request.Metadata);
            Assert.True(request.EnableAutomaticPaymentMethods);
        }

        /// <summary>
        /// Tests that stripe payment intent request enable automatic payment methods defaults to false
        /// </summary>
        [Fact]
        public void StripePaymentIntentRequest_EnableAutomaticPaymentMethodsDefaultsToFalse()
        {
            // Arrange & Act
            StripePaymentIntentRequest request = new StripePaymentIntentRequest();

            // Assert
            Assert.False(request.EnableAutomaticPaymentMethods);
        }

        #endregion

        #region StripePaymentIntentResponse Tests

        /// <summary>
        /// Tests that stripe payment intent response properties initialize correctly
        /// </summary>
        [Fact]
        public void StripePaymentIntentResponse_PropertiesInitializeCorrectly()
        {
            // Arrange & Act
            StripePaymentIntentResponse response = new StripePaymentIntentResponse
            {
                PaymentIntentId = "pi_test_789",
                ClientSecret = "pi_test_789_secret",
                Status = "succeeded"
            };

            // Assert
            Assert.Equal("pi_test_789", response.PaymentIntentId);
            Assert.Equal("pi_test_789_secret", response.ClientSecret);
            Assert.Equal("succeeded", response.Status);
        }

        /// <summary>
        /// Tests that stripe payment intent response status can be any valid status
        /// </summary>
        /// <param name="status">The status</param>
        [Theory]
        [InlineData("requires_payment_method")]
        [InlineData("requires_confirmation")]
        [InlineData("requires_action")]
        [InlineData("processing")]
        [InlineData("requires_capture")]
        [InlineData("canceled")]
        [InlineData("succeeded")]
        public void StripePaymentIntentResponse_StatusCanBeAnyValidStatus(string status)
        {
            // Arrange & Act
            StripePaymentIntentResponse response = new StripePaymentIntentResponse
            {
                PaymentIntentId = "pi_test",
                ClientSecret = "secret",
                Status = status
            };

            // Assert
            Assert.Equal(status, response.Status);
        }

        #endregion

        #region StripeRefundRequest Tests

        /// <summary>
        /// Tests that stripe refund request properties initialize correctly
        /// </summary>
        [Fact]
        public void StripeRefundRequest_PropertiesInitializeCorrectly()
        {
            // Arrange & Act
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_refund_123",
                Amount = 1000,
                Reason = "requested_by_customer"
            };

            // Assert
            Assert.Equal("pi_refund_123", request.PaymentIntentId);
            Assert.Equal(1000, request.Amount);
            Assert.Equal("requested_by_customer", request.Reason);
        }

        /// <summary>
        /// Tests that stripe refund request amount can be null
        /// </summary>
        [Fact]
        public void StripeRefundRequest_AmountCanBeNull()
        {
            // Arrange & Act
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_full_refund",
                Amount = null,
                Reason = "duplicate"
            };

            // Assert
            Assert.Equal("pi_full_refund", request.PaymentIntentId);
            Assert.Null(request.Amount);
            Assert.Equal("duplicate", request.Reason);
        }

        /// <summary>
        /// Tests that stripe refund request reason can be various values
        /// </summary>
        /// <param name="reason">The reason</param>
        [Theory]
        [InlineData("requested_by_customer")]
        [InlineData("duplicate")]
        [InlineData("fraudulent")]
        [InlineData(null)]
        public void StripeRefundRequest_ReasonCanBeVariousValues(string reason)
        {
            // Arrange & Act
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_test",
                Amount = 500,
                Reason = reason
            };

            // Assert
            Assert.Equal(reason, request.Reason);
        }

        #endregion

        #region StripeRefundResponse Tests

        /// <summary>
        /// Tests that stripe refund response properties initialize correctly
        /// </summary>
        [Fact]
        public void StripeRefundResponse_PropertiesInitializeCorrectly()
        {
            // Arrange & Act
            StripeRefundResponse response = new StripeRefundResponse
            {
                RefundId = "re_refund_123",
                AmountRefunded = 2000,
                Currency = "gbp",
                Status = "succeeded"
            };

            // Assert
            Assert.Equal("re_refund_123", response.RefundId);
            Assert.Equal(2000, response.AmountRefunded);
            Assert.Equal("gbp", response.Currency);
            Assert.Equal("succeeded", response.Status);
        }

        /// <summary>
        /// Tests that stripe refund response supports various statuses
        /// </summary>
        [Fact]
        public void StripeRefundResponse_SupportsVariousStatuses()
        {
            // Arrange & Act
            StripeRefundResponse response1 = new StripeRefundResponse { Status = "succeeded" };
            StripeRefundResponse response2 = new StripeRefundResponse { Status = "pending" };
            StripeRefundResponse response3 = new StripeRefundResponse { Status = "failed" };

            // Assert
            Assert.Equal("succeeded", response1.Status);
            Assert.Equal("pending", response2.Status);
            Assert.Equal("failed", response3.Status);
        }

        #endregion

        #region Cross-Model Tests

        /// <summary>
        /// Tests that all request models can be instantiated empty
        /// </summary>
        [Fact]
        public void AllRequestModels_CanBeInstantiatedEmpty()
        {
            // Act
            StripeCheckoutSessionRequest checkoutRequest = new StripeCheckoutSessionRequest();
            StripePaymentIntentRequest paymentRequest = new StripePaymentIntentRequest();
            StripeRefundRequest refundRequest = new StripeRefundRequest();

            // Assert
            Assert.NotNull(checkoutRequest);
            Assert.NotNull(paymentRequest);
            Assert.NotNull(refundRequest);
        }

        /// <summary>
        /// Tests that all response models can be instantiated empty
        /// </summary>
        [Fact]
        public void AllResponseModels_CanBeInstantiatedEmpty()
        {
            // Act
            StripeCheckoutSessionResponse checkoutResponse = new StripeCheckoutSessionResponse();
            StripePaymentIntentResponse paymentResponse = new StripePaymentIntentResponse();
            StripeRefundResponse refundResponse = new StripeRefundResponse();

            // Assert
            Assert.NotNull(checkoutResponse);
            Assert.NotNull(paymentResponse);
            Assert.NotNull(refundResponse);
        }

        /// <summary>
        /// Tests that metadata dictionaries are independent
        /// </summary>
        [Fact]
        public void MetadataDictionaries_AreIndependent()
        {
            // Arrange
            Dictionary<string, string> metadata1 = new Dictionary<string, string> { { "key1", "value1" } };
            Dictionary<string, string> metadata2 = new Dictionary<string, string> { { "key2", "value2" } };

            StripeCheckoutSessionRequest request1 = new StripeCheckoutSessionRequest { Metadata = metadata1 };
            StripePaymentIntentRequest request2 = new StripePaymentIntentRequest { Metadata = metadata2 };

            // Act
            metadata1["key1"] = "modified";

            // Assert
            Assert.Equal("modified", metadata1["key1"]);
            Assert.Equal("value2", metadata2["key2"]);
            Assert.NotEqual(metadata1, metadata2);
        }

        #endregion
    }
}

