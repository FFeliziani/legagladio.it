using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class AfterGameEvent
    {
        public static LegaGladio.Entities.AfterGameEvent GetAfterGameEvent(Int32 id)
        {
            var ageta = new after_game_eventTableAdapter();
            var agedt = new LegaGladioDS.after_game_eventDataTable();
            ageta.FillById(agedt, id);
            if(agedt.Rows.Count != 1) throw new Exception("Wrong number of rows returned for After Game Event");
            var ager = (LegaGladioDS.after_game_eventRow)agedt.Rows[0];
            return new LegaGladio.Entities.AfterGameEvent
            {
                Id = ager.id,
                Augmentation = ager.augmentationID != 0 ? Augmentation.GetAugmentation(ager.augmentationID) : null,
                Injury = ager.injuryID != 0 ? Injury.GetInjury(ager.injuryID) : null,
                Player = Player.GetPlayer(ager.playerID),
                Skill = ager.skillID != 0 ? Skill.GetSkill(ager.skillID) : null,
                Game = Game.GetGameSimple(ager.gameID)
            };
        }

        public static ICollection<LegaGladio.Entities.AfterGameEvent> GetAfterGameEvent(LegaGladio.Entities.Game game)
        {
            var ageta = new after_game_eventTableAdapter();
            var agedt = new LegaGladioDS.after_game_eventDataTable();
            ageta.FillByGameId(agedt, game.Id);

            return (from LegaGladioDS.after_game_eventRow ager in agedt.Rows
                    select new LegaGladio.Entities.AfterGameEvent
                    {
                        Id = ager.id,
                        Augmentation = ager.augmentationID != 0 ? Augmentation.GetAugmentation(ager.augmentationID) : null,
                        Injury = ager.injuryID != 0 ? Injury.GetInjury(ager.injuryID) : null,
                        Player = Player.GetPlayer(ager.playerID),
                        Skill = ager.skillID != 0 ? Skill.GetSkill(ager.skillID) : null,
                        Game = Game.GetGameSimple(ager.gameID)
                    }).ToList();
        }

        public static void NewAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent)
        {
            var ageta = new after_game_eventTableAdapter();

            ageta.Insert(afterGameEvent.Player.Id, afterGameEvent.Skill?.Id ?? 0, afterGameEvent.Injury?.Id ?? 0, afterGameEvent.Augmentation?.Id ?? 0, afterGameEvent.Game.Id);
        }

        public static void UpdateAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent, Int32 oldId)
        {
            var ageta = new after_game_eventTableAdapter();

            ageta.Update(afterGameEvent.Game.Id, afterGameEvent.Skill.Id, afterGameEvent.Injury.Id, afterGameEvent.Augmentation.Id, afterGameEvent.Game.Id, oldId);
        }

        public static void DeleteAfterGameEvent(Int32 id)
        {
            var ageta = new after_game_eventTableAdapter();

            ageta.Delete(id);
        }
    }
}
