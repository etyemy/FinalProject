using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FinalProject
{
    class CosmicWebService
    {
        private CookieContainer _cookieContainer;

        public CosmicWebService()
        {
            _cookieContainer = new CookieContainer();
        }

        public bool loginToCosmic(string email,string password)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://cancer.sanger.ac.uk/cosmic/login?email="+email+"&password="+password);
            req.CookieContainer = _cookieContainer; // <= HERE
            req.Method = "HEAD";
            req.KeepAlive = false;
            req.AllowAutoRedirect = false;
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            return isLogedIn();
        }

        public bool isLogedIn()
        {
           string pageSource;
            string getUrl = "https://cancer.sanger.ac.uk/cosmic/user_info";
            HttpWebRequest getRequest = (HttpWebRequest)HttpWebRequest.Create(getUrl);
            getRequest.CookieContainer = _cookieContainer;
            WebResponse getResponse = getRequest.GetResponse();
            using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
            {
                pageSource = sr.ReadToEnd();
            }
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(pageSource);
            string loginTest=htmlDoc.GetElementbyId("user").InnerText.Trim();
            if (loginTest.Equals("Login"))
                return false;
            return true;
        }
    }
}
