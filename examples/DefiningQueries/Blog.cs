using System.Collections.Generic;

namespace DefiningQueries
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
