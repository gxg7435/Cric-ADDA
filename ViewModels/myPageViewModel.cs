using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Services;
using Project.Models;
using System.Collections.ObjectModel;

namespace Project.ViewModels
{

    public class myPageViewModel
    {
        PlayerInfo infoDataSvc;

        public Uri IconUri { get; set; }
        public string ItemData { get; set; }
        public string ItemCountry{get;set;}
        public string ItemAge { get; set; }
        public string ItemBorn { get; set; }
        public string ItemBat { get; set; }
        public string ItemBowl { get; set; }

        public ObservableCollection<Player> Players { get; set; }

        public myPageViewModel()
        {
            infoDataSvc = new PlayerInfo();
            
        }

        internal void GetData(string itemNumber)
        {
            Players =
                new ObservableCollection<Player>(infoDataSvc.GetPlayers(itemNumber));
            
            var item = infoDataSvc.GetItemDetails(itemNumber);
            
            if (null != item.ItemIconPath)
            {
                IconUri = new Uri(item.ItemIconPath); 
            }
            
            ItemData = item.profile;
            ItemCountry = item.country;
            
            ItemAge = item.currentAge;
            ItemBorn = item.born;
            
            ItemBat = item.bat;
            ItemBowl = item.bowl;
        }
    }
}
