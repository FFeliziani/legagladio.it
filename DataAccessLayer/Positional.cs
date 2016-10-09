using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Positional
    {
        public static int countPositional()
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
            return (int)pta.Count();
        }

        public static List<LegaGladio.Entities.Positional> listPositional()
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
            LegaGladioDSTableAdapters.positional_skillTableAdapter psta = new LegaGladioDSTableAdapters.positional_skillTableAdapter();

            List<LegaGladio.Entities.Positional> positionalList = new List<LegaGladio.Entities.Positional>();

            LegaGladioDS.positionalDataTable pdt = pta.GetData();

            foreach (LegaGladioDS.positionalRow pr in pdt.Rows)
            {
                LegaGladio.Entities.Positional positional = Positional.getPositional((int)pr.id);

                positionalList.Add(positional);
            }

            return positionalList;
        }

        public static LegaGladio.Entities.Positional getPositional(int id)
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = null;
            LegaGladioDSTableAdapters.positional_skillTableAdapter psta = null;
            LegaGladioDS.positionalDataTable pdt = null;
            LegaGladioDS.positionalRow pr = null;
            LegaGladio.Entities.Positional positional = null;

            try
            {
                pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
                pdt = pta.GetDataById(id);

                if (pdt.Rows.Count > 1)
                {
                    throw new Exception("Troppi positional trovati per l'ID " + id);
                }

                pr = (LegaGladioDS.positionalRow)pdt.Rows[0];
                
                positional = new LegaGladio.Entities.Positional();

                positional.Ma = pr.ma;
                positional.St = pr.st;
                positional.Ag = pr.ag;
                positional.Av = pr.av;
                positional.Cost = pr.cost;
                positional.Qty = pr.qty;
                positional.Title = pr.title;
                psta = new LegaGladioDSTableAdapters.positional_skillTableAdapter();
                LegaGladioDS.positional_skillDataTable psdt = psta.GetDataByPositionalId((int)pr.id);
                foreach (LegaGladioDS.positional_skillRow psr in psdt.Rows)
                {
                    LegaGladio.Entities.Skill skill = Skill.getSkill((int)psr.skillID);

                    switch (skill.SkillType)
                    {
                        case LegaGladio.Entities.SkillType.AGILITY:
                            positional.Agility.Add(skill);
                            break;
                        case LegaGladio.Entities.SkillType.EXTRAORDINARY:
                            positional.Extraordinary.Add(skill);
                            break;
                        case LegaGladio.Entities.SkillType.GENERAL:
                            positional.General.Add(skill);
                            break;
                        case LegaGladio.Entities.SkillType.MUTATION:
                            positional.Mutation.Add(skill);
                            break;
                        case LegaGladio.Entities.SkillType.PASSING:
                            positional.Passing.Add(skill);
                            break;
                        case LegaGladio.Entities.SkillType.STRENGTH:
                            positional.Strength.Add(skill);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return positional;
            
        }

        public static Boolean newPositional(LegaGladio.Entities.Positional positional)
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
            LegaGladioDSTableAdapters.positional_skillTableAdapter psta = new LegaGladioDSTableAdapters.positional_skillTableAdapter();

            //g, a, s, p, m, e
            int id = (int)pta.InsertPositional(positional.Qty, positional.Title, (Decimal)positional.Cost, positional.Ma, positional.St, positional.Ag, positional.Av);

            foreach (LegaGladio.Entities.Skill skill in positional.Agility)
            {
                psta.InsertPositionalSkill(id, skill.Id);
            }

            foreach (LegaGladio.Entities.Skill skill in positional.General)
            {
                psta.InsertPositionalSkill(id, skill.Id);
            }

            foreach (LegaGladio.Entities.Skill skill in positional.Strength)
            {
                psta.InsertPositionalSkill(id, skill.Id);
            }

            foreach (LegaGladio.Entities.Skill skill in positional.Passing)
            {
                psta.InsertPositionalSkill(id, skill.Id);
            }

            foreach (LegaGladio.Entities.Skill skill in positional.Mutation)
            {
                psta.InsertPositionalSkill(id, skill.Id);
            }

            foreach (LegaGladio.Entities.Skill skill in positional.Extraordinary)
            {
                psta.InsertPositionalSkill(id, skill.Id);
            }

            return id > -1;
        }

        public static Boolean updatePositional(LegaGladio.Entities.Positional positional, int oldID)
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
            LegaGladioDSTableAdapters.positional_skillTableAdapter psta = new LegaGladioDSTableAdapters.positional_skillTableAdapter();

            int rowNum = pta.Update(positional.Qty, positional.Title, (Decimal)positional.Cost, positional.Ma, positional.St, positional.Ag, positional.Av, oldID);

            LegaGladioDS.positional_skillDataTable psdt =  psta.GetDataByPositionalId(positional.Id);

            List<LegaGladio.Entities.Skill> agilityList = new List<LegaGladio.Entities.Skill>();
            List<LegaGladio.Entities.Skill> generalList = new List<LegaGladio.Entities.Skill>();
            List<LegaGladio.Entities.Skill> strengthList = new List<LegaGladio.Entities.Skill>();
            List<LegaGladio.Entities.Skill> passingList = new List<LegaGladio.Entities.Skill>();
            List<LegaGladio.Entities.Skill> mutationList = new List<LegaGladio.Entities.Skill>();
            List<LegaGladio.Entities.Skill> extraordinaryList = new List<LegaGladio.Entities.Skill>();

            foreach (LegaGladioDS.positional_skillRow psRow in psdt)
            {
                LegaGladio.Entities.Skill skill = Skill.getSkill((int)psRow.skillID);

                switch (skill.SkillType)
                {
                    case LegaGladio.Entities.SkillType.AGILITY:
                        agilityList.Add(skill);
                        break;
                    case LegaGladio.Entities.SkillType.GENERAL:
                        generalList.Add(skill);
                        break;
                    case LegaGladio.Entities.SkillType.STRENGTH:
                        strengthList.Add(skill);
                        break;
                    case LegaGladio.Entities.SkillType.PASSING:
                        passingList.Add(skill);
                        break;
                    case LegaGladio.Entities.SkillType.MUTATION:
                        mutationList.Add(skill);
                        break;
                    case LegaGladio.Entities.SkillType.EXTRAORDINARY:
                        extraordinaryList.Add(skill);
                        break;
                }

            }

            List<LegaGladio.Entities.Skill> listaAggiunte = new List<LegaGladio.Entities.Skill>();
            List<LegaGladio.Entities.Skill> listaRimozioni = new List<LegaGladio.Entities.Skill>();

            listaAggiunte.AddRange((List<LegaGladio.Entities.Skill>)positional.Agility.Except(agilityList));
            listaAggiunte.AddRange((List<LegaGladio.Entities.Skill>)positional.General.Except(generalList));
            listaAggiunte.AddRange((List<LegaGladio.Entities.Skill>)positional.Strength.Except(strengthList));
            listaAggiunte.AddRange((List<LegaGladio.Entities.Skill>)positional.Passing.Except(passingList));
            listaAggiunte.AddRange((List<LegaGladio.Entities.Skill>)positional.Mutation.Except(mutationList));
            listaAggiunte.AddRange((List<LegaGladio.Entities.Skill>)positional.Extraordinary.Except(extraordinaryList));

            listaRimozioni.AddRange((List<LegaGladio.Entities.Skill>)agilityList.Except(positional.Agility));
            listaRimozioni.AddRange((List<LegaGladio.Entities.Skill>)generalList.Except(positional.General));
            listaRimozioni.AddRange((List<LegaGladio.Entities.Skill>)strengthList.Except(positional.Strength));
            listaRimozioni.AddRange((List<LegaGladio.Entities.Skill>)passingList.Except(positional.Passing));
            listaRimozioni.AddRange((List<LegaGladio.Entities.Skill>)mutationList.Except(positional.Mutation));
            listaRimozioni.AddRange((List<LegaGladio.Entities.Skill>)extraordinaryList.Except(positional.Extraordinary));

            Skill.newSkills(listaAggiunte);
            Skill.deleteSkills(listaRimozioni);

            return rowNum == 1;
        }

        public static Boolean deletePositional(int id)
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
            LegaGladioDSTableAdapters.positional_skillTableAdapter psta = new LegaGladioDSTableAdapters.positional_skillTableAdapter();

            Boolean works = true;

            LegaGladio.Entities.Positional positional = Positional.getPositional(id);

            works &= Skill.deleteSkills(positional.Agility);
            works &= Skill.deleteSkills(positional.General);
            works &= Skill.deleteSkills(positional.Strength);
            works &= Skill.deleteSkills(positional.Passing);
            works &= Skill.deleteSkills(positional.Mutation);
            works &= Skill.deleteSkills(positional.Extraordinary);

            int rowNum = pta.Delete(id);

            return rowNum == 1 && works;
        }
    }
}
