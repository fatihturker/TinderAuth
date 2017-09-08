using SimpleBrowser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TinderAuth.Helpers
{
    public static class FacebookHelper
    {
        private const string FacebookUrl = "https://www.facebook.com/v2.6/dialog/oauth?redirect_uri=fb464891386855067%3A%2F%2Fauthorize%2F&display=touch&state=%7B%22challenge%22%3A%22IUUkEUqIGud332lfu%252BMJhxL4Wlc%253D%22%2C%220_auth_logger_id%22%3A%2230F06532-A1B9-4B10-BB28-B29956C71AB1%22%2C%22com.facebook.sdk_client_state%22%3Atrue%2C%223_method%22%3A%22sfvc_auth%22%7D&scope=user_birthday%2Cuser_photos%2Cuser_education_history%2Cemail%2Cuser_relationship_details%2Cuser_friends%2Cuser_work_history%2Cuser_likes&response_type=token%2Csigned_request&default_audience=friends&return_scopes=true&auth_type=rerequest&client_id=464891386855067&ret=login&sdk=ios&logger_id=30F06532-A1B9-4B10-BB28-B29956C71AB1&ext=1470840777&hash=AeZqkIcf-NEW6vBd";

        public static string GetAccessToken(string email, string password)
        {
            try
            {
                var browser = new Browser
                {
                    UserAgent = "Tinder/7.5.3 (iPhone; iOS 10.3.2; Scale/2.00)"
                };
                
                browser.SetHeader("Host: m.facebook.com");
                
                browser.Navigate(FacebookUrl);

                browser.Find("input", FindBy.Name, "email").Value = email;
                browser.Find("input", FindBy.Name, "pass").Value = password;
                browser.Find("input", FindBy.Name, "login").Click();
                browser.Find("input", FindBy.Name, "__CONFIRM__").Click();

                var body = browser.CurrentHtml.ToString();
                if (body.Contains("access_token"))
                {
                    var match = Regex.Match(body, @"access_token=(.*)&expires_in", RegexOptions.IgnoreCase);
                    return match.Groups[1].Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "";
        }
    }
}
