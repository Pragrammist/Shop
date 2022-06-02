using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMK_shop.Models;


namespace VMK_shop.Servecise
{
    public interface ISearch
    {
        IEnumerable<Blog> GetBlog(ApplicationDBContext dBContext, SearchParametres parametres);
    }
}
