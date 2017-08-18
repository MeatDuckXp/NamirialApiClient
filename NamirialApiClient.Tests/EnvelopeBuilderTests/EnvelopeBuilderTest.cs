using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;
using Castle.Components.DictionaryAdapter;
using NamirialApiClient.Builders;
using NamirialApiClient.Contracts.Reciepients;
using NamirialApiClient.Tests.TestBase;
using NUnit.Framework;

namespace NamirialApiClient.Tests.EnvelopeBuilderTests
{
    [TestFixture]
    public class EnvelopeBuilderTest : NamirialClientTestBase
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _recipients = new EditableList<Recipient>();
            _documetns = new EditableList<string>();
            _envelopeName = "Test Envelope";
            _emailSubject = "Test Email Subject";
            _emailBody = "Test Email Body";
            _daysTillExpires = 5;
        }

        private List<Recipient> _recipients;
        private List<string> _documetns;
        private string _envelopeName;
        private string _emailSubject;
        private string _emailBody;
        private int _daysTillExpires;

        #region Envelope creation tests

        [Test]
        public void BuildEvnelope()
        {
            var envelopeBuilder = new EnvelopeBuilder(Configuration);
            var evnelope = envelopeBuilder.Build(_recipients, _documetns, _envelopeName, _emailSubject, _emailBody, _daysTillExpires);

            Assert.AreNotEqual(null, evnelope);
        }
        
        [Test]
        public void CheckDaysTillExpirte()
        {
            var envelopeBuilder = new EnvelopeBuilder(Configuration);
            var evnelope = envelopeBuilder.Build(_recipients, _documetns, _envelopeName, _emailSubject, _emailBody, _daysTillExpires);

            Assert.AreEqual(_daysTillExpires, evnelope.DaysUntilExpire);
        }

        [Test]
        public void CheckEnvelopeEmailData()
        {
            var envelopeBuilder = new EnvelopeBuilder(Configuration);
            var evnelope = envelopeBuilder.Build(_recipients, _documetns, _envelopeName, _emailSubject, _emailBody, _daysTillExpires);


            Assert.AreEqual(_emailSubject, evnelope.EmailSubject);
            Assert.AreEqual(_emailBody, evnelope.EmailBody);
            Assert.AreEqual(_daysTillExpires, evnelope.DaysUntilExpire);
        }

        [Test]
        public void CheckEnvelopeName()
        {
            var envelopeBuilder = new EnvelopeBuilder(Configuration);
            var evnelope = envelopeBuilder.Build(_recipients, _documetns, _envelopeName, _emailSubject, _emailBody, _daysTillExpires);

            Assert.AreEqual(_envelopeName, evnelope.Name);
        }

        #endregion

        #region Envelope Serialization Test

        [Test]
        public void SerilizationValidate()
        {
            var envelopeBuilder = new EnvelopeBuilder(Configuration);
            var evnelope = envelopeBuilder.Build(_recipients, _documetns, _envelopeName, _emailSubject, _emailBody, _daysTillExpires);

            var envelopeAsXml = evnelope.Serialize();
            Assert.AreNotEqual(string.Empty, envelopeAsXml);
        }
 
        [Test]
        public void SerilizationValidateSerializedOutput()
        {
            var envelopeBuilder = new EnvelopeBuilder(Configuration);
            var evnelope = envelopeBuilder.Build(_recipients, _documetns, _envelopeName, _emailSubject, _emailBody, _daysTillExpires);

            var envelopeAsXml = evnelope.Serialize();
            Assert.NotNull(XDocument.Parse(envelopeAsXml));
        }

        [Test]
        public void SerilizationValidateSerializedOutputContent()
        {
            var envelopeBuilder = new EnvelopeBuilder(Configuration);
            var evnelope = envelopeBuilder.Build(_recipients, _documetns, _envelopeName, _emailSubject, _emailBody, _daysTillExpires);
             
            var xmlDocumetn = XDocument.Parse(evnelope.Serialize());

            Assert.AreEqual(_envelopeName, xmlDocumetn.XPathSelectElement("envelope/name").Value);
            Assert.AreEqual(_emailSubject, xmlDocumetn.XPathSelectElement("envelope/eMailSubject").Value);
            Assert.AreEqual(_emailBody, xmlDocumetn.XPathSelectElement("envelope/eMailBody").Value);
            Assert.AreEqual(_daysTillExpires.ToString(), xmlDocumetn.XPathSelectElement("envelope/daysUntilExpire").Value);
        }
            
        #endregion

    }
}