namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    /// The store configuration class
    /// </summary>
    public class StoreConfiguration
    {
        /// <summary>
        /// Gets or sets the value of the secret api key
        /// </summary>
        public string SecretApiKey { get; set; }

        /// <summary>
        /// Gets or sets the value of the default currency
        /// </summary>
        public string DefaultCurrency { get; set; } = "usd";

        /// <summary>
        /// Gets or sets the value of the success url
        /// </summary>
        public string SuccessUrl { get; set; } = "https://example.com/payment/success";

        /// <summary>
        /// Gets or sets the value of the cancel url
        /// </summary>
        public string CancelUrl { get; set; } = "https://example.com/payment/cancel";

        /// <summary>
        /// Gets or sets the value of the enable automatic payment methods
        /// </summary>
        public bool EnableAutomaticPaymentMethods { get; set; } = true;
    }
}

