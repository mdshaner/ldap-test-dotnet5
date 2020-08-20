using System;
using System.DirectoryServices.Protocols;
using System.Net;

namespace LdapTest
{
    public class LdapTester
    {
        public bool Test(string username, string password, string domain)
        {
            LdapDirectoryIdentifier identifier = new LdapDirectoryIdentifier("");
            NetworkCredential credential = new NetworkCredential(username, password, domain);
            LdapConnection connection = new LdapConnection(identifier, credential, AuthType.Negotiate);
            try
            {
                connection.Bind();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}