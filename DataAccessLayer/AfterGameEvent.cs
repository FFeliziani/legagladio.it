using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    class AfterGameEvent
    {
        public static List<LegaGladio.Entities.AfterGameEvent> getAfterGameEvent(LegaGladio.Entities.Game game)
        {
            LegaGladioDSTableAdapters.after_game_eventTableAdapter ageta = null;
            LegaGladioDS.after_game_eventDataTable agedt = null;
            List<LegaGladio.Entities.AfterGameEvent> ageL = null;

            try
            {
                ageta = new LegaGladioDSTableAdapters.after_game_eventTableAdapter();
                agedt = new LegaGladioDS.after_game_eventDataTable();
                ageta.FillByGameId(agedt, game.Id);
                foreach (LegaGladioDS.after_game_eventRow ager in agedt.Rows)
                {
                    LegaGladio.Entities.AfterGameEvent age = new LegaGladio.Entities.AfterGameEvent();
                    age.Id = ager.id;
                    age.Injury = Injury.getInjury(ager.injuryID);
                    age.Player = Player.getPlayer(ager.playerID);
                    age.Skill = Skill.getSkill(ager.skillID);
                    age.Game = Game.getGame(ager.gameID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ageta = null;
                agedt = null;
            }

            return ageL;
        }

        public static void newAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent)
        {
            LegaGladioDSTableAdapters.after_game_eventTableAdapter ageta = new LegaGladioDSTableAdapters.after_game_eventTableAdapter();

            ageta.Insert(afterGameEvent.Player.Id, afterGameEvent.Skill.Id, afterGameEvent.Injury.Id, afterGameEvent.Game.Id);
        }

        public static void updateAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent, Int32 oldId)
        {
            LegaGladioDSTableAdapters.after_game_eventTableAdapter ageta = new LegaGladioDSTableAdapters.after_game_eventTableAdapter();

            ageta.Update(afterGameEvent.Game.Id, afterGameEvent.Skill.Id, afterGameEvent.Injury.Id, afterGameEvent.Game.Id, oldId);
        }

        public static void deleteAfterGameEvent(Int32 id)
        {
            LegaGladioDSTableAdapters.after_game_eventTableAdapter ageta = new LegaGladioDSTableAdapters.after_game_eventTableAdapter();

            ageta.Delete(id);
        }
    }
}
