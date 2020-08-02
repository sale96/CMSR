using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Image : BaseEntity
    {
        public string Location { get; set; }
        public string Alt { get; set; }

        public virtual IList<ProductImage> ProductImages { get; set; }
    }
}
