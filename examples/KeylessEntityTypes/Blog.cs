using System.Collections.Generic;

namespace KeylessEntityTypes
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
