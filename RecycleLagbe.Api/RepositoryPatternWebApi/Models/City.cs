﻿using RepositoryPatternWebApi.Models;

namespace RepositoryPatternWebApi.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        // Foreign key reference to the State
        public int StateId { get; set; }

        // Navigation property to the parent State
        public State State { get; set; }
    }
}