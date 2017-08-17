using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Task
{
    /// <summary>
    ///     Represents namirial signing system task structure
    /// </summary>
    [Serializable]
    [XmlRoot("Task", Namespace = "", IsNullable = false)]
    public class Task : ServiceMessageBase<Task>
    {
        /// <summary>
        ///     Gets or Sets flag is task enabled
        /// </summary>
        [XmlAttribute(AttributeName = "Enabled")]
        public byte Enabled { get; set; }

        /// <summary>
        ///     Gets or Sets flag is task completed
        /// </summary>
        [XmlAttribute(AttributeName = "Completed")]
        public byte Completed { get; set; }

        /// <summary>
        ///     Gets or Sets flag is task required
        /// </summary>
        [XmlAttribute(AttributeName = "Required")]
        public byte Required { get; set; }

        /// <summary>
        ///     Gets or set Task Unique Id
        /// </summary>
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets task display name
        /// </summary>
        [XmlAttribute(AttributeName = "DisplayName")]
        public string DisplayName { get; set; }

        /// <summary>
        ///     gets or sets Document Reference Number
        /// </summary>
        [XmlAttribute(AttributeName = "DocRefNumber")]
        public byte DocRefNumber { get; set; }

        /// <summary>
        ///     Gets or Sets Type
        /// </summary>
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or Sets Internal All Concerned Doc Ref Numbers List
        /// </summary>
        [XmlAttribute(AttributeName = "InternalAllConcernedDocRefNumbersList")]
        public byte InternalAllConcernedDocRefNumbersList { get; set; }
    }
}