using System.Web;

namespace Com.Jamim.Infrastructure.Helpers
{
    public static class UrlHelper
    {
        public static string Resolve(string resource)
        {
            return string.Format("{0}://{1}{2}{3}",
                HttpContext.Current.Request.Url.Scheme,
                HttpContext.Current.Request.ServerVariables["HTTP_HOST"],
                (HttpContext.Current.Request.ApplicationPath.Equals("/")) ?
                string.Empty : HttpContext.Current.Request.ApplicationPath,
                resource
               );
        }
    }
}
