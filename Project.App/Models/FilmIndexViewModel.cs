using Project.Entities.Concrete;

namespace Project.App.Models
{
    public class FilmIndexViewModel
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string DirectorName { get; set; }

    }
}