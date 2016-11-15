using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace System
{
    public static class PagingExtensions
    {
        #region HtmlHelper extensions

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, bool isAjax, string funcName)
        {
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, null, null, isAjax, funcName);
        }


        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, string actionName, bool isAjax, string funcName)
        {
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, actionName, null, isAjax, funcName);
        }

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, object values, bool isAjax, string funcName)
        {
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, null, new RouteValueDictionary(values), isAjax, funcName);
        }

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, string actionName, object values, bool isAjax, string funcName)
        {
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, actionName, new RouteValueDictionary(values), isAjax, funcName);
        }

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, RouteValueDictionary valuesDictionary, bool isAjax, string funcName)
        {
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, null, valuesDictionary, isAjax, funcName);
        }

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, string actionName, RouteValueDictionary valuesDictionary, bool isAjax, string funcName)
        {
            if (totalItemCount <= pageSize)
            {
                return "";
            }
            if (valuesDictionary == null)
            {
                valuesDictionary = new RouteValueDictionary();
            }
            if (actionName != null)
            {
                if (valuesDictionary.ContainsKey("action"))
                {
                    throw new ArgumentException("The valuesDictionary already contains an action.", "actionName");
                }
                valuesDictionary.Add("action", actionName);
            }
            var pager = new Pager(htmlHelper.ViewContext, pageSize, currentPage, totalItemCount, valuesDictionary, isAjax, funcName);
            return pager.RenderHtml();
        }



        #region 平台后台通用分页
        public static string Pager(Int32 pageIndex, Int32 pageSize, Int32 totalPages, Int32 maxPage)
        {
            var pageCount = totalPages; //总页数
            if (pageCount <= 1)
            {
                return string.Empty;
            }

            var strHtml = new StringBuilder();

            strHtml.AppendFormat("<div class='sortpage-number'><span>{0}条/页</span><span>共{1}页</span></div>", pageSize, pageCount);
            strHtml.Append("<div class='sortpage fr' id='pagetitle'>");
            //strHtml.AppendFormat("<a class='first' data-pageIndex='1' href='{0}?pageIndex=1&pageSize={1}'>首页</a>");
            if (pageIndex == 1)
            {
                strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'><</a>", 1);
            }
            else
            {
                strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'><</a>", (pageIndex - 1));
            }

            if (pageCount <= 10)
            {
                for (var i = 1; i <= pageCount; i++)
                {
                    if (pageIndex == i)
                    {
                        strHtml.AppendFormat("<a class='page-now' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", i);
                    }
                    else
                    {
                        strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", i);
                    }
                }
            }
            else
            {
                if (pageIndex <= 4)
                {
                    for (var i = 1; i < pageIndex; i++)
                    {
                        strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", i);
                    }
                    strHtml.AppendFormat("<a class='page-now' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageIndex);
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageIndex + 1);
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageIndex + 2);
                    strHtml.AppendFormat("<label class='ellipsis' style='float:left;padding: 8px 12px'>…</label>");
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageCount);
                }
                if (pageIndex > 4 && (pageIndex < pageCount - 3))
                {
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", 1);
                    strHtml.Append("<label class='ellipsis' style='float:left;padding: 8px 12px'>…</label>");
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageIndex - 2);
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageIndex - 1);
                    strHtml.AppendFormat("<a class='page-now' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageIndex);
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageIndex + 1);
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageIndex + 2);
                    strHtml.Append("<label class='ellipsis' style='float:left;padding: 8px 12px'>…</label>");
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageCount);
                }
                if (pageIndex >= pageCount - 3)
                {
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", 1);
                    strHtml.Append("<label class='ellipsis' style='float:left;padding: 8px 12px'>…</label>");
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageIndex - 2);
                    strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageIndex - 1);
                    strHtml.AppendFormat("<a class='page-now' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", pageIndex);
                    for (var i = pageIndex + 1; i <= pageCount; i++)
                    {
                        strHtml.AppendFormat("<a class='pageLink' data-pageIndex='{0}' href='javascript:void(0)'>{0}</a>", i);
                    }
                }
            }
            if (pageIndex == pageCount)
            {
                strHtml.AppendFormat("<a class='page-next' data-pageIndex='{0}' href='javascript:void(0)'>></a>", pageCount);
            }
            else
            {
                strHtml.AppendFormat("<a class='page-next' data-pageIndex='{0}' href='javascript:void(0)'>></a>", pageIndex + 1);

            }


            //strHtml.AppendFormat("<a class='last' data-pageIndex='{1}' href='javascript:void(0)'>尾页</a>", pageCount);
            strHtml.Append("</div>");
            return strHtml.ToString();
        }
        #endregion



        #endregion
    }
}