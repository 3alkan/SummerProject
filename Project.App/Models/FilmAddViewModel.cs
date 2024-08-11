using Project.Entities.Concrete;

namespace Project.App.Models
{
    public class FilmAddViewModel
    {
        // Film details
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Time { get; set; }
        public int DirectorId { get; set; }

        // For search functionality
        public string DirectorName { get; set; }
        public List<Director> Directors { get; set; } = new List<Director>();

        // To inform user
        public string Message { get; set; }

    }
}