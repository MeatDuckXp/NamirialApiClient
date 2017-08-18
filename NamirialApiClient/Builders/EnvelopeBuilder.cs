using System;
using System.Collections.Generic;
using NamirialApiClient.Configuration;
using NamirialApiClient.Contracts.Envleopes;
using NamirialApiClient.Contracts.Reciepients;

namespace NamirialApiClient.Builders
{
    /// <summary>
    ///     Performs building of the envelope object / envelope draft
    /// </summary>
    public class EnvelopeBuilder
    {
        private readonly NamirialApiConfiguration _signingServiceConfiguration;

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="config">Adapter Configuration</param>
        public EnvelopeBuilder(NamirialApiConfiguration config)
        {
            _signingServiceConfiguration = config;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Builds envelope based on the provided method parameters and configuration
        /// </summary>
        /// <param name="recipients">Collection of Recipients(Signers)</param>
        /// <param name="documentIds">Collection of Document Ids</param>
        /// <param name="envelopeName">Envelope Name</param>
        /// <param name="emailSubject">Email Subject</param>
        /// <param name="emailBody">Email Body</param>
        /// <param name="daysUntilExpire">Days (count) Until The Envelope Expires</param>
        /// <returns>Envelope</returns>
        public Envelope Build(IList<Recipient> recipients, IList<string> documentIds, string envelopeName, string emailSubject, string emailBody, int daysUntilExpire)
        {
            var envelope = new Envelope
            {
                Name = envelopeName ?? _signingServiceConfiguration.DefaultEnvelopeName,
                EmailSubject = emailSubject,
                EmailBody = emailBody,
                DaysUntilExpire = daysUntilExpire,
                EnableReminders = false,
                RecurrentReminderDayAmount = 1,
                FirstReminderDayAmount = 1,
                BeforeExpirationReminderDayAmount = 1,
                CallbackUrl = _signingServiceConfiguration.DefaultEnvelopeCallbackUrl,
                StatusUpdateCallbackUrl = _signingServiceConfiguration.DefaultEnvelopeStatusUpdateCallbackUrl
            };


            var recipientType = RecipientType.Signer;
            RecipientType tempRecipientType;

            if (Enum.TryParse(_signingServiceConfiguration.DefaultRecipientType, out tempRecipientType))
            {
                recipientType = tempRecipientType;
            }

            foreach (var recipient in recipients)
            {
                var requestStep = new Step
                {
                    OrderIndex = recipient.OrderIndex ?? 1,
                    EmailBodyExtra = string.Empty,
                    RecipientType = recipientType,
                    Recipients = new List<Recipient>
                    {
                        new Recipient
                        {
                            Email = recipient.Email,
                            FirstName = recipient.FirstName,
                            LastName = recipient.LastName,
                            OrderIndex = recipient.OrderIndex,
                            LanguageCode = recipient.LanguageCode,
                            Authentications = recipient.Authentications
                        }
                    }
                };

                envelope.AddStep(requestStep);
            }

            return envelope;
        }

        #endregion
    }
}