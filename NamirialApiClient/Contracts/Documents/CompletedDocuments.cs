using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Documents
{
    /// <summary>
    ///     Represents Completed Document
    /// </summary>
    [Serializable]
    [XmlRoot("completedDocuments", Namespace = "", IsNullable = false)]
    public class CompletedDocuments : ServiceMessageBase<CompletedDocuments>
    {
        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [XmlElement("logDocumentId", typeof (string))]
        public string LogDocumentId { get; set; }

        /// <summary>
        ///     Gets or Sets committed document
        /// </summary>
        //[XmlArrayItem("completedDocument")]
        [XmlElement("completedDocument")]
        public List<CompletedDocument> CompletedDocument { get; set; }

        /// <summary>
        ///     Adds Completed Document to Completed Document list
        /// </summary>
        /// <param name="document">Completed Document</param>
        public void AddCompletedDocument(CompletedDocument document)
        {
            if (document == null)
            {
                return;
            }

            if (CompletedDocument == null)
            {
                CompletedDocument = new List<CompletedDocument>();
            }

            CompletedDocument.Add(document);
        }
    }
}