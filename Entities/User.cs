using System;

namespace LegaGladio.Entities
{
    public class User
    {
        public virtual Int32 Id { get; set; }
        public virtual String Username { get; set; }
        public virtual String Password { get; set; }
        public virtual DateTime LastLogin { get; set; }
        public virtual Guid LastToken { get; set; }
    }
}
