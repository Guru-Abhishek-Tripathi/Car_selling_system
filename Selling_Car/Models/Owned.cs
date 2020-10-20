using System;
using System.Collections.Generic;

namespace Selling_Car.Models
{
    public partial class Owned
    {
        public string CarId { get; set; }
        public string CusId { get; set; }
        public string Payment { get; set; }
        public decimal? Installment { get; set; }
        public int? NoOfInstallments { get; set; }

        public virtual CarsInfo Car { get; set; }
        public virtual Customer Cus { get; set; }
    }
}
