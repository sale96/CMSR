using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Dto
{
    public class ImageDto : BaseDto
    {
        public string Location { get; set; }
        public string Alt { get; set; }
    }
}
