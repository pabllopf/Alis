

using System;
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Tests for result models (CheckoutSessionResult, PaymentIntentResult, RefundResult)
    /// </summary>
    public class ResultModelsTest
    {
        /// <summary>
        ///     Tests that checkout session result can be instantiated
        /// </summary>
        [Fact]
        public void CheckoutSessionResult_CanBeInstantiated()
        {
            CheckoutSessionResult result = new CheckoutSessionResult();

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that checkout session result all properties can be set
        /// </summary>
        [Fact]
        public void CheckoutSessionResult_AllPropertiesCanBeSet()
        {
            CheckoutSessionResult result = new CheckoutSessionResult
            {
                SessionId = "cs_test_123",
                Url = new Uri("https://checkout.stripe.com/c/pay/cs_test_123"),
                PaymentIntentId = "pi_test_456",
                ProductId = "prod_001",
                Quantity = 3,
                UnitAmount = 1999,
                Currency = "usd"
            };

            Assert.Equal("cs_test_123", result.SessionId);
            Assert.Equal("https://checkout.stripe.com/c/pay/cs_test_123", result.Url.ToString());
            Assert.Equal("pi_test_456", result.PaymentIntentId);
            Assert.Equal("prod_001", result.ProductId);
            Assert.Equal(3, result.Quantity);
            Assert.Equal(1999, result.UnitAmount);
            Assert.Equal("usd", result.Currency);
        }


        /// <summary>
        ///     Tests that payment intent result can be instantiated
        /// </summary>
        [Fact]
        public void PaymentIntentResult_CanBeInstantiated()
        {
            PaymentIntentResult result = new PaymentIntentResult();

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that payment intent result all properties can be set
        /// </summary>
        [Fact]
        public void PaymentIntentResult_AllPropertiesCanBeSet()
        {
            PaymentIntentResult result = new PaymentIntentResult
            {
                PaymentIntentId = "pi_test_789",
                ClientSecret = "pi_test_789_secret_abc123",
                ProductId = "prod_002",
                Amount = 2999,
                Currency = "eur",
                Status = PaymentStatus.Succeeded
            };

            Assert.Equal("pi_test_789", result.PaymentIntentId);
            Assert.Equal("pi_test_789_secret_abc123", result.ClientSecret);
            Assert.Equal("prod_002", result.ProductId);
            Assert.Equal(2999, result.Amount);
            Assert.Equal("eur", result.Currency);
            Assert.Equal(PaymentStatus.Succeeded, result.Status);
        }

        /// <summary>
        ///     Tests that payment intent result status defaults to unknown
        /// </summary>
        [Fact]
        public void PaymentIntentResult_StatusDefaultsToUnknown()
        {
            PaymentIntentResult result = new PaymentIntentResult();

            Assert.Equal(PaymentStatus.Unknown, result.Status);
        }


        /// <summary>
        ///     Tests that refund result can be instantiated
        /// </summary>
        [Fact]
        public void RefundResult_CanBeInstantiated()
        {
            RefundResult result = new RefundResult();

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that refund result all properties can be set
        /// </summary>
        [Fact]
        public void RefundResult_AllPropertiesCanBeSet()
        {
            RefundResult result = new RefundResult
            {
                RefundId = "re_test_001",
                PaymentIntentId = "pi_test_123",
                AmountRefunded = 1500,
                Currency = "gbp",
                Status = "succeeded"
            };

            Assert.Equal("re_test_001", result.RefundId);
            Assert.Equal("pi_test_123", result.PaymentIntentId);
            Assert.Equal(1500, result.AmountRefunded);
            Assert.Equal("gbp", result.Currency);
            Assert.Equal("succeeded", result.Status);
        }
    }
}