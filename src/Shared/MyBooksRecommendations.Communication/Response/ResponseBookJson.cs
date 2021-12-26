namespace MyBooksRecommendations.Communication.Response
{
    public class ResponseBookJson
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public uint PrintLength { get; set; }
        public DateTime Publication { get; set; }
        public string Review { get; set; } = "";
        public IList<string> Language { get; set; } = new List<string>();
        public IList<uint> IReadAt { get; set; } = new List<uint>();
        public uint Status { get; set; }
        public uint Type { get; set; }
    }
}
