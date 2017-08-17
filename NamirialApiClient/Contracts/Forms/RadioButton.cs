using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Forms
{
    /// <summary>
    ///     Represents Form Element RadioButton
    /// </summary>
    [Serializable]
    [XmlRoot("RadioButton", Namespace = "", IsNullable = false)]
    public class RadioButton : ServiceMessageBase<RadioButton>
    {
        /// <summary>
        ///     Gets or Sets PositionPage
        /// </summary>
        [XmlElement("PositionPage", typeof (byte))]
        public byte PositionPage { get; set; }

        /// <summary>
        ///     Gets or Sets DocRefNumber
        /// </summary>
        [XmlElement("DocRefNumber", typeof (byte))]
        public byte DocRefNumber { get; set; }

        /// <summary>
        ///     Gets or Sets PositionX
        /// </summary>
        [XmlElement("PositionX", typeof (decimal))]
        public decimal PositionX { get; set; }

        /// <summary>
        ///     Gets or Sets PositionY
        /// </summary>
        [XmlElement("PositionY", typeof (decimal))]
        public decimal PositionY { get; set; }

        /// <summary>
        ///     Gets or Sets Height
        /// </summary>
        [XmlElement("Width", typeof (decimal))]
        public decimal Width { get; set; }

        /// <summary>
        ///     Gets or Sets Height
        /// </summary>
        [XmlElement("Height", typeof (decimal))]
        public decimal Height { get; set; }

        /// <summary>
        ///     Gets or Sets GeneratedId
        /// </summary>
        [XmlElement("GeneratedId", typeof (string))]
        public string GeneratedId { get; set; }

        /// <summary>
        ///     Gets or Sets IsReadonly
        /// </summary>
        [XmlElement("IsReadonly", typeof (byte))]
        public byte IsReadonly { get; set; }

        /// <summary>
        ///     Gets or Sets IsRequired
        /// </summary>
        [XmlElement("IsRequired", typeof (byte))]
        public byte IsRequired { get; set; }

        /// <summary>
        ///     Gets or Sets IsHidden
        /// </summary>
        [XmlElement("IsHidden", typeof (byte))]
        public byte IsHidden { get; set; }

        /// <summary>
        ///     Gets or Sets KeepExistingValue
        /// </summary>
        [XmlElement("KeepExistingValue", typeof (byte))]
        public byte KeepExistingValue { get; set; }

        /// <summary>
        ///     Gets or Sets CustomOrder
        /// </summary>
        [XmlElement("CustomOrder", typeof (byte))]
        public byte CustomOrder { get; set; }

        /// <summary>
        ///     Gets or Sets Description
        /// </summary>
        [XmlElement("Description", typeof (object))]
        public object Description { get; set; }

        /// <summary>
        ///     Gets or Sets IsEditable
        /// </summary>
        [XmlElement("IsEditable", typeof (byte))]
        public byte IsEditable { get; set; }

        /// <summary>
        ///     Gets or Sets Value
        /// </summary>
        [XmlElement("Value", typeof (string))]
        public string Value { get; set; }

        /// <summary>
        ///     Gets or Sets Combo Box Items
        /// </summary>
        [XmlArrayItem("item", IsNullable = false)]
        public ComboBoxItem[] Items { get; set; }

        /// <summary>
        ///     Gets or Sets FontSettings
        /// </summary>
        [XmlElement("FontSettings", typeof (FontSettings))]
        public FontSettings FontSettings { get; set; }

        /// <remarks />
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or Sets IsChecked
        /// </summary>
        [XmlElement("IsChecked", typeof (byte))]
        public byte IsChecked { get; set; }

        /// <summary>
        ///     Gets or Sets IsSelectUnison
        /// </summary>
        [XmlElement("IsSelectUnison", typeof (byte))]
        public byte IsSelectUnison { get; set; }

        /// <summary>
        ///     Gets or Sets IsToggleToOff
        /// </summary>
        [XmlElement("IsToggleToOff", typeof (byte))]
        public byte IsToggleToOff { get; set; }

        /// <summary>
        ///     Gets or Sets GroupName
        /// </summary>
        [XmlElement("GroupName", typeof (string))]
        public string GroupName { get; set; }
    }
}