namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    /// The stripe refund response class
    /// </summary>
    public class StripeRefundResponse
    {
        /// <summary>
        /// Gets or sets the value of the refund id
        /// </summary>
        public string RefundId { get; set; }

        /// <summary>
        /// Gets or sets the value of the amount refunded
        /// </summary>
        public long AmountRefunded { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the value of the status
        /// </summary>
        public string Status { get; set; }
    }
}