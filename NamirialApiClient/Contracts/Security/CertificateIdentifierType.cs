using System.Xml.Serialization;

namespace NamirialApiClient.Contracts.Security
{
    /// <summary>
    ///     Defines certificate identifier type
    /// </summary>
    public enum CertificateIdentifierType
    {
        /// <summary>
        ///     Subject
        /// </summary>
        [XmlEnum("Subject")] Subject,

        /// <summary>
        ///     Sha1Thumbprint
        /// </summary>
        [XmlEnum("Sha1Thumbprint")] Sha1Thumbprint
    }
}