using HtmlAgilityPack;
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
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://cancer.sanger.ac.uk/cosmic/User?email=" + email + "&password=" + password);
            req.CookieContainer = _cookieContainer; // <= HERE
            req.Method = "POST";
            req.KeepAlive = false;
            req.AllowAutoRedirect = false;
            req.Timeout = 10000;
            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                resp.Close();
                return isLogedIn();
            }
            catch (Exception)
            {
                return loginToCosmic(email, password);
            }
            
        }

        public void logoutFromCosmic()
        {
            _cookieContainer = new CookieContainer();
        }

        public bool isLogedIn()
        {
            string pageSource = getPageSource("http://cancer.sanger.ac.uk/cancergenome/projects/cosmic/");
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(pageSource);
            string loginTest=htmlDoc.GetElementbyId("login").InnerText.Trim();
            Console.WriteLine("XXXXXXXXXXX "+loginTest);
            if (loginTest.Equals("Login"))
                return false;
            return true;
        }

        public string getTsvFromCosmic(int CosmicId)
        {
            string pageSource = getPageSource("http://cancer.sanger.ac.uk/cosmic/references?q=MUTATION_REFERENCES&amp;id=" + CosmicId);
            return pageSource;
        }

        private string getPageSource(string url)
        {
            string pageSource;
            HttpWebRequest getRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            getRequest.CookieContainer = _cookieContainer;
            WebResponse getResponse = getRequest.GetResponse();
            using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
            {
                pageSource = sr.ReadToEnd();
            }
            getResponse.Close();
            return pageSource;
        }
    }
}
