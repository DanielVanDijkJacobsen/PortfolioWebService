using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class UserRatingDto
    {
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public float Score { get; set; }

        public UserDto User { get; set; }
        public TitleDto Title { get; set; }
    }
}
