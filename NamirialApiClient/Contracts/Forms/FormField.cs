using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Forms
{
    /// <summary>
    ///     Represents Completed Document
    /// </summary>
    [Serializable]
    [XmlRoot("formField", Namespace = "", IsNullable = false)]
    public class FormField : ServiceMessageBase<FormField>
    {
        /// <summary>
        ///     Gets or Sets Name
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or Sets Value
        /// </summary>
        [XmlElement("value", typeof (string))]
        public string Value { get; set; }
    }
}