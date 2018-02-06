using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class MatchDataService
    {
        public List<Match> GetMatches()
        {
            List<Match> matches = new List<Match>();

            try
            {
                using (var client = new HttpClient())
                {
                        //client.DefaultRequestHeaders.Add("X-API-Key", "9ef8ddfc6d254dc3a7b2cac337c6d837");
                        string uri = "http://cricapi.com/api/matches?apikey=jAjlTP6gVXeAFBiyJwr8TdVrmHn1";

                        var response = client.GetAsync(uri).Result;
                        var content = response.Content.ReadAsStringAsync().Result;
                        dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                        //int length = item.matches.length;

                        for (var i = 0; i < 20; i++)
                        {
                            matches.Add(new Match()
                            {
                                team1 = item.matches[i]["team-1"] + " VS " + item.matches[i]["team-2"],
                                unique_id = item.matches[i].unique_id
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

        public List<Match> GetPlayers(string id)
        {
            List<Match> mtch = new List<Match>();
        
            try
            {
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Add("X-API-Key", "9ef8ddfc6d254dc3a7b2cac337c6d837");
                    string uri = "http://cricapi.com/api/fantasySummary?unique_id=" + id + "&apikey=jAjlTP6gVXeAFBiyJwr8TdVrmHn1";

                    var response = client.GetAsync(uri).Result;
                    var content = response.Content.ReadAsStringAsync().Result;
                    dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                                        
                    for (int i = 0; i < 12; i++)
                    {
                        mtch.Add(new Match()
                        {
                            playerName = item.data.team[0].players[i].name,
                            playerName2 = item.data.team[1].players[i].name
                        });
                    }
                }
            }
            catch (System.Exception ex)
            {
                return mtch;
            }
            return mtch;
        }

        public Match getTeams(string id)
        {
            Match m = new Match();
            try
            {
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Add("X-API-Key", "9ef8ddfc6d254dc3a7b2cac337c6d837");
                    string uri = "http://cricapi.com/api/fantasySummary?unique_id=" + id + "&apikey=jAjlTP6gVXeAFBiyJwr8TdVrmHn1";

                    var response = client.GetAsync(uri).Result;
                    var content = response.Content.ReadAsStringAsync().Result;
                    dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                    m.firstTeam = item.data.team[0].name;
                    m.secondTeam = item.data.team[1].name;
                     
                }
            }
            catch (System.Exception ex)
            {
                return m;
            }
            return m;
        }
    }
}
