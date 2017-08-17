using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Envleopes
{
    /// <summary>
    ///     Represents e signing envelope
    /// </summary>
    [Serializable]
    [XmlRoot("envelope", Namespace = "", IsNullable = false)]
    public class Envelope : ServiceMessageBase<Envelope>
    {
        /// <summary>
        ///     Gets or Sets Envelope Name
        /// </summary>
        [XmlElement("name", typeof (string))]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or Sets Email Subject
        /// </summary>
        [XmlElement("eMailSubject", typeof (string))]
        public string EmailSubject { get; set; }

        /// <summary>
        ///     Gets or Sets EmailBody
        /// </summary>
        [XmlElement("eMailBody", typeof (string))]
        public string EmailBody { get; set; }

        /// <summary>
        ///     Gets or Sets EnableReminders flag
        /// </summary>
        [XmlElement("enableReminders", typeof (bool))]
        public bool EnableReminders { get; set; }

        /// <summary>
        ///     Gets or Sets First Reminder Day Amount
        /// </summary>
        [XmlElement("firstReminderDayAmount", typeof (int))]
        public int FirstReminderDayAmount { get; set; }

        /// <summary>
        ///     Gets or Sets Recurrent Reminder Day Amount
        /// </summary>
        [XmlElement("recurrentReminderDayAmount", typeof (int))]
        public int RecurrentReminderDayAmount { get; set; }

        /// <summary>
        ///     Gets or Sets Before Expiration Reminder Day Amount
        /// </summary>
        [XmlElement("beforeExpirationReminderDayAmount", typeof (int))]
        public int BeforeExpirationReminderDayAmount { get; set; }

        /// <summary>
        ///     Gets or Sets Days Until Envelope Expires
        /// </summary>
        [XmlElement("daysUntilExpire", typeof (int))]
        public int DaysUntilExpire { get; set; }

        /// <summary>
        ///     Gets or Sets Call back URL to get notified when envelope is completed.
        /// </summary>
        /// <remarks>
        ///     URL to notify your back end on a completed envelope: eg:
        ///     http://172.16.17.78:57550/default.aspx?envelopeId=##EnvelopeId##&amp;myParamForMe=1234
        /// </remarks>
        [XmlElement("callbackUrl", typeof (string))]
        public string CallbackUrl { get; set; }

        /// <summary>
        ///     Gets or Sets Call back URL to get notified when envelope status changes.
        /// </summary>
        /// <remarks>
        ///     URL to notify your back end on a status change of the envelope: eg:
        ///     http://172.16.17.78:57550/default.aspx?envelopeId=##EnvelopeId##&amp;action=##Action##&amp;myParamForMe=1234
        /// </remarks>
        [XmlElement("statusUpdateCallbackUrl", typeof (string))]
        public string StatusUpdateCallbackUrl { get; set; }

        /// <summary>
        ///     Gets or Sets Steps
        /// </summary>
        [XmlArray("steps"), XmlArrayItem("step")]
        public List<Step> Steps { get; set; }

        /// <summary>
        ///     Adds a Step to Steps Collection
        /// </summary>
        /// <param name="step"></param>
        public void AddStep(Step step)
        {
            if (step == null)
            {
                return;
            }

            if (Steps == null)
            {
                Steps = new List<Step>();
            }

            Steps.Add(step);
        }
    }
}