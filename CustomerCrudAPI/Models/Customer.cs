using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerCrudAPI.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
}
