using NUnit.Framework;

namespace NamirialApiClient.Tests.TestBase
{
    [TestFixture]
    public abstract class NamirialClientTestBase 
    {
        [SetUp]
        public virtual void SetUp()
        { 
            InitTest();
        }

        private void InitTest()
        {
            
        }
    }  
}
