using LdapTest;
using NUnit.Framework;

namespace LdapTestTest
{
    public class Tests
    {
        private const string LDAP_SERVER_ADDRESS = "192.168.6.145";

        private LdapTester Tester { get; set; }

        [SetUp]
        public void Setup()
        {
            Tester = new LdapTester(LDAP_SERVER_ADDRESS);
        }

        [Test]
        public void Test_ShouldAuthenticate()
        {
            bool result = Tester.Test("username", "password", "domain");
            Assert.IsTrue(result);
        }
    }
}