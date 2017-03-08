namespace LegaGladio.Entities
{
    public class AfterGameEvent
    {
        public virtual int Id { get; set; }
        public virtual Player Player { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual Injury Injury { get; set; }
        public virtual Augmentation Augmentation { get; set; }
        public virtual Game Game { get; set; }
    }
}
