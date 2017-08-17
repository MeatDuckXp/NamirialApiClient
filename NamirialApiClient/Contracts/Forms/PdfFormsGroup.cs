using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Forms
{
    /// <summary>
    ///     Represents PDF Forms Group
    /// </summary>
    [Serializable]
    [XmlRoot("PdfFormsGroup", Namespace = "", IsNullable = false)]
    public class PdfFormsGroup : ServiceMessageBase<PdfFormsGroup>
    {
        /// <summary>
        ///     Gets or Sets Items Array
        /// </summary>
        [XmlElement("checkBox", typeof (CheckBox))]
        [XmlElement("comboBox", typeof (ComboBox))]
        [XmlElement("radioButton", typeof (RadioButton))]
        [XmlElement("textBox", typeof (TextBox))]
        public object[] Items { get; set; }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
    }
}