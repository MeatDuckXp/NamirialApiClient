using NamirialApiClient.Tests.TestBase;
using NUnit.Framework;

namespace NamirialApiClient.Tests.NamirialServiceTests
{
    [TestFixture]
    public class NamirialServiceTest : NamirialClientTestBase
    {
        private INamirialService _namirialService;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _namirialService = new NamirialService(Configuration);
        }
   
        [Test]
        public void Test1()
        {
            
        }
    }
}