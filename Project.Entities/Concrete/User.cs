using Project.Core.Entities;

namespace Project.Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string Username { get; set;}
        public string Email{ get; set;}
        public string Password{ get; set;}
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<WillWatchedFilm> WatchList{ get; set; }= new List<WillWatchedFilm>();
        public List<WatchedFilm> WatchedFilms{ get; set; }=new List<WatchedFilm>();
    }
}