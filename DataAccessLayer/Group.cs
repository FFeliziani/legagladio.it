using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class Group
    {
        public static IEnumerable<LegaGladio.Entities.Group> ListGroup(LegaGladio.Entities.Series s)
        {
            var gta = new groupTableAdapter();
            var gdt = new LegaGladioDS.groupDataTable();

            gta.FillBySeriesId(gdt, s.Id);

            return (from LegaGladioDS.groupRow gr in gdt.Rows select new LegaGladio.Entities.Group {Id = gr.id, Name = gr.name, Notes = gr.notes}).ToList();
        }

        public static LegaGladio.Entities.Group GetGroup(Int32 id)
        {
            var gta = new groupTableAdapter();
            var gdt = new LegaGladioDS.groupDataTable();

            gta.FillById(gdt, id);

            if (gdt.Rows.Count != 1) throw new Exception("Wrong number of rows returned for group");
            var gr = (LegaGladioDS.groupRow) gdt.Rows[0];

            var group = new LegaGladio.Entities.Group
            {
                Id = gr.id,
                Name = gr.name,
                Notes = gr.notes
            };
            group.RoundList = Round.ListRound(group);

            return group;
        }

        public static void AddGroupToSeries(Int32 groupId, Int32 seriesId)
        {
            var sta = new groupTableAdapter();

            sta.AddGroupToSeries(groupId, seriesId);
        }

        public static void RemoveGroupFromSeries(Int32 groupId, Int32 seriesId)
        {
            var gta = new groupTableAdapter();

            gta.RemoveGroupFromSeries(groupId, seriesId);
        }

        public static void NewGroup(LegaGladio.Entities.Group group)
        {
            var gta = new groupTableAdapter();

            gta.Insert(group.Name, group.Notes);
        }

        public static void UpdateGroup(LegaGladio.Entities.Group group, Int32 oldId)
        {
            var gta = new groupTableAdapter();

            gta.Update(group.Name, group.Notes, oldId);
        }

        public static void RemoveGroup(Int32 id)
        {
            var gta = new groupTableAdapter();

            gta.Delete(id);
        }
    }
}
