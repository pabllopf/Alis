namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    /// The payment intent result class
    /// </summary>
    public class PaymentIntentResult
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
        /// Gets or sets the value of the product id
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the value of the amount
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the value of the status
        /// </summary>
        public PaymentStatus Status { get; set; }
    }
}