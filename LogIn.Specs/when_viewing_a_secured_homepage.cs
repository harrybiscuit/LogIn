using System.Net;
using LogIn.Specs;
using Machine.Specifications;

[Subject("Viewing Secured Home Page")]
public class when_viewing_a_secured_homepage_with_auth_cookie
{
    private static HttpWebRequest request;
    private static HttpWebResponse response;

    private Establish context = () =>
    {

        var authCookie = TestCookies.GetAuthCookie();
        var cookieContainer = new CookieContainer();
        cookieContainer.Add(authCookie);
        request = HttpWebRequest.Create("http://localhost:53759/") as HttpWebRequest ;
        request.CookieContainer = new CookieContainer();
        request.CookieContainer.Add(authCookie);
        request.AllowAutoRedirect = false;
        
    };
    private Because of = () => response = request.GetResponse() as HttpWebResponse;

    private It should_return_the_home_page = () => response.StatusCode.ShouldEqual(HttpStatusCode.OK);
}