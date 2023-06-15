namespace disability_map.Models
{
    public class Score: Entity
    {


        public int likes { get; set; }
        public int dislikes{ get; set;}

        public Score(string id)
        {
            this.Id = id;
            this.likes = 0;
            this.dislikes = 0;
        }
    }
}
