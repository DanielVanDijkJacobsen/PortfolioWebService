using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public DateTime CommentTime { get; set; }
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public string Comment { get; set; }
        public int? ParentCommentId { get; set; }
        public bool Edited { get; set; }

        public UserDto User { get; set; }
        public TitleDto Title { get; set; }
        public virtual CommentDto Parent { get; set; }
        public virtual ICollection<CommentDto> Children { get; set; }
        public virtual ICollection<FlaggedCommentDto> FlaggedComments { get; set; }
    }
}
