namespace disability_map.Models
{
    public class ScoreUser
    {
        public int ScoreId{ get; set; }
        public int UserId { get; set; }

        public User User{ get; set; }
        public Score Score{ get; set; }
    }
}
