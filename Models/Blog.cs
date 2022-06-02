using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using HtmlAgilityPack;

namespace VMK_shop.Models
{
    public class Blog
    {
        string html;
        string title;
        string titleComment;
        string mainImg;
        string tematic;
        public int Id { get; set; }
        [Required]
        public string Html { get => html; set => html = value; }
        public string Title { get => title; set => title = value; }
        public string TitleComment { get => titleComment; set => titleComment = value; }
        public string MainImg { get => mainImg; set => mainImg = value; }
        public string Tematic { get => tematic; set => tematic = value; }
        public Blog()
        {
            Inittializate();
        }

        private void Inittializate()
        {
            html = "";
            title = "";
            titleComment = "";
            mainImg = "";
            tematic = "";
        }
        public Blog(string page, string title, string titleComment, string mainImg, string tematic)
        {
            if (page != null && title != null && titleComment != null && mainImg != null)
            {
                Html = page;
                Title = title;
                TitleComment = titleComment;
                MainImg = mainImg;
                Tematic = tematic;
            }
            else
            {
                Inittializate();
            }
        }
        public static string GetStringContent(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var str = doc.DocumentNode.InnerText;
            return str;
        }

        public static string GetAtributValue(string html, string value)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var src = doc.DocumentNode.Descendants()
            .Select(x => x.Attributes[value].Value)
            .ToArray().FirstOrDefault();
            return src;
        }
    }
}
