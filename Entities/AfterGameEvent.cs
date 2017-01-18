namespace LegaGladio.Entities
{
    public class AfterGameEvent
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public Skill Skill { get; set; }
        public Injury Injury { get; set; }
        public Augmentation Augmentation { get; set; }
        public Game Game { get; set; }
    }
}
