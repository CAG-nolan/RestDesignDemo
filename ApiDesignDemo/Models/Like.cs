namespace ApiDesignDemo.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
