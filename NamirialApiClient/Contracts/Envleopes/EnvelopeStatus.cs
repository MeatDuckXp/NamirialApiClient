using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;
using NamirialApiClient.Contracts.Reciepients;

namespace NamirialApiClient.Contracts.Envleopes
{
    /// <summary>
    ///     Represents Envelope in Namirial signing system
    /// </summary>
    [Serializable]
    [XmlRoot("envelopeStatus", Namespace = "", IsNullable = false)]
    public class EnvelopeStatus : ServiceMessageBase<EnvelopeStatus>
    {
        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [XmlElement("id", typeof (Guid))]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or Sets Name
        /// </summary>
        [XmlElement("name", typeof (string))]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [XmlElement("status", typeof (Status))]
        public Status Status { get; set; }

        /// <summary>
        ///     Gets or Sets SendDate
        /// </summary>
        [XmlElement("sendDate", typeof (string), IsNullable = true)]
        public string SendDate { get; set; }

        /// <summary>
        ///     Gets or Sets ExpirationDate
        /// </summary>
        [XmlElement("expirationDate", typeof (string), IsNullable = true)]
        public string ExpirationDate { get; set; }

        /// <summary>
        ///     Gets or sets Recipients
        /// </summary>
        [XmlArray("bulkRecipients"), XmlArrayItem("bulkRecipient")]
        public List<BulkRecipient> BulkRecipients { get; set; }

        /// <summary>
        ///     Adds bulk recipient to the bulk recipient collection
        /// </summary>
        /// <param name="recipient">BulkRecipient</param>
        public void AddBulkRecipient(BulkRecipient recipient)
        {
            if (recipient == null)
            {
                return;
            }

            if (BulkRecipients == null)
            {
                BulkRecipients = new List<BulkRecipient>();
            }

            BulkRecipients.Add(recipient);
        }
    }
}