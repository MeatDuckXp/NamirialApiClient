using NamirialApiClient.Configuration;
using NUnit.Framework;

namespace NamirialApiClient.Tests.TestBase
{
    [TestFixture]
    public abstract class NamirialClientTestBase 
    {
        protected NamirialApiConfiguration Configuration { get; set; }

        [SetUp]
        public virtual void SetUp()
        { 
            Configuration = new NamirialApiConfiguration();
        } 
    }  
}
