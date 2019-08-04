using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourneyBracket.Models;

namespace TourneyBracket.Data
{
    public class BracketContext : DbContext
    {
        public BracketContext(DbContextOptions<BracketContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<BracketTable> BracketTable { get; set; }
        public DbSet<Round> Rounds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<BracketTable>().ToTable("BracketTable");
            modelBuilder.Entity<Round>().ToTable("Round");
        
            modelBuilder.Entity<Match>()
                .HasOne(m => m.TeamA)
                .WithMany(p => p.Matches)
                .HasForeignKey(m => m.TeamAID);
            modelBuilder.Entity<Match>()
                    .HasOne(m => m.TeamB)
                    .WithMany(p => p.OppMatches)
                    .HasForeignKey(m => m.TeamBID);
           
        }
    }
}