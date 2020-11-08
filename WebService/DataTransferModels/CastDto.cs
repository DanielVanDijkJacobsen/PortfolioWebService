using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DataTransferModels
{
    public class CastDto
    {
        public string Id { get; set; }
        public string PrimaryName { get; set; }
        public List<string> CastTitlesIds;
    }
}
