using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public String Title{ get; set; }
        public String Content{ get; set; } 
        public String ImgUrl { get; set; } 
        public String BlogUrl { get; set; } 
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }

    public class Comment 
    {
        public int Id { get; set; }
        public String comment { get; set; }

        [ForeignKey("Blog")]
        public int BlogId { get; set; }
    }
}
