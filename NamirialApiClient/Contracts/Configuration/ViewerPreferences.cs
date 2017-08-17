using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Configuration
{
    /// <summary>
    ///     Defines general Viewer Preferences
    /// </summary>
    [Serializable]
    [XmlRoot("ViewerPreferences", Namespace = "", IsNullable = false)]
    public class ViewerPreferences : ServiceMessageBase<ViewerPreferences>
    {
        /// <summary>
        ///     Gets or Sets Show Version Number
        /// </summary>
        [XmlElement("ShowVersionNumber", typeof (byte))]
        public byte ShowVersionNumber { get; set; }

        /// <summary>
        ///     Gets or Sets Enable Thumbnail Display
        /// </summary>
        [XmlElement("EnableThumbnailDisplay", typeof (byte))]
        public byte EnableThumbnailDisplay { get; set; }

        /// <summary>
        ///     Gets or Sets Enable Warning Popup On Leave
        /// </summary>
        [XmlElement("EnableWarningPopupOnLeave", typeof (byte))]
        public byte EnableWarningPopupOnLeave { get; set; }

        /// <summary>
        ///     Gets or Sets Warning Popup Display After
        /// </summary>
        [XmlElement("WarningPopupDisplayAfter", typeof (string))]
        public string WarningPopupDisplayAfter { get; set; }

        /// <summary>
        ///     Gets or Sets Guiding Behavior
        /// </summary>
        [XmlElement("GuidingBehavior", typeof (string))]
        public string GuidingBehavior { get; set; }

        /// <summary>
        ///     Gets or Sets Form Fields Guiding Behavior
        /// </summary>
        [XmlElement("FormFieldsGuidingBehavior", typeof (string))]
        public string FormFieldsGuidingBehavior { get; set; }

        /// <summary>
        ///     Gets or Sets Finish Work step On Open
        /// </summary>
        [XmlElement("FinishWorkstepOnOpen", typeof (byte))]
        public byte FinishWorkstepOnOpen { get; set; }
    }
}