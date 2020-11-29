﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProjectAPI.Models
{
    public class Like
    {
        public int LikeID { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }
        public int ArticleID { get; set; }
        public Article Article { get; set; }

    }
}
