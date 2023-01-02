﻿namespace RealEstate.Models.Entities.Listings
{
    public class ListingStats
    {
        public int TimesViewed { get; set; }

        public int TimesSaved { get; set; }

        public int TimesCommented { get; set; }

        public int TimesReviewed { get; set; }

        public int TimesRented { get; set; }

        public int TimesReported { get; set; }

        public PriceHistory PriceHistory { get; set; }
    }
}