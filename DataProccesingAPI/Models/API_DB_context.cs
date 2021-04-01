using Microsoft.EntityFrameworkCore;

namespace DataProccesingAPI.Models
{
    public class API_DB_context : DbContext
    {
        public API_DB_context(DbContextOptions<API_DB_context> options) : base(options)
        {
        }

        public virtual DbSet<achievement_percentages> achievement_percentages { get; set; }
        public virtual DbSet<app_id_info> app_id_info { get; set; }
        public virtual DbSet<games_1> games_1 { get; set; }
        public virtual DbSet<games_2> games_2 { get; set; }
        public virtual DbSet<games_daily> games_daily { get; set; }
        public virtual DbSet<player_summaries> player_summaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set all primary keys
            modelBuilder.Entity<achievement_percentages>().HasKey(a => new { a.appid, a.Name });
            modelBuilder.Entity<app_id_info>().HasKey(b => new { b.appid });
            modelBuilder.Entity<games_1>().HasKey(c => new { c.steamid, c.appid });
            modelBuilder.Entity<games_2>().HasKey(d => new { d.steamid, d.appid });
            modelBuilder.Entity<games_daily>().HasKey(e => new { e.steamid, e.appid });
            modelBuilder.Entity<player_summaries>().HasKey(f => new { f.steamid });
        }
    }
}
