using System;
using System.Collections.Generic;
using NamirialApiClient.Contracts.Documents;
using NamirialApiClient.Contracts.Reciepients;

namespace NamirialApiClient
{
    public interface INamirialService
    {
        /// <summary>
        ///     Returns Namirial Service Version
        /// </summary>
        /// <returns>ServiceResponse</returns>
        ServiceResponse GetServiceVersion();

        /// <summary>
        ///     Validates Authorization Information
        /// </summary>
        /// <returns>ServiceResponse</returns>
        ServiceResponse ValidateAuthorization();

        /// <summary>
        ///     Cancels Envelope
        /// </summary>
        /// <param name="id">Envelope Id</param>
        /// <returns>ServiceResponse</returns>
        /// <remarks>
        ///     Signing request can be canceled only in certain states. It is to expect that the envelope cancellation fails.
        /// </remarks>
        ServiceResponse CancelEnvelope(Guid id);

        /// <summary>
        ///     Restarts Envelope
        /// </summary>
        /// <param name="id">Envelope Id</param>
        /// <param name="expiriationDaysCount">Envelope Expiration In Days (Count)</param>
        /// <returns>ServiceResponse</returns>
        ServiceResponse RestartEnvelope(Guid id, int expiriationDaysCount);

        /// <summary>
        ///     Deletes Envelope
        /// </summary>
        /// <param name="id">Envelope Id</param>
        /// <returns>ServiceResponse</returns>
        ServiceResponse DeleteEnvelope(Guid id);

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
        ServiceResponse CreateEnvelopeDraft(IList<Recipient> recipients, IList<string> documentIds, DateTime validFrom, DateTime validTo, string envelopeName, string emailSubject, string emailBody);

        /// <summary>
        ///     Returns Envelope status
        /// </summary>
        /// <param name="id">Envelope Id</param>
        /// <returns>ServiceResponse</returns>
        ServiceResponse GetEnvelopeStatus(Guid id);

        /// <summary>
        ///     Disposes Document on server
        /// </summary>
        /// <param name="id">Document Id</param>
        /// <returns>ServiceResponse</returns>
        ServiceResponse DisposeDocument(Guid id);

        /// <summary>
        ///     Downloads Signed Documents
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        ServiceResponse DownloadSignedDocuments(Guid envelopeId);

        /// <summary>
        ///     Returns Single Document regardless its state.
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        /// <param name="documentId">Document Id</param>
        /// <returns>ServiceResponse</returns>
        ServiceResponse DownloadDocument(Guid envelopeId, Guid documentId);

        /// <summary>
        ///     Deletes Envelope Documents
        /// </summary>
        /// <param name="envelopeId">Envelope Id</param>
        /// <returns>ServiceResponse</returns>
        ServiceResponse DeleteDocuments(Guid envelopeId);

        /// <summary>
        ///     Uploads Documents for signing
        /// </summary>
        /// <param name="file">Document Content</param>
        /// <returns>ServiceResponse</returns>
        ServiceResponse SendDocument(File file);

        /// <summary>
        ///     Uploads Documents for signing
        /// </summary>
        /// <param name="files">Collection of document contents</param>
        /// <returns>ServiceResponse</returns>
        ServiceResponse SendDocument(IList<File> files);
    }
}