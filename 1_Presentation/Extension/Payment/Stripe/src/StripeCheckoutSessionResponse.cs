namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    /// The stripe checkout session response class
    /// </summary>
    public class StripeCheckoutSessionResponse
    {
        /// <summary>
        /// Gets or sets the value of the session id
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the value of the url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the value of the payment intent id
        /// </summary>
        public string PaymentIntentId { get; set; }
    }
}