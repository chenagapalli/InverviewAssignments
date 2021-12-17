using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace University
{
    public class HttpHelper
    {
        public List<UniversityAPI.University> GetUniversity()
        {
            HttpClient client = new HttpClient();
            List<UniversityAPI.University> universities = null;
            client.BaseAddress = new Uri("http://universities.hipolabs.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("search?country=United+Kingdom").Result;
            if (response.IsSuccessStatusCode)
            {
                universities = JsonConvert.DeserializeObject<List<UniversityAPI.University>>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return universities;
        }
    }
}