using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Actions
{
    /// <summary>
    ///     client action specifies the redirect, when a recipient clicks on finish.
    /// </summary>
    [Serializable]
    [XmlRoot("ClientAction", Namespace = "", IsNullable = false)]
    public class ClientAction : ServiceMessageBase<ClientAction>
    {
        /// <summary>
        ///     Gets or Sets Client Name
        /// </summary>
        [XmlAttribute(AttributeName = "ClientName")]
        public string ClientName { get; set; }

        /// <summary>
        ///     Gets or Sets CloseApp
        /// </summary>
        [XmlAttribute(AttributeName = "CloseApp")]
        public byte CloseApp { get; set; }

        /// <summary>
        ///     Gets or Sets Remove Document From Recent Document List
        /// </summary>
        [XmlAttribute(AttributeName = "RemoveDocumentFromRecentDocumentList")]
        public byte RemoveDocumentFromRecentDocumentList { get; set; }

        /// <summary>
        ///     Gets or Sets Call Client Action Only After Success full Sync
        /// </summary>
        [XmlAttribute(AttributeName = "CallClientActionOnlyAfterSuccessfulSync")]
        public byte CallClientActionOnlyAfterSuccessfulSync { get; set; }

        /// <summary>
        ///     Gets or Sets Value
        /// </summary>
        [XmlText(typeof (string))]
        public string Value { get; set; }
    }
}