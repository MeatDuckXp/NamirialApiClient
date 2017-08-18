namespace NamirialApiClient.Configuration
{
    /// <summary>
    ///     Configuration Holder for Namirial API operations
    /// </summary>
    public class NamirialApiConfiguration
    {
        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        /// <remarks>
        ///     Default value is https://www.significant.com/api.asmx
        /// </remarks>
        public string ServiceEndpointUrl { get; set; }

        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        public string OrganizationKey { get; set; }

        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        public string UserLoginName { get; set; }
                 
        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        public string DefaultDraftOptionAfterSendCallbackUrl { get; set; }

        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        public string DefaultDraftOptionAfterSendRedirectUrl { get; set; }

        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        public string DefaultRedirectPolicy { get; set; }

        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        public string DefaultEnvelopeName { get; set; }

        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        public string DefaultRecipientType { get; set; }

        #region Envelope Level Call Back URLS

        /// <summary>
        ///     Gets or Sets AppendEnvelopeIdToUrl
        /// </summary>
        /// <remarks>
        ///     If true, the call back URLs will have ##EnvelopeId## appended to the query string
        /// </remarks>
        public bool AppendEnvelopeIdToUrl { get; set; }

        /// <summary>
        ///     Gets or Sets AppendDraftIdToUrl
        /// </summary>
        /// <remarks>
        ///     If true, the call back URLs will have ##DraftId## appended to the query string
        /// </remarks>
        public bool AppendDraftIdToUrl { get; set; }

        /// <summary>
        ///     Gets or Sets AppendActionChangedToUrl
        /// </summary>
        /// <remarks>
        ///     If true, the call back URLs will have ##Action## appended to the query string
        /// </remarks>
        public bool AppendActionChangedToUrl { get; set; }

        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        public string DefaultEnvelopeCallbackUrl { get; set; }

        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        public string DefaultEnvelopeStatusUpdateCallbackUrl { get; set; }

        /// <summary>
        ///     Gets or Sets ClientConnectUrl
        /// </summary>
        public string ClientConnectUrl { get; set; }

        #endregion
    }
}