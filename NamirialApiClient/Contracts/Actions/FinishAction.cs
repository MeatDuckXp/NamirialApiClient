using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Actions
{
    /// <summary>
    ///     Represents structure that should be used when configure the actions done by the server and the by the clients when
    ///     the work-step is finished.
    /// </summary>
    [Serializable]
    [XmlRoot("FinishAction", Namespace = "", IsNullable = false)]
    public class FinishAction : ServiceMessageBase<FinishAction>
    {
        /// <summary>
        ///     Gets or Sets Server Action Definition
        /// </summary>
        /// <remarks>
        ///     If provided this action will be done by the server when the work step is finished
        /// </remarks>
        [XmlElement("ServerAction", typeof (ServerAction))]
        public ServerAction ServerAction { get; set; }

        /// <summary>
        ///     Gets or Sets Client Action Definition
        /// </summary>
        /// <remarks>
        ///     If provided this action will be done by the client when the work step is finished
        /// </remarks>
        [XmlElement("ClientAction", typeof (ClientAction))]
        public ClientAction ClientAction { get; set; }
    }
}