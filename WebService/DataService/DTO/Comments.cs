using System;
using System.Collections.Generic;

namespace WebService.DataService.DTO
{
    public class Comments
    {
        public int CommentId { get; set; }
        public DateTime CommentTime { get; set; }
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public string Comment { get; set; }
        public virtual Users User { get; set; }
        public virtual Titles Title { get; set; }
        public virtual bool? IsEdited { get; set; }
        public virtual int? ParentCommentId { get; set; }
        public virtual Comments ParentComment { get; set; }

        public virtual ICollection<FlaggedComment> FlaggedComments { get; set; }
        public virtual ICollection<Comments> ChildComments { get; set; }
    }
}
