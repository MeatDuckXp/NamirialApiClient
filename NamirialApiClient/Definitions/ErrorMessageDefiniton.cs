namespace NamirialApiClient.Definitions
{
    /// <summary>
    ///     Defines Error Message Keys used when communicating with Namirial system
    /// </summary>
    internal class ErrorMessageDefiniton
    {
        /// <summary>
        ///     Envelope Id Not Provided
        /// </summary>
        public static string EnvelopeIdNotProvided { get; set; } = "ENVELOPE_ID_NOT_PROVIDED";

        /// <summary>
        ///     Document Id Not Provided
        /// </summary>
        public static string DocumentIdNotProvided { get; set; } = "DOCUMENT_ID_NOT_PROVIDED";

        /// <summary>
        ///     Envelope Not Found
        /// </summary>
        public static string EnvelopeNotFound { get; set; } = "ENVELOPE_NOT_FOUND";

        /// <summary>
        ///     Envelope Not Completed
        /// </summary>
        public static string EnvelopeNotCompleted { get; set; } = "ENVELOPE_NOT_COMPLETED";

        /// <summary>
        ///     No Service Response
        /// </summary>
        public static string NoServiceResponse { get; set; } = "NO_SERVICE_RESPONSE";

        /// <summary>
        ///     No Error Message Provided
        /// </summary>
        public static string NoErrorMessageProvided { get; set; } = "NO_ERROR_MESSAGES_PROVIDED";

        /// <summary>
        ///     Expiration Days Value Too Small
        /// </summary>
        public static string ExpirationDaysValueTooSmall { get; set; } = "EXPIRATION_DAYS_VALUE_TOO_SMALL";

        /// <summary>
        ///     Document Download Failed
        /// </summary>
        public static string DocumentDownloadFailed { get; set; } = "DOCUMENT_DOWNLOAD_FAILED";

        /// <summary>
        ///     File Content Missing
        /// </summary>
        public static string FileContentMissing { get; set; } = "FILE_CONTENT_MISSING";

        /// <summary>
        ///     Recipient List Not Provided
        /// </summary>
        public static string RecipientListNotProvided { get; set; } = "RECIPIENT_LIST_NOT_PROVIDED";

        /// <summary>
        ///     Document List Not Provided
        /// </summary>
        public static string DocumentListNotProvided { get; set; } = "DOCUMENT_LIST_NOT_PROVIDED";
    }
}