using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Security
{
    /// <summary>
    ///     Cryptographic data configuration structure
    /// </summary>
    [Serializable]
    [XmlRoot("PdfSignatureCryptographicData_V1", Namespace = "", IsNullable = false)]
    public class PdfSignatureCryptographicDataV1 : ServiceMessageBase<PdfSignatureCryptographicDataV1>
    {
        /// <summary>
        ///     Gets or Sets Signature Hash Algorithm
        /// </summary>
        public AlgorithmSsignature SignatureHashAlgorithm { get; set; }

        /// <summary>
        ///     Gets or Sets Signing Certificate Descriptor
        /// </summary>
        /// <remarks>
        ///     The description of the signing certificate. More than one SigningCertificateDescriptor can be defined by adding
        ///     this node more than once. If more SigningCertificateDescriptors are present, these configurations are used as
        ///     backup if the selected SigningCertificateDescriptor is not working. For example if no revocation information can be
        ///     retrieved although it should be included into the signature
        /// </remarks>
        public SigningCertificateDescriptor SigningCertificateDescriptor { get; set; }
    }
}