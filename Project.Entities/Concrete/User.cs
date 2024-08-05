using Project.Core.Entities;

namespace Project.Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string Username { get; set;}
        public string Email{ get; set;}
        public string Password{ get; set;}
    }
}