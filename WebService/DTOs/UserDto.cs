using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public int? DerivedAge { get; set; }
        public string JwtToken { get; set; }

        public virtual ICollection<UserRatingDto> UserRating { get; set; }
        public virtual ICollection<BookmarkDto> Bookmarks { get; set; }
        public virtual ICollection<CommentDto> Comments { get; set; }
        public virtual ICollection<SearchHistoryDto> SearchHistories { get; set; }
        public virtual ICollection<SpecialRoleDto> SpecialRoles { get; set; }
        public virtual ICollection<FlaggedCommentDto> FlaggedComments { get; set; }
    }
}
