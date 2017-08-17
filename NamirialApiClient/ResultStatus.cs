using System.Xml.Serialization;

namespace NamirialApiClient
{
    /// <summary>
    ///     Indicates general result of an operation
    /// </summary>
    public enum ResultStatus
    {
        /// <summary>
        ///     Ok
        /// </summary>
        [XmlEnum(Name = "ok")] Ok,

        /// <summary>
        ///     Failed
        /// </summary>
        [XmlEnum(Name = "failed")] Failed
    }
}