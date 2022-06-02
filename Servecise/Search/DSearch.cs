using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMK_shop.Models;
using HtmlAgilityPack;
namespace VMK_shop.Servecise
{
    public class Search : ISearch
    {
        public virtual IEnumerable<Blog> GetBlog(ApplicationDBContext dBContext, SearchParametres parametres)
        {

            throw new Exception();


        }
        
        
    }
}
