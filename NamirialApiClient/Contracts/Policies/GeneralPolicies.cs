using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Policies
{
    /// <summary>
    ///     Defines General policies
    /// </summary>
    [Serializable]
    [XmlRoot("AdhocWorkstepConfiguration", Namespace = "", IsNullable = false)]
    public class GeneralPolicies : ServiceMessageBase<GeneralPolicies>
    {
        /// <summary>
        ///     Gets or Sets Allow Save Document flag
        /// </summary>
        /// <remarks>
        ///     Is the client allowed to save the work step document
        /// </remarks>
        [XmlElement("AllowSaveDocument", typeof (byte))]
        public byte AllowSaveDocument { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Save Audit Trail flag
        /// </summary>
        /// <remarks>
        ///     Is the client allowed to save the audit trail document
        /// </remarks>
        [XmlElement("AllowSaveAuditTrail", typeof (byte))]
        public byte AllowSaveAuditTrail { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Rotating Pages flag
        /// </summary>
        [XmlElement("AllowRotatingPages", typeof (byte))]
        public byte AllowRotatingPages { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Append File To Work step flag
        /// </summary>
        [XmlElement("AllowAppendFileToWorkstep", typeof (byte))]
        public byte AllowAppendFileToWorkstep { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Append Tasks To Work step
        /// </summary>
        [XmlElement("AllowAppendTasksToWorkstep", typeof (byte))]
        public byte AllowAppendTasksToWorkstep { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Email Document
        /// </summary>
        [XmlElement("AllowEmailDocument", typeof (byte))]
        public byte AllowEmailDocument { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Print Document
        /// </summary>
        [XmlElement("AllowPrintDocument", typeof (byte))]
        public byte AllowPrintDocument { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Finish Work step
        /// </summary>
        [XmlElement("AllowFinishWorkstep", typeof (byte))]
        public byte AllowFinishWorkstep { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Reject Work step
        /// </summary>
        /// <remarks>
        ///     Is the client allowed to reject the work step
        /// </remarks>
        [XmlElement("AllowRejectWorkstep", typeof (byte))]
        public byte AllowRejectWorkstep { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Undo Last Action
        /// </summary>
        [XmlElement("AllowUndoLastAction", typeof (byte))]
        public byte AllowUndoLastAction { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Colorize PDF Forms
        /// </summary>
        [XmlElement("AllowColorizePdfForms", typeof (byte))]
        public byte AllowColorizePdfForms { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Ad-hoc PDF Attachments
        /// </summary>
        [XmlElement("AllowAdhocPdfAttachments", typeof (byte))]
        public byte AllowAdhocPdfAttachments { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Ad-hoc Signatures
        /// </summary>
        [XmlElement("AllowAdhocSignatures", typeof (byte))]
        public byte AllowAdhocSignatures { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Ad-hoc Stampings
        /// </summary>
        [XmlElement("AllowAdhocStampings", typeof (byte))]
        public byte AllowAdhocStampings { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Ad-hoc Free Hand Annotations
        /// </summary>
        [XmlElement("AllowAdhocFreeHandAnnotations", typeof (byte))]
        public byte AllowAdhocFreeHandAnnotations { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Ad-hoc Typewriter Annotations
        /// </summary>
        [XmlElement("AllowAdhocTypewriterAnnotations", typeof (byte))]
        public byte AllowAdhocTypewriterAnnotations { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Ad-hoc Picture Annotations
        /// </summary>
        [XmlElement("AllowAdhocPictureAnnotations", typeof (byte))]
        public byte AllowAdhocPictureAnnotations { get; set; }

        /// <summary>
        ///     Gets or Sets Allow Ad-hoc PDF Page Appending
        /// </summary>
        [XmlElement("AllowAdhocPdfPageAppending", typeof (byte))]
        public byte AllowAdhocPdfPageAppending { get; set; }
    }
}