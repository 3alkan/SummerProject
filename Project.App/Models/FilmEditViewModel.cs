using Project.Entities.Concrete;

namespace Project.App.Models
{
    public class FilmEditViewModel
    {
        // Film Object
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Time { get; set; }
        public int OriginalDirectorId { get; set; }
        public string OriginalDirectorName { get; set; }

        // For searching functionality
        public string NewDirectorName { get; set; }
        public int NewDirectorId { get; set; }
        public List<Director> Directors { get; set; } = new List<Director>();
        public bool ShowSearchDirector { get; set; }

        // To inform user
        public string Message { get; set; }
    }
}