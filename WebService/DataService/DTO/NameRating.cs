using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.DTOs;

namespace WebService.DataService.DTO
{
    public class NameRating
    {
        public string CastId { get; set; }
        public float Score { get; set; }
        public virtual CastInfo CastInfo { get; set; }
    }
}
