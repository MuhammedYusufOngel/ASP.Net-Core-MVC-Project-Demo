using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public string BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments{ get; set; }

        public Blog(int blogID, string blogTitle, string blogContent, string blogThumbnailImage, string blogImage, string blogCreateDate, bool blogStatus)
        {
            BlogID = blogID;
            BlogTitle = blogTitle;
            BlogContent = blogContent;
            BlogThumbnailImage = blogThumbnailImage;
            BlogImage = blogImage;
            BlogCreateDate = blogCreateDate;
            BlogStatus = blogStatus;
        }
    }
}
