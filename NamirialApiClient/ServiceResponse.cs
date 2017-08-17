using System.Collections.Generic;

namespace NamirialApiClient
{
    /// <summary>
    ///     Defines Service Response Containing The (namirial) web API response.
    /// </summary>
    public class ServiceResponse
    {
        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        public ServiceResponse()
        {
            Errors = new List<ErroMessage>();
        }

        #endregion

        /// <summary>
        ///     Error Message Format
        /// </summary>
        public class ErroMessage
        {
            /// <summary>
            ///     Gets or Sets Error Id
            /// </summary>
            public string ErrorId { get; set; }

            /// <summary>
            ///     Gets or Sets Error Message
            /// </summary>
            public string ErrorMessage { get; set; }
        }

        #region Properties

        /// <summary>
        ///     Gets a value indicating whether request has been completed successfully
        /// </summary>
        public bool Success => Errors.Count == 0;

        /// <summary>
        ///     Gets Errors
        /// </summary>
        public IList<ErroMessage> Errors { get; set; }

        /// <summary>
        ///     Gets or Sets Result object
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        ///     Gets or Sets
        /// </summary>
        public string OriginalResult { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds Error Message to Error Message Collection
        /// </summary>
        /// <param name="message">Message</param>
        public void AddErrorMessage(ErroMessage message)
        {
            if (message == null)
            {
                return;
            }

            Errors.Add(message);
        }

        /// <summary>
        ///     Adds Error Message to Error Message Collection
        /// </summary>
        /// <param name="messages">Error Message Collection</param>
        public void AddErrorMessage(IList<ErroMessage> messages)
        {
            if (messages == null)
            {
                return;
            }

            foreach (var erroMessage in messages)
            {
                Errors.Add(erroMessage);
            }
        }

        /// <summary>
        ///     Adds Error Message to Error Message Collection
        /// </summary>
        /// <param name="message">Message</param>
        public void AddErrorMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            Errors.Add(new ErroMessage {ErrorMessage = message});
        }

        /// <summary>
        ///     Return Result as Type T
        /// </summary>
        /// <typeparam name="T">Type T</typeparam>
        /// <returns>Result</returns>
        public T GetResult<T>() where T : class
        {
            return Result as T;
        }

        /// <summary>
        ///     Adds Error Message to Error Message Collection
        /// </summary>
        /// <param name="errorId">Error Id</param>
        /// <param name="message">Message</param>
        public void AddErrorMessage(string errorId, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            Errors.Add(new ErroMessage {ErrorId = errorId, ErrorMessage = message});
        }

        #endregion
    }
}