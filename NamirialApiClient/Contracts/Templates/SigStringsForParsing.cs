using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Templates
{
    /// <summary>
    ///     Defines a signature string to parse. Tag can be present more than once
    /// </summary>
    [Serializable]
    [XmlRoot("SigStringsForParsing", Namespace = "", IsNullable = false)]
    public class SigStringsForParsing : ServiceMessageBase<SigStringsForParsing>
    {
        /// <summary>
        ///     Gets or Sets Start Pattern
        /// </summary>
        /// <remarks>
        ///     The start pattern of the signature string if it has a start and end pattern. Otherwise the whole word to parse
        /// </remarks>
        [XmlElement("StartPattern", typeof (string))]
        public string StartPattern { get; set; }

        /// <summary>
        ///     Gets or Sets End Pattern
        /// </summary>
        /// <remarks>
        ///     End pattern if needed, otherwise empty
        /// </remarks>
        [XmlElement("EndPattern", typeof (string))]
        public string EndPattern { get; set; }

        /// <summary>
        ///     Gets or Sets Clear Sig String
        /// </summary>
        /// <remarks>
        ///     Define if the signature strings should be cleared from the document
        /// </remarks>
        /// <list type="bullet">
        ///     <listheader>
        ///         <term> Possible values:</term>
        ///     </listheader>
        ///     <item>
        ///         <term>'0'</term>
        ///         <description>Do not change the document</description>
        ///     </item>
        ///     <item>
        ///         <term>'1'</term>
        ///         <description>Remove the signature strings from the document</description>
        ///     </item>
        /// </list>
        [XmlElement("ClearSigString", typeof (byte))]
        public byte ClearSigString { get; set; }

        /// <summary>
        ///     Gets or Sets Search Entire Word Only
        /// </summary>
        /// <remarks>
        ///     Define if only the entire word should be searched. For example if start pattern is 'signature' only 'signature' but
        ///     not
        ///     'signaturepad' is found.This option does only effect signature string without end patterns.
        /// </remarks>
        /// <list type="bullet">
        ///     <listheader>
        ///         <term> Possible values:</term>
        ///     </listheader>
        ///     <item>
        ///         <term>'0'</term>
        ///         <description>Search words containing the pattern as well</description>
        ///     </item>
        ///     <item>
        ///         <term>'1'</term>
        ///         <description>Search only the entire word</description>
        ///     </item>
        /// </list>
        [XmlElement("SearchEntireWordOnly", typeof (byte))]
        public byte SearchEntireWordOnly { get; set; }
    }
}