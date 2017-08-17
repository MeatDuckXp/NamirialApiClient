using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Templates
{
    /// <summary>
    ///     Defines Structure used to define default properties of signature fields / tasks
    /// </summary>
    [Serializable]
    [XmlRoot("SigTemplate", Namespace = "", IsNullable = false)]
    public class SigTemplate : ServiceMessageBase<SigTemplate>
    {
        /// <summary>
        ///     Gets or Sets Width
        /// </summary>
        /// <remarks>
        ///     The elements width in points
        /// </remarks>
        [XmlElement("Width", typeof (decimal))]
        public decimal Width { get; set; }

        /// <summary>
        ///     Gets or Sets Height
        /// </summary>
        /// <remarks>
        ///     The elements height in points
        /// </remarks>
        [XmlElement("Height", typeof (decimal))]
        public decimal Height { get; set; }

        /// <summary>
        ///     Gets or Sets Array of parameters
        /// </summary>
        /// <remarks>
        ///     Parameter defining the signature type.
        /// </remarks>
        /// <list type="bullet">
        ///     <listheader>
        ///         <description>Possible values</description>
        ///     </listheader>
        ///     <item>
        ///         <term>BiometricSignature</term>
        ///         <description>Biometric Signature</description>
        ///     </item>
        ///     <item>
        ///         <term>LocalCertificate</term>
        ///         <description>Local Certificate</description>
        ///     </item>
        ///     <item>
        ///         <term>Picture</term>
        ///         <description>Picture</description>
        ///     </item>
        ///     <item>
        ///         <term>TransactionCode</term>
        ///         <description>Transaction Code</description>
        ///     </item>
        ///     <item>
        ///         <term>TransactionCodeAndBiometricSignature</term>
        ///         <description>Transaction Code And Biometric Signature</description>
        ///     </item>
        ///     <item>
        ///         <term>TransactionCodeAndLocalCertificate</term>
        ///         <description>Transaction Code And Local Certificate</description>
        ///     </item>
        ///     <item>
        ///         <term>TransactionCodeBiometricSignatureAndLocalCertificate</term>
        ///         <description>Transaction Code Biometric Signature And Local Certificate</description>
        ///     </item>
        ///     <item>
        ///         <term>BiometricSignature_and_LocalCertificate</term>
        ///         <description>Biometric Signature and Local Certificate</description>
        ///     </item>
        /// </list>
        [XmlElement("param")]
        public List<SigTemplateParam> Param { get; set; }

        /// <summary>
        ///     Adds new parameter to the parameters collection
        /// </summary>
        /// <param name="paramName">Parameter Name</param>
        /// <param name="paramValue">Parameter Value</param>
        /// <list type="bullet">
        ///     <listheader>
        ///         <description>Possible values</description>
        ///     </listheader>
        ///     <item>
        ///         <term>BiometricSignature</term>
        ///         <description>Biometric Signature</description>
        ///     </item>
        ///     <item>
        ///         <term>LocalCertificate</term>
        ///         <description>Local Certificate</description>
        ///     </item>
        ///     <item>
        ///         <term>Picture</term>
        ///         <description>Picture</description>
        ///     </item>
        ///     <item>
        ///         <term>TransactionCode</term>
        ///         <description>Transaction Code</description>
        ///     </item>
        ///     <item>
        ///         <term>TransactionCodeAndBiometricSignature</term>
        ///         <description>Transaction Code And Biometric Signature</description>
        ///     </item>
        ///     <item>
        ///         <term>TransactionCodeAndLocalCertificate</term>
        ///         <description>Transaction Code And Local Certificate</description>
        ///     </item>
        ///     <item>
        ///         <term>TransactionCodeBiometricSignatureAndLocalCertificate</term>
        ///         <description>Transaction Code Biometric Signature And Local Certificate</description>
        ///     </item>
        ///     <item>
        ///         <term>BiometricSignature_and_LocalCertificate</term>
        ///         <description>Biometric Signature and Local Certificate</description>
        ///     </item>
        /// </list>
        public void AddSignatureTypeParameter(string paramName, string paramValue)
        {
            if (string.IsNullOrWhiteSpace(paramValue))
            {
                return;
            }

            if (Param == null)
            {
                Param = new List<SigTemplateParam>();
            }

            Param.Add(new SigTemplateParam
            {
                Name = "sigType",
                Value = paramValue
            });
        }
    }
}