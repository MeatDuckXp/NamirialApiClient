using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Error;

namespace NamirialApiClient
{
    /// <summary>
    ///     Structure representing namirial service response
    /// </summary>
    [Serializable]
    [XmlRoot("apiResult", Namespace = "", IsNullable = false)]
    public class ApiCallResult<T>
    {
        /// <summary>
        ///     Gets or Sets Version
        /// </summary>
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        /// <summary>
        ///     Gets  Base Result
        /// </summary>
        [XmlElement("baseResult", typeof (ResultStatus))]
        public ResultStatus BaseResult { get; set; }

        /// <summary>
        ///     Gets or Sets OK Info
        /// </summary>
        [XmlElement("okInfo")]
        public virtual T OkInfo { get; set; }

        /// <summary>
        ///     Gets or Sets Error Info
        /// </summary>
        [XmlElement("errorInfo", typeof (ErrorInfo), IsNullable = true)]
        public ErrorInfo Error { get; set; }

        /// <summary>
        ///     Gets Flag indicating was the operation successful
        /// </summary>
        [XmlIgnore]
        public bool Sucessful => Error == null;
    }
}