using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RhymesUI.Models
{
    public class BookViewModel
    {
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
        public string Search { get; set; }
    }
}
