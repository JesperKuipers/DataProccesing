using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamDatasetAPI.Models
{
    public class GamePlayed
    {
        public int appid { get; set; }
        public int steamid { get; set; }
        public string loccountrycode { get; set; }
        public int playtime_forever { get; set; }
        public int playtime_2weeks { get; set; }
    }
}
