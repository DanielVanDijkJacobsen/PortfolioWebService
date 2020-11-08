using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.CustomTypes;

namespace WebService.DTOs
{
    public class BookmarkForCreateDto
    {
        public int UserId { get; set; }
        public BookmarkType BookmarkType { get; set; }
        public string TypeId { get; set; }
    }
}
