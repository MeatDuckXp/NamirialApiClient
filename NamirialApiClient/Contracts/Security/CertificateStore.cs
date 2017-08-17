using System.Xml.Serialization;

namespace NamirialApiClient.Contracts.Security
{
    /// <summary>
    ///     Defines possible certificate stores
    /// </summary>
    public enum CertificateStore
    {
        /// <summary>
        ///     Uses the servers certificate store
        /// </summary>
        [XmlEnum("default")] Default,

        /// <summary>
        ///     Uses the Custom certificate store
        /// </summary>
        [XmlEnum("custom")] Custom
    }
}