using System;
namespace ConnectedVehiclesAPP.Models
{
    public class Vehicle
    {

        public int Id { get; set; }
        public string Vin { get; set; }
        public string RegNumber { get; set; }
        public int CustomerFk { get; set; }
        public bool IsConnected { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
