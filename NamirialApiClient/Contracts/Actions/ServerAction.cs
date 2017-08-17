using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Actions
{
    /// <summary>
    ///     Represents action done by the server  when the work-step is finished.
    /// </summary>
    /// <remarks>
    ///     Although a part of the FinishAction structure, the official examples state that this is not relevant information
    /// </remarks>
    [Serializable]
    [XmlRoot("ServerAction", Namespace = "", IsNullable = false)]
    public class ServerAction : ServiceMessageBase<ServerAction>
    {
        /// <summary>
        ///     Gets or Sets Call Synchronous flag
        /// </summary>
        [XmlAttribute(AttributeName = "CallSynchronous")]
        public byte CallSynchronous { get; set; }
    }
}