using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class SearchHistoryDto
    {
        public int UserId { get; set; }
        public int Ordering { get; set; }
        public DateTime SearchTime { get; set; }
        public string SearchString { get; set; }

        public UserDto User { get; set; }
    }
}
