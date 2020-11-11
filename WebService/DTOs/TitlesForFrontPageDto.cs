using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.DataService.DTO;

namespace WebService.DTOs
{
    public class TitlesForFrontPageDto
    {
        public string PrimaryTitle { get; set; }
        public string Poster { get; set; }
        public string StartYear { get; set; }
    }
}
