using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Configuration
{
    [Serializable]
    [XmlRoot("transactionCodeConfiguration", Namespace = "", IsNullable = false)]
    public class TransactionCodeConfiguration : ServiceMessageBase<TransactionCodeConfiguration>
    {
        /// <summary>
        ///     Gets or Sets Message
        /// </summary>
        [XmlElement("Message", typeof (string))]
        public string Message { get; set; }

        /// <summary>
        ///     Gets or Sets  Hash Algorithm Identifier
        /// </summary>
        [XmlElement("HashAlgorithmIdentifier", typeof (string))]
        public string HashAlgorithmIdentifier { get; set; }

        /// <summary>
        ///     Gets or Sets Transaction Configuration Identifier
        /// </summary>
        [XmlAttribute(AttributeName = "TrConfId")]
        public string TrConfId { get; set; }

        /// <summary>
        ///     Gets or Sets Language
        /// </summary>
        [XmlAttribute(AttributeName = "Language")]
        public string Language { get; set; }
    }
}