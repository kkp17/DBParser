using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace Parser.Core.Wiki
{
    class WikiParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("td").Where(item => item.ClassName != null);

            int i = 0;

            foreach(var item in items)
            {
                list.Add(item.TextContent);
                i++;
            }

           
            return list.ToArray();
        }
    }
}
