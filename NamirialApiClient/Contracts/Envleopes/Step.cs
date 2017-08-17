using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;
using NamirialApiClient.Contracts.Configuration;
using NamirialApiClient.Contracts.Reciepients;

namespace NamirialApiClient.Contracts.Envleopes
{
    /// <summary>
    ///     Represents Signing Step Within Envelope structure
    /// </summary>
    /// <remarks>
    ///     Defines recipient and tasks for this recipient of every step in this envelope
    /// </remarks>
    [Serializable]
    [XmlRoot("step", Namespace = "", IsNullable = false)]
    public class Step : ServiceMessageBase<Step>
    {
        /// <summary>
        ///     Gets or Sets Email Body Extra
        /// </summary>
        [XmlElement("emailBodyExtra", typeof (string))]
        public string EmailBodyExtra { get; set; }

        /// <summary>
        ///     Gets or Sets Recipient Ordering Index when sending documents
        /// </summary>
        [XmlElement("orderIndex", typeof (int))]
        public int OrderIndex { get; set; }

        /// <summary>
        ///     Gets or Sets Recipient Type
        /// </summary>
        [XmlElement("recipientType", typeof (RecipientType))]
        public RecipientType RecipientType { get; set; }

        /// <summary>
        ///     Gets or Sets list of recipients.
        /// </summary>
        [XmlArray("recipients"), XmlArrayItem("recipient")]
        public List<Recipient> Recipients { get; set; }

        /// <summary>
        ///     Gets or Sets Work-step Configuration
        /// </summary>
        [XmlElement("workstepConfiguration", typeof (WorkstepConfiguration))]
        public WorkstepConfiguration WorkstepConfiguration { get; set; }

        /// <summary>
        ///     Gets or sets Recipients
        /// </summary>
        [XmlArray("bulkRecipients"), XmlArrayItem("bulkRecipient")]
        public List<BulkRecipient> BulkRecipients { get; set; }

        /// <summary>
        ///     Adds Recipient to Recipient collection
        /// </summary>
        /// <param name="recipient">Recipient</param>
        public void AddRecipient(Recipient recipient)
        {
            if (recipient == null)
            {
                return;
            }

            if (BulkRecipients == null)
            {
                BulkRecipients = new List<BulkRecipient>();
            }

            Recipients.Add(recipient);
        }
    }
}