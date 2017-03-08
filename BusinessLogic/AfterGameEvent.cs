using System;
using System.Collections.Generic;
using NHibernate;
using NLog;

namespace BusinessLogic
{
    public static class AfterGameEvent
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly static ISessionFactory SessionFactory = Utilities.DatabaseUtilities.CreateSessionFactory();

        public static LegaGladio.Entities.AfterGameEvent GetAfterGameEvent(Int32 id)
        {
            try
            {
                return DataAccessLayer.AfterGameEvent.GetAfterGameEvent(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting after game events - After Game Event Id: [" + id + "]");
                throw;
            }
        }
        
        public static ICollection<LegaGladio.Entities.AfterGameEvent> GetAfterGameEvent(LegaGladio.Entities.Game game)
        {
            try
            {
                return DataAccessLayer.AfterGameEvent.GetAfterGameEvent(game);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting after game events - Game Id: [" + (game?.Id.ToString() ?? "GAME IS NULL!") + "]");
                throw;
            }
        }

        public static void NewAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    DataAccessLayer.AfterGameEvent.NewAfterGameEvent(afterGameEvent);
                    if (afterGameEvent.Skill != null)
                    {
                        Skill.AddSkillToPlayer(afterGameEvent.Skill.Id, afterGameEvent.Player.Id);
                    }
                    var p = session.CreateCriteria(typeof (LegaGladio.Entities.Player))
                        .UniqueResult<LegaGladio.Entities.Player>(); //Player.GetPlayer(afterGameEvent.Player.Id);
                    if (afterGameEvent.Injury != null)
                    {
                        switch (afterGameEvent.Injury.Id)
                        {
                            case 1: //killed
                                p.Dead = true;
                                break;
                            case 2: //-ST
                                p.StMinus++;
                                p.MissNextGame = true;
                                break;
                            case 3: //-AG
                                p.AgMinus++;
                                p.MissNextGame = true;
                                break;
                            case 4: //-MV
                                p.MaMinus++;
                                p.MissNextGame = true;
                                break;
                            case 5: //-AV
                                p.AvMinus++;
                                p.MissNextGame = true;
                                break;
                            case 6: //NIGG
                                p.Niggling++;
                                p.MissNextGame = true;
                                break;
                            case 7: //MNG
                                p.MissNextGame = true;
                                break;
                        }
                    }
                    if (afterGameEvent.Augmentation != null)
                    {
                        switch (afterGameEvent.Augmentation.Id)
                        {
                            case 1: //+ST
                                p.StPlus++;
                                break;
                            case 2: //+AG
                                p.AgPlus++;
                                break;
                            case 3: //+AV
                                p.AvPlus++;
                                break;
                            case 4: //+MV
                                p.MaPlus++;
                                break;
                        }
                    }
                    Player.UpdatePlayer(p, afterGameEvent.Player.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating a new after game event = After Game Event Data:" + (afterGameEvent.Game != null ? " Game Id: [" + afterGameEvent.Game.Id + "], " : " Game is null,") + (afterGameEvent.Player != null ? " Player Id: [" + afterGameEvent.Player.Id + "], Player Name: [" + afterGameEvent.Player.Name + "]," : " PLAYER ID IS NULL! ") + (afterGameEvent.Skill != null ? " Skill Id: [" + afterGameEvent.Skill.Id + "], Skill Name: " + afterGameEvent.Skill.Name + "]," : " Skill is null,") + (afterGameEvent.Injury != null ? " Injury Id: [" + afterGameEvent.Injury.Id + "], Injury Name: [" + afterGameEvent.Injury.Name + "]," : " Injury is null") + (afterGameEvent.Augmentation != null ? " Augmentation Id: [" + afterGameEvent.Augmentation.Id + "], Augmentation Name: [" + afterGameEvent.Augmentation.Name + "]" : " Augmentation is null"));
                throw;
            }
        }

        public static void UpdateAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent, Int32 oldId)
        {
            try
            {
                DataAccessLayer.AfterGameEvent.UpdateAfterGameEvent(afterGameEvent, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating an after game event");
                throw;
            }
        }

        public static void DeleteAfterGameEvent(Int32 id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    var afterGameEvent = GetAfterGameEvent(id);
                    if (afterGameEvent.Skill != null)
                    {
                        Skill.RemoveSkillFromPlayer(afterGameEvent.Skill.Id, afterGameEvent.Player.Id);
                    }
                    var p = session.CreateCriteria(typeof(LegaGladio.Entities.Player))
                        .UniqueResult<LegaGladio.Entities.Player>();
                    ;//Player.GetPlayer(afterGameEvent.Player.Id);
                    if (afterGameEvent.Injury != null)
                    {
                        switch (afterGameEvent.Injury.Id)
                        {
                            case 1: //killed
                                p.Dead = false;
                                break;
                            case 2: //-ST
                                p.StMinus--;
                                p.MissNextGame = false;
                                break;
                            case 3: //-AG
                                p.AgMinus--;
                                p.MissNextGame = false;
                                break;
                            case 4: //-MV
                                p.MaMinus--;
                                p.MissNextGame = false;
                                break;
                            case 5: //-AV
                                p.AvMinus--;
                                p.MissNextGame = false;
                                break;
                            case 6: //NIGG
                                p.Niggling--;
                                p.MissNextGame = false;
                                break;
                            case 7: //MNG
                                p.MissNextGame = false;
                                break;
                        }
                    }
                    if (afterGameEvent.Augmentation != null)
                    {
                        switch (afterGameEvent.Augmentation.Id)
                        {
                            case 1: //+ST
                                p.StPlus--;
                                break;
                            case 2: //+AG
                                p.AgPlus--;
                                break;
                            case 3: //+AV
                                p.AvPlus--;
                                break;
                            case 4: //+MV
                                p.MaPlus--;
                                break;
                        }
                    }
                    Player.UpdatePlayer(p, afterGameEvent.Player.Id);
                    DataAccessLayer.AfterGameEvent.DeleteAfterGameEvent(id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting an after game event - AfterGameEvent Id: [" + id + "]");
                throw;
            }
        }
    }
}
