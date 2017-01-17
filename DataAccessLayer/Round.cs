using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class Round
    {
        public static LegaGladio.Entities.Round GetRound(Int32 id)
        {
            var rta = new roundTableAdapter();
            var rdt = new LegaGladioDS.roundDataTable();
            rta.FillById(rdt, id);
            if (rdt.Rows.Count != 1)
            {
                throw new ArgumentException("Wrong number of rounds returned!");
            }
            var rr = (LegaGladioDS.roundRow)rdt.Rows[0];
            var r = new LegaGladio.Entities.Round {Id = rr.id, Name = rr.name, Number = rr.number};
            r.GameList = Game.ListGame(r);

            return r;
        }

        public static List<LegaGladio.Entities.Round> ListRound(LegaGladio.Entities.Group g)
        {
            var rta = new roundTableAdapter();
            var rdt = new LegaGladioDS.roundDataTable();

            rta.FillByGroupId(rdt, g.Id);

            var rL = (from LegaGladioDS.roundRow rr in rdt.Rows
                select new LegaGladio.Entities.Round
                {
                    Id = rr.id, Name = rr.name, Number = rr.number
                }).ToList();

            return rL;
        }

        public static void AddRoundToGroup(Int32 roundId, Int32 groupId)
        {
            var rta = new roundTableAdapter();

            rta.AddRoundToGroup(roundId, groupId);
        }

        public static void RemoveRoundFromGroup(Int32 roundId, Int32 groupId)
        {
            var rta = new roundTableAdapter();

            rta.RemoveRoundFromGroup(roundId, groupId);
        }

        public static void NewRound(LegaGladio.Entities.Round round)
        {
            var rta = new roundTableAdapter();

            rta.Insert(round.Name, round.Number);
        }

        public static void UpdateRound(LegaGladio.Entities.Round round, Int32 oldId)
        {
            var rta = new roundTableAdapter();

            rta.Update(round.Name, round.Number, oldId);
        }

        public static void RemoveRound(Int32 id)
        {
            var rta = new roundTableAdapter();

            rta.Delete(id);
        }
    }
}
