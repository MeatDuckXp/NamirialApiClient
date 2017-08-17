using System.Xml.Serialization;

namespace NamirialApiClient.Contracts.Forms
{
    /// <summary>
    ///     Specify how the parsed forms should be grouped into tasks
    /// </summary>
    public enum FormsGrouping
    {
        /// <summary>
        ///     PerPage
        /// </summary>
        /// <remarks>
        ///     All forms on one page are grouped to one forms group.
        /// </remarks>
        [XmlEnum("PerPage")] PerPage,

        /// <summary>
        ///     PerDocument
        /// </summary>
        /// <remarks>
        ///     All forms of one document are grouped to one forms group.
        /// </remarks>
        [XmlEnum("PerDocument")] PerDocument,

        /// <summary>
        ///     PerEnvelope
        /// </summary>
        /// <remarks>
        ///     All forms of all documents inside the envelope are grouped to one forms group
        /// </remarks>
        [XmlEnum("PerEnvelope")] PerEnvelope
    }
}