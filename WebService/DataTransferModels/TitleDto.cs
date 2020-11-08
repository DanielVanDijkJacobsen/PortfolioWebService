using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DataTransferModels
{
    public class TitleDto
    {
        public string Id { get; set; }
        public string PrimaryTitle { get; set; }
        public List<string> TitleCastsIds;
    }
}
