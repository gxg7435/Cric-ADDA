using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class MainWindowViewModel
    {
        public List<Player> Players { get; set; }

        PlayerDataService plyDataSvc;

        public MainWindowViewModel()
        {
            plyDataSvc = new PlayerDataService();
            Players = plyDataSvc.GetPlayers();
        }

    }
}
