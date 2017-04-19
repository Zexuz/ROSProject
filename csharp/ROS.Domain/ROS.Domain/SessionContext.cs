using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using ROS.Domain.Models;

namespace ROS.Domain
{
    public class SessionContext
    {
        public void SetAuthenticationToken(string name, bool isPersistant, User userData)
        {
//            if (userData != null)
//                data = new JavaScriptSerializer().Serialize(userData);

            var ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddYears(1), isPersistant, userData.Id.ToString());

            var cookieData = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData)
            {
                HttpOnly = true,
                Expires = ticket.Expiration
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public User GetUserData()
        {
            User userData = null;

            try
            {
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    var ticket = FormsAuthentication.Decrypt(cookie.Value);

                    userData = new JavaScriptSerializer().Deserialize(ticket.UserData, typeof(User)) as User;
                }
            }
            catch (Exception ex)
            {
            }

            return userData;
        }
    }
}