using RepositoryPatternWebApi.Models;

namespace RepositoryPatternWebApi.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }

        // Foreign key reference to the Country
        public int CountryId { get; set; }

        // Navigation property to the parent Country
        public Country Country { get; set; }

        // one-to-many relationship: A state can have multiple cities
        public List<City> Cities { get; set; }
    }
}