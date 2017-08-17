using System.Xml.Serialization;

namespace NamirialApiClient.Contracts.Security
{
    /// <summary>
    ///     Authentication Methods
    /// </summary>
    public enum AuthenticationMethod
    {
        /// <summary>
        ///     Pin
        /// </summary>
        [XmlEnum("Pin")] Pin = 0,

        /// <summary>
        ///     Sms
        /// </summary>
        [XmlEnum("Sms")] Sms = 1,

        /// <summary>
        ///     WindowsLive
        /// </summary>
        [XmlEnum("WindowsLive")] WindowsLive = 2
    }
}