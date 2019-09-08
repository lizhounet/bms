using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Zhouli.BLL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BlogWebApi.Filters.ArticleBrowsing
{
    public class ArticleBrowsingFilterAttribute : Attribute, IActionFilter
    {
        private readonly IBlogArticleBrowsingBLL _blogArticleBrowsingBLL;
        public ArticleBrowsingFilterAttribute(IBlogArticleBrowsingBLL blogArticleBrowsingBLL)
        {
            _blogArticleBrowsingBLL = blogArticleBrowsingBLL;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            if (!string.IsNullOrEmpty(ipAddress))
            {
                var arrIpAddress = ipAddress.Split(':');
                string ip = "::1".Equals(ipAddress) ? "127.0.0.1" : arrIpAddress[arrIpAddress.Length - 1];
                int.TryParse(context.HttpContext.Request.Query["articleId"][0], out int articleId);
                if (articleId != 0)
                {
                    if (_blogArticleBrowsingBLL.GetCount(t => t.ArticleId == articleId && t.Ip.Equals(ip)) == 0)
                        _blogArticleBrowsingBLL.Add(new BlogArticleBrowsing
                        {
                            ArticleId = articleId,
                            Ip = ip,
                            CreateTime = DateTime.Now
                        });
                }
            }
        }
    }
}
