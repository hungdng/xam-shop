using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamShopX.Models
{
    public class Category: BindableBase
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }
    }
}
