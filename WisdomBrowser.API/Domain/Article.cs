namespace WisdomBrowser.API.Domain
{
    public class Article
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string YouTubeID { get; private set; }
        public int UserId { get; private set; }
        public Article(string name, string youTubeID, int userId)
        {
            Name = name;
            YouTubeID = youTubeID;
            UserId = UserId;
        }
        private Article()
        {
            
        }
    }
}