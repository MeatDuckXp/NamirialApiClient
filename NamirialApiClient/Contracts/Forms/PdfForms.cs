using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Forms
{
    /// <summary>
    ///     Represents PDF Forms collection
    /// </summary>
    [Serializable]
    [XmlRoot("FontSettings", Namespace = "", IsNullable = false)]
    public class PdfForms : ServiceMessageBase<PdfForms>
    {
        /// <summary>
        ///     Gets or Sets PDF Forms Group
        /// </summary>
        [XmlElement("PdfFormsGroup", typeof (PdfFormsGroup))]
        public PdfFormsGroup PdfFormsGroup { get; set; }

        /// <summary>
        ///     Gets or Sets IsEditingAllowed flag
        /// </summary>
        [XmlAttribute(AttributeName = "IsEditingAllowed")]
        public byte IsEditingAllowed { get; set; }
    }
}