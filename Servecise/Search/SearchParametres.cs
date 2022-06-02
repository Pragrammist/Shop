using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMK_shop.Servecise
{
    public class SearchParametres 
    {
        string[] keyWords = new string[] { };
        public string Tematic { get; set; } = "";
        public string KeyString { get; set; } = "";
        public string[] KeyWords { get => (string[])keyWords.Clone(); }
             
        

        public SearchParametres(string keyString = "")
        {
            keyWords = keyString.Split(new char[] {' ' },StringSplitOptions.RemoveEmptyEntries);
        }
        
    }
}
