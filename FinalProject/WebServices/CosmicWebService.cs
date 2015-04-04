using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

        public bool loginToCosmic(string email,string password,int times)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://cancer.sanger.ac.uk/cosmic/User?email=" + email + "&pass=" + password);
            req.CookieContainer = _cookieContainer; 
            req.Method = "POST";
            req.KeepAlive = false;
            req.AllowAutoRedirect = false;
            req.Timeout = 10000;
            try
            {
                if (times == 0)
                    return false;
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                
                return isLogedIn();
            }
            catch (Exception)
            {
                return loginToCosmic(email, password,times-1);
            }
        }
        public void logoutFromCosmic()
        {
            _cookieContainer = new CookieContainer();
        }

        public bool isLogedIn()
        {
            string pageSource = getPageSource("http://cancer.sanger.ac.uk/cosmic/user_info","GET");
            return !Regex.IsMatch(pageSource, "\\bLogin\\b");
            
        }

        public string getTsvFromCosmic(int CosmicId)
        {
            string pageSource = getPageSource("http://cancer.sanger.ac.uk/cosmic/references?q=MUTATION_REFERENCES&amp;id=" + CosmicId,"GET");
            return pageSource;
        }

        private string getPageSource(string url,string method)
        {
            string pageSource;
            HttpWebRequest getRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            getRequest.CookieContainer = _cookieContainer;
            getRequest.Method = method;
            getRequest.KeepAlive = false;
            getRequest.AllowAutoRedirect = false;
            getRequest.Timeout = 10000;
            try
            {
                WebResponse getResponse = getRequest.GetResponse();
                using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
                {
                    pageSource = sr.ReadToEnd();
                }
                getResponse.Close();
                return pageSource;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error on creation: {0}", e.ToString());
                return null;
            }
           
        }
    }
}
