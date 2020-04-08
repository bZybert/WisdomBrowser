namespace WisdomBrowser.API.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}