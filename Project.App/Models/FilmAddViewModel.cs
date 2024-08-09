using Project.Entities.Concrete;

namespace Project.App.Models
{
    public class FilmAddViewModel
    {
        public Film Film { get; set; }
        public string DirectorName { get; set; }
        public List<Director> Directors { get; set; } = new List<Director>();
        public string Message{ get; set; }="";

    }
}