using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class Augmentation
    {
        public static List<LegaGladio.Entities.Augmentation> ListAugmentation()
        {
            var ata = new augmentationTableAdapter();
            var adt = new LegaGladioDS.augmentationDataTable();
            ata.Fill(adt);
            var augmentationList = (from LegaGladioDS.augmentationRow ar in adt.Rows
                select new LegaGladio.Entities.Augmentation()
                {
                    Id = ar.id,
                    Name = ar.name
                }).ToList();
            return augmentationList;
        }

        public static LegaGladio.Entities.Augmentation GetAugmentation(Int32 id)
        {
            var ata = new augmentationTableAdapter();
            var adt = new LegaGladioDS.augmentationDataTable();
            ata.FillById(adt, id);
            if(adt.Rows.Count != 1) throw new Exception("Wrong number of augmentations returned");
            var ar = (LegaGladioDS.augmentationRow) adt.Rows[0];
            return new LegaGladio.Entities.Augmentation()
            {
                Id = ar.id,
                Name = ar.name
            };
        }

        public static void NewAugmentation(LegaGladio.Entities.Augmentation augmentation)
        {
            var ata = new augmentationTableAdapter();

            ata.Insert(augmentation.Name);
        }

        public static void UpdateAugmentation(LegaGladio.Entities.Augmentation augmentation, Int32 oldId)
        {
            var ata = new augmentationTableAdapter();

            ata.Update(augmentation.Name, oldId);
        }

        public static void DeleteAugmentation(Int32 id)
        {
            var ata = new augmentationTableAdapter();

            ata.Delete(id);
        }
    }
}
