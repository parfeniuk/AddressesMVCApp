using Addresses.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Addresses.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo)
        {
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", "#");
                a.AddCssClass("mypaging");
                a.SetInnerText(i.ToString());
                if (i == pagingInfo.CurrentPage)
                {
                    li.AddCssClass("active");
                }
                li.InnerHtml += a.ToString();
                ul.InnerHtml += li.ToString();
            }
            return MvcHtmlString.Create(ul.ToString());
        }
    }
}