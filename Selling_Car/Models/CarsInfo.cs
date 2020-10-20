using System;
using System.Collections.Generic;

namespace Selling_Car.Models
{
    public partial class CarsInfo
    {
        public string Id { get; set; }
        public string CName { get; set; }
        public string Model { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Origin { get; set; }
    }
}
