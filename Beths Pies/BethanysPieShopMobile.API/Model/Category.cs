using System.Collections.Generic;
using Newtonsoft.Json;

namespace BethanysPieShopMobile.API.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [JsonIgnore]
        public List<Pie> Pies { get; set; }
    }
}
