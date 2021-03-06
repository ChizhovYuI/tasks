﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonConversion
{
    class ProductV2
    {
        [JsonConstructor]
        public ProductV2(string name, string price, int count,int[] size)
        {
            this.name = name;
            this.price = price;
            this.count = count;
            this.size = size;
        }

        public string name { get; set; }
        public string price { get; set; }
        public int count { get; set; }
        public int[] size { get; set; }
    }
}
