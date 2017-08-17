using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;
using NamirialApiClient.Contracts.Forms;

namespace NamirialApiClient.Contracts.Documents
{
    /// <summary>
    ///     Represents Completed Document
    /// </summary>
    [Serializable]
    [XmlRoot("completedDocument", Namespace = "", IsNullable = false)]
    public class CompletedDocument : ServiceMessageBase<CompletedDocument>
    {
        /// <summary>
        ///     Gets or Sets DocumentId
        /// </summary>
        [XmlElement("documentId", typeof (Guid))]
        public Guid DocumentId { get; set; }

        /// <summary>
        ///     Gets or Sets FileName
        /// </summary>
        [XmlElement("fileName", typeof (string))]
        public string FileName { get; set; }

        /// <summary>
        ///     Gets or Sets Fields
        /// </summary>
        [XmlArray("fields"), XmlArrayItem("formField")]
        public List<FormField> Fields { get; set; }

        /// <summary>
        ///     Document Content
        /// </summary>
        [XmlIgnore]
        public File Content { get; set; }

        /// <summary>
        ///     Adds form filed to the Fields Collection
        /// </summary>
        /// <param name="filed">Form Field</param>
        public void AddFormFiled(FormField filed)
        {
            if (filed == null)
            {
                return;
            }

            if (Fields == null)
            {
                Fields = new List<FormField>();
            }

            Fields.Add(filed);
        }
    }
}