using System.Collections.Generic;
using System.Linq;

namespace AsNoTracking
{
    public class AuthorService
    {
        private readonly AsNoTrackingContext context;

        public AuthorService(AsNoTrackingContext context)
        {
            this.context = context;
        }

        public IReadOnlyCollection<Author> GetAuthors()
        {
            return context.Authors.ToList();
        }

        public void DoSomethingWithAuthors()
        {
            var authors = context.Authors;
            foreach (var author in authors)
            {
                if (author.FirstName == "Ivo") continue;

                if (!string.IsNullOrWhiteSpace(author.FirstName))
                    author.FirstName = author.FirstName.Substring(0, 1) + ".";
                if (!string.IsNullOrWhiteSpace(author.MiddleName))
                    author.MiddleName = author.MiddleName.Substring(0, 1) + ".";
            }

            context.SaveChanges();
        }
    }
}
