using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scrapping
{
    public static class LibraryScrapping
    {

        #region "Scraping Book Search"
        public static List<Book> GetBooksSearch(string html)
        {
            html = html.Replace("\r", " ").Replace("\t", " ").Replace("\n", " ").Replace("&nbsp;", " ");
            html = Regex.Replace(html, " {2,}", " ");

            string patternCount = @"<div class=""counter.*?</div>";
            Regex rgxCount = new Regex(patternCount, RegexOptions.IgnoreCase);
            MatchCollection matchesCount = rgxCount.Matches(html);

            string pattern = @"<div class=""dvList.*?</div>";

            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(html);

            List<Book> books = new List<Book>();
            foreach (Match match in matches)
            {
                string libro = match.Value;
                string title = getTitleBookSearch(libro);
                List<string> dataSet = GetDataSetBookSearch(libro);
                Book book = MapperBookSearch(title, dataSet);
                books.Add(book);
            }
            
            return books;
        }

        private static string getTitleBookSearch(string html)
        {
            string pattern = @";return false;"">.*?</a>";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(html);

            string title = "";
            foreach (Match match in matches)
            {
                if (!match.Value.Contains("<img"))
                {
                    title = match.Value.Replace(@";return false;"">", "").Replace("</a>", "");
                }
            }

            return title;
        }

        private static List<string> GetDataSetBookSearch(string html)
        {

            string patternLink = @"href=""\?.*?""";
            Regex regexLink = new Regex(patternLink, RegexOptions.IgnoreCase);
            MatchCollection matchesLink = regexLink.Matches(html);

            string valueLink = matchesLink[0].Value.Replace(@"href=""?", "").Replace(@"""", "");
            List<String> listLink = valueLink.Split(new string[] { "&amp;" }, StringSplitOptions.None).ToList();

            string pattern = @"class=""noMosaic"">.*?</p>";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(html);

            List<string> datasetBook = new List<string>();
            foreach (Match match in matches)
            {
                string dataBook = match.Value.Replace(@"class=""noMosaic"">", "").Replace("</p>", "");
                datasetBook.Add(dataBook);
            }

            return datasetBook.Concat(listLink).ToList();
        }

        private static Book MapperBookSearch(string title, List<string> dataSet)
        {
            Book book = new Book();
            book.Title = title;
            foreach (string data in dataSet)
            {
                if (data.Contains("Publicaci"))
                {
                    book.Publication = data;
                }
                else if (data.Contains("Descripci"))
                {
                    book.PhysicalDescription = data;
                }
                else if (data.Contains("Autores"))
                {
                    book.Authors = data;
                }
                else if (data.Contains("ISBN"))
                {
                    book.ISBN = data;
                }
                else if (data.Contains("ACC"))
                {
                    book.ACC = data.Replace("ACC=", "");
                }
                else if (data.Contains("DOC"))
                {
                    book.DOC = data.Replace("DOC=", "");
                }
            }

            return book;
        }
        #endregion


        #region "Scraping Loan Book Library"

        public static List<LoanCity> GetLoanCityBook(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodes = doc.DocumentNode.SelectNodes("//div[@class='detmain detbib']");

            //Zonas de bibliotecas
            List<LoanCity> listLoanCity = new List<LoanCity>();
            foreach (var node in nodes)
            {                
                var cityLibrarie = node.SelectSingleNode("a").InnerText;
                var nodesNameLibraries = node.SelectNodes("div[@class='dtSuc']/a");
                List<string> namesLibraries = nodesNameLibraries.Select(x => x.InnerText).ToList();

                var nodesTrBookLibraries = node.SelectNodes("table[@class='dtNone']/tr");

                int countLibrarie = 0;
                List<LoanLibrary> listLoanLibrary = new List<LoanLibrary>();
                List<LoanData> listLoandData = new List<LoanData>();
                foreach (var nodeTrBook in nodesTrBookLibraries)
                {
                    var nodesTdBookData = nodeTrBook.SelectNodes("td");

                    if (nodesTdBookData != null)
                    {
                        List<string> listLoanData = new List<string>();
                        foreach (var nodeTd in nodesTdBookData)
                        {
                            if (!string.IsNullOrEmpty(nodeTd.InnerText))
                            {
                                listLoanData.Add(nodeTd.InnerText);
                            }
                        }
                        LoanData loanData = MapperLoanData(listLoanData);
                        listLoandData.Add(loanData);
                    }
                    else if (listLoandData.Count > 0)
                    {
                        LoanLibrary loanLibrary = new LoanLibrary();
                        loanLibrary.Name = namesLibraries.ElementAt(countLibrarie);
                        loanLibrary.LoanData = listLoandData;
                        listLoanLibrary.Add(loanLibrary);
                        listLoandData = new List<LoanData>();
                        countLibrarie++;
                    }
                }

                LoanLibrary loanLibrary1 = new LoanLibrary();
                loanLibrary1.Name = namesLibraries.ElementAt(countLibrarie);
                loanLibrary1.LoanData = listLoandData;
                listLoanLibrary.Add(loanLibrary1);

                LoanCity loanCity = new LoanCity();
                loanCity.Name = cityLibrarie;
                loanCity.ListLoanLibrary = listLoanLibrary;
                listLoanCity.Add(loanCity);

                listLoandData = new List<LoanData>();
                listLoanLibrary = new List<LoanLibrary>();

            }

            return listLoanCity;
        }

        private static LoanData MapperLoanData(List<string> listLoanData)
        {
            LoanData loanData = new LoanData();
            loanData.Location = listLoanData.ElementAt(0);
            loanData.TypeReader = listLoanData.ElementAt(0);
            loanData.TypeCopy = listLoanData.ElementAt(1);
            loanData.Signature = listLoanData.ElementAt(2);
            loanData.Availability = listLoanData.ElementAt(3);
            loanData.Support = listLoanData.ElementAt(4);

            return loanData;
        }
        #endregion
    }
}
