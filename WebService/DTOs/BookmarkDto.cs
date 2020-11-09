using WebService.DataService.CustomTypes;

namespace WebService.DTOs
{
    public class BookmarkDto
    {
        public int UserId { get; set; }
        //public enum bookmark_type;
        public BookmarkType BookmarkType { get; set; }
        public string TypeId { get; set; }

        public UserDto User { get; set; }
        public TitleDto Title { get; set; }
    }
}
