using System.Xml.Serialization;

namespace NamirialApiClient.Contracts.Envleopes
{
    /// <summary>
    ///     Defines envelope and bulk recipient status
    /// </summary>
    public enum Status
    {
        /// <summary>
        ///     Draft
        /// </summary>
        [XmlEnum(Name = "Draft")] Draft,

        /// <summary>
        ///     Started
        /// </summary>
        [XmlEnum(Name = "Started")] Started,

        /// <summary>
        ///     In Progress
        /// </summary>
        [XmlEnum(Name = "InProgress")] InProgress,

        /// <summary>
        ///     Canceled
        /// </summary>
        [XmlEnum(Name = "Canceled")] Canceled,

        /// <summary>
        ///     Completed
        /// </summary>
        [XmlEnum(Name = "Completed")] Completed,

        /// <summary>
        ///     Expired
        /// </summary>
        [XmlEnum(Name = "Expired")] Expired,

        /// <summary>
        ///     Rejected
        /// </summary>
        [XmlEnum(Name = "Rejected")] Rejected,

        /// <summary>
        ///     Template
        /// </summary>
        [XmlEnum(Name = "Template")] Template
    }
}