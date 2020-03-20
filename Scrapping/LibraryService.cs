using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scrapping
{
    public static class LibraryService
    {        
        public static string GetCodeApiHTTP()
        {
            var client = new RestClient("https://gestiona3.madrid.org/mopac/cgi-bin/abnetopac/");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("origin", "https://gestiona3.madrid.org");
            request.AddHeader("host", "gestiona3.madrid.org");
            IRestResponse response = client.Execute(request);
            var input = response.Content;

            string pattern = "abnetopac.*\"";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(input);

            string codeApi = "";
            if (matches.Count > 0)
            {
                Console.WriteLine("{0} ({1} matches):", input, matches.Count);
                foreach (Match match in matches)
                {
                    codeApi = match.Value.Replace("abnetopac/", "").Replace("\"", "").Replace("?ACC=101", "");
                    Console.WriteLine("   " + codeApi);
                }

            }            

            return codeApi;            
        }

        public static string GetHtmlSearchHTTP( string search, int numberBook, string codeApi)
        {
            string url = string.Format("https://gestiona3.madrid.org/mopac/cgi-bin/abnetopac/{0}/NT1", codeApi);

            var client = new RestClient(url);
            var request = GetRequestGeneric(url);

            request.AddParameter("ACC", "131", ParameterType.GetOrPost);
            request.AddParameter("START", "1", ParameterType.GetOrPost);
            request.AddParameter("FORM", "1", ParameterType.GetOrPost);
            request.AddParameter("xsface", "on", ParameterType.GetOrPost);
            request.AddParameter("xindbt", "", ParameterType.GetOrPost);
            request.AddParameter("xmismo", "on", ParameterType.GetOrPost);
            request.AddParameter("FORM_DIGITAL", "9", ParameterType.GetOrPost);
            request.AddParameter("xsqf01", search, ParameterType.GetOrPost);
            request.AddParameter("xsnlis", numberBook, ParameterType.GetOrPost);

            //request.AddParameter("application/x-www-form-urlencoded", "ACC=131&START=1&FORM=2&xsface=on&xindbt=%20&xmismo=on&FORM_DIGITAL=9&xsqf01=coco", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public static string GetHtmlLoanBook(string ACC, string DOC, string codeApi)
        {
            string url = string.Format("https://gestiona3.madrid.org/biblio_publicas/cgi-bin/abnetopac/{0}", codeApi);

            var client = new RestClient(url);
            var request = GetRequestGeneric(url);
            request.AddParameter("ACC", ACC, ParameterType.GetOrPost);
            request.AddParameter("DOC", DOC, ParameterType.GetOrPost);

            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        private static RestRequest GetRequestGeneric(string url)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "7c35d13e-d041-2658-d0de-599296dd42e6");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("referer", url);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://gestiona3.madrid.org");
            request.AddHeader("host", "gestiona3.madrid.org");
            request.AddHeader("cookie", "ROUTEID=.p11773399");
            request.AddHeader("upgrade-insecure-requests", "1");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-mode", "navigate");
            return request;
        }
    }
}
