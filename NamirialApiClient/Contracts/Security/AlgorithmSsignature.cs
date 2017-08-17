using System.Xml.Serialization;

namespace NamirialApiClient.Contracts.Security
{
    /// <summary>
    ///     The hash algorithm used for the signatures.
    /// </summary>
    public enum AlgorithmSsignature
    {
        /// <summary>
        ///     Sha1
        /// </summary>
        [XmlEnum("Sha1")] Sha1,

        /// <summary>
        ///     Sha256
        /// </summary>
        [XmlEnum("Sha256")] Sha256,

        /// <summary>
        ///     Sha512
        /// </summary>
        [XmlEnum("Sha512")] Sha512
    }
}