using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Task
{
    /// <summary>
    ///     Represents namirial signing system task collection
    /// </summary>
    [Serializable]
    [XmlRoot("WorkstepTasks", Namespace = "", IsNullable = false)]
    public class WorkstepTasks : ServiceMessageBase<WorkstepTasks>
    {
        /// <summary>
        ///     Gets or Sets Task collection
        /// </summary>
        [XmlArray("Task"),
         XmlArrayItem("Task", typeof (Task))]
        public List<Task> Task { get; set; }

        /// <summary>
        ///     Gets or Sets SequenceMode
        /// </summary>
        [XmlAttribute(AttributeName = "SequenceMode")]
        public string SequenceMode { get; set; }

        /// <summary>
        ///     Gets or Sets OriginalSequenceMode
        /// </summary>
        [XmlAttribute(AttributeName = "OriginalSequenceMode")]
        public string OriginalSequenceMode { get; set; }
    }
}