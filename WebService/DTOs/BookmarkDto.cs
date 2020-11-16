using WebService.DataService.CustomTypes;

namespace WebService.DTOs
{
    public class BookmarkDto
    {
        public int UserId { get; set; }
        public BookmarkType BookmarkType { get; set; }
        public string TypeId { get; set; }
    }
}
