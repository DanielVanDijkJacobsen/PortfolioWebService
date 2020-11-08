using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class FlaggedCommentForCreateDto
    {
        public int CommentId { get; set; }
        public int FlaggingUser { get; set; }
    }
}
