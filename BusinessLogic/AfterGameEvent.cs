using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class AfterGameEvent
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        public static IEnumerable<LegaGladio.Entities.AfterGameEvent> GetAfterGameEvent(LegaGladio.Entities.Game game)
        {
            try
            {
                return DataAccessLayer.AfterGameEvent.GetAfterGameEvent(game);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting after game events");
                throw;
            }
        }

        public static void NewAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent)
        {
            try
            {
                DataAccessLayer.AfterGameEvent.NewAfterGameEvent(afterGameEvent);
                if (afterGameEvent.Skill != null)
                {
                    Skill.AddSkillToPlayer(afterGameEvent.Skill.Id, afterGameEvent.Player.Id);
                }
                var p = Player.GetPlayer(afterGameEvent.Player.Id);
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
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating a new after game event");
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

                DataAccessLayer.AfterGameEvent.DeleteAfterGameEvent(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting an after game event");
                throw;
            }
        }
    }
}
