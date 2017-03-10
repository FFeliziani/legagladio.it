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
                using (var session = SessionFactory.OpenSession())
                {
                    return session.CreateCriteria<LegaGladio.Entities.Player>()
                        .SetProjection(Projections.Count(Projections.Id())).UniqueResult<Int32>();
                }
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
                    return session
                        .CreateCriteria(typeof (LegaGladio.Entities.Player))
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
        public static ICollection<LegaGladio.Entities.Dto.Player> ListPlayer(int teamId)
        {
            try
            {
                using(var session = SessionFactory.OpenSession())
                {
                    return session
                        .CreateCriteria<LegaGladio.Entities.Player>()
                        .CreateCriteria("team")
                            .Add(Expression.Eq("id", teamId))
                        .List<LegaGladio.Entities.Player>()
                        .Select(x=> new LegaGladio.Entities.Dto.Player(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing players for team - TeamId: [" + teamId + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Dto.Player> ListPlayer(int teamId, Boolean active)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session
                    .CreateCriteria<LegaGladio.Entities.Player>()
                    .Add(Expression.Eq("active", active))
                    .CreateCriteria("team")
                        .Add(Expression.Eq("id", teamId))
                    .List<LegaGladio.Entities.Player>()
                    .Select(x => new LegaGladio.Entities.Dto.Player(x)).ToList();
                    //return DataAccessLayer.Player.ListPlayer(teamId, active);
                }
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
                using (var session = SessionFactory.OpenSession())
                {
                    var team = session.CreateCriteria<LegaGladio.Entities.Team>().Add(Expression.Eq("id", teamId)).UniqueResult<LegaGladio.Entities.Team>();
                    var player = session.CreateCriteria<LegaGladio.Entities.Player>().Add(Expression.Eq("id", playerId)).UniqueResult<LegaGladio.Entities.Player>();
                    team.ListPlayer.Add(player);
                    session.Save(team);
                }
                //DataAccessLayer.Player.AddPlayerToTeam(playerId, teamId);
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
                using (var session = SessionFactory.OpenSession()) {
                    var team = session.CreateCriteria<LegaGladio.Entities.Team>().Add(Expression.Eq("id", teamId)).UniqueResult<LegaGladio.Entities.Team>();
                    team.ListPlayer = team.ListPlayer.Where(x => x.Id != playerId).ToList();
                    session.Save(team);

                //DataAccessLayer.Player.RemovePlayerFromTeam(playerId, teamId);
                }
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
                using(var session = SessionFactory.OpenSession())
                {
                    session.Save(player);
                    return player.Id;
                }
                //return DataAccessLayer.Player.NewPlayer(player);
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
                using (var session = SessionFactory.OpenSession())
                {
                    session.Update(player, oldId);
                    //DataAccessLayer.Player.UpdatePlayer(player, oldId);
                }
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
                using (var session = SessionFactory.OpenSession())
                {
                    session.Delete(new LegaGladio.Entities.Player { Id = id });
                }
                //DataAccessLayer.Player.DeletePlayer(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting players - Id: [" + id + "]");
                throw;
            }
        }
    }
}
