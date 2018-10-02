using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamShopX.Models
{
    public class Product: BindableBase
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("fullDescription")]
        public string FullDescription { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("imageThumbnail")]
        public string ImageThumbnail { get; set; }
    }
}
