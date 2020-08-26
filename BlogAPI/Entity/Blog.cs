﻿using System;
using System.Collections.Generic;
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
    }
}
