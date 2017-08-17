using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Error
{
    /// <summary>
    ///     Represents Structure that holds error data in general returned from Namirial system
    /// </summary>
    [Serializable]
    [XmlRoot("errorInfo", Namespace = "", IsNullable = false)]
    public class ErrorInfo : ServiceMessageBase<ErrorInfo>
    {
        /// <summary>
        ///     Gets or Sets Error
        /// </summary>
        [XmlElement("error", typeof (string))]
        public string Error { get; set; }

        /// <summary>
        ///     Gets or Sets ErrorMsg
        /// </summary>
        [XmlElement("errorMsg", typeof (string))]
        public string ErrorMsg { get; set; }
    }
}