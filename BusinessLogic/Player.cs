using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Util;
using NLog;

namespace BusinessLogic
{
    public static class Player
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly static ISessionFactory SessionFactory = Utilities.DatabaseUtilities.CreateSessionFactory();
        
        public static int Count()
        {
            try
            {
                return DataAccessLayer.Player.CountPlayer();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while counting players");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Dto.Player> ListPlayer()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return
                        session.CreateCriteria(typeof (LegaGladio.Entities.Player))
                            .List<LegaGladio.Entities.Player>()
                            .Select(x => new LegaGladio.Entities.Dto.Player(x))
                            .ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing players");
                throw;
            }
        }
        public static ICollection<LegaGladio.Entities.Player> ListPlayer(int teamId)
        {
            try
            {
                return DataAccessLayer.Player.ListPlayer(teamId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing players for team - TeamId: [" + teamId + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Player> ListPlayer(int teamId, Boolean active)
        {
            try
            {
                return DataAccessLayer.Player.ListPlayer(teamId, active);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing active players for team - TeamId: [" + teamId + "], Active: [" + active + "]");
                throw;
            }
        }

        public static LegaGladio.Entities.Dto.Player GetPlayer(int id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return
                        new LegaGladio.Entities.Dto.Player(session.CreateCriteria(typeof(LegaGladio.Entities.Player)).Add(Restrictions.Eq("id", id))
                            .UniqueResult<LegaGladio.Entities.Player>())
                    ;
                }
                //return DataAccessLayer.Player.GetPlayer(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting players - Player Id: [" + id + "]");
                throw;
            }
        }

        public static void AddPlayerToTeam(Int32 playerId, Int32 teamId)
        {
            try
            {
                DataAccessLayer.Player.AddPlayerToTeam(playerId, teamId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while adding player to team - PlayerId: [" + playerId + "], TeamId: [" + teamId + "]");
                throw;
            }
        }

        public static void RemovePlayerFromTeam(Int32 playerId, Int32 teamId)
        {
            try
            {
                DataAccessLayer.Player.RemovePlayerFromTeam(playerId, teamId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while removing player from team - PlayerId: [" + playerId + "], TeamId: [" + teamId + "]");
                throw;
            }
        }

        public static Int32 NewPlayer(LegaGladio.Entities.Player player)
        {
            try
            {
                return DataAccessLayer.Player.NewPlayer(player);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating player - Player Data: " + (player != null ? "Player Name: [" + player.Name + "]" + (player.Positional != null ? " Player Postional Id: [" + player.Positional.Id + "]" : "POSITIONAL IS NULL!!!") : "PLAYER IS NULL!!!"));
                throw;
            }
        }

        public static void UpdatePlayer(LegaGladio.Entities.Player player, int oldId)
        {
            try
            {
                DataAccessLayer.Player.UpdatePlayer(player, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating players - Player Data: OldId: [" + oldId + "], " + (player != null ? "Player Name: [" + player.Name + "]" + (player.Positional != null ? " Player Postional Id: [" + player.Positional.Id + "]" : "POSITIONAL IS NULL!!!") : "PLAYER IS NULL!!!"));
                throw;
            }
        }

        public static void DeletePlayer(int id)
        {
            try
            {
                DataAccessLayer.Player.DeletePlayer(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting players - Id: [" + id + "]");
                throw;
            }
        }
    }
}
