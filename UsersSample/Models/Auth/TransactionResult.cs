using System.Net.Http.Headers;

namespace UsersSample.Models.Auth
{
    /// <summary>
    /// Class for the transaction result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TransactionResult<T>
    {
        /// <summary>
        /// The success
        /// </summary>
        public bool Success;

        /// <summary>
        /// Gets or sets the HTTP status.
        /// </summary>
        /// <value>
        /// The HTTP status.
        /// </value>
        public int HttpStatus { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the raw value.
        /// </summary>
        /// <value>
        /// The raw value.
        /// </value>
        public string RawValue { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The headers
        /// </summary>
        public HttpResponseHeaders Headers;
    }
}
