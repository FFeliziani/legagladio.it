using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Round
    {
        public static LegaGladio.Entities.Round getRound(Int32 id)
        {
            LegaGladioDSTableAdapters.roundTableAdapter rta = null;
            LegaGladioDS.roundDataTable rdt = null;
            LegaGladio.Entities.Round r = null;

            try
            {
                rta = new LegaGladioDSTableAdapters.roundTableAdapter();
                rdt = new LegaGladioDS.roundDataTable();
                rta.FillById(rdt, id);
                if (rdt.Rows.Count != 1)
                {
                    throw new ArgumentException("Wrong number of rounds returned!");
                }
                LegaGladioDS.roundRow rr = (LegaGladioDS.roundRow)rdt.Rows[0];
                r = new LegaGladio.Entities.Round();
                r.Id = rr.id;
                r.Name = rr.name;
                r.Number = rr.number;
                r.GameList = Game.listGame(r);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                rta = null;
                rdt = null;
            }

            return r;
        }

        public static List<LegaGladio.Entities.Round> listRound(LegaGladio.Entities.Group g)
        {
            LegaGladioDSTableAdapters.roundTableAdapter rta = null;
            LegaGladioDS.roundDataTable rdt = null;
            List<LegaGladio.Entities.Round> rL = null;

            try
            {
                rta = new LegaGladioDSTableAdapters.roundTableAdapter();
                rdt = new LegaGladioDS.roundDataTable();
                rL = new List<LegaGladio.Entities.Round>();

                rta.FillByGroupId(rdt, g.Id);

                foreach (LegaGladioDS.roundRow rr in rdt.Rows)
                {
                    LegaGladio.Entities.Round r = new LegaGladio.Entities.Round();

                    r.Id = rr.id;
                    r.Name = rr.name;
                    r.Number = rr.number;
                    rL.Add(r);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                rta = null;
                rdt = null;
            }

            return rL;
        }

        public static void addRoundToGroup(Int32 roundId, Int32 groupId)
        {
            LegaGladioDSTableAdapters.roundTableAdapter rta = new LegaGladioDSTableAdapters.roundTableAdapter();

            rta.AddRoundToGroup(roundId, groupId);
        }

        public static void removeRoundFromGroup(Int32 roundId, Int32 groupId)
        {
            LegaGladioDSTableAdapters.roundTableAdapter rta = new LegaGladioDSTableAdapters.roundTableAdapter();

            rta.RemoveRoundFromGroup(roundId, groupId);
        }

        public static void newRound(LegaGladio.Entities.Round round)
        {
            LegaGladioDSTableAdapters.roundTableAdapter rta = new LegaGladioDSTableAdapters.roundTableAdapter();

            rta.Insert(round.Name, round.Number);
        }

        public static void updateRound(LegaGladio.Entities.Round round, Int32 oldId)
        {
            LegaGladioDSTableAdapters.roundTableAdapter rta = new LegaGladioDSTableAdapters.roundTableAdapter();

            rta.Update(round.Name, round.Number, oldId);
        }

        public static void removeRound(Int32 id)
        {
            LegaGladioDSTableAdapters.roundTableAdapter rta = new LegaGladioDSTableAdapters.roundTableAdapter();

            rta.Delete(id);
        }
    }
}
