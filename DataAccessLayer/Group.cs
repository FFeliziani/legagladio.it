using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Group
    {
        public static List<LegaGladio.Entities.Group> listGroup(LegaGladio.Entities.Series s)
        {
            LegaGladioDSTableAdapters.groupTableAdapter gta = null;
            LegaGladioDS.groupDataTable gdt = null;
            List<LegaGladio.Entities.Group> groupList = null;

            try
            {
                gta = new LegaGladioDSTableAdapters.groupTableAdapter();
                gdt = new LegaGladioDS.groupDataTable();
                groupList = new List<LegaGladio.Entities.Group>();

                gta.FillBySeriesId(gdt, s.Id);

                foreach (LegaGladioDS.groupRow gr in gdt.Rows)
                {
                    LegaGladio.Entities.Group group = new LegaGladio.Entities.Group();

                    group.Id = gr.id;
                    group.Name = gr.name;
                    group.Notes = gr.notes;
                    groupList.Add(group);
                }
            }
            finally
            {
            }
            return groupList;
        }

        public static LegaGladio.Entities.Group getGroup(Int32 id)
        {
            LegaGladioDSTableAdapters.groupTableAdapter gta = null;
            LegaGladioDS.groupDataTable gdt = null;
            LegaGladioDS.groupRow gr = null;
            LegaGladio.Entities.Group group = null;

            try
            {
                gta = new LegaGladioDSTableAdapters.groupTableAdapter();
                gdt = new LegaGladioDS.groupDataTable();
                group = new LegaGladio.Entities.Group();

                gta.FillById(gdt, id);

                if (gdt.Rows.Count != 1)
                {
                    throw new Exception("Wrong number of rows returned for group");
                }

                gr = (LegaGladioDS.groupRow)gdt.Rows[0];

                group.Id = gr.id;
                group.Name = gr.name;
                group.Notes = gr.notes;
                group.RoundList = Round.listRound(group);
            }
            finally
            {
            }

            return group;
        }

        public static void addGroupToSeries(Int32 groupId, Int32 seriesId)
        {
            LegaGladioDSTableAdapters.groupTableAdapter sta = new LegaGladioDSTableAdapters.groupTableAdapter();

            sta.AddGroupToSeries(groupId, seriesId);
        }

        public static void removeGroupFromSeries(Int32 groupId, Int32 seriesId)
        {
            LegaGladioDSTableAdapters.groupTableAdapter gta = new LegaGladioDSTableAdapters.groupTableAdapter();

            gta.RemoveGroupFromSeries(groupId, seriesId);
        }

        public static void newGroup(LegaGladio.Entities.Group group)
        {
            LegaGladioDSTableAdapters.groupTableAdapter gta = new LegaGladioDSTableAdapters.groupTableAdapter();

            gta.Insert(group.Name, group.Notes);
        }

        public static void updateGroup(LegaGladio.Entities.Group group, Int32 oldId)
        {
            LegaGladioDSTableAdapters.groupTableAdapter gta = new LegaGladioDSTableAdapters.groupTableAdapter();

            gta.Update(group.Name, group.Notes, oldId);
        }

        public static void removeGroup(Int32 id)
        {
            LegaGladioDSTableAdapters.groupTableAdapter gta = new LegaGladioDSTableAdapters.groupTableAdapter();

            gta.Delete(id);
        }
    }
}
