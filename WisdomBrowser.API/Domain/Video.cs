namespace WisdomBrowser.API.Domain
{
    public class Video
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string YouTubeID { get; private set; }
        public int UserId { get; private set; }
        public bool IsArchive { get; private set; }
        private Video()
        {
            
        }
        public Video(string name, string youTubeID, int userId)
        {
            Name = name;
            YouTubeID = youTubeID;
            UserId = userId;
        }

        public void SetVideoAsArchived()
        {
            IsArchive = true;
        }
    }
}