using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamShopX.Models
{
    public class Product: BindableBase, ICloneable
    {
        private string _productName;
        private string _shortDescription;
        private string _fullDescription;
        private string _category;
        private string _price;
        private string _imageThumbnail;

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("productName")]
        public string ProductName
        {
            get => _productName;
            set
            {
                SetProperty(ref _productName, value);                
            }
        }

        [JsonProperty("shortDescription")]
        public string ShortDescription
        {
            get => _shortDescription;
            set
            {
                SetProperty(ref _shortDescription, value);
            }
        }

        [JsonProperty("fullDescription")]
        public string FullDescription
        {
            get => _fullDescription;
            set
            {
                SetProperty(ref _fullDescription, value);
            }
        }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("category")]
        public string Category
        {
            get => _category;
            set
            {
                SetProperty(ref _category, value);
            }
        }

        [JsonProperty("price")]
        public string Price
        {
            get => _price;
            set
            {
                SetProperty(ref _price, value);
            }
        }

        [JsonProperty("imageThumbnail")]
        public string ImageThumbnail
        {
            get => _imageThumbnail;
            set
            {
                SetProperty(ref _imageThumbnail, value);
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
