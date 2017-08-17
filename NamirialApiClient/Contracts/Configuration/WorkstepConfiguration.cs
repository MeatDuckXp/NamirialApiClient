using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Actions;
using NamirialApiClient.Contracts.Base;
using NamirialApiClient.Contracts.Forms;
using NamirialApiClient.Contracts.Policies;
using NamirialApiClient.Contracts.Templates;

namespace NamirialApiClient.Contracts.Configuration
{
    /// <summary>
    ///     Defines Work Step Configuration Model
    /// </summary>
    [Serializable]
    [XmlRoot("WorkstepConfiguration", Namespace = "", IsNullable = false)]
    public class WorkstepConfiguration : ServiceMessageBase<WorkstepConfiguration>
    {
        /// <summary>
        ///     Gets or Sets Work-step Label
        /// </summary>
        [XmlElement("WorkstepLabel", typeof (string))]
        public string WorkstepLabel { get; set; }

        /// <summary>
        ///     Gets or Sets Small Text Zoom Factor Percent
        /// </summary>
        [XmlElement("SmallTextZoomFactorPercent", typeof (byte))]
        public byte SmallTextZoomFactorPercent { get; set; }

        /// <summary>
        ///     Gets or Sets Work-step Time To Live In Minutes
        /// </summary>
        [XmlElement("WorkstepTimeToLiveInMinutes", typeof (byte))]
        public byte WorkstepTimeToLiveInMinutes { get; set; }

        /// <summary>
        ///     Gets or Sets Finish Action
        /// </summary>
        [XmlElement("FinishAction", typeof (FinishAction))]
        public FinishAction FinishAction { get; set; }

        /// <summary>
        ///     Gets or Sets Signature Template
        /// </summary>
        [XmlElement("SignatureTemplate", typeof (SignatureTemplate))]
        public SignatureTemplate SignatureTemplate { get; set; }

        /// <summary>
        ///     Gets or Sets  PdfForms
        /// </summary>
        [XmlElement("PdfForms", typeof (PdfForms))]
        public PdfForms PdfForms { get; set; }

        /// <summary>
        ///     Gets or Sets ViewerPreferences
        /// </summary>
        [XmlElement("ViewerPreferences", typeof (ViewerPreferences))]
        public ViewerPreferences ViewerPreferences { get; set; }

        /// <summary>
        ///     Gets or Sets Policy
        /// </summary>
        [XmlElement("Policy", typeof (Policy))]
        public Policy Policy { get; set; }

        /// <summary>
        ///     Gets or Sets TimeCreated
        /// </summary>
        [XmlElement("TimeCreated", typeof (DateTime))]
        public DateTime TimeCreated { get; set; }

        /// <summary>
        ///     Gets or Sets Signature Plugin Configuration
        /// </summary>
        [XmlElement("SignaturePluginConfiguration", typeof (SignaturePluginConfiguration))]
        public SignaturePluginConfiguration SignaturePluginConfiguration { get; set; }

        /// <summary>
        ///     Gets or Sets Transaction Code Configurations
        /// </summary>
        [XmlArrayItem("TransactionCodeConfiguration")]
        public List<TransactionCodeConfiguration> TransactionCodeConfigurations { get; set; }
    }
}