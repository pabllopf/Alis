using System;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     High-volume theory tests for StoreManager payment status mapping.
    /// </summary>
    public class PaymentStatusBulkTheoryTest
    {
        /// <summary>
        /// Tests that get payment status async bulk mappings should map expected status
        /// </summary>
        /// <param name="stripeStatus">The stripe status</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [MemberData(nameof(StripeTheoryData.PaymentStatusMappingCases), MemberType = typeof(StripeTheoryData))]
        public async Task GetPaymentStatusAsync_BulkMappings_ShouldMapExpectedStatus(string stripeStatus, PaymentStatus expected)
        {
            Mock<IStripeGatewayClient> gateway = new Mock<IStripeGatewayClient>();
            gateway
                .Setup(x => x.GetPaymentIntentAsync("pi_bulk", It.IsAny<CancellationToken>()))
                .ReturnsAsync(new StripePaymentIntentResponse
                {
                    PaymentIntentId = "pi_bulk",
                    ClientSecret = "pi_bulk_secret",
                    Status = stripeStatus
                });

            StoreManager manager = new StoreManager(new Context(), gateway.Object);
            await manager.InitializeAsync(new StoreConfiguration
            {
                SecretApiKey = "sk_test_bulk_status",
                DefaultCurrency = "usd",
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            });

            PaymentStatus result = await manager.GetPaymentStatusAsync("pi_bulk");

            Assert.Equal(expected, result);
        }
    }
}

