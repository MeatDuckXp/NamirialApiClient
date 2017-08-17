using System;
using System.ComponentModel;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;
using NamirialApiClient.Contracts.Task;

namespace NamirialApiClient.Contracts.Policies
{
    /// <summary>
    ///     Defines Policy
    /// </summary>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Policy : ServiceMessageBase<Policy>
    {
        /// <summary>
        ///     Gets or Sets GeneralPolicies
        /// </summary>
        public GeneralPolicies GeneralPolicies { get; set; }

        /// <summary>
        ///     Gets or Sets WorkstepTasks
        /// </summary>
        public WorkstepTasks WorkstepTasks { get; set; }

        /// <summary>
        ///     Gets or Sets AdhocPolicies
        /// </summary>
        public AdhocPolicies AdhocPolicies { get; set; }

        /// <summary>
        ///     Gets or Sets Version
        /// </summary>
        [XmlAttribute]
        public string Version { get; set; }
    }
}