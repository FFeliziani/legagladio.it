using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Team
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        public static int CountTeam()
        {
            try
            {
                return DataAccessLayer.Team.CountTeam();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while counting teams");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Team> ListTeam()
        {
            try
            {
                return DataAccessLayer.Team.ListTeam();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing teams");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Team> ListTeam(int coachId)
        {
            try
            {
                return DataAccessLayer.Team.ListTeam(coachId);
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

        public static int CalculateFanFactor(Int32 Id)
        {
            try
            {
                var fanFactor = GetTeam(Id).FanFactor;

                var gamesList = Game.ListGame(new LegaGladio.Entities.Team() { Id = Id });
                foreach (var game in gamesList)
                {
                    if (game.Home.Id == Id)
                    {
                        fanFactor += game.VarFfHome;
                    }
                    if (game.Guest.Id == Id)
                    {
                        fanFactor += game.VarFfGuest;
                    }
                }

                return fanFactor;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while calculating Fan factor - Id: [" + Id + "]");
                throw;
            }
           
        }

        public static int CalculateTreasury(Int32 Id)
        {
            try
            {
                var treasury = GetTeam(Id).Treasury;

                var gamesList = Game.ListGame(new LegaGladio.Entities.Team() { Id = Id });
                foreach (var game in gamesList)
                {
                    if (game.Home.Id == Id)
                    {
                        treasury += game.EarningHome;
                    }
                    if (game.Guest.Id == Id)
                    {
                        treasury += game.EarningGuest;
                    }
                }

                return treasury;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while calculating Treasury - Id: [" + Id + "]");
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
