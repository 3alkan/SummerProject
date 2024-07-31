using Project.Core.Entities;

namespace Project.Entities.Concrete
{
    public class Film : IEntity
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Time { get; set; }
        public int Rate { get; set; }
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
    }
}
