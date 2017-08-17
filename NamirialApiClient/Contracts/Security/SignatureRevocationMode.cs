using System.Xml.Serialization;

namespace NamirialApiClient.Contracts.Security
{
    /// <summary>
    ///     Defines if and how the revocation information for the signing certificate chain should be embedded.
    /// </summary>
    public enum SignatureRevocationMode
    {
        /// <summary>
        ///     No revocation information is included
        /// </summary>
        [XmlEnum("DoNotInclude")] DoNotInclude,

        /// <summary>
        ///     The revocation information has to be included, if not possible the signature throws an exception
        /// </summary>
        [XmlEnum("Include")] Include,

        /// <summary>
        ///     If the revocation information can be fetched, it should be included, if not the signature is done without
        ///     revocation information. Information about the signatures where the revocation information could not be included is
        ///     saved into the WorkstepStatus
        /// </summary>
        [XmlEnum("TryToInclude")] TryToInclude,

        /// <summary>
        ///     The revocation information has to be included when it is an OCSP, if checking of the revocation (OCSP or CRL) fails
        ///     an exception is thrown. Information about the signatures where the revocation information could not be included is
        ///     saved into the WorkstepStatus
        /// </summary>
        [XmlEnum("CheckRevocationIncludeOcsp")] CheckRevocationIncludeOcsp
    }
}