using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Forms
{
    /// <summary>
    ///     Represents Form Element Text Color
    /// </summary>
    [Serializable]
    [XmlRoot("TextColor", Namespace = "", IsNullable = false)]
    public class TextColor : ServiceMessageBase<TextColor>
    {
        /// <summary>
        ///     Gets or Sets alpha channel value
        /// </summary>
        [XmlElement("A", typeof (byte))]
        public byte A { get; set; }

        /// <summary>
        ///     Gets or Sets red channel value
        /// </summary>
        [XmlElement("R", typeof (byte))]
        public byte R { get; set; }

        /// <summary>
        ///     Gets or Sets green channel value
        /// </summary>
        [XmlElement("G", typeof (byte))]
        public byte G { get; set; }

        /// <summary>
        ///     Gets or Sets blue channel value
        /// </summary>
        [XmlElement("B", typeof (byte))]
        public byte B { get; set; }
    }
}