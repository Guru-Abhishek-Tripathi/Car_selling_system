using System;
using System.Collections.Generic;

namespace Owned_car.Models
{
    public partial class Customer
    {
        public string CusId { get; set; }
        public string CusName { get; set; }
        public string CusGender { get; set; }
        public DateTime? CusDob { get; set; }
        public string CusAddress { get; set; }
        public decimal? CusPhone { get; set; }
        public string CusEmail { get; set; }
        public string CusPassword { get; set; }
    }
}
