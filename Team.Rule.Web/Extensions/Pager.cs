using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace System
{
    public class Pager
    {
        private ViewContext viewContext;
        private readonly int pageSize;
        private readonly int currentPage;
        private readonly int totalItemCount;
        private readonly RouteValueDictionary linkWithoutPageValuesDictionary;
        private readonly bool m_IsAjax;
        private readonly string functionName;

        public Pager(ViewContext viewContext, int pageSize, int currentPage, int totalItemCount, RouteValueDictionary valuesDictionary, bool isAjax, string funcName)
        {
            this.viewContext = viewContext;
            this.pageSize = pageSize;
            this.currentPage = currentPage;
            this.totalItemCount = totalItemCount;
            this.linkWithoutPageValuesDictionary = valuesDictionary;
            m_IsAjax = isAjax;
            functionName = funcName;
        }

        public string RenderHtml()
        {
            int pageCount = (int)Math.Ceiling(this.totalItemCount / (double)this.pageSize);
            int nrOfPagesToDisplay = 4;

            var sb = new StringBuilder();

            // Previous
            sb.Append("<ul class=\"sortpage fr\">");
            if (this.currentPage > 1)
            {
                sb.Append("<li style=\" float:left; \" class=\"turnleft\">").Append(GeneratePageLink("<", this.currentPage - 1)).Append("</li>");
            }
            else
            {
                sb.Append("<li style=\" float:left; \" class=\"turnleft\"><a href=\"javascript:;\"><</a></li>");
            }

            int start = 1;
            int end = pageCount;

            if (pageCount > nrOfPagesToDisplay)
            {
                int middle = (int)Math.Ceiling(nrOfPagesToDisplay / 2d) - 1;
                int below = (this.currentPage - middle);
                int above = (this.currentPage + middle);

                if (below <= 2)
                {
                    above = (pageCount - nrOfPagesToDisplay) > 2 ? nrOfPagesToDisplay : pageCount;
                    below = 1;
                }
                else if (above >= (pageCount - 2))
                {
                    above = pageCount;
                    below = (pageCount - nrOfPagesToDisplay) > 2 ? (pageCount - nrOfPagesToDisplay) : 1;
                }

                start = below;
                end = above;
            }

            if (start > 2)
            {
                sb.Append("<li style=\" float:left; \">").Append(GeneratePageLink("1", 1)).Append("</li>");
                sb.Append("<li style=\" float:left; \">").Append("...").Append("</li>");
            }
            for (int i = start; i <= end; i++)
            {
                if (i == this.currentPage)
                {
                    sb.Append("<li style=\" float:left; \" >").Append("<a class=\"page-now\" href=\"javascript:;\">" + i + "</a>").Append("</li>");
                }
                else
                {
                    sb.Append("<li style=\" float:left; \">").Append(GeneratePageLink(i.ToString(), i)).Append("</li>");
                }
            }
            if (end < (pageCount - 2))
            {
                sb.Append("<li style=\" float:left; \">").Append("...").Append("</li>");
                sb.Append("<li style=\" float:left; \">").Append(GeneratePageLink(pageCount.ToString(), pageCount)).Append("</li>");
            }
            int valuePage = currentPage == pageCount ? 1 : currentPage + 1 > pageCount ? pageCount : currentPage + 1;
            int currentCount = pageCount - currentPage == 0 ? (totalItemCount - pageSize * (currentPage - 1)) : pageSize;
            // Next
            if (this.currentPage < pageCount)
            {
                sb.Append("<li style=\" float:left; \" class=\"turnright\">").Append(GeneratePageLink(">", (this.currentPage + 1))).Append("</li>");
            }
            else
            {
                sb.Append("<li style=\" float:left; \" class=\"turnright\"><a href=\"javascript:;\">></a></li>");
            }
            sb.Append("</ul>");
            sb.Append("<div class=\"sortpage-number\">共<span class=\"blue\">" + totalItemCount + "</span>条信息，本页展示<span class=\"blue\">" + currentCount + "</span>条</div>");
            sb.Append("<script type=\"text/javascript\">" + "$(function () {$(\".linkbtn\").click(function () {").Append(functionName + "($(\".inp_page\").val());})})").Append("<\\/script>");
            return sb.ToString();
        }

        private string GeneratePageLink(string linkText, int pageNumber)
        {
            var pageLinkValueDictionary = new RouteValueDictionary(this.linkWithoutPageValuesDictionary);
            pageLinkValueDictionary.Add("page", pageNumber);


            string url = string.Empty;

            var routes = RouteTable.Routes;
            var requestContext = viewContext.RequestContext;
            var routeData = requestContext.RouteData;
            var dataTokens = routeData.DataTokens;
            if (dataTokens["area"] == null)
                dataTokens.Add("area", "");
            var virtualPathData = routes.GetVirtualPathForArea(requestContext, routeData.Values);
            if (virtualPathData != null)
            {
                var virtualPath = virtualPathData.VirtualPath.ToLower();
                var request = requestContext.HttpContext.Request;
                string queryString = request.Url.Query;
                if (string.IsNullOrEmpty(queryString))
                {
                    queryString = queryString + "?page=" + pageNumber.ToString();
                }
                else if (queryString.ToLower().IndexOf("page=") > 0)
                {
                    int i = queryString.ToLower().IndexOf("page=");
                    queryString = queryString.Substring(0, i + 5) + pageNumber.ToString() + queryString.Substring(i + 6);
                }
                else
                {
                    queryString += "&page" + pageNumber.ToString();
                }
                url = virtualPath + queryString;
            }

            if (virtualPathData != null)
            {
                if (!m_IsAjax)
                {
                    string linkFormat = "<a href=\"{0}\">{1}</a>";
                    return string.Format(linkFormat, url, linkText);
                }
                else
                {
                    string linkFormat = "<a href=\"javascript:{1}({2})\">{0}</a>";
                    return String.Format(linkFormat, linkText, functionName, pageNumber);
                }
            }
            else
            {
                return null;
            }
        }
    }
}