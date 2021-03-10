namespace SteamDatasetAPI.Models
{
    public class Player
    {
        public int steamid { get; set; }
        public string loccountrycode { get; set; }
        public int playtime_forever { get; set; }
        public int playtime_2weeks { get; set; }
    }
}