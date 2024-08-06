using Project.Core.Entities;

namespace Project.Entities.Concrete
{
    public class Review:IEntity{
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}