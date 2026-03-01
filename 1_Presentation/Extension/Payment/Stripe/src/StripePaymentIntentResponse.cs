namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    /// The stripe payment intent response class
    /// </summary>
    public class StripePaymentIntentResponse
    {
        /// <summary>
        /// Gets or sets the value of the payment intent id
        /// </summary>
        public string PaymentIntentId { get; set; }

        /// <summary>
        /// Gets or sets the value of the client secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the value of the status
        /// </summary>
        public string Status { get; set; }
    }
}