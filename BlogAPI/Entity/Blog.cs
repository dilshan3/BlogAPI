using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Entity
{
    public class Blog
    {
        public int id { get; set; }
        public String title{ get; set; }
        public String content{ get; set; }
        public String imgUrl { get; set; }
    }
}
