using System;
using System.Xml.Serialization;
using NamirialApiClient.Contracts.Base;

namespace NamirialApiClient.Contracts.Security
{
    /// <summary>
    ///     Represents Structure used as authorization input sent to Namirial WEB API
    /// </summary>
    [Serializable]
    [XmlRoot("authorization", Namespace = "", IsNullable = false)]
    public class AuthorizationData : ServiceMessageBase<AuthorizationData>
    {
        /// <summary>
        ///     Gets or Sets Organization Key
        /// </summary>
        [XmlElement("organizationKey", typeof (string), IsNullable = false)]
        public string OrganizationKey { get; set; }

        /// <summary>
        ///     Gets or Sets User Login Name
        /// </summary>
        [XmlElement("userLoginName", typeof (string), IsNullable = false)]
        public string UserLoginName { get; set; }
    }
}