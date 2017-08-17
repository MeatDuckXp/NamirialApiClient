using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Security
{
    /// <summary>
    ///     Structure defining configuration of the signature properties
    /// </summary>
    [Serializable]
    [XmlRoot("PdfSignaturePropertiesV1", Namespace = "", IsNullable = false)]
    [XmlType(AnonymousType = true)]
    public class PdfSignaturePropertiesV1 : ServiceMessageBase<PdfSignaturePropertiesV1>
    {
        /// <summary>
        ///     Gets or Sets PdfAConformant
        /// </summary>
        /// <remarks>
        ///     Defines if the signature should be PAdES part 4 compliant.
        /// </remarks>
        /// <list type="bullet">
        ///     <listheader>
        ///         <term> Possible values:</term>
        ///         <description> Default value: '0'</description>
        ///     </listheader>
        ///     <item>
        ///         <term> '0' sign the document with standard PDF signature</term>
        ///     </item>
        ///     <item>
        ///         <term>'1' sign the document PAdES part 4 compliant</term>
        ///     </item>
        /// </list>
        public byte PdfAConformant { get; set; }

        /// <summary>
        ///     Gets or Sets PadEsPart4Compliant
        /// </summary>
        /// <remarks>
        ///     Defines if the signature should be PAdES part 4 compliant
        /// </remarks>
        /// <list type="bullet">
        ///     <listheader>
        ///         <term> Possible values:</term>
        ///         <description> Default value: '0'</description>
        ///     </listheader>
        ///     <item>
        ///         <term>'0' sign the document with standard PDF signature</term>
        ///     </item>
        ///     <item>
        ///         <term>'1' sign the document PAdES part 4 compliant</term>
        ///     </item>
        /// </list>
        public byte PadEsPart4Compliant { get; set; }

        /// <summary>
        ///     Gets or Sets IncludeSigningCertificateChain
        /// </summary>
        /// <remarks>
        ///     Defines if the certificate chain for the signing certificate should be embedded into the signature.
        /// </remarks>
        /// <list type="bullet">
        ///     <listheader>
        ///         <term> Possible values:</term>
        ///         <description> Default value: '0'</description>
        ///     </listheader>
        ///     <item>
        ///         <term>'0' do not include the certificate chain</term>
        ///     </item>
        ///     <item>
        ///         <term>'1' include the certificate chain</term>
        ///     </item>
        /// </list>
        public byte IncludeSigningCertificateChain { get; set; }

        /// <summary>
        ///     Gets or Sets Signing Certificate Revocation Information Include Mode
        /// </summary>
        /// <remarks>
        ///     Defines if and how the revocation information for the signing certificate chain should be embedded.
        /// </remarks>
        public SignatureRevocationMode SigningCertificateRevocationInformationIncludeMode { get; set; }
    }
}