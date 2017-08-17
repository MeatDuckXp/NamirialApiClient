using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;
using NamirialApiClient.Contracts.Documents;
using NamirialApiClient.Contracts.Envleopes;

namespace NamirialApiClient.Contracts.Reciepients
{
    /// <summary>
    ///     Represents bulk recipient structure
    /// </summary>
    [Serializable]
    [XmlRoot("bulkRecipient", Namespace = "", IsNullable = false)]
    public class BulkRecipient : ServiceMessageBase<BulkRecipient>
    {
        /// <summary>
        ///     Gets or Sets eMail
        /// </summary>
        [XmlAttribute(AttributeName = "eMail")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [XmlElement("status", typeof (Status))]
        public Status Status { get; set; }

        /// <summary>
        ///     Gets or Sets LogDocumentId
        /// </summary>
        [XmlElement("logDocumentId")]
        public string LogDocumentId { get; set; }

        /// <summary>
        ///     Gets or Sets list of recipients.
        /// </summary>
        [XmlArray("recipients"), XmlArrayItem("recipient")]
        public List<Recipient> Recipients { get; set; }

        /// <summary>
        ///     Gets or Sets list of completed documents.
        /// </summary>
        [XmlElement("completedDocuments", typeof (CompletedDocuments))]
        public CompletedDocuments CompletedDocuments { get; set; }

        /// <summary>
        ///     Adds Recipient to Recipient Collections
        /// </summary>
        /// <param name="recipient">Recipient</param>
        public void AddRecipient(Recipient recipient)
        {
            if (recipient == null)
            {
                return;
            }

            if (Recipients == null)
            {
                Recipients = new List<Recipient>();
            }

            Recipients.Add(recipient);
        }

        /// <summary>
        ///     Returns Recipient object for the given email if found
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Recipient GetRecipient(string email)
        {
            return Recipients?.FirstOrDefault(recipient => recipient.Email == email);
        }
    }
}