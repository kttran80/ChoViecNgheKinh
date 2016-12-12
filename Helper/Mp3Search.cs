using System.Collections.Generic;
using HtmlAgilityPack;

namespace Onha.Kiet
{
    public class Mp3Search
    {
        public List<Mp3Collection> GetCollectin(string htmlContent)
        {
            var result = new List<Mp3Collection>();
            var html = new HtmlDocument();
            html.LoadHtml(htmlContent);
            var root = html.DocumentNode;

            var tr = root.Descendants("tr");


            return result;
        }
    }
}