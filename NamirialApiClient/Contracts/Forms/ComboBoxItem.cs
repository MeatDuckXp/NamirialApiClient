using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Forms
{
    /// <summary>
    ///     Represents Form Element ComboBoxItem
    /// </summary>
    [Serializable]
    [XmlRoot("CheckBox", Namespace = "", IsNullable = false)]
    public class ComboBoxItem : ServiceMessageBase<ComboBoxItem>
    {
        /// <summary>
        ///     Gets or Sets Key
        /// </summary>
        [XmlAttribute(AttributeName = "Key")]
        public string Key { get; set; }

        /// <summary>
        ///     Gets or Sets Value
        /// </summary>
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }

        /// <summary>
        ///     Gets or Sets IsSelected
        /// </summary>
        [XmlAttribute(AttributeName = "IsSelected")]
        public byte IsSelected { get; set; }
    }
}