using System;

namespace WebService.DataService.DTO
{
    public class SearchHistory
    {
        public int UserId { get; set; }
        public int Ordering { get; set; }
        public DateTime SearchTime { get; set; }
        public string SearchString { get; set; }
        public virtual Users User { get; set; }
    }
}
