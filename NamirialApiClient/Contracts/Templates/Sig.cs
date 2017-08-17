using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Templates
{
    /// <summary>
    ///     Defines Structure used to define default properties of signature fields / tasks
    /// </summary>
    [Serializable]
    [XmlRoot("TemplateSig", Namespace = "", IsNullable = false)]
    public class Sig : ServiceMessageBase<Sig>
    {
        /// <summary>
        ///     Gets or Sets Position Page
        /// </summary>
        [XmlElement("positionPage", typeof (byte))]
        public byte PositionPage { get; set; }

        /// <summary>
        ///     Gets or Sets DocRefNumber
        /// </summary>
        [XmlElement("DocRefNumber", typeof (byte))]
        public byte DocRefNumber { get; set; }

        /// <summary>
        ///     Gets or Sets PositionX
        /// </summary>
        [XmlElement("positionX", typeof (decimal))]
        public decimal PositionX { get; set; }

        /// <summary>
        ///     Gets or Sets PositionY
        /// </summary>
        [XmlElement("positionY", typeof (decimal))]
        public decimal PositionY { get; set; }

        /// <summary>
        ///     Gets or Sets Width
        /// </summary>
        [XmlElement("width", typeof (decimal))]
        public decimal Width { get; set; }

        /// <summary>
        ///     Gets or Sets Height
        /// </summary>
        [XmlElement("height", typeof (decimal))]
        public decimal Height { get; set; }

        /// <summary>
        ///     Gets or Sets Parameters
        /// </summary>
        [XmlElement("param")]
        public TemplateSigParam[] Param { get; set; }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
    }
}