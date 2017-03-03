using System;

namespace LegaGladio.Entities
{
    public class User
    {
        public Int32 Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public DateTime LastLogin { get; set; }
        public Guid LastToken { get; set; }
    }
}
