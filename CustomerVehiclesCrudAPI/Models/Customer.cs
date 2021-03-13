using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerVehiclesCrudAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
