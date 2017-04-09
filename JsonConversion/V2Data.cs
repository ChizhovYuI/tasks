using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonConversion
{
    class V2Data
    {
        [JsonConstructor]
        public V2Data(Dictionary<string, double> constants, string version, Dictionary<int, ProductV2> products)
        {
            this.constants = constants;
            this.version = version;
            this.products = products;
        }

        public Dictionary<string,double> constants { get; set; }
        public string version { get; set; }
        public Dictionary<int,ProductV2> products { get; set; }
    
    }
}