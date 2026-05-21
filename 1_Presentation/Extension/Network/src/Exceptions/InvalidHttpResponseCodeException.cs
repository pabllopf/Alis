

using System;

namespace Alis.Extension.Network.Exceptions
{
    /// <summary>
    ///     The invalid http response code exception class
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public partial class InvalidHttpResponseCodeException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidHttpResponseCodeException" /> class
        /// </summary>
        public InvalidHttpResponseCodeException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidHttpResponseCodeException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public InvalidHttpResponseCodeException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidHttpResponseCodeException" /> class
        /// </summary>
        /// <param name="responseCode">The response code</param>
        /// <param name="responseDetails">The response details</param>
        /// <param name="responseHeader">The response header</param>
        public InvalidHttpResponseCodeException(string responseCode, string responseDetails, string responseHeader) :
            base(responseCode)
        {
            ResponseCode = responseCode;
            ResponseDetails = responseDetails;
            ResponseHeader = responseHeader;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidHttpResponseCodeException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="inner">The inner</param>
        public InvalidHttpResponseCodeException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        ///     Gets or sets the value of the response code
        /// </summary>
        public string ResponseCode { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the response header
        /// </summary>
        public string ResponseHeader { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the response details
        /// </summary>
        public string ResponseDetails { get; private set; }
    }
}