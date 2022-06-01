namespace friendzone.Models
{
    public class Follow : Profile
    {
        public int Id { get; set; }
        public string FollowingId { get; set; }
        public string FollowerId { get; set; }
    }
}