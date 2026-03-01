namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    /// The stripe refund request class
    /// </summary>
    public class StripeRefundRequest
    {
        /// <summary>
        /// Gets or sets the value of the payment intent id
        /// </summary>
        public string PaymentIntentId { get; set; }

        /// <summary>
        /// Gets or sets the value of the amount
        /// </summary>
        public long? Amount { get; set; }

        /// <summary>
        /// Gets or sets the value of the reason
        /// </summary>
        public string Reason { get; set; }
    }
}