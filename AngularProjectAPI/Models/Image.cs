using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProjectAPI.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        //relations
        public int? ArticleID { get; set; }
        public Article Article { get; set; }
    }
}
