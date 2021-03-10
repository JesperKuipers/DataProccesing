using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamDatasetAPI.Models
{
    public class Game
    {
        public int appID { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public List<Developer> Developer { get; set; }
        public List<Publisher> Publisher { get; set; }
        public List<Player> Players { get; set; }
    }
}
