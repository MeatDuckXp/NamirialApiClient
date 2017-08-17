using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;
using NamirialApiClient.Contracts.Security;

namespace NamirialApiClient.Contracts.Reciepients
{
    /// <summary>
    ///     Represents Recipient
    /// </summary>
    [Serializable]
    [XmlRoot("recipient", Namespace = "", IsNullable = false)]
    public class Recipient : ServiceMessageBase<Recipient>
    {
        /// <summary>
        ///     Gets or Sets Order Index
        /// </summary>
        [XmlElement("orderIndex")]
        public string OrderIndexString { get; set; }

        /// <summary>
        ///     Gets or Sets Order Index
        /// </summary>
        [XmlIgnore]
        public int? OrderIndex
        {
            get
            {
                if (string.IsNullOrWhiteSpace(OrderIndexString))
                {
                    return null;
                }

                return Convert.ToInt32(OrderIndexString);
            }
            set
            {
                if (value.HasValue)
                {
                    OrderIndexString = value.ToString();
                }
            }
        }

        /// <summary>
        ///     Gets or Sets First Name
        /// </summary>
        [XmlElement("firstName", typeof (string), IsNullable = false)]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or Sets Last Name
        /// </summary>
        [XmlElement("lastName", typeof (string), IsNullable = false)]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or Sets EMail
        /// </summary>
        [XmlElement("eMail", typeof (string), IsNullable = false)]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or Sets Language Code
        /// </summary>
        [XmlElement("languageCode", typeof (string))]
        public string LanguageCode { get; set; }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [XmlElement("status", typeof (string))]
        public string StatusString { get; set; }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [XmlIgnore]
        public RecipientStatus? Status
        {
            get
            {
                if (string.IsNullOrWhiteSpace(StatusString))
                {
                    return null;
                }

                var status = RecipientStatus.NotSigned;
                RecipientStatus tempRecipientStatus;
                if (Enum.TryParse(StatusString, out tempRecipientStatus))
                {
                    status = tempRecipientStatus;
                }

                return status;
            }
            set
            {
                if (value.HasValue)
                {
                    StatusString = value.ToString();
                }
            }
        }

        /// <summary>
        ///     Gets or Sets SignedDate
        /// </summary>
        [XmlElement("signedDate", typeof (string))]
        public string SignedDate { get; set; }

        /// <summary>
        ///     Gets or Sets Recipient Type
        /// </summary>
        [XmlElement("type", typeof (string))]
        public string TypeString { get; set; }

        /// <summary>
        ///     Gets or Sets Recipient Type
        /// </summary>
        [XmlIgnore]
        public RecipientType? Type
        {
            get
            {
                if (string.IsNullOrWhiteSpace(StatusString))
                {
                    return null;
                }

                var recipientType = RecipientType.Cc;
                RecipientType tempRecipientType;
                if (Enum.TryParse(TypeString, out tempRecipientType))
                {
                    recipientType = tempRecipientType;
                }

                return recipientType;
            }
            set
            {
                if (value.HasValue)
                {
                    StatusString = value.ToString();
                }
            }
        }

        /// <summary>
        ///     Gets or Sets Work-Step Redirection URL
        /// </summary>
        [XmlElement("workstepRedirectionUrl", typeof (string))]
        public string WorkstepRedirectionUrl { get; set; }

        /// <summary>
        ///     Gets or Sets
        /// </summary>
        [XmlArray("authentications"), XmlArrayItem("authentication")]
        public List<EnvelopeAuthentication> Authentications { get; set; }

        /// <summary>
        ///     Gets flag indicating has the signer signed the document
        /// </summary>
        public bool HasSignedDocument => Status == RecipientStatus.Signed;

        /// <summary>
        ///     Adds Authentication option to collection of authentication methods
        /// </summary>
        /// <param name="authentication">EnvelopeAuthentication</param>
        public void AddAuthentication(EnvelopeAuthentication authentication)
        {
            if (authentication == null)
            {
                return;
            }

            if (Authentications == null)
            {
                Authentications = new List<EnvelopeAuthentication>();
            }

            Authentications.Add(authentication);
        }
    }
}