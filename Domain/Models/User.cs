using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Bank { get; set; }
    }
}
