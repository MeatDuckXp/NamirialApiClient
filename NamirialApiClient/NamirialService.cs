using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Xml.XPath;
using NamirialApiClient.Builders;
using NamirialApiClient.Configuration;
using NamirialApiClient.Contracts.Base;
using NamirialApiClient.Contracts.Common;
using NamirialApiClient.Contracts.Documents;
using NamirialApiClient.Contracts.Envleopes;
using NamirialApiClient.Contracts.Reciepients;
using NamirialApiClient.Contracts.Security;
using NamirialApiClient.Definitions;
using NamirialApiClient.Web_References.com.significant.www;

namespace NamirialApiClient
{
    /// <summary>
    ///     Represents wrapper around Namirial SOAP API Calls and the required logic close to the API
    /// </summary>
    public class NamirialService
    {
        #region Constructor 

        /// <summary>
        ///     Constructor Namirial Adapter Configuration
        /// </summary>
        /// <param name="configuration"></param>
        public NamirialService(NamirialAdapterConfiguration configuration)
        {
            _signingServiceConfiguration = configuration;

            _credentials = new AuthorizationData {OrganizationKey = _signingServiceConfiguration.OrganizationKey, UserLoginName = _signingServiceConfiguration.UserLoginName}.Serialize();

            _signingService = new Api
            {
                Url = _signingServiceConfiguration.ServiceEndpointUrl,
                Credentials = CredentialCache.DefaultCredentials
            };
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Cancels Singing Request
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        /// <returns>ServiceResponse</returns>
        /// <remarks>
        ///     Signing request can be canceled only in certain states. It is to expect that the envelope cancellation fails.
        /// </remarks>
        public ServiceResponse CancelSigningRequet(Guid envelopeId)
        {
            var response = new ServiceResponse();

            var apiResponseString = _signingService.CancelEnvelope_v1(_credentials, envelopeId.ToString());
            var apiResponseObject = default(ApiCallResult<bool>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<bool>>(apiResponseString);
            }

            //assuming we did not receive any response from their soap API
            if (apiResponseObject == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.NoServiceResponse);
                return response;
            }

            if (apiResponseObject.BaseResult == ResultStatus.Failed)
            {
                //check this just in case
                if (apiResponseObject.Error != null)
                {
                    response.AddErrorMessage(apiResponseObject.Error.Error, apiResponseObject.Error.ErrorMsg);
                }
                else
                {
                    response.AddErrorMessage(ErrorMessageDefiniton.NoErrorMessageProvided);
                }

                return response;
            }

            response.Result = apiResponseObject.OkInfo;

            return response;
        }

        /// <summary>
        ///     Restart Singing Request
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        /// <param name="expiriationDays">Envelope Expiration In Days (Count)</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse RestartSigningRequet(string envelopeId, int expiriationDays)
        {
            var response = new ServiceResponse();

            if (string.IsNullOrWhiteSpace(envelopeId))
            {
                response.AddErrorMessage(ErrorMessageDefiniton.EnvelopeIdNotProvided);
                return response;
            }

            if (expiriationDays <= default(int))
            {
                response.AddErrorMessage(ErrorMessageDefiniton.ExpirationDaysValueTooSmall);
                return response;
            }

            var apiResponseString = _signingService.RestartEnvelope_v1(_credentials, envelopeId, expiriationDays);
            var apiResponseObject = default(ApiCallResult<bool>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<bool>>(apiResponseString);
            }

            if (apiResponseObject == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.NoServiceResponse);
                return response;
            }

            if (apiResponseObject.BaseResult == ResultStatus.Failed)
            {
                //check this just in case
                if (apiResponseObject.Error != null)
                {
                    response.AddErrorMessage(apiResponseObject.Error.Error, apiResponseObject.Error.ErrorMsg);
                }
                else
                {
                    response.AddErrorMessage(ErrorMessageDefiniton.NoErrorMessageProvided);
                }

                return response;
            }

            response.Result = apiResponseObject.OkInfo;

            return response;
        }

        /// <summary>
        ///     Deletes Singing Request
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse DeleteSigningRequet(Guid envelopeId)
        {
            var response = new ServiceResponse();

            var apiResponseString = _signingService.DeleteEnvelope_v1(_credentials, envelopeId.ToString());
            var apiResponseObject = default(ApiCallResult<bool>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<bool>>(apiResponseString);
            }

            if (apiResponseObject == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.NoServiceResponse);
                return response;
            }

            if (apiResponseObject.BaseResult == ResultStatus.Failed)
            {
                //check this just in case
                if (apiResponseObject.Error != null)
                {
                    response.AddErrorMessage(apiResponseObject.Error.Error, apiResponseObject.Error.ErrorMsg);
                }
                else
                {
                    response.AddErrorMessage(ErrorMessageDefiniton.NoErrorMessageProvided);
                }
                return response;
            }

            response.Result = apiResponseObject.OkInfo;

            return response;
        }

        /// <summary>
        ///     Disposes Signing Document on server
        /// </summary>
        /// <param name="documentId">Document Id</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse DisposeSigningDocument(string documentId)
        {
            var response = new ServiceResponse();

            if (string.IsNullOrWhiteSpace(documentId))
            {
                response.AddErrorMessage(ErrorMessageDefiniton.EnvelopeIdNotProvided);
                return response;
            }

            var apiResponseString = _signingService.DisposeSspFile_v1(_credentials, documentId);
            var apiResponseObject = default(ApiCallResult<bool>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<bool>>(apiResponseString);
            }

            if (apiResponseObject == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.NoServiceResponse);
                return response;
            }

            if (apiResponseObject.BaseResult == ResultStatus.Failed)
            {
                //check this just in case
                if (apiResponseObject.Error != null)
                {
                    response.AddErrorMessage(apiResponseObject.Error.Error, apiResponseObject.Error.ErrorMsg);
                }
                else
                {
                    response.AddErrorMessage(ErrorMessageDefiniton.NoErrorMessageProvided);
                }

                return response;
            }

            response.Result = apiResponseObject.OkInfo;

            return response;
        }

        /// <summary>
        ///     Downloads Completed Documents for a given Envelope
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        public ServiceResponse DownloadCompletedDocuments(Guid envelopeId)
        {
            var response = new ServiceResponse();

            var result = GetEnvelope(envelopeId);

            if (!result.Success)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.EnvelopeNotFound);
                return response;
            }

            var envelopeStatus = (EnvelopeStatus) result.Result; //will just assume that we have here the envelope info ready

            if (envelopeStatus.Status != Status.Completed)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.EnvelopeNotCompleted);
                return response;
            }

            var signedDocuments = new List<CompletedDocument>();

            foreach (var bulkRecipient in envelopeStatus.BulkRecipients)
            {
                if (bulkRecipient.Status != Status.Completed)
                {
                    continue;
                }

                foreach (var complitedDocument in bulkRecipient.CompletedDocuments.CompletedDocument)
                {
                    var fileDownLoadResponseXml = _signingService.DownloadCompletedDocument_v1(_credentials, envelopeId.ToString(), complitedDocument.DocumentId.ToString());

                    if (string.IsNullOrWhiteSpace(fileDownLoadResponseXml))
                    {
                        continue;
                    }

                    var downloadDocumentResult = ServiceMessageBase.Deserialize<ApiCallResult<File>>(fileDownLoadResponseXml);

                    var documentFileContentNode = XDocument.Parse(fileDownLoadResponseXml).XPathSelectElement(_signingServiceConfiguration.FileElementPath);
                    if (documentFileContentNode != null)
                    {
                        downloadDocumentResult.OkInfo = ServiceMessageBase.Deserialize<File>(documentFileContentNode.ToString());
                    }

                    if (downloadDocumentResult.Sucessful)
                    {
                        complitedDocument.Content = downloadDocumentResult.OkInfo;
                        signedDocuments.Add(complitedDocument);
                    }
                }
            }

            response.Result = signedDocuments;

            return response;
        }

        /// <summary>
        ///     Returns Single Document regardless its state.
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        /// <param name="documentId">Document Id</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse DownloadDocument(Guid envelopeId, Guid documentId)
        {
            var response = new ServiceResponse();

            var apiResponseString = _signingService.DownloadCompletedDocument_v1(_credentials, envelopeId.ToString(), documentId.ToString());
            var apiResponseObject = default(ApiCallResult<File>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<File>>(apiResponseString);
                var fileNode = XDocument.Parse(apiResponseString).XPathSelectElement("/apiResult/okInfo/file");
                if (fileNode != null)
                {
                    apiResponseString = fileNode.ToString();
                    apiResponseObject.OkInfo = ServiceMessageBase.Deserialize<File>(apiResponseString);
                }
            }

            if (apiResponseObject == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.NoServiceResponse);
                return response;
            }

            if (apiResponseObject.BaseResult == ResultStatus.Failed)
            {
                //check this just in case
                if (apiResponseObject.Error != null)
                {
                    response.AddErrorMessage(apiResponseObject.Error.Error, apiResponseObject.Error.ErrorMsg);
                }
                else
                {
                    response.AddErrorMessage(ErrorMessageDefiniton.NoErrorMessageProvided);
                }
                return response;
            }

            response.Result = apiResponseObject.OkInfo;

            return response;
        }

        /// <summary>
        ///     Deletes Envelope Documents
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse DeleteEnvelopeDocuments(Guid envelopeId)
        {
            var response = new ServiceResponse();
            var envelopeStatusResult = GetEnvelope(envelopeId);

            if (!envelopeStatusResult.Success)
            {
                //failed to retrieve the envelope status, just send back he original issue
                return envelopeStatusResult;
            }

            var envelopeStatus = (EnvelopeStatus) envelopeStatusResult.Result;
            var deletedDocuments = new List<CompletedDocument>();

            foreach (var bulkRecipient in envelopeStatus.BulkRecipients)
            {
                if (bulkRecipient.Status != Status.Completed)
                {
                    continue;
                }

                foreach (var complitedDocument in bulkRecipient.CompletedDocuments.CompletedDocument)
                {
                    var fileDownLoadResponseXml = _signingService.DisposeSspFile_v1(_credentials, complitedDocument.DocumentId.ToString());
                    if (string.IsNullOrWhiteSpace(fileDownLoadResponseXml))
                    {
                        continue;
                    }

                    var downloadDocumentResult = ServiceMessageBase.Deserialize<ApiCallResult<File>>(fileDownLoadResponseXml);

                    var documentFileContentNode = XDocument.Parse(fileDownLoadResponseXml).XPathSelectElement(_signingServiceConfiguration.FileElementPath);
                    if (documentFileContentNode != null)
                    {
                        downloadDocumentResult.OkInfo = ServiceMessageBase.Deserialize<File>(documentFileContentNode.ToString());
                    }

                    if (downloadDocumentResult.Sucessful)
                    {
                        complitedDocument.Content = downloadDocumentResult.OkInfo;
                        deletedDocuments.Add(complitedDocument);
                    }
                    else
                    {
                        response.AddErrorMessage(ErrorMessageDefiniton.DocumentDownloadFailed);
                        return response;
                    }
                }
            }

            response.Result = deletedDocuments;

            return response;
        }

        /// <summary>
        ///     Uploads Temporal Documents for signing
        /// </summary>
        /// <param name="file">Document Content</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse UploadTemporaryDocument(File file)
        {
            var response = new ServiceResponse();

            if (file == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.FileContentMissing);
                return response;
            }

            var apiResponseString = _signingService.UploadTemporarySspFile_v1(_credentials, file.Serialize());
            var apiResponseObject = default(ApiCallResult<string>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<string>>(apiResponseString);
            }

            if (apiResponseObject == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.NoServiceResponse);
                return response;
            }

            if (apiResponseObject.BaseResult == ResultStatus.Failed)
            {
                if (apiResponseObject.Error != null)
                {
                    response.AddErrorMessage(apiResponseObject.Error.Error, apiResponseObject.Error.ErrorMsg);
                }
                else
                {
                    response.AddErrorMessage(ErrorMessageDefiniton.NoErrorMessageProvided);
                }

                return response;
            }

            response.Result = apiResponseObject.OkInfo;

            return response;
        }

        /// <summary>
        ///     Uploads Temporal Documents for signing
        /// </summary>
        /// <param name="files">Collection of document contents</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse UploadTemporaryDocument(IList<File> files)
        {
            var response = new ServiceResponse();

            var serviceResponses = files?.Select(UploadTemporaryDocument).ToList();

            if (serviceResponses != null)
            {
                response.Result = serviceResponses.Select(serviceResponse => serviceResponse.Result as string).ToList();
            }
            return response;
        }

        /// <summary>
        ///     Drafts Envelope
        /// </summary>
        /// <param name="recipients">Collection of Recipients</param>
        /// <param name="documentIds">Collection of document ids</param>
        /// <param name="validTo">Valid From</param>
        /// <param name="envelopeName">Envelope Name</param>
        /// <param name="emailSubject">Email Subject</param>
        /// <param name="emailBody">Email Body</param>
        /// <param name="validFrom">Valid To</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse SendDraftEnvelope(IList<Recipient> recipients, IList<string> documentIds, DateTime validFrom, DateTime validTo, string envelopeName, string emailSubject, string emailBody)
        {
            var response = new ServiceResponse();

            if (recipients == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.RecipientListNotProvided);
                return response;
            }

            if (documentIds == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.DocumentListNotProvided);
                return response;
            }

            var envelopeBuilder = new EnvelopeBuilder(_signingServiceConfiguration);
            var daysUntilExpire = (validTo - validFrom).Days;
            var envelope = envelopeBuilder.Build(recipients, documentIds, envelopeName, emailSubject, emailBody, daysUntilExpire);

            var redirectionConfig = new DraftOptions
            {
                AfterSendCallbackUrl = _signingServiceConfiguration.DefaultDraftOptionAfterSendCallbackUrl,
                AfterSendRedirectUrl = _signingServiceConfiguration.DefaultDraftOptionAfterSendRedirectUrl,
                RedirectPolicy = RedirectPolicy.ToDesigner,
                //to enable embedding of the IFrame showing the designer screen, this has to be set as is 
                IFrameWhiteList = _signingServiceConfiguration.ClientConnectUrl,
                AllowAgentRedirect = true
            };

            var apiResponseString = _signingService.CreateDraft_v1(_credentials, documentIds.ToArray(), envelope.Serialize(), redirectionConfig.Serialize());
            var apiResponseObject = default(ApiCallResult<string>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<string>>(apiResponseString);
            }

            if (apiResponseObject == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.NoServiceResponse);
                return response;
            }

            if (apiResponseObject.BaseResult == ResultStatus.Failed)
            {
                if (apiResponseObject.Error != null)
                {
                    response.AddErrorMessage(apiResponseObject.Error.Error, apiResponseObject.Error.ErrorMsg);
                }
                else
                {
                    response.AddErrorMessage(ErrorMessageDefiniton.NoErrorMessageProvided);
                }
                return response;
            }

            response.Result = apiResponseObject.OkInfo;

            return response;
        }

        /// <summary>
        ///     Returns envelope status
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse GetEnvelope(Guid envelopeId)
        {
            var response = new ServiceResponse();

            var apiResponseString = _signingService.GetEnvelopeById_v1(_credentials, envelopeId.ToString());
            var apiResponseObject = default(ApiCallResult<EnvelopeStatus>);
            var envelopeStatusString = default(string);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<EnvelopeStatus>>(apiResponseString);

                var envelopeStatusNode = XDocument.Parse(apiResponseString).XPathSelectElement("/apiResult/okInfo/envelopeStatus");
                if (envelopeStatusNode != null)
                {
                    envelopeStatusString = envelopeStatusNode.ToString();
                    apiResponseObject.OkInfo = ServiceMessageBase.Deserialize<EnvelopeStatus>(envelopeStatusString);
                }
            }

            if (apiResponseObject == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.NoServiceResponse);
                return response;
            }

            if (apiResponseObject.BaseResult == ResultStatus.Failed)
            {
                if (apiResponseObject.Error != null)
                {
                    response.AddErrorMessage(apiResponseObject.Error.Error, apiResponseObject.Error.ErrorMsg);
                }
                else
                {
                    response.AddErrorMessage(ErrorMessageDefiniton.NoErrorMessageProvided);
                }
                return response;
            }

            response.Result = apiResponseObject.OkInfo;
            response.OriginalResult = envelopeStatusString;

            return response;
        }

        /// <summary>
        ///     Restart Signing Request on server in order to initiate the process from beginning
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        /// <param name="expirationInDays">Envelope Expiration In Days (Count)</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse RestartSigningRequest(string envelopeId, int expirationInDays)
        {
            var response = new ServiceResponse();

            if (string.IsNullOrWhiteSpace(envelopeId))
            {
                response.AddErrorMessage(ErrorMessageDefiniton.EnvelopeIdNotProvided);
                return response;
            }

            var apiResponseString = _signingService.RestartEnvelope_v1(_credentials, envelopeId, expirationInDays);
            var apiResponseObject = default(ApiCallResult<bool>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<bool>>(apiResponseString);
            }

            if (apiResponseObject == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.NoServiceResponse);
                return response;
            }

            if (apiResponseObject.BaseResult == ResultStatus.Failed)
            {
                if (apiResponseObject.Error != null)
                {
                    response.AddErrorMessage(apiResponseObject.Error.Error, apiResponseObject.Error.ErrorMsg);
                }
                else
                {
                    response.AddErrorMessage(ErrorMessageDefiniton.NoErrorMessageProvided);
                }

                return response;
            }

            response.Result = apiResponseObject.OkInfo;

            return response;
        }

        #endregion

        #region Fields

        private readonly string _credentials;
        private readonly Api _signingService;
        private readonly NamirialAdapterConfiguration _signingServiceConfiguration;

        #endregion
    }
}