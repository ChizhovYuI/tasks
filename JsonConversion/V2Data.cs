using System.Collections.Generic;

namespace JsonConversion
{
    class V2Data
    {
        public Dictionary<string,double> constants { get; set; }
        public string version { get; set; }
        public Dictionary<int,ProductV2> products { get; set; }
    
    }
}