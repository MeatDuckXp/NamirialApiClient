using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Forms
{
    /// <summary>
    ///     Represents Form Element CheckBox
    /// </summary>
    [Serializable]
    [XmlRoot("CheckBox", Namespace = "", IsNullable = false)]
    public class CheckBox : ServiceMessageBase<CheckBox>
    {
        /// <summary>
        ///     Gets or Sets Position on Page
        /// </summary>
        [XmlElement("PositionPage", typeof (byte))]
        public byte PositionPage { get; set; }

        /// <summary>
        ///     Gets or Sets Document Reference Number
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
        ///     Gets or Sets Width
        /// </summary>
        [XmlElement("Width", typeof (decimal))]
        public decimal Width { get; set; }

        /// <summary>
        ///     Gets or Sets Height
        /// </summary>
        [XmlElement("Height", typeof (decimal))]
        public decimal Height { get; set; }

        /// <summary>
        ///     Gets or Sets Generated Id
        /// </summary>
        [XmlElement("GeneratedId", typeof (string))]
        public string GeneratedId { get; set; }

        /// <summary>
        ///     Gets or Sets Is Read-only flag
        /// </summary>
        [XmlElement("IsReadonly", typeof (byte))]
        public byte IsReadonly { get; set; }

        /// <summary>
        ///     Gets or Sets Is Required flag
        /// </summary>
        [XmlElement("IsRequired", typeof (byte))]
        public byte IsRequired { get; set; }

        /// <summary>
        ///     Gets or Sets Is Hidden flag
        /// </summary>
        [XmlElement("IsHidden", typeof (byte))]
        public byte IsHidden { get; set; }

        /// <summary>
        ///     Gets or Sets Keep Existing Value flag
        /// </summary>
        [XmlElement("KeepExistingValue", typeof (byte))]
        public byte KeepExistingValue { get; set; }

        /// <summary>
        ///     Gets or Sets Custom Order
        /// </summary>
        [XmlElement("CustomOrder", typeof (byte))]
        public byte CustomOrder { get; set; }

        /// <summary>
        ///     Gets or Sets Description
        /// </summary>
        [XmlElement("Description", typeof (object))]
        public object Description { get; set; }

        /// <summary>
        ///     Gets or Sets Is Checked flag
        /// </summary>
        [XmlElement("IsChecked", typeof (byte))]
        public byte IsChecked { get; set; }

        /// <summary>
        ///     Gets or Sets RequiredEvalPolicy
        /// </summary>
        [XmlElement("RequiredEvalPolicy", typeof (string))]
        public string RequiredEvalPolicy { get; set; }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
    }
}