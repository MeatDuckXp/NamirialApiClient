using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Security
{
    /// <summary>
    ///     Represents Structure used as authorization in order to access the envelope
    /// </summary>
    [Serializable]
    [XmlRoot("authentication", Namespace = "", IsNullable = false)]
    public class EnvelopeAuthentication : ServiceMessageBase<EnvelopeAuthentication>
    {
        /// <summary>
        ///     Gets or Sets Method
        /// </summary>
        [XmlElement("method", typeof (AuthenticationMethod), IsNullable = false)]
        public AuthenticationMethod Method { get; set; }

        /// <summary>
        ///     Gets or Sets Parameter
        /// </summary>
        [XmlElement("parameter")]
        public string Parameter { get; set; }
    }
}