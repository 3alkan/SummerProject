using Project.Core.Entities;

namespace Project.Entities.Concrete
{
    public class WatchedFilm:IEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int FilmId { get; set; }
        public Film Film { get; set; }
        
        public DateTime DateWatched { get; set; }
    }
}
