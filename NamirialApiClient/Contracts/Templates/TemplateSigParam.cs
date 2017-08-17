using System;
using System.ComponentModel;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Templates
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class TemplateSigParam : ServiceMessageBase<TemplateSigParam>
    {
        /// <summary>
        ///     Gets or Sets Name
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or Sets Value
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}