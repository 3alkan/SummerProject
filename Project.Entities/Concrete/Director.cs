using Project.Core.Entities;

namespace Project.Entities.Concrete
{
    public class Director : IEntity
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public List<Film> Films { get; set; }=new List<Film>();
    }
}