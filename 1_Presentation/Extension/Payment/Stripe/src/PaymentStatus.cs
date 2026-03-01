namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    /// The payment status enum
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// The unknown payment status
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The requires payment method payment status
        /// </summary>
        RequiresPaymentMethod = 1,
        /// <summary>
        /// The requires confirmation payment status
        /// </summary>
        RequiresConfirmation = 2,
        /// <summary>
        /// The requires action payment status
        /// </summary>
        RequiresAction = 3,
        /// <summary>
        /// The processing payment status
        /// </summary>
        Processing = 4,
        /// <summary>
        /// The requires capture payment status
        /// </summary>
        RequiresCapture = 5,
        /// <summary>
        /// The canceled payment status
        /// </summary>
        Canceled = 6,
        /// <summary>
        /// The succeeded payment status
        /// </summary>
        Succeeded = 7
    }
}