using System;
using System.Collections.Generic;
using System.Text;

namespace BethsPiesMobile.core.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
