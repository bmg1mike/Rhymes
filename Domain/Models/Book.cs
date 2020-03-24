using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Book : DateTracking
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public string AuthorBio { get; set; }
        public string image { get; set; }
        public bool IsApproved { get; set; }
        public int MarketingBudget { get; set; }
        public string MarketingPlan { get; set; }
        public bool IsDeleted { get; set; }

        public Book()
        {
            BookId = Guid.NewGuid().ToString();
        }
    }
}
