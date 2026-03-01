namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    /// The stripe gateway client interface
    /// </summary>
    public interface IStripeGatewayClient
    {
        /// <summary>
        /// Configures the secret api key
        /// </summary>
        /// <param name="secretApiKey">The secret api key</param>
        void Configure(string secretApiKey);

        /// <summary>
        /// Creates the checkout session using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe checkout session response</returns>
        System.Threading.Tasks.Task<StripeCheckoutSessionResponse> CreateCheckoutSessionAsync(
            StripeCheckoutSessionRequest request,
            System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates the payment intent using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe payment intent response</returns>
        System.Threading.Tasks.Task<StripePaymentIntentResponse> CreatePaymentIntentAsync(
            StripePaymentIntentRequest request,
            System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the payment intent using the specified payment intent id
        /// </summary>
        /// <param name="paymentIntentId">The payment intent id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe payment intent response</returns>
        System.Threading.Tasks.Task<StripePaymentIntentResponse> GetPaymentIntentAsync(
            string paymentIntentId,
            System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates the refund using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe refund response</returns>
        System.Threading.Tasks.Task<StripeRefundResponse> CreateRefundAsync(
            StripeRefundRequest request,
            System.Threading.CancellationToken cancellationToken = default);
    }
}