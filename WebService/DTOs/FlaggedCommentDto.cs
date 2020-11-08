using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class FlaggedCommentDto
    {
        public int CommentId { get; set; }
        public int FlaggingUser { get; set; }

        public UserDto User { get; set; }
        public CommentDto Comment { get; set; }
    }
}
