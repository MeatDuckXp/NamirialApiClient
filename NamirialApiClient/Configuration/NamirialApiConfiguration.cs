using NamirialApiClient.Contracts.Reciepients;

namespace NamirialApiClient.Configuration
{
    /// <summary>
    ///     Configuration Holder for Namirial API operations
    /// </summary>
    public class NamirialApiConfiguration
    {
        /// <summary>
        ///     Gets or Sets ClientUrl
        /// </summary>
        public string ClientUrl { get; set; }

        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
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
        ///     Gets or Sets DefaultRecipientType
        /// </summary>
        public RecipientType DefaultRecipientType { get; set; }

        #region Envelope Level Call Back URLS

        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        public string DefaultEnvelopeCallbackUrl { get; set; }

        /// <summary>
        ///     Gets or Sets ServiceEndpointUrl
        /// </summary>
        public string DefaultEnvelopeStatusUpdateCallbackUrl { get; set; }
        
        #endregion
    }
}