using System;
using System.Collections.Generic;

#nullable disable

namespace WpfApp1
{
    public partial class PizzaOrder
    {
        public int PizzaOrderId { get; set; }
        public int PizzaAssortimentId { get; set; }
        public int PizzaCount { get; set; }
        public DateTime OrderDate { get; set; }
        public int ClientAddresId { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual ClientAddre ClientAddres { get; set; }
        public virtual PizzaAssortiment PizzaAssortiment { get; set; }
    }
}
