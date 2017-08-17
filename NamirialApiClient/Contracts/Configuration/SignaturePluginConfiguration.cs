using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;
using NamirialApiClient.Contracts.Security;

namespace NamirialApiClient.Contracts.Configuration
{
    /// <summary>
    ///     Represents Structure to configure the signatures for this work step.
    /// </summary>
    /// <remarks>
    ///     One default configuration has to be defined. The default configuration is used for flatten signatures, ad-hoc
    ///     signatures and signature fields which do not reference a special signature plugin configuration. The default
    ///     configuration does not contain the attribute 'spcId'. If the attribute 'spcId' is defined the signature plugin
    ///     configuration does only apply to signature fields referencing the configuration by specifying
    /// </remarks>
    [Serializable]
    [XmlRoot("signaturePluginConfiguration", Namespace = "", IsNullable = false)]
    public class SignaturePluginConfiguration : ServiceMessageBase<SignaturePluginConfiguration>
    {
        /// <summary>
        ///     Gets or Sets Signature properties
        /// </summary>
        [XmlElement("PdfSignatureProperties_V1", typeof (PdfSignaturePropertiesV1))]
        public PdfSignaturePropertiesV1 PdfSignaturePropertiesV1 { get; set; }

        /// <summary>
        ///     Gets or Sets cryptographic data configuration
        /// </summary>
        [XmlElement("PdfSignatureCryptographicData_V1", typeof (PdfSignatureCryptographicDataV1))]
        public PdfSignatureCryptographicDataV1 PdfSignatureCryptographicDataV1 { get; set; }
    }
}