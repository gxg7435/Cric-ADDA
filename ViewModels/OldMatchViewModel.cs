using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class OldMatchViewModel
    {
        public List<OldMatch> om { get; set; }

        OldMatchDataService matchDataSvc;

        public OldMatchViewModel()
        {
            matchDataSvc = new OldMatchDataService();
            om = matchDataSvc.GetMatches();
        }
    }
}
