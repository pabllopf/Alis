

using System;
using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Tests for Stripe request models
    /// </summary>
    public class StripeRequestModelsTest
    {
        /// <summary>
        ///     Tests that stripe checkout session request can be instantiated
        /// </summary>
        [Fact]
        public void StripeCheckoutSessionRequest_CanBeInstantiated()
        {
            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest();

            Assert.NotNull(request);
        }

        /// <summary>
        ///     Tests that stripe checkout session request all properties can be set
        /// </summary>
        [Fact]
        public void StripeCheckoutSessionRequest_AllPropertiesCanBeSet()
        {
            Dictionary<string, string> metadata = new Dictionary<string, string>
            {
                {"user_id", "user_123"},
                {"order_type", "digital"}
            };

            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductId = "prod_001",
                ProductName = "Premium Pack",
                ProductDescription = "Premium features bundle",
                Currency = "usd",
                UnitAmount = 2999,
                Quantity = 1,
                SuccessUrl = new Uri("https://app.example.com/success"),
                CancelUrl = new Uri("https://app.example.com/cancel"),
                CustomerEmail = "customer@example.com",
                Metadata = metadata
            };

            Assert.Equal("prod_001", request.ProductId);
            Assert.Equal("Premium Pack", request.ProductName);
            Assert.Equal("Premium features bundle", request.ProductDescription);
            Assert.Equal("usd", request.Currency);
            Assert.Equal(2999, request.UnitAmount);
            Assert.Equal(1, request.Quantity);
            Assert.Equal("https://app.example.com/success", request.SuccessUrl.ToString());
            Assert.Equal("https://app.example.com/cancel", request.CancelUrl.ToString());
            Assert.Equal("customer@example.com", request.CustomerEmail);
            Assert.Equal(metadata, request.Metadata);
        }


        /// <summary>
        ///     Tests that stripe checkout session response can be instantiated
        /// </summary>
        [Fact]
        public void StripeCheckoutSessionResponse_CanBeInstantiated()
        {
            StripeCheckoutSessionResponse response = new StripeCheckoutSessionResponse();

            Assert.NotNull(response);
        }

        /// <summary>
        ///     Tests that stripe checkout session response all properties can be set
        /// </summary>
        [Fact]
        public void StripeCheckoutSessionResponse_AllPropertiesCanBeSet()
        {
            StripeCheckoutSessionResponse response = new StripeCheckoutSessionResponse
            {
                SessionId = "cs_test_session_123",
                Url = new Uri("https://checkout.stripe.com/c/pay/cs_test_session_123"),
                PaymentIntentId = "pi_test_intent_456"
            };

            Assert.Equal("cs_test_session_123", response.SessionId);
            Assert.Equal("https://checkout.stripe.com/c/pay/cs_test_session_123", response.Url.ToString());
            Assert.Equal("pi_test_intent_456", response.PaymentIntentId);
        }


        /// <summary>
        ///     Tests that stripe payment intent request can be instantiated
        /// </summary>
        [Fact]
        public void StripePaymentIntentRequest_CanBeInstantiated()
        {
            StripePaymentIntentRequest request = new StripePaymentIntentRequest();

            Assert.NotNull(request);
        }

        /// <summary>
        ///     Tests that stripe payment intent request all properties can be set
        /// </summary>
        [Fact]
        public void StripePaymentIntentRequest_AllPropertiesCanBeSet()
        {
            Dictionary<string, string> metadata = new Dictionary<string, string>
            {
                {"product_category", "virtual_goods"},
                {"transaction_type", "purchase"}
            };

            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                ProductId = "prod_002",
                Amount = 1999,
                Currency = "eur",
                CustomerId = "cus_test_789",
                Description = "Purchase of virtual goods",
                Metadata = metadata,
                EnableAutomaticPaymentMethods = true
            };

            Assert.Equal("prod_002", request.ProductId);
            Assert.Equal(1999, request.Amount);
            Assert.Equal("eur", request.Currency);
            Assert.Equal("cus_test_789", request.CustomerId);
            Assert.Equal("Purchase of virtual goods", request.Description);
            Assert.Equal(metadata, request.Metadata);
            Assert.True(request.EnableAutomaticPaymentMethods);
        }


        /// <summary>
        ///     Tests that stripe payment intent response can be instantiated
        /// </summary>
        [Fact]
        public void StripePaymentIntentResponse_CanBeInstantiated()
        {
            StripePaymentIntentResponse response = new StripePaymentIntentResponse();

            Assert.NotNull(response);
        }

        /// <summary>
        ///     Tests that stripe payment intent response all properties can be set
        /// </summary>
        [Fact]
        public void StripePaymentIntentResponse_AllPropertiesCanBeSet()
        {
            StripePaymentIntentResponse response = new StripePaymentIntentResponse
            {
                PaymentIntentId = "pi_test_intent_789",
                ClientSecret = "pi_test_intent_789_secret_xyz",
                Status = "succeeded"
            };

            Assert.Equal("pi_test_intent_789", response.PaymentIntentId);
            Assert.Equal("pi_test_intent_789_secret_xyz", response.ClientSecret);
            Assert.Equal("succeeded", response.Status);
        }


        /// <summary>
        ///     Tests that stripe refund request can be instantiated
        /// </summary>
        [Fact]
        public void StripeRefundRequest_CanBeInstantiated()
        {
            StripeRefundRequest request = new StripeRefundRequest();

            Assert.NotNull(request);
        }

        /// <summary>
        ///     Tests that stripe refund request all properties can be set
        /// </summary>
        [Fact]
        public void StripeRefundRequest_AllPropertiesCanBeSet()
        {
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_test_refund_123",
                Amount = 500,
                Reason = "requested_by_customer"
            };

            Assert.Equal("pi_test_refund_123", request.PaymentIntentId);
            Assert.Equal(500, request.Amount);
            Assert.Equal("requested_by_customer", request.Reason);
        }

        /// <summary>
        ///     Tests that stripe refund request amount can be null
        /// </summary>
        [Fact]
        public void StripeRefundRequest_AmountCanBeNull()
        {
            StripeRefundRequest request = new StripeRefundRequest
            {
                PaymentIntentId = "pi_test_full_refund",
                Amount = null,
                Reason = "fraudulent"
            };

            Assert.Equal("pi_test_full_refund", request.PaymentIntentId);
            Assert.Null(request.Amount);
            Assert.Equal("fraudulent", request.Reason);
        }


        /// <summary>
        ///     Tests that stripe refund response can be instantiated
        /// </summary>
        [Fact]
        public void StripeRefundResponse_CanBeInstantiated()
        {
            StripeRefundResponse response = new StripeRefundResponse();

            Assert.NotNull(response);
        }

        /// <summary>
        ///     Tests that stripe refund response all properties can be set
        /// </summary>
        [Fact]
        public void StripeRefundResponse_AllPropertiesCanBeSet()
        {
            StripeRefundResponse response = new StripeRefundResponse
            {
                RefundId = "re_test_001",
                AmountRefunded = 2500,
                Currency = "usd",
                Status = "succeeded"
            };

            Assert.Equal("re_test_001", response.RefundId);
            Assert.Equal(2500, response.AmountRefunded);
            Assert.Equal("usd", response.Currency);
            Assert.Equal("succeeded", response.Status);
        }
    }
}