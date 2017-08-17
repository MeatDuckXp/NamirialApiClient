using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Templates
{
    /// <summary>
    ///     Configure the signature string parsing pattern: Text in the document will be parsed for this pattern and if found,
    ///     a signature task is generated.
    /// </summary>
    [Serializable]
    [XmlRoot("SigStringParsingConfiguration", Namespace = "", IsNullable = false)]
    public class SigStringParsingConfiguration : ServiceMessageBase<SigStringParsingConfiguration>
    {
        /// <summary>
        ///     Gets or Sets Sig Strings For Parsing
        /// </summary>
        /// <remarks>
        ///     Defines a signature string to parse. Tag can be present more than once-
        /// </remarks>
        [XmlElement("SigStringsForParsing", typeof (SigStringsForParsing))]
        public SigStringsForParsing SigStringsForParsing { get; set; }
    }
}