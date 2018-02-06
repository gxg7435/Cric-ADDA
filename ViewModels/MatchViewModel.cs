using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
   public class MatchViewModel
    {
       public List<Match> Matches { get; set; }
       public ObservableCollection<Match> TeamPlayers { get; set; }
       public string firstTeam { get; set; }
       public string secondTeam { get; set; }

        MatchDataService matchDataSvc;
        private string id;

        public MatchViewModel()
        {
            matchDataSvc = new MatchDataService();
            Matches = matchDataSvc.GetMatches();
        }

        public MatchViewModel(string id)
        {
            // TODO: Complete member initialization
            this.id = id;
            matchDataSvc = new MatchDataService();
            TeamPlayers =
                new ObservableCollection<Match>(matchDataSvc.GetPlayers(id));
            Match m = matchDataSvc.getTeams(id);
            firstTeam = m.firstTeam;
            secondTeam = m.secondTeam;
        }
    }
}
