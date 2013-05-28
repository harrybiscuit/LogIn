using System.Net;
using Machine.Specifications;

[Subject("Viewing Secured Home Page")]
public class when_viewing_a_secured_homepage_with_no_auth_cookie
{
    private static HttpWebRequest request;
    private static HttpWebResponse response;

    private Establish context = () =>
                                    {
                                        request = HttpWebRequest.Create("http://localhost:53759/") as HttpWebRequest;
                                        request.AllowAutoRedirect = false;
                                    };
    private Because of = () => { response = request.GetResponse() as HttpWebResponse; };

    private It should_redirect_to_the_login_page = () =>
                                                       {
                                                           response.StatusCode.ShouldEqual(HttpStatusCode.Redirect);
                                                           response.GetResponseHeader("Location").ShouldEqual("/Account/LogOn?ReturnUrl=%2f");
                                                       };
}