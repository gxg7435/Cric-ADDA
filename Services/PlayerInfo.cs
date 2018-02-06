using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;
using System.Net.Http;

namespace Project.Services
{
    public class PlayerInfo
    {
        public Player GetItemDetails(string itemNumber)
        {
            Player invItem = new Player();
            try
            {
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Add("X-API-Key", "9ef8ddfc6d254dc3a7b2cac337c6d837");
                     string uri = "http://cricapi.com/api/playerStats?pid="+itemNumber+"&apikey=jAjlTP6gVXeAFBiyJwr8TdVrmHn1";
                        
                        var response = client.GetAsync(uri).Result;
                        var content = response.Content.ReadAsStringAsync().Result;
                        dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                        invItem.ItemIconPath = item.imageURL;
                        invItem.profile = item.profile;
                        invItem.country = item.country;
                        invItem.currentAge = item.currentAge;
                        invItem.born = item.born;
                        invItem.bat = item.battingStyle;
                        invItem.bowl = item.bowlingStyle;
                }
            }
            catch (System.Exception ex)
            {
                return invItem;
            }
            return invItem;
        }



        public List<Player> GetPlayers(string id)
        {
            List<Player> plys = new List<Player>();



            try
            {
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Add("X-API-Key", "9ef8ddfc6d254dc3a7b2cac337c6d837");
                    string uri = "http://cricapi.com/api/playerStats?pid=" + id + "&apikey=jAjlTP6gVXeAFBiyJwr8TdVrmHn1";

                    var response = client.GetAsync(uri).Result;
                    var content = response.Content.ReadAsStringAsync().Result;
                    dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                    string[] type = { "twenty20", "listA", "firstClass", "T20Is", "ODIs", "tests" };

                    foreach (var val in type)
                    {
                        plys.Add(new Player()
                        {
                            league = val,
                            fifty = item.data.batting[val]["50"],
                            hundred = item.data.batting[val]["100"],
                            st = item.data.batting[val].St,
                            ct = item.data.batting[val].Ct,
                            four = item.data.batting[val]["4s"],
                            six = item.data.batting[val]["6s"],
                            ave = item.data.batting[val].Ave,
                            high = item.data.batting[val].HS,
                            runs = item.data.batting[val].Runs,
                            notout = item.data.batting[val].NO,
                            match = item.data.batting[val].Mat,

                            tenw = item.data.bowling[val]["10"],
                            fivew = item.data.bowling[val]["5w"],
                            fourw = item.data.bowling[val]["4w"],
                            sr = item.data.bowling[val].SR,
                            econ = item.data.bowling[val]["Econ"],
                            aveb = item.data.bowling[val]["Ave"],
                            bbm = item.data.bowling[val].BBM,
                            bbi = item.data.bowling[val].BBI,
                            wktsb = item.data.bowling[val].Wkts,
                            runsb = item.data.bowling[val].Runs,
                            balls = item.data.bowling[val].Balls,
                            matchb = item.data.bowling[val].Mat

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
