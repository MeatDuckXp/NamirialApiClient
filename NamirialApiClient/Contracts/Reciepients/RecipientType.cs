using System.Xml.Serialization;

namespace NamirialApiClient.Contracts.Reciepients
{
    /// <summary>
    ///     Defines what type the actual recipient belongs to
    /// </summary>
    public enum RecipientType
    {
        /// <summary>
        ///     Signer
        /// </summary>
        [XmlEnum(Name = "Signer")] Signer = 1,

        /// <summary>
        ///     CC
        /// </summary>
        [XmlEnum(Name = "Cc")] Cc = 2,

        /// <summary>
        ///     Acknowledge
        /// </summary>
        Acknowledge = 3
    }
}