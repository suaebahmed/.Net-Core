namespace RepositoryPatternWebApi.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        // one-to-many relationship: A country can have multiple states
        public List<State> States { get; set; }
    }
}
