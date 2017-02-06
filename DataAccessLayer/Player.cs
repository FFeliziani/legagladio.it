using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using DataAccessLayer.LegaGladioDSTableAdapters;
using LegaGladio.Entities;

namespace DataAccessLayer
{
    public static class Player
    {
        public static int CountPlayer()
        {
            var pta = new playerTableAdapter();
            var count = (int)pta.Count();
            return count;
        }

        public static ICollection<LegaGladio.Entities.Player> ListPlayer()
        {
            var pdt = new LegaGladioDS.playerDataTable();
            var pta = new playerTableAdapter();
            pta.Fill(pdt);
            var playerList = new List<LegaGladio.Entities.Player>();
            foreach (var player in from LegaGladioDS.playerRow playerRow in pdt.Rows select new LegaGladio.Entities.Player
            {
                Id = playerRow.id,
                AgMinus = playerRow.agm,
                Dead = playerRow.dead == 1,
                Retired = playerRow.retired == 1,
                AgPlus = playerRow.agp,
                AvMinus = playerRow.avm,
                AvPlus = playerRow.avp,
                Cas = playerRow.cas,
                Inter = playerRow.inter,
                Mvp = playerRow.mvp,
                MaMinus = playerRow.mam,
                MaPlus = playerRow.map,
                MissNextGame = playerRow.missNextGame == 1,
                Name = playerRow.name,
                Niggling = playerRow.niggling,
                Pass = playerRow.pass,
                Spp = playerRow.spp,
                StMinus = playerRow.stm,
                StPlus = playerRow.stp,
                Position = playerRow.position,
                Td = playerRow.td
            })
            {
                player.Cost = CalculatePlayerValue(player.Id);
                player.ListAbility = Skill.ListSkill(player.Id);
                player.Positional = Positional.GetPositional(player);
                playerList.Add(player);
            }
            return playerList;
        }

        public static ICollection<LegaGladio.Entities.Player> ListPlayer(int teamId, Boolean active)
        {
            var pdt = new LegaGladioDS.playerDataTable();
            var pta = new playerTableAdapter();
            pta.FillByTeamIdActive(pdt, teamId, active);
            var playerList = new List<LegaGladio.Entities.Player>();
            foreach (var player in from LegaGladioDS.playerRow playerRow in pdt.Rows select new LegaGladio.Entities.Player
            {
                AgMinus = playerRow.agm,
                AgPlus = playerRow.agp,
                Dead = playerRow.dead == 1,
                Retired = playerRow.retired == 1,
                AvMinus = playerRow.avm,
                AvPlus = playerRow.avp,
                Cas = playerRow.cas,
                Inter = playerRow.inter,
                Id = playerRow.id,
                MaMinus = playerRow.mam,
                MaPlus = playerRow.map,
                MissNextGame = playerRow.missNextGame == 1,
                Mvp = playerRow.mvp,
                Name = playerRow.name,
                Niggling = playerRow.niggling,
                Pass = playerRow.pass,
                Spp = playerRow.spp,
                StMinus = playerRow.stm,
                StPlus = playerRow.stp,
                Position = playerRow.position,
                Td = playerRow.td
            })
            {
                player.Cost = CalculatePlayerValue(player.Id);
                player.ListAbility = Skill.ListSkill(player.Id);
                player.Positional = Positional.GetPositional(player);
                playerList.Add(player);
            }
            return playerList;
        }

        public static ICollection<LegaGladio.Entities.Player> ListPlayer(int teamId)
        {
            var pdt = new LegaGladioDS.playerDataTable();
            var pta = new playerTableAdapter();
            pta.FillByTeamId(pdt, teamId);
            var playerList = new List<LegaGladio.Entities.Player>();
            foreach (var player in from LegaGladioDS.playerRow playerRow in pdt.Rows select new LegaGladio.Entities.Player
            {
                AgMinus = playerRow.agm,
                AgPlus = playerRow.agp,
                Dead = playerRow.dead == 1,
                Retired = playerRow.retired == 1,
                AvMinus = playerRow.avm,
                AvPlus = playerRow.avp,
                Cas = playerRow.cas,
                Inter = playerRow.inter,
                Id = playerRow.id,
                MaMinus = playerRow.mam,
                MaPlus = playerRow.map,
                MissNextGame = playerRow.missNextGame == 1,
                Mvp = playerRow.mvp,
                Name = playerRow.name,
                Niggling = playerRow.niggling,
                Pass = playerRow.pass,
                Spp = playerRow.spp,
                StMinus = playerRow.stm,
                StPlus = playerRow.stp,
                Position = playerRow.position,
                Td = playerRow.td
            })
            {
                player.Cost = CalculatePlayerValue(player.Id);
                player.ListAbility = Skill.ListSkill(player.Id);
                player.Positional = Positional.GetPositional(player);
                playerList.Add(player);
            }
            return playerList;
        }

        public static LegaGladio.Entities.Player GetPlayer(int id)
        {
            var pdt = new LegaGladioDS.playerDataTable();
            var pta = new playerTableAdapter();
            pta.FillById(pdt, id);
            var playerRow = (LegaGladioDS.playerRow)pdt.Rows[0];
            var player = new LegaGladio.Entities.Player
            {
                AgMinus = playerRow.agm,
                AgPlus = playerRow.agp,
                Dead = playerRow.dead == 1,
                Retired = playerRow.retired == 1,
                AvMinus = playerRow.avm,
                AvPlus = playerRow.avp,
                Cas = playerRow.cas,
                Inter = playerRow.inter,
                Id = playerRow.id,
                MaMinus = playerRow.mam,
                MaPlus = playerRow.map,
                MissNextGame = playerRow.missNextGame == 1,
                Mvp = playerRow.mvp,
                Name = playerRow.name,
                Niggling = playerRow.niggling,
                Pass = playerRow.pass,
                Spp = playerRow.spp,
                StMinus = playerRow.stm,
                StPlus = playerRow.stp,
                Position = playerRow.position,
                Td = playerRow.td
            };
            player.Cost = CalculatePlayerValue(player.Id);
            player.ListAbility = Skill.ListSkill(player.Id);
            player.Positional = Positional.GetPositional(player);
            return player;
        }

        public static void AddPlayerToTeam(Int32 playerId, Int32 teamId)
        {
            var pta = new playerTableAdapter();

            pta.AddPlayerToTeam(playerId, teamId);
        }

        public static void RemovePlayerFromTeam(Int32 playerId, Int32 teamId)
        {
            var pta = new playerTableAdapter();

            pta.RemovePlayerFromTeam(playerId, teamId);
        }

        public static Int32 NewPlayer(LegaGladio.Entities.Player player)
        {
            var pta = new playerTableAdapter();
            //name, map, agp, avp, stp, cost, spp, td, cas, pass, inter, niggling, missNextGame, mam, agm, avm, stm, retired, dead
            return Convert.ToInt32(pta.NewPlayer(player.Name, player.MaPlus, player.AgPlus, player.AvPlus, player.StPlus, player.Cost, player.Spp, player.Td, player.Cas, player.Pass, player.Inter, player.Mvp, player.Niggling, (player.MissNextGame ? 1 : 0), player.MaMinus, player.AgMinus, player.AvMinus, player.StMinus, (player.Retired ? 1 : 0), (player.Dead?1:0), player.Positional.Id, player.Position));
        }

        public static void UpdatePlayer(LegaGladio.Entities.Player player, int oldId)
        {
            var pta = new playerTableAdapter();

            pta.Update(player.Name, player.MaPlus, player.AgPlus, player.AvPlus, player.StPlus, CalculatePlayerValue(oldId), player.Spp, player.Td, player.Cas, player.Pass, player.Inter, player.Mvp, player.Niggling, (player.MissNextGame ? 1 : 0), player.MaMinus, player.AgMinus, player.AvMinus, player.StMinus, (player.Retired ? 1 : 0), (player.Dead ? 1 : 0), player.Positional.Id, player.Position, oldId);
        }

        private static int CalculatePlayerValue(Int32 id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Calculate Player Value: Id must not be null");
            }
            try
            {
                var playerValue = 0;

                var pdt = new LegaGladioDS.playerDataTable();
                var pta = new playerTableAdapter();
                pta.FillById(pdt, id);
                if (pdt.Rows.Count != 1)
                    throw new Exception("Wrong number of rows returned for player in CalculatePlayerValue");
                var playerRow = (LegaGladioDS.playerRow)pdt.Rows[0];

                if (playerRow.missNextGame == 1)
                {
                    return 0;
                }
                var player = new LegaGladio.Entities.Player
                {
                    Id = playerRow.id,
                    Positional = Positional.GetPositional(playerRow.positionalId),
                    StPlus = playerRow.stp,
                    AgPlus = playerRow.agp,
                    AvPlus = playerRow.avp,
                    MaPlus = playerRow.map
                };

                player.ListAbility = Skill.ListSkill(player.Id);
                playerValue += player.Positional.Cost;

                foreach (var s in player.ListAbility)
                {
                    switch (s.SkillType)
                    {
                        case SkillType.Agility:
                            if (player.Positional.Agility != -1)
                            {
                                playerValue += 20000 + (10000 * player.Positional.Agility);
                            }
                            break;
                        case SkillType.General:
                            if (player.Positional.General != -1)
                            {
                                playerValue += 20000 + (10000 * player.Positional.General);
                            }
                            break;
                        case SkillType.Passing:
                            if (player.Positional.Passing != -1)
                            {
                                playerValue += 20000 + (10000 * player.Positional.Passing);
                            }
                            break;
                        case SkillType.Strength:
                            if (player.Positional.Strength != -1)
                            {
                                playerValue += 20000 + (10000 * player.Positional.Strength);
                            }
                            break;
                        case SkillType.Mutation:
                            if (player.Positional.Mutation != -1)
                            {
                                playerValue += 20000 + (10000 * player.Positional.Mutation);
                            }
                            break;
                    }
                }
                playerValue += 50000 * player.StPlus;
                playerValue += 40000 * player.AgPlus;
                playerValue += 30000 * player.AvPlus;
                playerValue += 30000 * player.MaPlus;

                return playerValue;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while calculating player value", ex);
            }
        }

        public static void DeletePlayer(int id)
        {
            var pta = new playerTableAdapter();
            pta.Delete(id);
        }

        public static string GenerateName(LegaGladio.Entities.Race race)
        {
            Utilities.RandomUtilities.Init();
            var names = new List<String>() {"Abrielle","Adair","Adara","Adriel","Aiyana","Alissa","Alixandra","Altair","Amara","Anatola","Anya","Arcadia","Ariadne","Arianwen","Aurelia","Aurelian","Aurelius","Avalon","Acalia","Alaire","Auristela","Bastian","Breena","Brielle","Briallan","Briseis","Cambria","Cara","Carys","Caspian","Cassia","Cassiel","Cassiopeia","Cassius","Chaniel","Cora","Corbin","Cyprian","Daire","Darius","Destin","Drake","Drystan","Dagen","Devlin","Devlyn","Eira","Eirian","Elysia","Eoin","Evadne","Eliron","Evanth","Fineas","Finian","Fyodor","Gareth","Gavriel","Griffin","Guinevere","Gaerwn","Ginerva","Hadriel","Hannelore","Hermione","Hesperos","Iagan","Ianthe","Ignacia","Ignatius","Iseult","Isolde","Jessalyn","Kara","Kerensa","Korbin","Kyler","Kyra","Katriel","Kyrielle","Leala","Leila","Lilith","Liora","Lucien","Lyra","Leira","Liriene","Liron","Maia","Marius","Mathieu","Mireille","Mireya","Maylea","Meira","Natania","Nerys","Nuriel","Nyssa","Neirin","Nyfain","Oisin","Oralie","Orion","Orpheus","Ozara","Oleisa","Orinthea","Peregrine","Persephone","Perseus","Petronela","Phelan","Pryderi","Pyralia","Pyralis","Qadira","Quintessa","Quinevere","Raisa","Remus","Rhyan","Rhydderch","Riona","Renfrew","Saoirse","Sarai","Sebastian","Seraphim","Seraphina","Sirius","Sorcha","Saira","Sarielle","Serian","Séverin","Tavish","Tearlach","Terra","Thalia","Thaniel","Theia","Torian","Torin","Tressa","Tristana","Uriela","Urien","Ulyssia","Vanora","Vespera","Vasilis","Xanthus","Xara","Xylia","Yadira","Yseult","Yakira","Yeira","Yeriel","Yestin","Zaira","Zephyr","Zora","Zorion","Zaniel","Zarek"};
            var surnames = new List<String>(){"Hillsilver","Quiverautumn","Macequiver","Daydagger","Bornbolt","Goldflame","Fullhillbull","Glidedark","Redcapemane","Paladinshield","Ramhell","Earbreaker","Heartseaspear","Leafdusk","Treebright","Firebreak","Shademourne","Shieldwinter","Wormnose","Glazemane","Brave","Shadowdark","Bloodblue","Moonpaladin","Glazegate","Sidecloak","Walker","Falconhelm","Bladeriver","Shadowred","Ragewalker","Land-bull","Dusk-nose","Staff","Pickersand","Blade","Greyax","Huntershade","Glazesun","Wolfwhite","Shadowelf","Shadowgaze","Shinelord","Plainsfury","Dwarfgaze","Wulfborn","Wormflare","Firebow","Bloodeagle","Watershield","Elvenbull","Arrowsummerore","Oakengoat","Hammerdark","Borne-worm","Eyebreak","Moonbolt","Blood-silver","Gazehalf","Manman"};

            var name = names[Utilities.RandomUtilities.Random.Next(names.Count)] + " " + surnames[Utilities.RandomUtilities.Random.Next(surnames.Count)];
            return name;
        }
    }
}
