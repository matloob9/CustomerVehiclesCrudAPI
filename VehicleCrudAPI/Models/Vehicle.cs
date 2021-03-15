using System;
using System.Collections.Generic;

#nullable disable

namespace VehicleCrudAPI.Models
{
    public partial class Vehicle
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public string RegNumber { get; set; }
        public int CustomerFk { get; set; }
        public bool IsConnected { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
