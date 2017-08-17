using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Common
{
    /// <summary>
    ///     Defines Draft Options Configuration
    /// </summary>
    [Serializable]
    [XmlRoot("draftOptions", Namespace = "", IsNullable = false)]
    public class DraftOptions : ServiceMessageBase<DraftOptions>
    {
        /// <summary>
        ///     Gets or Sets After Send Redirect URL
        /// </summary>
        [XmlElement("afterSendRedirectUrl", typeof (string))]
        public string AfterSendRedirectUrl { get; set; }

        /// <summary>
        ///     Gets or Sets After Send Callback URL
        /// </summary>
        [XmlElement("afterSendCallbackUrl", typeof (string))]
        public string AfterSendCallbackUrl { get; set; }

        /// <summary>
        ///     Gets or Sets Redirect Policy
        /// </summary>
        [XmlElement("redirectPolicy", typeof (RedirectPolicy))]
        public RedirectPolicy RedirectPolicy { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Agent Redirect
        /// </summary>
        /// <remarks>
        ///     This flag if set to true allows us to access the desiger screen via this url
        ///     https://www.significant.com/AgentRedirect/index?draftid=
        ///     without the need for the user to log in.
        /// </remarks>
        [XmlElement("allowAgentRedirect", typeof (bool))]
        public bool AllowAgentRedirect { get; set; }

        /// <summary>
        ///     Gets or sets IFrame While list
        /// </summary>
        /// <remarks>
        ///     Is not a list in a container representing a true list sense, rather is it semicolon separated string
        ///     <iFrameWhiteList>http://172.16.17.181/iframe/;http://foo.org</iFrameWhiteList>
        /// </remarks>
        [XmlElement("iFrameWhiteList", typeof (string))]
        public string IFrameWhiteList { get; set; }
    }
}