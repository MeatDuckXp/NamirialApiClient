using System;
using System.Collections.Generic;
using System.IO;
using NamirialApiClient;
using NamirialApiClient.Configuration;
using NamirialApiClient.Contracts.Reciepients;

namespace NamirialApiClientTestProject.DraftCrationExamples
{
    public class DraftCrationExample
    {
        public static void RunExample()
        {
            var envelopeName = "Test Envelope Name";
            var emailSubject = "Notification Email Subject";
            var emailBody = "Notification Email Body";

            var recipients = new List<Recipient>
            {
                new Recipient
                {
                    Authentications = null,
                    Email = "youremail@emailprovider.com",
                    FirstName = "FirstName",
                    LanguageCode = "en-US", //this one depends on your settings in https://www.significant.com/Localization/Index. Don't forget to set them active
                    LastName = "LastName",
                    OrderIndex = 1,
                    Type = RecipientType.Signer
                }
            };

            var fileToBeSigned = new NamirialApiClient.Contracts.Documents.File("example.pdf", File.ReadAllBytes(GetDocumentPath()));

            Console.WriteLine("Loading Configuration");
            var namirialConfiguraiton = NamirialApiConfigurationCreator.Create();

            Console.WriteLine("Creating Namirial Client Service");
            var namirialClient = new NamirialService(namirialConfiguraiton);

            var documentUploadResult = namirialClient.SendDocument(fileToBeSigned);
            var documentReference = documentUploadResult.GetResult<string>();

            Console.WriteLine($"Document registered @ Namirial: {documentReference}");
            var envelopeDraftCreation = namirialClient.CreateEnvelopeDraft(recipients, new List<string> {documentReference}, DateTime.Today, DateTime.Today.AddDays(15), envelopeName, emailSubject, emailBody);

            var envelopeId = Guid.Parse(envelopeDraftCreation.GetResult<string>());
            Console.WriteLine($"Envelope created with reference: {envelopeId}");
        }

        public static string GetDocumentPath()
        {
            var path = Environment.CurrentDirectory + "\\Resources\\example.pdf";
            return path;
        }
    }
}