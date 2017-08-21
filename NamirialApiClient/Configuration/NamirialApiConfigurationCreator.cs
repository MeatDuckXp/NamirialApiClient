using System;
using System.Configuration;
using NamirialApiClient.Contracts.Reciepients;

namespace NamirialApiClient.Configuration
{
    /// <summary>
    ///     Fetches configuration values and creates NamirialApiConfiguration object
    /// </summary>
    public class NamirialApiConfigurationCreator
    {
        /// <summary>
        ///     Returns Configuration value
        /// </summary>
        /// <param name="configKeyname">Configuration Key</param>
        /// <param name="defaultValue">Default Value</param>
        /// <returns>Configuration value</returns>
        public static string GetConfiguration(string configKeyname, string defaultValue)
        {
            var item = ConfigurationManager.AppSettings[configKeyname];
            return !string.IsNullOrWhiteSpace(item) ? item : defaultValue;
        }

        /// <summary>
        ///     Returns Configuration value
        /// </summary>
        /// <param name="configKeyname">Configuration Key</param>
        /// <param name="defaultValue">Default Value</param>
        /// <returns>Configuration value</returns>
        public static bool GetConfiguration(string configKeyname, bool defaultValue)
        {
            var localConfigurationValue = false;
            var item = ConfigurationManager.AppSettings[configKeyname];

            if (!string.IsNullOrWhiteSpace(item))
            {
                if (bool.TryParse(item, out localConfigurationValue))
                {
                    return localConfigurationValue;
                }
            }
            return localConfigurationValue;
        }

        /// <summary>
        ///     Creates new Namirial API Configuration based on the configuration values
        /// </summary>
        /// <returns>NamirialApiConfiguration</returns>
        public static NamirialApiConfiguration Create()
        {
            var configuration = new NamirialApiConfiguration
            {
                ServiceEndpointUrl = GetConfiguration("ServiceEndpointUrl", string.Empty),
                OrganizationKey = GetConfiguration("OrganizationKey", string.Empty),
                UserLoginName = GetConfiguration("UserLoginName", string.Empty),
                DefaultDraftOptionAfterSendCallbackUrl = GetConfiguration("DefaultDraftOptionAfterSendCallbackUrl", string.Empty),
                DefaultDraftOptionAfterSendRedirectUrl = GetConfiguration("DefaultDraftOptionAfterSendRedirectUrl", string.Empty),
                DefaultRedirectPolicy = GetConfiguration("DefaultRedirectPolicy", string.Empty),  
                DefaultEnvelopeCallbackUrl = GetConfiguration("DefaultEnvelopeCallbackUrl", string.Empty),
                DefaultEnvelopeStatusUpdateCallbackUrl = GetConfiguration("DefaultEnvelopeStatusUpdateCallbackUrl", string.Empty),
                ClientUrl = GetConfiguration("ClientUrl", string.Empty)
            };

            var item = ConfigurationManager.AppSettings["DefaultRecipientType"];
            if (!string.IsNullOrWhiteSpace(item))
            {
                configuration.DefaultRecipientType = RecipientType.Signer;
                RecipientType tempRecipientType;
                if (Enum.TryParse(item, out tempRecipientType))
                {
                    configuration.DefaultRecipientType = tempRecipientType;
                }
            }

            return configuration;
        }
    }
}