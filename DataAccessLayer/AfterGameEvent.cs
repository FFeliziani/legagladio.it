using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class AfterGameEvent
    {
        public static IEnumerable<LegaGladio.Entities.AfterGameEvent> GetAfterGameEvent(LegaGladio.Entities.Game game)
        {
            var ageta = new after_game_eventTableAdapter();
            var agedt = new LegaGladioDS.after_game_eventDataTable();
            ageta.FillByGameId(agedt, game.Id);

            return (from LegaGladioDS.after_game_eventRow ager in agedt.Rows
                select new LegaGladio.Entities.AfterGameEvent
                {
                    Id = ager.id, Injury = Injury.GetInjury(ager.injuryID), Player = Player.GetPlayer(ager.playerID), Skill = Skill.GetSkill(ager.skillID), Game = Game.GetGame(ager.gameID)
                }).ToList();
        }

        public static void NewAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent)
        {
            var ageta = new after_game_eventTableAdapter();

            ageta.Insert(afterGameEvent.Player.Id, afterGameEvent.Skill.Id, afterGameEvent.Injury.Id, afterGameEvent.Game.Id);
        }

        public static void UpdateAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent, Int32 oldId)
        {
            var ageta = new after_game_eventTableAdapter();

            ageta.Update(afterGameEvent.Game.Id, afterGameEvent.Skill.Id, afterGameEvent.Injury.Id, afterGameEvent.Game.Id, oldId);
        }

        public static void DeleteAfterGameEvent(Int32 id)
        {
            var ageta = new after_game_eventTableAdapter();

            ageta.Delete(id);
        }
    }
}
