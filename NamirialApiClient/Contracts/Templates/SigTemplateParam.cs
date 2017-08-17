using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Templates
{
    /// <summary>
    ///     Defines Structure for signature template parameter
    /// </summary>
    [Serializable]
    [XmlRoot("SigTemplate", Namespace = "", IsNullable = false)]
    public class SigTemplateParam : ServiceMessageBase<SigTemplateParam>
    {
        /// <summary>
        ///     Gets or Sets Name
        /// </summary>
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or Sets Value
        /// </summary>
        [XmlText(typeof (string))]
        public string Value { get; set; }
    }
}