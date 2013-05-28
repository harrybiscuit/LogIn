using System.Web.Mvc;
using System.Web.Security;

namespace LogIn.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";            
            FormsAuthenticationTicket t = FormsAuthentication.Decrypt(Request.Cookies[".aspxauth"].Values[0]);
            //FormsAuthenticationTicket t = FormsAuthentication.Decrypt("DBFF3F0DD64D98B4224024101E5BB0954BC0E62E92F5A5B8238116F9D7CFBAE5A418C1FA94240EAE0AD89620BBB211F91AF6C5E369FB37C092187FAB095B782A0C1A0A6A4DCCED521357B4A1B6CE32D001A5F2638FD5446F93B1FA389C121AA70D2825CFAD4E16AF7F069159AC668145CA136D29");
            //t = FormsAuthentication.Decrypt("DBFF3F0DD64D98B4224024101E5BB0954BC0E62E92F5A5B8238116F9D7CFBAE5A418C1FA94240EAE0AD89620BBB211F91AF6C5E369FB37C092187FAB095B782A0C1A0A6A4DCCED521357B4A1B6CE32D001A5F2638FD5446F93B1FA389C121AA70D2825CFAD4E16AF7F069159AC668145CA136D29");
            
            var v = ViewBag;
            v.CookiePath = t.CookiePath;
            v.Expiration = t.Expiration;
            v.Expired = t.Expired;
            v.IsPersisent = t.IsPersistent;
            v.IssueDate = t.IssueDate;
            v.Name = t.Name;
            v.UserData = t.UserData;
            v.version = t.Version;            
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
