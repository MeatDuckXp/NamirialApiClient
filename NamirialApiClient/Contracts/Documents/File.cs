using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Documents
{
    /// <summary>
    ///     Defines File Sent to signing system
    /// </summary>
    [Serializable]
    [XmlRoot("file", Namespace = "", IsNullable = false)]
    public class File : ServiceMessageBase<File>
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <remarks>
        ///     PLaceholder to ensure that the class has parameterless constructor. This constructor is used by the XML
        ///     serializer and deserializer
        /// </remarks>
        public File()
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="name">File Name</param>
        /// <param name="data"></param>
        public File(string name, string data)
        {
            Name = name;
            Data = data;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="data">Data</param>
        public File(string name, byte[] data)
        {
            Name = name;
            Data = Convert.ToBase64String(data);
        }

        /// <summary>
        ///     Gets or Sets File Content
        /// </summary>
        [XmlElement("data", typeof (string))]
        public string Data { get; set; }

        /// <summary>
        ///     Gets or Sets File Name
        /// </summary>
        [XmlElement("name", typeof (string))]
        public string Name { get; set; }
    }
}