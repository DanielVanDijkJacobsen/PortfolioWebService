using System;
using System.Collections.Generic;

namespace WebService.DataService.DMO
{
    public class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string Nickname { get; set; }
        public DateTime AccountCreation { get; set; }
        public DateTime LastAccess { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public virtual ICollection<UserRating> UserRating { get; set; }
        public virtual ICollection<Bookmarks> Bookmarks { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<SearchHistory> SearchHistories{ get; set; }
        public virtual ICollection<SpecialRoles> SpecialRoles { get; set; }
        public virtual ICollection<FlaggedComment> FlaggedComments { get; set; }
    }
}
