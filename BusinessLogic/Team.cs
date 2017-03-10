using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using NHibernate;
using NHibernate.Criterion;

namespace BusinessLogic
{
    public static class Team
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly static ISessionFactory SessionFactory = Utilities.DatabaseUtilities.CreateSessionFactory();

        public static int CountTeam()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session
                        .CreateCriteria<LegaGladio.Entities.Team>()
                        .SetProjection(Projections.Count(Projections.Id()))
                        .UniqueResult<Int32>();
                }
                //return DataAccessLayer.Team.CountTeam();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while counting teams");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Dto.Team> ListTeam()
        {
            try
            {
                using(var session = SessionFactory.OpenSession())
                {
                    return session
                        .CreateCriteria<LegaGladio.Entities.Team>()
                        .List<LegaGladio.Entities.Team>()
                        .Select(x => new LegaGladio.Entities.Dto.Team(x))
                        .ToList();
                }
                //return DataAccessLayer.Team.ListTeam();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing teams");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Dto.Team> ListTeam(int coachId)
        {
            try
            {
                using(var session = SessionFactory.OpenSession())
                {
                    return session
                        .CreateCriteria<LegaGladio.Entities.Team>()
                        .CreateCriteria("coach")
                            .Add(Expression.Eq("Id", coachId))
                        .List<LegaGladio.Entities.Team>()
                        .Select(x => new LegaGladio.Entities.Dto.Team(x))
                        .ToList();
                }
                //return DataAccessLayer.Team.ListTeam(coachId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing teams for coach - Coach Id: [" + coachId + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Team> ListTeam(Boolean active)
        {
            try
            {
                return DataAccessLayer.Team.ListTeam(active);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing active teams - Active: [" + active + "]");
                throw;
            }
        }

        public static LegaGladio.Entities.Team GetTeam(int id)
        {
            try
            {
                return DataAccessLayer.Team.GetTeam(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting teams - Id: [" + id + "]");
                throw;
            }
        }

        public static LegaGladio.Entities.Team GetTeam(Int32 id, Boolean active)
        {
            try
            {
                return DataAccessLayer.Team.GetTeam(id, active);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting teams - Id [" + id + "], Active: [" + active + "]");
                throw;
            }
        }

        public static void NewTeam(LegaGladio.Entities.Team team)
        {
            try
            {
                DataAccessLayer.Team.NewTeam(team);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating teams");
                throw;
            }
        }

        public static void UpdateTeam(LegaGladio.Entities.Team team, int oldId)
        {
            try
            {
                DataAccessLayer.Team.UpdateTeam(team, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating teams");
                throw;
            }
        }

        public static int CalculateFanFactor(Int32 id)
        {
            try
            {
                var fanFactor = GetTeam(id).FanFactor;

                var gamesList = Game.ListGame(new LegaGladio.Entities.Team { Id = id });
                foreach (var game in gamesList)
                {
                    if (game.Home.Id == id)
                    {
                        fanFactor += game.VarFfHome;
                    }
                    if (game.Guest.Id == id)
                    {
                        fanFactor += game.VarFfGuest;
                    }
                }

                return fanFactor;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while calculating Fan factor - Id: [" + id + "]");
                throw;
            }
           
        }

        public static int CalculateTreasury(Int32 id)
        {
            try
            {
                var treasury = GetTeam(id).Treasury;

                var gamesList = Game.ListGame(new LegaGladio.Entities.Team { Id = id });
                foreach (var game in gamesList)
                {
                    if (game.Home.Id == id)
                    {
                        treasury += game.EarningHome;
                    }
                    if (game.Guest.Id == id)
                    {
                        treasury += game.EarningGuest;
                    }
                }

                return treasury;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while calculating Treasury - Id: [" + id + "]");
                throw;
            }
        }

        /*public static Boolean DeleteTeam(int id)
        {
            try
            {
                return DataAccessLayer.Team.DeleteTeam(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting teams");
                throw;
            }
        }*/
    }
}
