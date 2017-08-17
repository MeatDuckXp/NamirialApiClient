using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Forms
{
    /// <summary>
    ///     Structure defining the configuration for parsing the form fields
    /// </summary>
    [Serializable]
    [XmlRoot("ParseFormFields", Namespace = "", IsNullable = false)]
    public class ParseFormFields : ServiceMessageBase<ParseFormFields>
    {
        /// <summary>
        ///     Gets or Sets Map Required Fields To Required Task
        /// </summary>
        /// <remarks>
        ///     Sets the form filling task required when some of the fields are required.
        /// </remarks>
        /// <list type="bullet">
        ///     <listheader>
        ///         <description>Possible values</description>
        ///     </listheader>
        ///     <item>
        ///         <term>'0'  - Required fields do not enforce the task to be required</term>
        ///     </item>
        ///     <item>
        ///         <term>'1' - Required forms lead to required tasks</term>
        ///     </item>
        /// </list>
        [XmlAttribute(AttributeName = "mapRequiredFieldsToRequiredTask")]
        public byte MapRequiredFieldsToRequiredTask { get; set; }

        /// <summary>
        ///     Gets or Sets Forms Grouping
        /// </summary>
        /// <remarks>
        ///     Specify how the parsed forms should be grouped into tasks
        /// </remarks>
        [XmlAttribute(AttributeName = "formsGrouping")]
        public FormsGrouping FormsGrouping { get; set; }

        /// <summary>
        ///     Gets or Sets Value
        /// </summary>
        /// <remarks>
        ///     Configuration for parsing the form fields
        /// </remarks>
        /// <list type="bullet">
        ///     <listheader>
        ///         <description>Possible values</description>
        ///     </listheader>
        ///     <item>
        ///         <term>'0' do not parse form fields</term>
        ///     </item>
        ///     <item>
        ///         <term>'1' parse the form fields</term>
        ///     </item>
        /// </list>
        [XmlText]
        public byte Value { get; set; }
    }
}