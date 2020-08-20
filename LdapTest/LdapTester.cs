using System;
using System.DirectoryServices.Protocols;
using System.Net;

namespace LdapTest
{
    public class LdapTester
    {

        public LdapTester(string ldapServer)
        {
            Identifier = new LdapDirectoryIdentifier(ldapServer);
        }

        private LdapDirectoryIdentifier Identifier { get; }

        public bool Test(string username, string password, string domain)
        {
            try
            {
                using LdapConnection ldapConnection = new LdapConnection(Identifier);
                ldapConnection.AuthType = AuthType.Negotiate;
                ldapConnection.Credential = new NetworkCredential(username, password, domain);
                ldapConnection.Timeout = TimeSpan.FromSeconds(1);

                // bind ldap connection...assume valid credentials if bind succeeds
                ldapConnection.Bind();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}