using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMK_shop.Models;
using System;
using VMK_shop.Servecise;

namespace VMK_shop.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDBContext db;
        ISearch search;
        public HomeController(ApplicationDBContext db, ISearch search)
        {
            this.db = db;
            this.search = search;
        }
        [Route("~/Article")]
        public IActionResult Article(int id)
        {
            
            var articles = db.Blogs.ToList();
            string res = "";
            for (int i = 0; i < articles.Count; i++)
            {
                if(articles[i].Id == id)
                {
                    res = articles[i].Html;
                    break;
                }
            }
            return View(model:res);
        }
        public IActionResult Index()
        {
            var articles = db.Blogs.ToList();
            

            return View(articles);
        }



        [HttpGet]
        [Route("~/CreateArticle")]
        public IActionResult CreaterArticleGet()
        {
            return View();
        }

        void Clear()
        {
            var l = db.Blogs.ToList();
            if (l.Count > 1)
            {
                for (int i = 1; i < l.Count; i++)
                {
                    db.Blogs.Remove(l[i]);
                }
                db.SaveChanges();
            }
        }

        [HttpPost("~/CreateArticle")]
        public IActionResult AddCreatedArticle()
        {
            string[] tematics = new string[] {"спорт", "личная жизнь", "психология", "сексуальная жизнь", "языки", "природа", "семья", "музыка", "it"  };
            var tematic = GetRandom(tematics);
            var form = ControllerContext.HttpContext.Request.Form;
            var html = form["html"].ToString().Trim(new char[] { '{', '}' });
            var title = form["title"].ToString().Trim(new char[] { '{', '}' }); ;
            var titleComment = form["titleComment"].ToString().Trim(new char[] { '{', '}' }); ;
            var mainImg = form["mainImg"].ToString().Trim(new char[] { '{', '}' }); ;
            Blog articleToDb = new Blog(html, title, titleComment, mainImg, tematic);
            
            db.Blogs.Add(articleToDb);
            db.SaveChanges();
            return View("ShowArticlePost", articleToDb);
            
        }
        
        T GetRandom<T>(T[] arr)
        {
            Random r = new Random();
            var t = r.Next(0, arr.Length);
            return arr[t];
            
            
        }




    }

    public static class ListHelper
    {
        public static HtmlString CreatorArticle(this IHtmlHelper html, Blog article)
        {
            
            var str = article.Html;
            return new HtmlString(str);
        }
        public static HtmlString ShowArticleFromDb(this IHtmlHelper html, string article)
        {
            return new HtmlString(article);
        }
    }


}