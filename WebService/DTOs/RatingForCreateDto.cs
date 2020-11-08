using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class RatingForCreateDto
    {
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public float Score { get; set; }

    }
}
