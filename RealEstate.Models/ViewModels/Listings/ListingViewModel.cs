﻿using RealEstate.Models.Entities.Estates;
using RealEstate.Models.Entities.Listings;

namespace RealEstate.Models.ViewModels.Listings
{
    public class ListingViewModel
    {
        public int Id { get; init; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int Year { get; set; }

        public bool IsPublic { get; set; }

        public DateTime DateBuilt { get; set; }

        public DateTime DateListed { get; set; }

        public decimal SquareMeters { get; set; }

        public Estate_Type Estate_Type { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; init; }

        public int EmployeeId { get; init; }

        public Employee? Employee { get; init; }
    }
}