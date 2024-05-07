using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    internal interface ICommentService
    {
        void AddComment(Comment comment);
        List<Comment> GetAllComments(int id);
    }
}
