using IssueTest.Data;
using IssueTest.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTest.Utility
{
    public class Utility
    {
        public static void SeedDatabase(IServiceProvider serviceProvider)
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (dbContext.Champ.SingleOrDefault(season => season.SeasonNum == 0) != null)
                    return;

                dbContext.Champ.Add(new Champ
                {
                    SeasonNum = 0
                });

                dbContext.SaveChanges();

                Champ champ = dbContext.Champ.Single(season => season.SeasonNum == 0);

                dbContext.Team.Add(new Team
                {
                    ChampID = champ.ID,
                    Nickname = "I Rossoneri",
                    TeamName = "AC Milan"
                });

                dbContext.Team.Add(new Team
                {
                    ChampID = champ.ID,
                    Nickname = "I nerazzurri",
                    TeamName = "FC Internazionale"
                });

                dbContext.Team.Add(new Team
                {
                    ChampID = champ.ID,
                    Nickname = "I granata",
                    TeamName = "Torino FC"
                });

                dbContext.SaveChanges();

                Team Milan = dbContext.Team.Single(team => team.TeamName == "AC Milan");
                Team Inter = dbContext.Team.Single(team => team.TeamName == "FC Internazionale");
                Team Torino = dbContext.Team.Single(team => team.TeamName == "Torino FC");

                dbContext.Player.Add(new Player
                {
                    TeamID = Milan.ID,
                    Name = "Mateo Musacchio",
                    Birthday = GetDays(1990, 8, 26)
                });

                dbContext.Player.Add(new Player
                {
                    TeamID = Milan.ID,
                    Name = "Patrick Cutrone",
                    Birthday = GetDays(1998, 1, 3)
                });

                dbContext.Player.Add(new Player
                {
                    TeamID = Inter.ID,
                    Name = "Yuto Nagatomo",
                    Birthday = GetDays(1986, 9, 12)
                });

                dbContext.Player.Add(new Player
                {
                    TeamID = Inter.ID,
                    Name = "Ivan Perisic",
                    Birthday = GetDays(1989, 2, 2)
                });

                dbContext.Player.Add(new Player
                {
                    TeamID = Torino.ID,
                    Name = "Antonio Barreca",
                    Birthday = GetDays(1995, 3, 18)
                });

                dbContext.Player.Add(new Player
                {
                    TeamID = Torino.ID,
                    Name = "Andrea Belotti",
                    Birthday = GetDays(1993, 12, 20)
                });

                dbContext.SaveChanges();
            }
        }

        static int GetDays(int year, int month, int day)
        {
            DateTime birthday = new DateTime(year, month, day);
            TimeSpan timespan = (birthday - (new DateTime(1970, 1, 1)));
            return timespan.Days;
        }
    }
}
