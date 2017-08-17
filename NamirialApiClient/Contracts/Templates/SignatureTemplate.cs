using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Templates
{
    /// <summary>
    ///     Represents namirial Signature Template
    /// </summary>
    [Serializable]
    [XmlRoot("signatureTemplate", Namespace = "", IsNullable = false)]
    public class SignatureTemplate : ServiceMessageBase<SignatureTemplate>
    {
        /// <summary>
        ///     Gets or Sets Version
        /// </summary>
        [XmlElement("version", typeof (string))]
        public string Version { get; set; }

        /// <summary>
        ///     Gets or Sets PositionUnits
        /// </summary>
        [XmlElement("positionUnits", typeof (string))]
        public string PositionUnits { get; set; }

        /// <summary>
        ///     Gets or Sets PositionReferenceCorner
        /// </summary>
        [XmlElement("PositionReferenceCorner", typeof (string))]
        public string PositionReferenceCorner { get; set; }

        /// <summary>
        ///     Gets or Sets Sig
        /// </summary>
        [XmlArray("sig"), XmlArrayItem("sig", typeof (Sig))]
        public List<Sig> Sig { get; set; }
    }
}