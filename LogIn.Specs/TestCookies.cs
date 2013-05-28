using System;
using System.Net;
using System.Web.Security;

namespace LogIn.Specs
{
    public class TestCookies
    {
        public static Cookie GetAuthCookie()
        {
            FormsAuthentication.Initialize();
            var utcNow = DateTime.UtcNow;
            var expirationUtc = utcNow.AddMinutes(2880);
            var ticket = new FormsAuthenticationTicket(2, "fred", utcNow, expirationUtc, false,string.Empty, FormsAuthentication.FormsCookiePath);            
            var hash = FormsAuthentication.Encrypt(ticket);
            var cookie = new Cookie(FormsAuthentication.FormsCookieName, hash)
            {
                Domain = FormsAuthentication.CookieDomain,
                Path = FormsAuthentication.FormsCookiePath,
                Expires = ticket.Expiration
            };
            return cookie;
        }
    }
}