using System.Xml.Serialization;

namespace NamirialApiClient.Contracts.Reciepients
{
    /// <summary>
    ///     Defines what is the signing status of a document regard a given signer
    /// </summary>
    public enum RecipientStatus
    {
        /// <summary>
        ///     Signed
        /// </summary>
        [XmlEnum(Name = "Signed")] Signed = 0,

        /// <summary>
        ///     NotSigned
        /// </summary>
        [XmlEnum(Name = "NotSigned")] NotSigned = 1,

        /// <summary>
        ///     Rejected
        /// </summary>
        [XmlEnum(Name = "Rejected")] Rejected = 2
    }
}