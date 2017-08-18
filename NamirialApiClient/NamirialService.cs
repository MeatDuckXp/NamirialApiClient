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
    public class NamirialService : INamirialService
    {
        #region Constructor 

        /// <summary>
        ///     Constructor Namirial Adapter Configuration
        /// </summary>
        /// <param name="configuration"></param>
        public NamirialService(NamirialApiConfiguration configuration)
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

        #region Private Methods

        /// <summary>
        ///     Creates instance of ServiceResponse
        /// </summary>
        /// <returns></returns>
        private static ServiceResponse CreateServiceResponse()
        {
            var response = new ServiceResponse();
            return response;
        }

        #endregion

        #region API Related Actions

        /// <summary>
        ///     Returns Namirial Service Version 
        /// </summary>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse GetServiceVersion()
        {
            var apiResponseString = _signingService.GetVersion_v1();
            var apiResponseObject = default(ApiCallResult<string>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<string>>(apiResponseString);
            }
            
            var response = CreateServiceResponse();
            if (apiResponseObject == null)
            {
                response.AddErrorMessage(ErrorMessageDefiniton.NoServiceResponse);
                return response;
            }

            if (apiResponseObject.BaseResult == ResultStatus.Failed)
            {
                if (apiResponseObject.Error != null) {
                    response.AddErrorMessage(apiResponseObject.Error.Error, apiResponseObject.Error.ErrorMsg);
                } else {
                    response.AddErrorMessage(ErrorMessageDefiniton.NoErrorMessageProvided);
                }

                return response;
            }

            response.Result = apiResponseObject.OkInfo;

            return response;
        }

        /// <summary>
        ///     Validates Authorization Information
        /// </summary>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse ValidateAuthorization()
        {
            throw new NotImplementedException();
            //var apiResponseString = _signingService.ValidateAuthorization_v1(_credentials);

            //var response = CreateServiceResponse();
            //return response;
        }

        #endregion

        #region Envelope Related Actions

        /// <summary>
        ///     Cancels Envelope
        /// </summary>
        /// <param name="id">Envelope Id</param>
        /// <returns>ServiceResponse</returns>
        /// <remarks>
        ///     Signing request can be canceled only in certain states. It is to expect that the envelope cancellation fails.
        /// </remarks>
        public ServiceResponse CancelEnvelope(Guid id)
        {
            var apiResponseString = _signingService.CancelEnvelope_v1(_credentials, id.ToString());
            var apiResponseObject = default(ApiCallResult<bool>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<bool>>(apiResponseString);
            }

            var response = CreateServiceResponse();
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
        ///     Restarts Envelope
        /// </summary>
        /// <param name="id">Envelope Id</param>
        /// <param name="expiriationDaysCount">Envelope Expiration In Days (Count)</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse RestartEnvelope(Guid id, int expiriationDaysCount)
        {
            var apiResponseString = _signingService.RestartEnvelope_v1(_credentials, id.ToString(), expiriationDaysCount);
            var apiResponseObject = default(ApiCallResult<bool>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<bool>>(apiResponseString);
            }

            var response = CreateServiceResponse();
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
        ///     Deletes Envelope
        /// </summary>
        /// <param name="id">Envelope Id</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse DeleteEnvelope(Guid id)
        {
            var apiResponseString = _signingService.DeleteEnvelope_v1(_credentials, id.ToString());
            var apiResponseObject = default(ApiCallResult<bool>);

            if (!string.IsNullOrWhiteSpace(apiResponseString))
            {
                apiResponseObject = ServiceMessageBase.Deserialize<ApiCallResult<bool>>(apiResponseString);
            }

            var response = CreateServiceResponse();
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
        ///     Creates Envelope Draft
        /// </summary>
        /// <param name="recipients">Collection of Recipients</param>
        /// <param name="documentIds">Collection of document ids</param>
        /// <param name="validTo">Valid From</param>
        /// <param name="envelopeName">Envelope Name</param>
        /// <param name="emailSubject">Email Subject</param>
        /// <param name="emailBody">Email Body</param>
        /// <param name="validFrom">Valid To</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse CreateEnvelopeDraft(IList<Recipient> recipients, IList<string> documentIds, DateTime validFrom, DateTime validTo, string envelopeName, string emailSubject, string emailBody)
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
        ///     Returns Envelope status
        /// </summary>
        /// <param name="id">Envelope Id</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse GetEnvelopeStatus(Guid id)
        {
            var apiResponseString = _signingService.GetEnvelopeById_v1(_credentials, id.ToString());
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

            var response = CreateServiceResponse();
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

        #endregion

        #region Document related Actions

        /// <summary>
        ///     Disposes Document on server
        /// </summary>
        /// <param name="id">Document Id</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse DisposeDocument(Guid id)
        {
            var response = new ServiceResponse();

            var apiResponseString = _signingService.DisposeSspFile_v1(_credentials, id.ToString());
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
        ///     Downloads Signed Documents
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        public ServiceResponse DownloadSignedDocuments(Guid envelopeId)
        {
            var response = new ServiceResponse();
            var result = GetEnvelopeStatus(envelopeId);

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

                    var documentFileContentNode = XDocument.Parse(fileDownLoadResponseXml).XPathSelectElement("/apiResult/okInfo/file");
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
        public ServiceResponse DeleteDocuments(Guid envelopeId)
        {
            var response = new ServiceResponse();
            var envelopeStatusResult = GetEnvelopeStatus(envelopeId);

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

                    var documentFileContentNode = XDocument.Parse(fileDownLoadResponseXml).XPathSelectElement("/apiResult/okInfo/file");
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
        ///     Uploads Documents for signing
        /// </summary>
        /// <param name="file">Document Content</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse SendDocument(File file)
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
        ///     Uploads Documents for signing
        /// </summary>
        /// <param name="files">Collection of document contents</param>
        /// <returns>ServiceResponse</returns>
        public ServiceResponse SendDocument(IList<File> files)
        {
            var response = new ServiceResponse();

            var serviceResponses = files?.Select(SendDocument).ToList();
            if (serviceResponses != null)
            {
                response.Result = serviceResponses.Select(serviceResponse => serviceResponse.Result as string).ToList();
            }
            return response;
        }

        #endregion

        #region Fields

        private readonly string _credentials;
        private readonly Api _signingService;
        private readonly NamirialApiConfiguration _signingServiceConfiguration;

        #endregion
    }
}