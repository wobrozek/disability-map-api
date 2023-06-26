﻿using disability_map.Models;

namespace disability_map.Dtos
{
    public class GetPlaceDto
    {
        public string Name { get; set; }

        public Double Latitude { get; set; }

        public Double Longitude { get; set; }

        public string Adress { get; set; }

        public string OpeningHours { get; set; }

        public PlaceType Type { get; set; }

        public string? ImagePath { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}