using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Project.Services
{
    public class PlayerDataService
    {
        public List<Player> GetPlayers()
        {
            List<Player> plys = new List<Player>();
           
            try
            {
                using (var client = new HttpClient())
                {

                    String[] ids = { "35320","253802","35263","36084","44936","52337","5390","7133","8180"
                                   ,"29990"};

                    foreach(string val in ids)
                    {
                        //client.DefaultRequestHeaders.Add("X-API-Key", "9ef8ddfc6d254dc3a7b2cac337c6d837");
                        string uri = "http://cricapi.com/api/playerStats?pid="+val+"&apikey=jAjlTP6gVXeAFBiyJwr8TdVrmHn1";
                        
                        var response = client.GetAsync(uri).Result;
                        var content = response.Content.ReadAsStringAsync().Result;
                        dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);


                        plys.Add(new Player()
                        {
                            PlayerName = item.name,
                            id = val
                        });
                    }

                }
            }
            catch (System.Exception ex)
            {
                return plys;
            }
            
            return plys;
        }
    }
}
