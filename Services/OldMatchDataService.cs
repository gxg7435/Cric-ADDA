using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class OldMatchDataService
    {
        public List<OldMatch> GetMatches()
        {
            List<OldMatch> matches = new List<OldMatch>();

            try
            {
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Add("X-API-Key", "9ef8ddfc6d254dc3a7b2cac337c6d837");
                    string uri = "http://cricapi.com/api/cricket?apikey=jAjlTP6gVXeAFBiyJwr8TdVrmHn1";

                    var response = client.GetAsync(uri).Result;
                    var content = response.Content.ReadAsStringAsync().Result;
                    dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                    //int length = item.matches.length;

                    for (var i = 0; i < 20; i++)
                    {
                        matches.Add(new OldMatch()
                        {
                            description = item.data[i].description

                        });
                    }
                }
            }
            catch (System.Exception ex)
            {
                return matches;
            }

            return matches;
        }
    }
}
