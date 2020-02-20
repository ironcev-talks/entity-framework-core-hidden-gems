namespace AsNoTracking
{
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName => ((FirstName + " " + MiddleName).Trim() + " " + LastName).Trim();
    }
}
