
namespace WebService.DTOs
{
    public class CommentForCreateOrUpdateDto
    {
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public string Comment { get; set; }
        public int ParentCommentId { get; set; }
        public bool Edited { get; set; }
    }
}
