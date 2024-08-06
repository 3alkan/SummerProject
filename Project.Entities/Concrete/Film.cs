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
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public List<Review> Reviews{ get; set; }=new List<Review>();

        // Calculated Properties
        public double Rate { get{
            if(Reviews==null || Reviews.Count==0){
                return 0;
            }
            else{
                return Reviews.Average(r=>r.Rate);
            }
        } }
    }
}
