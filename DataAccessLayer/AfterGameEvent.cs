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

            ageta.Insert(afterGameEvent.Player.Id, afterGameEvent.Skill != null ? afterGameEvent.Skill.Id : 0, afterGameEvent.Injury != null ? afterGameEvent.Injury.Id : 0, afterGameEvent.Augmentation != null ? afterGameEvent.Augmentation.Id : 0, afterGameEvent.Game.Id);

            if (afterGameEvent.Skill != null)
            {
                Skill.AddSkillToPlayer(afterGameEvent.Skill.Id, afterGameEvent.Player.Id);
            }
            if (afterGameEvent.Injury != null)
            {
                var p = Player.GetPlayer(afterGameEvent.Player.Id);
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
                Player.UpdatePlayer(p, afterGameEvent.Player.Id);
            }
            if (afterGameEvent.Augmentation != null)
            {
                var p = Player.GetPlayer(afterGameEvent.Player.Id);
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
                Player.UpdatePlayer(p, afterGameEvent.Player.Id);
            }
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
