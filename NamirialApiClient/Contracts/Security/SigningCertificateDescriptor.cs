using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Security
{
    /// <summary>
    ///     Description of the signing certificate
    /// </summary>
    [Serializable]
    [XmlRoot("SigningCertificateDescriptor", Namespace = "", IsNullable = false)]
    public class SigningCertificateDescriptor : ServiceMessageBase<SigningCertificateDescriptor>
    {
        /// <summary>
        ///     Gets or Sets The certificates identifier
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        ///     Gets or sets certificate identifier type
        /// </summary>
        public CertificateIdentifierType Type { get; set; }

        /// <summary>
        ///     Gets or Sets CSP
        /// </summary>
        /// <remarks>
        ///     The cryptographic service provider to locate the certificate.
        /// </remarks>
        public CertificateStore Csp { get; set; }
    }
}