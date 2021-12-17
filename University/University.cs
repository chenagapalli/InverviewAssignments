using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAPI
{
   public class University
    {
        [JsonProperty("state-province")]
        public object StateProvince { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("web_pages")]
        public List<string> WebPage { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("alpha_two_code")]
        public string AlphaTwoCode { get; set; }
        [JsonProperty("domains")]
        public List<string> Domains { get; set; }
    }
}
