using TourneyBracket.Models;
using System;
using System.Linq;

namespace TourneyBracket.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BracketContext context)
        {
            context.Database.EnsureCreated();

            if (context.BracketTable.Any())
            {
                return;   // DB has been seeded
            }
            // BracketID, Name, RoundFormat, CreatedAt, Active, TeamTotal, 
            var brackets = new BracketTable[]
            {
            new BracketTable{BracketID=1,Name="Test Bracket",RoundFormat=1,CreatedAt=DateTime.Now,Active=1},
            };
            foreach (BracketTable s in brackets)
            {
                context.BracketTable.Add(s);
            }

            context.SaveChanges();
        }
    }
}