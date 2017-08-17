using System.Xml.Serialization;

namespace NamirialApiClient.Contracts.Common
{
    /// <summary>
    ///     Defines redirect policy
    /// </summary>
    public enum RedirectPolicy
    {
        /// <summary>
        ///     None
        /// </summary>
        [XmlEnum("None")] None,

        /// <summary>
        ///     ToRecipients
        /// </summary>
        [XmlEnum("ToRecipients")] ToRecipients,

        /// <summary>
        ///     ToDesigner
        /// </summary>
        [XmlEnum("ToDesigner")] ToDesigner,

        /// <summary>
        ///     ToSend
        /// </summary>
        [XmlEnum("ToSend")] ToSend
    }
}