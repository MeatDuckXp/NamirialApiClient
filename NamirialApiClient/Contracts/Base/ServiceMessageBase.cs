using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace NamirialApiClient.Contracts.Base
{
    /// <summary>
    ///     Represents Simple Service Message Base
    /// </summary>
    public abstract class ServiceMessageBase
    {
        /// <summary>
        ///     De-serializes object state from XML to Object instance of T
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="objectState">Object State As String</param>
        /// <returns>Instance of An object</returns>
        public static T Deserialize<T>(string objectState)
        {
            if (string.IsNullOrWhiteSpace(objectState))
            {
                return default(T);
            }

            T deserializedObject;

            using (var stringReader = new StringReader(objectState))
            {
                var serializer = new XmlSerializer(typeof (T));
                deserializedObject = (T) serializer.Deserialize(stringReader);
            }

            return deserializedObject;
        }
    }

    /// <summary>
    ///     Represents Namirial Service Message Base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ServiceMessageBase<T>
    {
        /// <summary>
        ///     Serializes the object state to XML string
        /// </summary>
        /// <returns></returns>
        public virtual string Serialize()
        {
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            };

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            string objectState;

            using (var memoryStream = new MemoryStream())
            {
                using (var streamReader = new StreamReader(memoryStream))
                {
                    using (var stringwriter = XmlWriter.Create(memoryStream, settings))
                    {
                        var serializer = new XmlSerializer(typeof (T));

                        serializer.Serialize(stringwriter, this, namespaces);

                        memoryStream.Flush();
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        objectState = streamReader.ReadToEnd();
                    }
                }
            }
            return objectState;
        }

        /// <summary>
        ///     Deserializes object state from XML to Object instance of T
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="objectState">Object State As String</param>
        /// <returns>Instance of An object</returns>
        public static T Deserialize(string objectState)
        {
            return ServiceMessageBase.Deserialize<T>(objectState);
        }
    }
}