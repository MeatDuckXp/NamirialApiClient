using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Forms
{
    /// <summary>
    ///     Represents Form Element ComboBoxItem
    /// </summary>
    [Serializable]
    [XmlRoot("FontSettings", Namespace = "", IsNullable = false)]
    public class FontSettings : ServiceMessageBase<FontSettings>
    {
        /// <summary>
        ///     Gets or Sets Text Color
        /// </summary>
        [XmlElement("TextColor", typeof (TextColor))]
        public TextColor TextColor { get; set; }

        /// <summary>
        ///     Gets or Sets Font Name
        /// </summary>
        [XmlElement("FontName", typeof (string))]
        public string FontName { get; set; }

        /// <summary>
        ///     Gets or Sets FontSize
        /// </summary>
        [XmlElement("FontSize", typeof (byte))]
        public byte FontSize { get; set; }

        /// <summary>
        ///     Gets or Sets FontStyleBold
        /// </summary>
        [XmlElement("FontStyleBold", typeof (byte))]
        public byte FontStyleBold { get; set; }

        /// <summary>
        ///     Gets or Sets FontStyleItalic
        /// </summary>
        [XmlElement("FontStyleItalic", typeof (byte))]
        public byte FontStyleItalic { get; set; }

        /// <summary>
        ///     Gets or Sets FontFamily
        /// </summary>
        [XmlElement("FontFamily", typeof (string))]
        public string FontFamily { get; set; }

        /// <summary>
        ///     Gets or Sets TextAlign
        /// </summary>
        [XmlElement("TextAlign", typeof (string))]
        public string TextAlign { get; set; }
    }
}