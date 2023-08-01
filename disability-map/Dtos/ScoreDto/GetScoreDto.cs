namespace disability_map.Dtos
{
    public class GetScoreDto
    {
        public string PlaceId { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }

        public int? UserData{ get; set; }
    }
}
